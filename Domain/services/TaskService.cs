using AutoMapper;
using Domain.Dto;
using Domain.Interface.Repository;
using Domain.Interface.ServicesRepository;
using Domain.Models;

namespace Domain.Interface
{
    public class TaskService : ITaskRepositoryService
    {
        private readonly ITaskRepositoryDomain _taskRepositoryDomain;
        private readonly IUserRepositoryDomain _userRepositoryDomain;

        private readonly IMapper _mapper;

        public TaskService(ITaskRepositoryDomain taskRepositoryDomain, IMapper mapper, IUserRepositoryDomain userRepositoryDomain)
        {
            _taskRepositoryDomain = taskRepositoryDomain;
            _userRepositoryDomain = userRepositoryDomain;
            _mapper = mapper;
        }
        //

        public async Task<ModelTaskDto[]> AllTaskAsync()
        {
            ModelTaskDto[] modelTask;

            try
            {
                var result = await _taskRepositoryDomain.allTasksAsync();
                modelTask = _mapper.Map<ModelTaskDto[]>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (modelTask.Length > 0)
            {
                return modelTask;
            }

            throw new Exception("A lista de Tarefas está vazia.");
        }

        public async Task<ModelTaskDto> AllTaskIdAsync(int? id)
        {
            ModelTaskDto modelTask;

            try
            {
                var result = await _taskRepositoryDomain.TaskByIdAsync(id);
                modelTask = _mapper.Map<ModelTaskDto>(result);



            }
            catch (Exception ex)
            {
                throw ex;
            }

            return modelTask;
        }

        public async Task<Object> AddTaskAsync(ModelTaskDto modelTask)
        {

            try
            {
                if (await _userRepositoryDomain.SearchUserByIdAsync(modelTask.UserId) == null) throw new Exception("erro ao buscar referencia");
                if (await _taskRepositoryDomain.TaskByIdAsync(modelTask.Id) != null) throw new Exception("erro ao buscar referencia");

                var result = _mapper.Map<ModelTask>(modelTask);
                result.UpdateAt = DateTime.Now;
                result.CreatedAt = DateTime.Now;

                _taskRepositoryDomain.Adicionar(result);

                if (await _taskRepositoryDomain.SalvarMudancasAsync())
                {
                    return modelTask;
                }
                throw new Exception("Erro ao Criar a Tarefa");
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<ModelTaskDto> UpTaskAsync(ModelTaskDto modelTask)
        {

            try
            {
                var task = await _taskRepositoryDomain.TaskByIdAsync(modelTask.Id);
                if (task != null)
                {
                    var result = _mapper.Map<ModelTask>(modelTask);
                    result.UpdateAt = DateTime.Now;
                    result.CreatedAt = task.CreatedAt;

                    _taskRepositoryDomain.Atualizar(result);
                }

                if (await _taskRepositoryDomain.SalvarMudancasAsync())
                {
                    return modelTask;
                }

                throw new Exception("Erro ao atualizar");
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> DeleteTaskAsync(ModelTaskDto id)
        {
           
            try
            {
                var Task = _mapper.Map<ModelTask>(id);
                _taskRepositoryDomain.Deletar(Task);

                if (await _taskRepositoryDomain.SalvarMudancasAsync())
                {
                    return true;
                }

                throw new Exception("Erro ao atualizar");
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}

