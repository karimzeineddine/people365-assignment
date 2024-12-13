using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure SQLite Database
builder.Services.AddDbContext<TodoDb>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddControllers();

// Add JWT Authentication using the extension method
builder.Services.AddJwtAuthentication("YourVeryLongSecretKeyOfAtLeast32Bytes!");

// Add Authorization
builder.Services.AddAuthorization();

var app = builder.Build();

// Enable Authentication and Authorization middleware
app.UseAuthentication();
app.UseAuthorization();

// Map controllers
app.MapControllers();

app.Run();
