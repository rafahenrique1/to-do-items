namespace crud_mtp.Models.Repositories
{
    public interface ITarefaRepository
    {
        Task<IEnumerable<Tarefa>> GetAllTarefasAsync();
        Task InsertTarefaAsync(Tarefa entidade);
        Task UpdateTarefaAsync(Tarefa entidade);
        Task DeleteTarefaAsync(Guid id);
    }
}
