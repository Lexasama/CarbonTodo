﻿
namespace CarbonTodo.Core.Todos.Entities
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public bool Completed { get; set; }

        public int Order { get; set; }

        public string Url { get; set; }

    }
}
