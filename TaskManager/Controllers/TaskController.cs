using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Interfaces;
using TaskManager.Models;
using Task = TaskManager.Models.Task;

namespace TaskManager.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository TaskRepository;


        public TaskController(ITaskRepository taskRepository)
        {

            TaskRepository = taskRepository;


        }

        [HttpGet]
        public async Task<ActionResult> All()
        {
            try
            {
                var result = await TaskRepository.All();
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            try
            {
                var result = await TaskRepository.Get(id);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Task dto)
        {
            try
            {
                var result =await TaskRepository.Create(dto);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, [FromBody] Task dto)
        {
            try
            {
                var result = await TaskRepository.Update(id,dto);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var result = await TaskRepository.Delete(id);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

       
    }
}
