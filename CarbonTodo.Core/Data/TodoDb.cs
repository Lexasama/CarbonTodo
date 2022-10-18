using CarbonTodo.Core.Todos;
using CarbonTodo.Core.Todos.Entities;
using EntityFramework.Exceptions.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace CarbonTodo.Core.Data
{
    public class TodoDb : DbContext
    {
        public DbSet<Todo> Todos => Set<Todo>();

        public TodoDb(DbContextOptions<TodoDb> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseExceptionProcessor();
        }

        protected override void OnModelCreating( ModelBuilder modelBuilder)
        {
            modelBuilder.AddTodos();
        }
    }
}
