using Domain.Dto;

namespace Domain.services.serviceUser.InterfaceUsersServices
{
    public interface IAllUsers
    {
        Task<ModelUserDto[]> SearchAllUsersAsync();
    }
}