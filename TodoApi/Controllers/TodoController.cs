using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/todoitems")]
[Authorize]
public class TodoController : ControllerBase
{
    private readonly TodoDb _db;

    public TodoController(TodoDb db)
    {
        _db = db;
    }
    // Get All Todo's
    [HttpGet]
    public async Task<IActionResult> GetTodos()
    {
        return Ok(await _db.Todos.ToListAsync());
    }
    // Create a Todo 
    [HttpPost]
    public async Task<IActionResult> CreateTodo([FromBody] Todo todo)
    {
        _db.Todos.Add(todo);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTodos), new { id = todo.Id }, todo);
    }
    // update a todo by id
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTodo(int id, [FromBody] Todo updatedTodo)
    {
        var todo = await _db.Todos.FindAsync(id);
        if (todo == null) return NotFound();

        todo.Name = updatedTodo.Name;
        todo.IsComplete = updatedTodo.IsComplete;
        await _db.SaveChangesAsync();
        return NoContent();
    }
    // delete a todo by id
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodoItem(int id)
    {
        var todo = await _db.Todos.FindAsync(id);
        if (todo == null) return NotFound();

        _db.Todos.Remove(todo);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}