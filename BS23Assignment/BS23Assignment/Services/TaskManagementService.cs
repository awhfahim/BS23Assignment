using BS23Assignment.Data;
using BS23Assignment.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BS23Assignment.Services
{
    public class TaskManagementService
    {
        private ApplicationDbContext _context;
        public TaskManagementService()
        {
            _context = new ApplicationDbContext();
        }

        public async Task CreateTaskAsync(TaskDto taskDto)
        {
            await _context.AddAsync(taskDto);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<TaskDto>> GetAllTaskAsync()
        {
            return  await _context.Task.ToListAsync();
        }

        public async Task UpdateById(Guid id, TaskDto taskDto)
        {
            var task = await _context.Task.FindAsync(id);
            if(task is not  null)
            {
                task.Title = taskDto.Title;
                task.Description = taskDto.Description;
                task.Stutus = taskDto.Stutus;
            }
            await _context.SaveChangesAsync();
        }

        internal async Task DeleteByIdAsync(Guid id)
        {
            var task = await _context.Task.FindAsync(id);
            if (task is not null)
            {
                _context.Task.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }
}
