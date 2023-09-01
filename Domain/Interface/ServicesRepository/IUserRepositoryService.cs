using Domain.Dto;

namespace Domain.Interface.ServicesRepository
{
    public interface IUserRepositoryService
    {
        Task<ModelUserDto[]> SearchAllUsersAsync();
        Task<ModelUserDto> SearchUserIdAsync(int id);
        Task<ModelUserDto> SearchEamil(string email);
       // Task<Object> AddUserAsync(ModelUserDto modelUser);
        Task<ModelUserDto> UpUserAsync(ModelUserDto modelUser);
        Task<bool> DeleteAsync(ModelUserDto id);
    }
}
