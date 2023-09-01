using Domain.Dto;

namespace Domain.Interface.ServicesRepository
{
    public interface ITaskRepositoryService
    {
        Task<ModelTaskDto[]> AllTaskAsync();
        Task<ModelTaskDto> AllTaskIdAsync(int? id);
        Task<Object> AddTaskAsync(ModelTaskDto modelTask);
        Task<ModelTaskDto> UpTaskAsync(ModelTaskDto modelTask);
        Task<bool> DeleteTaskAsync(ModelTaskDto id);
    }
}
