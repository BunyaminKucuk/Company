using System;
using System.Collections.Generic;
using System.Text;
using Company.Entities;

namespace Company.DataAccess.Abstract
{
    public interface IProjectRepository
    {
        List<Project> GetAllProjects();
        Project GetProjectById(int id);
        Project CreateProject(Project project);
        Project UpdateProject(Project project);
        void DeleteProject(int id);
    }
}
