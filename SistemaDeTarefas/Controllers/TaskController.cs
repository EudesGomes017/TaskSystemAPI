using Domain.Dto;
using Domain.Interface.ServicesRepository;
using Microsoft.AspNetCore.Mvc;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        /*    private readonly ITaskRepositoryService _taskRepositoryService;
            public TaskController(ITaskRepositoryService taskRepositoryService)
            {
                _taskRepositoryService = taskRepositoryService;
            }*/

        [HttpGet(Name = "Buscar todas as Tarefas")]
        public async Task<IActionResult> Get([FromServices] ITaskRepositoryService taskRepositoryService)
        {
            var tasks = await taskRepositoryService.AllTaskAsync();
            return this.StatusCode(StatusCodes.Status200OK, tasks);
        }

        [HttpGet("{id}", Name = "Buscar Tarefas pelo Id")]
        public async Task<IActionResult> Get([FromServices] ITaskRepositoryService taskRepositoryService, int id)
        {
            var tasks = await taskRepositoryService.AllTaskIdAsync(id);
            return this.StatusCode(StatusCodes.Status200OK, tasks);
        }

        [HttpPost(Name = "Adcionar Tarefa")]
        public async Task<IActionResult> Post([FromServices] ITaskRepositoryService taskRepositoryService, ModelTaskDto model)
        {
            var tasks = await taskRepositoryService.AddTaskAsync(model);
            return this.StatusCode(StatusCodes.Status201Created, tasks);
        }

        [HttpPut("{id}", Name = "Atulizar Tarefa")]
        public async Task<IActionResult> Put([FromServices] ITaskRepositoryService taskRepositoryService, ModelTaskDto modelTaskr)
        {
            ModelTaskDto tasks;
            var updatedUser = await taskRepositoryService.UpTaskAsync(modelTaskr);

            if (updatedUser != null && updatedUser.Id == modelTaskr.Id) // Verifique se o usuário foi atualizado e o ID corresponde
            {
                return this.StatusCode(StatusCodes.Status201Created, updatedUser);
            }
            else
            {
                throw new Exception("Erro ao Atualizar usuário");
            }
        }

        [HttpDelete("{id}", Name = "Deletar Tarefa pelo ID")]
        public async Task<IActionResult> Delete([FromServices] ITaskRepositoryService taskRepositoryService, int id)
        {
            var tasks = await taskRepositoryService.AllTaskIdAsync(id);
            await taskRepositoryService.DeleteTaskAsync(tasks);

            return this.StatusCode(StatusCodes.Status202Accepted, tasks);
        }
    }
}