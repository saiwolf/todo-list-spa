using System.ComponentModel.DataAnnotations;

namespace TodoListSPA.Entities;

public class Todo
{
    public Todo(string name)
        : this()
    {
        Name = name;
    }

    public Todo(string name, TodoStatus status)
        : this()
    {
        Name = name;
        Status = status;
    }

    public Todo()
    {
        Name = null;
        Id = Guid.NewGuid();
        Created = DateTime.Now;
        Status = TodoStatus.Open;
    }
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
    [Required]
    public TodoStatus Status { get; set; }
}
