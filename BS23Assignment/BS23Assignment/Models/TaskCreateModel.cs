
using BS23Assignment.DTOs;
using BS23Assignment.Services;
using Mapster;

namespace BS23Assignment.Models
{
    public class TaskCreateModel
    {
        private readonly TaskManagementService _taskManagementService;
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Stutus { get; set; }

        public TaskCreateModel()
        {
            _taskManagementService = new TaskManagementService();
        }
        internal async Task CreateTaskAsync()
        {
            var taskDto = this.Adapt<TaskDto>();
            await _taskManagementService.CreateTaskAsync(taskDto);
        }

        internal async Task UpdateById(Guid id)
        {
            var newTaskDto = this.Adapt<TaskDto>();
            await _taskManagementService.UpdateById(id, newTaskDto);
        }
    }
}
