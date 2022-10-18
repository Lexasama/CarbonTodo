using System.Net;
using System.Net.Http.Json;
using CarbonTodo.Core.Data;
using CarbonTodo.Core.Todos.Entities;

namespace CarbonTodo.Tests
{
    public  class TodoServiceTest
    {

        //public async Task POST_Todo_returns_create_response()
        //{
        //    var app = new ApiApplication();
        //    var todoTodCreate = new Todo()
        //    {
        //        Title = "Task" + new Guid(),
        //    };

        //    var todo = await app.TodoService.Create(todoTodCreate);
        //    var expectedResponseBody = @"";

        //    var client = app.CreateClient();
        //    var response = await client.PostAsync("/todos", todo);
        //    var responseBody = await response.Content.ReadAsStringAsync();

        //    //assert esuams HttpStatusCode.Created, response.StatusCode)
        //    // expectedResponseBody responseBody

        //}

        //public async Task when_todo_created_then_gets_response_and_status_code()
        //{
        //    var todoToCreate = new Todo { };
        //    var mockDbContext = CreateMockDbContext();
        //    var sut = new TodoService(mockDbContext.Object);

        //    var result = await sut.Create(todoToCreate);

        //    //var resultType = Assert.IsType<>(result);
        //    //assert.Equal status code 
        //    // assert.equal value 
        //}


       

        //private static Mock<TodoDb> CreateMockDbContext()
        //{
        //    var data = new List<Todo>
        //    {
        //        new Todo
        //        {
                    
        //        }
        //    };
        //}
    }
}
