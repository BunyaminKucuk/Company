using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Business.Abstract;
using Company.Business.Concrete;
using Company.Entities;

namespace Company.API.Controllers
{
    [Route("api/project")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController()
        {
            _projectService = new ProjectManager();
        }

        [HttpGet]
        [Route("list")]
        public IActionResult GetProject()
        {
            var project = _projectService.GetAllProjects();
            return Ok(project);
        }

        [HttpGet]
        [Route("getById/{id}")]
        public IActionResult GetProjectById(int id)
        {
            var project = _projectService.GetProjectById(id);
            if (project != null)
            {
                return Ok(project);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult CreateProject([FromBody] Project project)
        {
            var createdProject = _projectService.CreateProject(project);
            return CreatedAtAction("Get", new { id = createdProject.ProjectId }, createdProject);
        }
        [HttpPut]
        [Route("update")]

        public IActionResult UpdateProject([FromBody] Project project)
        {
            if (_projectService.GetProjectById(project.ProjectId) != null)
            {
                return Ok(_projectService.UpdateProject(project));//201+data
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public void DeleteProject(int id)
        {
            _projectService.DeleteProject(id);
        }
    }
}
