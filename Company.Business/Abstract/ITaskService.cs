﻿using System;
using System.Collections.Generic;
using System.Text;
using Company.Entities;

namespace Company.Business.Abstract
{
    public interface ITaskService
    {
        List<Task> GetAllTasks();
        Task GetTaskById(int id);
        Task CreateTask(Task task);
        Task UpdateTask(Task task);
        void DeleteTask(int id);
    }
}
