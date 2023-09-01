using Domain.Interface.Repository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class UserRepositoryData : GeralRepositoryData, IUserRepositoryDomain
    {

        private readonly TaskDbContex _taskDbContex;
        public UserRepositoryData(TaskDbContex taskDbContex) : base(taskDbContex)
        {
            _taskDbContex = taskDbContex;
        }

        public async Task<ModelUser[]> BuscaUsersAsync()
        {
            IQueryable<ModelUser> query = _taskDbContex.ModelUser;

            query = query.AsNoTracking()
                         .Include(c => c.ModelTasks)
                         .OrderBy(x => x.Id);

            return await query.ToArrayAsync();

        }

        public async Task<ModelUser> SearchUserByIdAsync(int? Id)
        {
            IQueryable<ModelUser> query = _taskDbContex.ModelUser;

            query = query.AsNoTracking()
                          .Include(c => c.ModelTasks)
                         .Where(x => x.Id == Id)
                         .OrderBy(x => x.Id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<ModelUser> SearchUserByEmailAsync(string? email)
        {
            IQueryable<ModelUser> query = _taskDbContex.ModelUser;

            query = query.AsNoTracking()
                         .Where(x => x.Email == email)
                         .OrderBy(x => x.Id);

            return await query.FirstOrDefaultAsync();
        }
    }
}
