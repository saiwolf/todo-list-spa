using System.ComponentModel.DataAnnotations;

namespace TodoListSPA.Entities.DTO;

public class AddTodo
{
    [Required]
    public string? Name { get; set; }
}
