using System.ComponentModel.DataAnnotations;

namespace TodoListSPA.Entities.DTO;

public class UpdateTodo
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public TodoStatus Status { get; set; }
}
