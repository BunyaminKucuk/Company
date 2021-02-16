using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Company.DataAccess.Abstract;
using Company.Entities;

namespace Company.DataAccess.Concrete
{
    public class ProjectRepository : IProjectRepository
    {
        public Project CreateProject(Project project)
        {
            using var projectDbContext=new CompanyDbContext();
            projectDbContext.Projects.Add(project);
            projectDbContext.SaveChanges();
            return project;
        }

        public void DeleteProject(int id)
        {
            using var employeeDbContext = new CompanyDbContext();
            var deletedProject = GetProjectById(id);
            employeeDbContext.Projects.Remove(deletedProject);
            employeeDbContext.SaveChanges();
        }

        public List<Project> GetAllProjects()
        {
            using var employeeDbContext = new CompanyDbContext();
            return employeeDbContext.Projects.ToList();
        }

        public Project GetProjectById(int id)
        {
            using var employeeDbContext = new CompanyDbContext();
            return employeeDbContext.Projects.Find(id);
        }

        public Project UpdateProject(Project project)
        {
            using var employeeDbContext = new CompanyDbContext();
            employeeDbContext.Projects.Update(project);
            employeeDbContext.SaveChanges();
            return project;
        }
    }
}
