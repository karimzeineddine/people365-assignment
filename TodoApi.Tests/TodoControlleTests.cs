using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Threading.Tasks;

public class TodoControllerSQLiteTests
{
    [Fact]
    public async Task CreateTodo_ShouldAddTodo_AndReturnCreatedAtAction()
    {
        // Arrange
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();

        var options = new DbContextOptionsBuilder<TodoDb>()
            .UseSqlite(connection)
            .Options;

        // Ensure database schema is created
        using (var context = new TodoDb(options))
        {
            context.Database.EnsureCreated();
        }

        using var testContext = new TodoDb(options);
        var controller = new TodoController(testContext);

        var newTodo = new Todo
        {
            Name = "Test Todo",
            IsComplete = false
        };

        // Act
        var result = await controller.CreateTodo(newTodo);

        // Assert
        var actionResult = Assert.IsType<CreatedAtActionResult>(result);
        var createdTodo = Assert.IsType<Todo>(actionResult.Value);

        Assert.Equal("Test Todo", createdTodo.Name);
        Assert.False(createdTodo.IsComplete);

        // Check if the item was added to the database
        var todoInDb = await testContext.Todos.FirstOrDefaultAsync();
        Assert.NotNull(todoInDb);
        Assert.Equal("Test Todo", todoInDb.Name);
    }
}
