using AutodocTest.Dal.Model;
using AutodocTest.Services;

using Microsoft.AspNetCore.Mvc;

namespace AutodocTest.Controllers;

[Route("[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpPost("{name}/{state}")]
    public Task<IActionResult> AddTask([FromRoute] string name, [FromRoute] string state, CancellationToken token)
    {
        var task = new TaskInfo { Name = name, State = state };
        return _taskService.AddTask(task, token).GetActionResult();
    }

    [HttpDelete("{id}")]
    public Task<IActionResult> DeleteTask([FromRoute] int id, CancellationToken token)
        => _taskService.DeleteTask(id, token).GetActionResult(true);

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTask([FromRoute] int id, CancellationToken token)
    {
        var task = await _taskService.GetTask(id, token);
        if (task == null)
            return NotFound();
        return Ok(task);
    }

    [HttpGet("list")]
    public Task<TaskInfo[]> GetTaskList([FromQuery] PageInfo? page, CancellationToken token)
    {
        if (page?.Start == 0 && page?.Count == 0)
            page = null;
        return _taskService.GetTaskList(page, token);
    }

    [HttpPut("{id}/{name}/{state}")]
    public Task<IActionResult> UpdateTask([FromRoute] int id, [FromRoute] string name, [FromRoute] string state, CancellationToken token)
    {
        var task = new TaskInfo { Id = id, Name = name, State = state };
        return _taskService.UpdateTask(task, token).GetActionResult(true);
    }
}
