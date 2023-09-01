using Domain.Interface.Repository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class TaskRepositoryData : GeralRepositoryData, ITaskRepositoryDomain
    {
        private readonly TaskDbContex _taskDbContex;

        public TaskRepositoryData(TaskDbContex taskDbContex) : base(taskDbContex)
        {
            _taskDbContex = taskDbContex;
        }

        public async Task<ModelTask[]> allTasksAsync()
        {
            IQueryable<ModelTask> query = _taskDbContex.ModelTask;

            return await query.ToArrayAsync();
        }


        public async Task<ModelTask> TaskByNameAsync(string name)
        {
            IQueryable<ModelTask> query = _taskDbContex.ModelTask;

            query = query
                .Where(x => x.Name == name)
                .OrderBy(x => x.Id);

            return await query.FirstOrDefaultAsync();
        }


        public async Task<ModelTask> TaskByIdAsync(int? id)
        {
            IQueryable<ModelTask> query = _taskDbContex.ModelTask;

            query = query.AsNoTracking()
                          .Include(x => x.User)   
                         .Where(x => x.Id == id)
                         .OrderBy(x => x.Id);

            return await query.FirstOrDefaultAsync();
        }



    }
}
