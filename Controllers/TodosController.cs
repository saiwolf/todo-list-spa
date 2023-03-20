using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TodoListSPA.Contracts;
using TodoListSPA.Entities;
using TodoListSPA.Entities.Configuration;
using TodoListSPA.Entities.DTO;
using TodoListSPA.Helpers;

namespace TodoListSPA.Controllers;

[Route("api/todos")]
[ApiController]
public class TodosController : ControllerBase
{
    private readonly AppSettings _appSettings;
    private readonly ILogger<TodosController> _logger;
    private readonly ITodoService _todoService;

    public TodosController(IOptions<AppSettings> appSettings,
        ILogger<TodosController> logger,
        ITodoService todoService)
    {
        _appSettings = appSettings.Value;
        _logger = logger;
        _todoService = todoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            List<Todo>? todos = await _todoService.GetAllAsync();
            if (todos is null || !todos.Any()) return Ok(); // Rather return a blank 200 OK than a 404.
            return Ok(todos);
        }
        catch (Exception ex)
        {
            _logger.Error(ex.Message);
            return BadRequest();
        }
    }

    [HttpGet("{status}")]
    public async Task<IActionResult> GetAllAsync(TodoStatus status)
    {
        try
        {
            List<Todo>? todos = await _todoService.GetAllAsync(status);
            if (todos is null || !todos.Any()) return Ok(); // Rather return a blank 200 OK than a 404.
            return Ok(todos);
        }
        catch (Exception ex)
        {
            _logger.Error(ex.Message);
            return BadRequest();
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        try
        {
            Todo? todo = await _todoService.GetByIdAsync(id);
            if (todo is null) return NotFound();
            return Ok(todo);
        }
        catch (Exception ex)
        {
            _logger.Error(ex.Message);
            return BadRequest();
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm]AddTodo model)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Todo newTodo = await _todoService.CreateAsync(model);
            string url = $"{_appSettings.AppUrl}/todos/{newTodo.Id}";
            return Created(url, newTodo);
        }
        catch (Exception ex)
        {
            _logger.Error(ex.Message);
            return BadRequest();
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateTodo model)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Todo updatedTodo = await _todoService.UpdateAsync(id, model);

            return Ok(updatedTodo);
        }
        catch (Exception ex)
        {
            _logger.Error(ex.Message);
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        try
        {
            await _todoService.DeleteAsync(id);

            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.Error(ex.Message);
            return BadRequest();
        }
    }
}
