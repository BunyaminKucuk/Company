using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Business.Abstract;
using Company.Business.Concrete;
using Task = Company.Entities.Task;


namespace Company.API.Controllers
{
    [Route("api/task")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController()
        {
            _taskService = new TaskManager();
        }

        [HttpGet]
        [Route("list")]
        public IActionResult GetTask()
        {
            var task = _taskService.GetAllTasks();
            return Ok(task);
        }

        [HttpGet]
        [Route("getById/{id}")]
        public IActionResult GetTaskById(int id)
        {
            var task = _taskService.GetTaskById(id);
            if (task != null)
            {
                return Ok(task);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult CreateTask([FromBody] Task task)
        {
            var createdTask = _taskService.CreateTask(task);
            return CreatedAtAction("Get", new { id = createdTask.TaskId }, createdTask);
        }
        [HttpPut]
        [Route("update")]

        public IActionResult UpdateTask([FromBody] Entities.Task task)
        {
            if (_taskService.GetTaskById(task.TaskId) != null)
            {
                return Ok(_taskService.UpdateTask(task));//201+data
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public void DeleteTask(int id)
        {
            _taskService.DeleteTask(id);
        }
    }
}
