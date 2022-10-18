using System.ComponentModel.DataAnnotations;

namespace CarbonTodo.Web.Todos.DTO
{
    public class CreateDTO
    {
        [Required]
        public string Title { get; set; }
    }
}
