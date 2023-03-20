using TodoListSPA.Entities;
using TodoListSPA.Entities.DTO;

namespace TodoListSPA.Contracts;

public interface ITodoService
{
    IEnumerable<Todo?> GetAll();
    Task<List<Todo>?> GetAllAsync();
    Task<List<Todo>?> GetAllAsync(TodoStatus status);
    Task<Todo?> GetByIdAsync(Guid id);
    Task<Todo?> GetByIdAsync(string id);
    Task<Todo> CreateAsync(AddTodo model);
    Task<Todo> UpdateAsync(Guid id, UpdateTodo model);
    Task DeleteAsync(Guid id);
}
