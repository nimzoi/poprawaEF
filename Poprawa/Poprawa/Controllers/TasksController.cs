
using Microsoft.AspNetCore.Mvc;
using Poprawa.DTOs;
using Poprawa.Models;
using Poprawa.Services;
using Task = Poprawa.Models.Task;

namespace Poprawa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly TaskService _taskService;
        private readonly ProjectService _projectService;
        private readonly UserService _userService;

        public TasksController(TaskService taskService, ProjectService projectService, UserService userService)
        {
            _taskService = taskService;
            _projectService = projectService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks([FromQuery] int? projectId)
        {
            var tasks = await _taskService.GetTasksAsync(projectId);
            return Ok(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskDTO createTaskDto)
        {
            var project = await _projectService.GetProjectByIdAsync(createTaskDto.ProjectId);
            if (project == null)
            {
                return NotFound("Project not found.");
            }

            var reporter = await _userService.GetUserByIdAsync(createTaskDto.ReporterId);
            if (reporter == null)
            {
                return NotFound("Reporter not found.");
            }

            if (createTaskDto.AssigneeId.HasValue)
            {
                var assignee = await _userService.GetUserByIdAsync(createTaskDto.AssigneeId.Value);
                if (assignee == null)
                {
                    return NotFound("Assignee not found.");
                }
            }
            else
            {
                createTaskDto.AssigneeId = project.DefaultAssigneeId;
            }

            if (!await _userService.UserHasAccessToProjectAsync(createTaskDto.ReporterId, createTaskDto.ProjectId) ||
                !await _userService.UserHasAccessToProjectAsync(createTaskDto.AssigneeId.Value, createTaskDto.ProjectId))
            {
                return Forbid("Reporter or Assignee does not have access to the project.");
            }

            var newTask = new Task
            {
                ProjectId = createTaskDto.ProjectId,
                ReporterId = createTaskDto.ReporterId,
                AssigneeId = createTaskDto.AssigneeId,
                Title = createTaskDto.Title,
                Description = createTaskDto.Description,
                CreatedAt = DateTime.UtcNow
            };

            await _taskService.CreateTaskAsync(newTask);

            return CreatedAtAction(nameof(GetTasks), new { id = newTask.TaskId }, newTask);
        }
    }
}
