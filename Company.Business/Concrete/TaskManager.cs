using System;
using System.Collections.Generic;
using System.Text;
using Company.Business.Abstract;
using Company.DataAccess.Abstract;
using Company.DataAccess.Concrete;
using Company.Entities;

namespace Company.Business.Concrete
{
    public class TaskManager : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskManager()
        {
            _taskRepository=new TaskRepository();
        }
        public Task CreateTask(Task task)
        {
            return _taskRepository.CreateTask(task);
        }

        public void DeleteTask(int id)
        {
            _taskRepository.DeleteTask(id);
        }

        public List<Task> GetAllTasks()
        {
            return _taskRepository.GetAllTasks();
        }

        public Task GetTaskById(int id)
        {
            return _taskRepository.GetTaskById(id);
        }

        public Task UpdateTask(Task task)
        {
            return _taskRepository.UpdateTask(task);
        }
    }
}
