
using Microsoft.EntityFrameworkCore;
using Repository.ServicesRepository;

namespace Repository
{
    public class TaskRepository : ITaskRepositoryService
    {
        private readonly TaskDbContex _taskDbContex;

        public TaskRepository(TaskDbContex taskDbContex)
        {
            _taskDbContex = taskDbContex;
        }

        public async Task<List<ModelTask>> AllTask()
        {
            return await _taskDbContex.ModelTask
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<ModelTask> AllTaskId(int id)
        {
           
            return await _taskDbContex.ModelTask
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ModelTask> AddTask(ModelTask modelTask)
        {
            await _taskDbContex.ModelTask.AddAsync(modelTask);
            await _taskDbContex.SaveChangesAsync();

            return modelTask;
        }
        public async Task<ModelTask> UpTask(ModelTask modelTask, int id)
        {

            ModelTask taskId = await AllTaskId(id);

            if (taskId == null)
            {
                throw new Exception($"Tarefa para id: {id} nao foi encontrado no banco de dados");
            }

            taskId.Name = modelTask.Name;
            taskId.Description = modelTask.Description;
            taskId.Status = modelTask.Status;
            taskId.UserId = modelTask.UserId;

            _taskDbContex.ModelTask.Update(taskId);
            await _taskDbContex.SaveChangesAsync();

            return taskId;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            ModelTask TaskId = await AllTaskId(id);

            if (TaskId == null)
            {
                throw new Exception($"Tarefa para id: {id} nao foi encontrado no banco de dados");
            }

            _taskDbContex.ModelTask.Remove(TaskId);
            await _taskDbContex.SaveChangesAsync();

            return true;
        }


    }
}
