using System;
using System.Collections.Generic;
using System.Text;
using Company.Business.Abstract;
using Company.DataAccess.Abstract;
using Company.DataAccess.Concrete;
using Company.Entities;

namespace Company.Business.Concrete
{
    public class ProjectManager : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectManager()
        {
            _projectRepository=new ProjectRepository();
        }
        public Project CreateProject(Project project)
        {
            return _projectRepository.CreateProject(project);
        }

        public void DeleteProject(int id)
        {
            _projectRepository.DeleteProject(id);
        }

        public List<Project> GetAllProjects()
        {
            return _projectRepository.GetAllProjects();
        }

        public Project GetProjectById(int id)
        {
            return _projectRepository.GetProjectById(id);
        }

        public Project UpdateProject(Project project)
        {
            return _projectRepository.UpdateProject(project);
        }
    }
}
