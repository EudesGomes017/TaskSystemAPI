

using Domain.Interface.Repository;

namespace Data.Repository
{
    public class GeralRepositoryData : IGeralRepositoryDomain
    {

        private readonly TaskDbContex _taskDbContex;

        public GeralRepositoryData(TaskDbContex taskDbContex)
        {
            _taskDbContex = taskDbContex;
        }

        public async void Adicionar<T>(T entity) where T : class
        {
            await _taskDbContex.AddAsync(entity);
        }

        public void Atualizar<T>(T entity) where T : class
        {
            _taskDbContex.Update(entity);
        }

        public void Deletar<T>(T entity) where T : class
        {
            _taskDbContex.Remove(entity);
        }

        public void DeletarVarias<T>(T[] entityArray) where T : class
        {
            _taskDbContex.RemoveRange(entityArray);
        }

        public async Task<bool> SalvarMudancasAsync()
        {
            return (await _taskDbContex.SaveChangesAsync()) > 0;
        }
    }
}

