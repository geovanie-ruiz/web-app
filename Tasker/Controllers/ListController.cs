using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Tasker.Controllers;

[ApiController]
[Route("[controller]")]
public class ListController : ControllerBase
{
    private readonly ToDoListContext _context;

    public ListController(ToDoListContext toDoListContext)
    {
        _context = toDoListContext;
    }

    // GET: api/list/all
    [HttpGet]
    [Route("all")]
    public async Task<ActionResult<IEnumerable<Task>>> GetToDoLists()
    {
        var tasks = await _context.Tasks.ToListAsync<Task>();
        return Ok(tasks);
    }

    public class TaskDef
    {
        public string? taskName { get; set; }
        public int listId { get; set; }
    }

    [HttpPost]
    [Route("add")]
    public async Task<ActionResult<Task>> AddNewTask([FromBody] TaskDef task)
    {
        Task newTask = new Task
        {
            TaskDescription = task.taskName,
            TaskComplete = false,
            ToDoListId = task.listId
        };
        _context.Add(newTask);
        await _context.SaveChangesAsync();

        return StatusCode(201);
    }

    [HttpDelete]
    [Route("delete/{id:int}")]
    public async Task<ActionResult<Task>> DeleteTask(int id)
    {
        var taskToDelete = await _context.Tasks.FindAsync(id);
        if (taskToDelete == null)
        {
            return NotFound();
        }

        _context.Tasks.Remove(taskToDelete);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
