using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using Task = TaskManager.Models.Task;

namespace TaskManager.Interfaces
{
    public interface ITaskRepository
    {
       public Task<List<Task>> All();
        public Task<Task> Get(string id);
        public Task<Task> Create(Task dto);
        public Task<Task> Update(string id,Task dto);
        public Task<Task> Delete(string id);


    }
}
