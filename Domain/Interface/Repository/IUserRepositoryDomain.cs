
using Data.Repository;
using Domain.Dto;
using Domain.Models;

namespace Domain.Interface.Repository
{
    public interface IUserRepositoryDomain : IGeralRepositoryDomain
    {
        Task<ModelUser> SearchUserByIdAsync(int? id);
        Task<ModelUser> SearchUserByEmailAsync(string? email);
        Task<ModelUser[]> BuscaUsersAsync();
    }
}
