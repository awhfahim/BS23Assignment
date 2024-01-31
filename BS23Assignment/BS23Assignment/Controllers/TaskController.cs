using BS23Assignment.DTOs;
using BS23Assignment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BS23Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        [Authorize(Roles = "Admin")]
        [HttpPost("Tasks")]
        public async Task<IActionResult> Create(TaskCreateModel model)
        {
            if (ModelState.IsValid)
            {
                await model.CreateTaskAsync();
                return Ok(new { message = "Data created successfully" });
            }
            return BadRequest(ModelState);
        }

        [HttpGet("Tasks"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllTask()
        {
            var model = new TaskRetrieveModel();
            var data = await model.GetAllTaskAsync();
            return Ok(data);
        }

        [HttpPut("Tasks"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromQuery]Guid id, TaskCreateModel model)
        {
            await model.UpdateById(id);
            return Ok(new {Message = "Successfully Updated"});
        }
        
        [HttpDelete("Tasks"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromQuery]Guid id)
        {
            var model = new TaskRetrieveModel();
            await model.DeleteByIdAsync(id);
            return Ok(new {Message = "Successfully Deleted"});
        }
    }
}
