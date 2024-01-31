
using BS23Assignment.DTOs;
using BS23Assignment.Services;

namespace BS23Assignment.Models
{
    public class TaskRetrieveModel
    {
        private readonly TaskManagementService _taskManagementService;
        public TaskRetrieveModel()
        {
            _taskManagementService = new TaskManagementService();
        }

        internal async Task DeleteByIdAsync(Guid id)
        {
            await _taskManagementService.DeleteByIdAsync(id);
        }

        internal async Task<IList<TaskDto>> GetAllTaskAsync()
        {
            return await _taskManagementService.GetAllTaskAsync();
        }
    }
}
