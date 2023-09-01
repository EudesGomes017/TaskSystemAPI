using Domain.Dto;

namespace Domain.services.serviceUser.InterfaceUsersServices
{
    public interface IDeleteUser
    {
        Task<bool> DeleteAsync(ModelUserDto id);
    }
}