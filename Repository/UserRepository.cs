

using AutoMapper;
using Domain.Dto;
using Microsoft.EntityFrameworkCore;
using Repository.ServicesRepository;

namespace Repository
{
    public class UserRepository : IUserRepositoryService
    {

        private readonly TaskDbContex _taskDbContex;
        private readonly IMapper _mapper;

        public UserRepository(TaskDbContex taskDbContex, IMapper mapper)
        {
            _taskDbContex = taskDbContex;
            _mapper = mapper;
        }

        public async Task<List<ModelUserDto[]>> SearchAllUsersAsync()
        {
            ModelUserDto[] user;

            try
            {
                var user = await _taskDbContex.BuscaUsersAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return
           }

        public Task<ModelUserDto> SearchUserIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ModelUserDto> AddUserAsync(ModelUser modelUser)
        {
            throw new NotImplementedException();
        }

        public Task<ModelUserDto> UpUserAsync(ModelUser modelUser, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            ModelUser userId = await SearchAllUsersAsync(id);

            if (userId == null)
            {
                throw new Exception($"Usuario para id: {id} nao foi encontrado no banco de dados");
            }

            _taskDbContex.ModelUser.Remove(userId);
            await _taskDbContex.SaveChangesAsync();

            return true;
        }

            public async Task<List<ModelUser>> SearchAllUsers()
        {
            return await _taskDbContex.ModelUser.ToListAsync();
        }

        public async Task<ModelUser> AddUser(ModelUser user)
        {
            await _taskDbContex.ModelUser.AddAsync(user);
            await _taskDbContex.SaveChangesAsync();

            return user;

        }

        public async Task<ModelUser> UpUser(ModelUser user, int id)
        {
            ModelUser userId = await SearchAllUsersAsync(id);

            if (userId == null)
            {
                throw new Exception($"Usuario para id: {id} nao foi encontrado no banco de dados");
            }

            userId.Name = user.Name;
            userId.Email = user.Email;

            _taskDbContex.ModelUser.Update(userId);
            await _taskDbContex.SaveChangesAsync();

            return userId;

        }

       
        }

       

       
    }
}
