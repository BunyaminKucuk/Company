using System;
using System.Collections.Generic;
using System.Text;
using Company.Entities;

namespace Company.Business.Abstract
{
    public interface IProjectService
    {
        List<Project> GetAllProjects();
        Project GetProjectById(int id);
        Project CreateProject(Project project);
        Project UpdateProject(Project project);
        void DeleteProject(int id);
    }
}
