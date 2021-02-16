using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Company.DataAccess.Abstract;
using Company.Entities;

namespace Company.DataAccess.Concrete
{
    public class TaskRepository : ITaskRepository
    {
        public Task CreateTask(Task task)
        {
            using var taskDbContext=new CompanyDbContext();
            taskDbContext.Tasks.Add(task);
            taskDbContext.SaveChangesAsync();
            return task;
        }

        public void DeleteTask(int id)
        {
            using var taskDbContext = new CompanyDbContext();
            var deletedTask = GetTaskById(id);
            taskDbContext.Tasks.Remove(deletedTask);
            taskDbContext.SaveChanges();
        }

        public List<Task> GetAllTasks()
        {
            using var taskDbContext = new CompanyDbContext();
            return taskDbContext.Tasks.ToList();
        }

        public Task GetTaskById(int id)
        {
            using var taskDbContext = new CompanyDbContext();
             return taskDbContext.Tasks.Find(id);
        }

        public Task UpdateTask(Task task)
        {
            using var taskDbContext = new CompanyDbContext();
            taskDbContext.Tasks.Update(task);
            taskDbContext.SaveChanges();
            return task;
        }
    }
}
