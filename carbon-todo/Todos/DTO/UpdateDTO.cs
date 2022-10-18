using System.ComponentModel.DataAnnotations;

namespace CarbonTodo.Web.Todos.DTO
{
    public class UpdateDTO
    {
        [Required]
        public string Title { get; set; }
        
        [Required]
        public bool Completed { get; set; }
       
        [Required]
        public int Order { get; set; }
    }
}
