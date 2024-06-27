using Microsoft.Data.SqlClient;
using TaskManager.Interfaces;
using TaskManager.Models;
using Task = TaskManager.Models.Task;

namespace TaskManager.Repository
{
    public class TaskRepository : ITaskRepository
    {

        private readonly TaskManagerContext _context;
        private readonly IConfiguration Configuration;

        public TaskRepository(TaskManagerContext context, IConfiguration configuration)
        {

            _context = context;
            Configuration = configuration;
        }

        public async Task<List<Task>> All()
        {
            try
            {
               // using var connection = new SqlConnection(Configuration.GetConnectionString("DbConnection"));

                var result = _context.Task.ToList();

                return result;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Task> Get(string id)
        {
            try
            {
                var result = _context.Task.Where(x => x.Id == id).FirstOrDefault();

                if (result == null)
                {
                    throw new Exception("Task does not exist");
                }

                return result;
            }catch (Exception ex)
            {
                throw ex;

            }
        }

        public async Task<Task>Create(Task dto)
        {
            try { 
            if (dto != null)
            {
                dto.Id = Guid.NewGuid().ToString();

                await _context.Task.AddAsync(dto);
                await _context.SaveChangesAsync();

                return dto;

            }
            else
            {
               throw new Exception("insert data was null");
            }

            }
            catch (Exception ex)
            {
                throw ex;

            }

        }


        public async Task<Task>Update(string id, Task dto)
        {
            try
            {
                var result = _context.Task.Where(x => x.Id == id).FirstOrDefault();
                if (result != null)
                {
                    result.Title = dto.Title;
                    result.Description = dto.Description;
                    result.DueDate = dto.DueDate;

                    await _context.SaveChangesAsync();

                    return result;
                }
                else
                {
                    throw new Exception("task is not exist");

                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public async Task<Task> Delete(string id)
        {
            try
            {
                var result = _context.Task.Where(x => x.Id == id).FirstOrDefault();
                if (result != null)
                {
                    _context.Task.Remove(result);
                    await _context.SaveChangesAsync();

                    return result;
                }
                else 
                {

                   throw new Exception("task is not exist");
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
