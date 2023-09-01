using Domain.Dto;

namespace Domain.services.serviceUser.InterfaceUsersServices
{
    public interface IUserId
    {
        Task<ModelUserDto> SearchUserIdAsync(int id);
    }
}