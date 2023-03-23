using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TodoListSPA.Contracts;
using TodoListSPA.Entities;
using TodoListSPA.Entities.Configuration;
using TodoListSPA.Entities.DTO;

namespace TodoListSPA.Controllers;

[Route("api/todos")]
[ApiController]
public class TodosController : ControllerBase
{
    private readonly AppSettings _appSettings;
    private readonly ITodoService _todoService;

    public TodosController(IOptions<AppSettings> appSettings,
        ITodoService todoService)
    {
        _appSettings = appSettings.Value;
        _todoService = todoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        List<Todo>? todos = await _todoService.GetAllAsync();
        if (!todos.Any()) return Ok(); // Rather return a blank 200 OK than a 404.
        return Ok(todos);     
    }

    [HttpGet("by-status/{status}")]
    public async Task<IActionResult> GetAllAsync(string status)
    {
        List<Todo>? todos = await _todoService.GetAllAsync(status);
        if (!todos.Any()) return Ok(); // Rather return a blank 200 OK than a 404.
        return Ok(todos);        
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        Todo todo = await _todoService.GetByIdAsync(id);        
        return Ok(todo);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm]AddTodo model)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        Todo newTodo = await _todoService.CreateAsync(model);
        string url = $"{_appSettings.AppUrl}/todos/{newTodo.Id}";
        return Created(url, newTodo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateTodo model)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        Todo updatedTodo = await _todoService.UpdateAsync(id, model);

        return Ok(updatedTodo);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        await _todoService.DeleteAsync(id);

        return NoContent();
    }
}
