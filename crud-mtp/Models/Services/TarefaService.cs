using crud_mtp.Models.Repositories;

namespace crud_mtp.Models.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<IEnumerable<Tarefa>> GetAllTarefasAsync()
        {
            return await _tarefaRepository.GetAllTarefasAsync();
        }

        public async Task InsertTarefaAsync(Tarefa entidade)
        {
            await _tarefaRepository.InsertTarefaAsync(entidade);
        }
        
        public async Task UpdateTarefaAsync(Tarefa entidade)
        {
            await _tarefaRepository.UpdateTarefaAsync(entidade);
        }
        
        public async Task DeleteTarefaAsync(Guid id)
        {
            await _tarefaRepository.DeleteTarefaAsync(id);
        }
    }
}
