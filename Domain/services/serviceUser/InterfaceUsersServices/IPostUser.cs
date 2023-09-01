using Domain.Dto;

namespace Domain.services.serviceUser.InterfaceUsersServices
{
    public interface IPostUser
    {
        Task<Object> AddUserAsync(ModelUserDto modelUser);
    }
}