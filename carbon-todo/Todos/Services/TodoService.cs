using CarbonTodo.Core.Data;
using CarbonTodo.Core.Todos.Entities;
using CarbonTodo.Web.Todos.DTO;
using Microsoft.EntityFrameworkCore;

namespace CarbonTodo.Web.Todos.Services
{
    public class TodoService
    {
        private readonly TodoDb _db;

        public TodoService(TodoDb database)
        {
            _db = database;
        }

        public async Task<List<Todo>> GetAllAsync()
        {
            return await _db.Todos.ToListAsync();
        }

        public async Task<IResult> GetById(int Id)
        {
            var todo = await _db.Todos.FirstOrDefaultAsync(todos => todos.Id == Id);

            return todo is null ? Results.NotFound() : Results.Ok(todo);
        }

        public async Task<IResult> Create(CreateDTO dto)
        {
            var todo = new Todo()
            {
                Title = dto.Title,
            };

            _db.Todos.Add(todo);
            await _db.SaveChangesAsync();
            return Results.Created($"/todos/{todo.Id}", todo);
        }
    }
}
