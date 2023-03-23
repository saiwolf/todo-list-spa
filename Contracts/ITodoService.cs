using TodoListSPA.Entities;
using TodoListSPA.Entities.DTO;

namespace TodoListSPA.Contracts;

/// <summary>
/// Interface definition for Todo Service
/// </summary>
public interface ITodoService
{
    /// <summary>
    /// Synchronous method to return all <see cref="Todo"/> in the DB table.
    /// </summary>
    /// <returns><see cref="IEnumerable{T}"/> where <c>T</c> is <see cref="Todo"/> or null</returns>
    IEnumerable<Todo?> GetAll();
    /// <summary>
    /// Asynchronous method to return all <see cref="Todo"/>s in the DB table.
    /// </summary>
    /// <returns>A <see cref="Task"/> containing <see cref="List{T}"/> where <c>T</c> is <see cref="Todo"/> or <see cref="null"/></returns>
    Task<List<Todo>> GetAllAsync();
    /// <summary>
    /// Asynchronous method to return <see cref="Todo"/>s in the DB table matching <paramref name="status"/>.
    /// </summary>
    /// <param name="status">Status to query.</param>
    /// <returns>A <see cref="Task"/> containing <see cref="List{T}"/> where <c>T</c> is <see cref="Todo"/> or <see cref="null"/></returns>
    Task<List<Todo>> GetAllAsync(string status);
    /// <summary>
    /// <para>
    /// Asynchronous method to return <see cref="Todo"/> by supplied ID.
    /// </para>
    /// </summary>
    /// <param name="id">A <see cref="Guid"/> value to lookup.</param>
    /// <returns><see cref="Todo"/> with ID equal to <paramref name="id"/> or null</returns>
    Task<Todo> GetByIdAsync(Guid id);
    /// <summary>
    /// <para>
    /// Asynchronous convienence method for <see cref="string"/> form of GUID IDs.
    /// </para>
    /// </summary>
    /// <param name="id">A <see cref="Guid"/> value in <see cref="string"/> format.</param>
    /// <returns><see cref="Todo"/> with ID equal to <paramref name="id"/> or null</returns>
    /// <exception cref="ArgumentException"><paramref name="id"/> was null or empty.</exception>
    /// <exception cref="FormatException"><paramref name="id" /> was not a valid <see cref="Guid"/></exception>
    Task<Todo> GetByIdAsync(string id);
    /// <summary>
    /// <para>
    /// Asynchronous method for creating a new <see cref="Todo"/> and persisting it to the DB.
    /// </para>
    /// </summary>
    /// <param name="model">POCO DTO of type <see cref="AddTodo"/> containing new record info.</param>
    /// <returns>A newly saved instance of <see cref="Todo"/> with information supplied by <paramref name="model"/></returns>
    Task<Todo> CreateAsync(AddTodo model);
    /// <summary>
    /// <para>
    /// Asynchronous method for updating an existing <see cref="Todo"/> in the DB.
    /// </para>
    /// </summary>
    /// <param name="id">A <see cref="Guid"/> used to lookup record in DB.</param>
    /// <param name="model">POCO DTO of type <see cref="UpdateTodo"/> containing updated record info.</param>
    /// <returns>An updated instance of <see cref="Todo"/> with information supplied by <paramref name="model"/></returns>
    Task<Todo> UpdateAsync(Guid id, UpdateTodo model);
    /// <summary>
    /// <para>
    /// Asynchronous method to remove an existing <see cref="Todo"/> from the DB.
    /// </para>
    /// </summary>
    /// <param name="id">A <see cref="Guid"/> used to lookup record in DB.</param>    
    Task DeleteAsync(Guid id);
}
