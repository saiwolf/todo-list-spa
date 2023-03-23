using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoListSPA.Contracts;
using TodoListSPA.Data;
using TodoListSPA.Entities;
using TodoListSPA.Entities.DTO;

namespace TodoListSPA.Services;

/// <summary>
/// Service that provides CRUD methods for the <see cref="Todo"/> model.
/// </summary>
public class TodoService : ITodoService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public TodoService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<Todo?> GetAll()
    {
        foreach (Todo todo in _context.Todos)
            yield return todo;
    }

    public async Task<List<Todo>> GetAllAsync()
    {
        List<Todo>? todos = await _context.Todos.ToListAsync();
        if (todos is null || !todos.Any())
            return new();
        return todos;
    }

    public async Task<List<Todo>> GetAllAsync(TodoStatus status)
    {
        List<Todo>? todos = await _context.Todos.Where(w => w.Status == status).ToListAsync();
        if (todos is null || !todos.Any())
            return new();
        return todos;
    }

    public async Task<Todo?> GetByIdAsync(Guid id)
    {
        Todo? todo = await _GetAsync(id);
        if (todo is null)
            return null;
        return todo;
    }

    public async Task<Todo?> GetByIdAsync(string id)
    {
        if (string.IsNullOrEmpty(id))
            throw new ArgumentNullException(nameof(id));
        if (Guid.TryParse(id, out Guid todoId))
            return await GetByIdAsync(todoId);
        else
            throw new FormatException($"Parameter `{id}` is malformed!");
    }

    public async Task<Todo> CreateAsync(AddTodo model)
    {
        Todo newTodo = _mapper.Map<Todo>(model);
        _context.Todos.Add(newTodo);
        await _context.SaveChangesAsync();
        return newTodo;
    }

    public async Task<Todo> UpdateAsync(Guid id, UpdateTodo model)
    {
        // Sanity check!
        if (id != model.Id)
            throw new Exception("ID mis-match found during update. Aborting!");

        Todo? dbTodo = await _GetAsync(id);
        if (dbTodo is null) throw new Exception($"Unable to find record with ID: `{id}`");
        _mapper.Map(model, dbTodo);
        _context.Todos.Update(dbTodo);
        await _context.SaveChangesAsync();
        return dbTodo;
    }

    public async Task DeleteAsync(Guid id)
    {
        Todo? dbTodo = await _GetAsync(id);
        if (dbTodo is null) throw new Exception($"Unable to find record with ID: `{id}`");
        _context.Todos.Remove(dbTodo);
        await _context.SaveChangesAsync();
    }

    #region Private/Helper methods

    /// <summary>
    /// Asynchronous method serving as a one-stop shop for getting DB records via their <paramref name="id"/>.
    /// </summary>
    /// <param name="id">A <see cref="Guid"/> used to lookup record in DB.</param>
    /// <returns><see cref="Todo"/> corresponding to given <paramref name="id"/> or null.</returns>
#pragma warning disable IDE1006 // Naming Styles
    private async Task<Todo?> _GetAsync(Guid id)
#pragma warning restore IDE1006 // Naming Styles
        => await _context.Todos.FindAsync(id);
    #endregion
}
