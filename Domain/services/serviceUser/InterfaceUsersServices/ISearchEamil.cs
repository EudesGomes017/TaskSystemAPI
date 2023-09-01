using Domain.Dto;

namespace Domain.services.serviceUser.InterfaceUsersServices
{
    public interface ISearchEamil
    {
        Task<ModelUserDto> SearchEamil(string email);
    }
}