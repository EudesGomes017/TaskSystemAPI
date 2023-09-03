using Domain.Dto;
using Domain.Shared;

namespace Domain.services.serviceUser.InterfaceUsersServices
{
    public interface IPostUser
    {
        Task<ReplyJsonRegisteredUser> AddUserAsync(ModelUserDto modelUser);
    }
}