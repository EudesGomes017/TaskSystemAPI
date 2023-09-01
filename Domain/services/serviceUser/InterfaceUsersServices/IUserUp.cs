using Domain.Dto;

namespace Domain.services.serviceUser.InterfaceUsersServices
{
    public interface IUserUp
    {
        Task<ModelUserDto> UpUserAsync(ModelUserDto modelUser);
    }
}