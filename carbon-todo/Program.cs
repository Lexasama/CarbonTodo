using CarbonTodo.Core.Data;
using CarbonTodo.Core.Todos.Entities;
using CarbonTodo.Web.Todos.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");
builder.Services.AddOptions();
builder.Services.AddCors();
builder.Services.AddDbContext<TodoDb>(options =>
options.UseSqlite(
    builder.Configuration.GetConnectionString("TodoDb")
 ));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/todos", async ([FromBody] CreateDTO dto, TodoDb db, HttpResponse response) =>
{
    var todo = new Todo { Title = dto.Title };
    db.Todos.Add(todo);
    await db.SaveChangesAsync();
    return Results.Created($"/todos/{todo.Id}", todo);
});

app.MapGet("/todos", async (TodoDb db) =>
{

    return Results.Ok(await db.Todos.OrderBy(t => t.Order).ToListAsync());
});

app.MapDelete("/todos", async (bool? completed, TodoDb db) =>
{

    if (completed is not null && completed == true)
    {
        var todosToRemove = db.Todos.Where(todo => todo.Completed).ToList();
        db.Todos.RemoveRange(todosToRemove);
        return Results.NoContent();
    }

    return Results.NoContent();
});

app.MapGet("/todos/{id}", async (int id, TodoDb db) =>

    await db.Todos.FirstOrDefaultAsync(todo => todo.Id == id) is Todo todo ? Results.Ok(todo) :
    Results.NotFound()
);

app.MapPut("/todos/{id}", async (int id, [FromBody] UpdateDTO dto, TodoDb db) =>
{
    var todo = await db.Todos.FirstOrDefaultAsync(todo => todo.Id == id);
    if (todo == null)
    {
        return Results.NotFound();
    }
    //cleaner way https://dotnetcoretutorials.com/2022/01/29/better-exception-handling-with-entityframeworkcore-exceptions/
    // ill have to fix my Dependencies 

    var orderTodo = await db.Todos.FirstOrDefaultAsync(todo => todo.Order == dto.Order);

    if (orderTodo is not null && orderTodo.Id == todo.Id)
    {
        return Results.Conflict();
    }

    return Results.Ok();
});



// Patch ?? 

app.MapDelete("/todos/{id}", async (int id, TodoDb db) =>
{
    var found = await db.Todos.FirstOrDefaultAsync(todo => todo.Id == id);

    if (found is null)
    {
        return Results.NotFound(); ;
    };
  //cleaner way using transactions  

    db.Todos.Remove(found);
    await db.SaveChangesAsync();
    return Results.NoContent();

});

app.UseCors();
app.Run();
