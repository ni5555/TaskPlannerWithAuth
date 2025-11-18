using System;
using System.Collections.Generic;
using System.Linq;
using TaskPlanner.Models;

namespace TaskPlanner.Services
{
    public class TaskService
    {
        private List<TaskItem> _tasks = new List<TaskItem>();
        private int _nextTaskId = 1;

        public TaskItem CreateTask(string title, string description, DateTime dueDate, int userId)
        {
            var task = new TaskItem
            {
                Id = _nextTaskId++,
                Title = title,
                Description = description,
                DueDate = dueDate,
                CreatedAt = DateTime.Now,
                IsCompleted = false,
                UserId = userId,
                SharedWithUserId = 0
            };

            _tasks.Add(task);
            return task;
        }

        public List<TaskItem> GetUserTasks(int userId, SortType sortType)
        {
            var userTasks = _tasks.Where(t => t.UserId == userId || t.SharedWithUserId == userId).ToList();

            if (sortType == SortType.ByCreationDate)
            {
                return userTasks.OrderByDescending(t => t.CreatedAt).ToList();
            }
            else
            {
                return userTasks.OrderBy(t => t.DueDate).ToList();
            }
        }

        public void UpdateTask(int taskId, string title, string description, DateTime dueDate, bool isCompleted)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            {
                task.Title = title;
                task.Description = description;
                task.DueDate = dueDate;
                task.IsCompleted = isCompleted;
            }
        }

        public void DeleteTask(int taskId)
        {
            _tasks.RemoveAll(t => t.Id == taskId);
        }

        // ДОБАВЛЕН МЕТОД ShareTask
        public void ShareTask(int taskId, int targetUserId)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            {
                var sharedTask = new TaskItem
                {
                    Id = _nextTaskId++,
                    Title = task.Title,
                    Description = task.Description,
                    DueDate = task.DueDate,
                    CreatedAt = DateTime.Now,
                    IsCompleted = false,
                    UserId = task.UserId,
                    SharedWithUserId = targetUserId
                };

                _tasks.Add(sharedTask);
            }
        }

        public List<TaskItem> GetUpcomingTasks(int userId)
        {
            return _tasks.Where(t =>
                (t.UserId == userId || t.SharedWithUserId == userId) &&
                !t.IsCompleted &&
                t.DueDate > DateTime.Now &&
                t.DueDate <= DateTime.Now.AddHours(1)
            ).ToList();
        }

        public TaskItem GetTaskById(int taskId)
        {
            return _tasks.FirstOrDefault(t => t.Id == taskId);
        }

        // ДОБАВЛЕН МЕТОД GetTasks (без параметра сортировки для внутреннего использования)
        public List<TaskItem> GetTasks(int userId)
        {
            return _tasks.Where(t => t.UserId == userId || t.SharedWithUserId == userId).ToList();
        }
    }
}