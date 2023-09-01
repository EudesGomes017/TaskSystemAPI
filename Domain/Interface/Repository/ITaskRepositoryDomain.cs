
using Data.Repository;
using Domain.Models;

namespace Domain.Interface.Repository
{
    public interface ITaskRepositoryDomain : IGeralRepositoryDomain
    {
        Task<ModelTask> TaskByIdAsync(int? id);
        Task<ModelTask> TaskByNameAsync(string nome);
        Task<ModelTask[]> allTasksAsync();
    }
}
