using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Poprawa.Data;
using Poprawa.Models;
using Task = Poprawa.Models.Task;

namespace Poprawa.Services
{
    public class TaskService
    {
        private readonly TaskManagementContext _context;

        public TaskService(TaskManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Task>> GetTasksAsync(int? projectId = null)
        {
            if (projectId.HasValue)
            {
                return await _context.Tasks
                    .Where(t => t.ProjectId == projectId.Value)
                    .ToListAsync();
            }
            else
            {
                return await _context.Tasks.ToListAsync();
            }
        }

        public async Task<bool> CreateTaskAsync(Task newTask)
        {
            _context.Tasks.Add(newTask);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}