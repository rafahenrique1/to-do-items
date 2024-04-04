namespace crud_mtp.Models.Services
{
    public interface ITarefaService
    {
        Task<IEnumerable<Tarefa>> GetAllTarefasAsync();
        Task InsertTarefaAsync(Tarefa entidade);
        Task UpdateTarefaAsync(Tarefa entidade);
        Task DeleteTarefaAsync(Guid id);
    }
}
