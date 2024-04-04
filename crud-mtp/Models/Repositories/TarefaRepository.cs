using crud_mtp.Infrastructure.SqlScripts.Tarefa;
using Dapper;
using System.Data.SqlClient;
using static Dapper.SqlMapper;

namespace crud_mtp.Models.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly string _connectionString;

        public TarefaRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("Local");
        }

        public async Task<IEnumerable<Tarefa>> GetAllTarefasAsync()
        {
            string sqlQuery = await File.ReadAllTextAsync(Path.Combine("Infrastructure", "SqlScripts", "Tarefa", TarefaConstants.GetAllTarefas));

            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            var result = await connection.QueryAsync<Tarefa>(sqlQuery);
            return result.ToList();
        }

        public async Task InsertTarefaAsync(Tarefa entidade)
        {
            string sqlQuery = await File.ReadAllTextAsync(Path.Combine("Infrastructure", "SqlScripts", "Tarefa", TarefaConstants.InsertTarefa));

            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            await connection.ExecuteAsync(sqlQuery, entidade);
        }

        public async Task UpdateTarefaAsync(Tarefa entidade)
        {
            string sqlQuery = await File.ReadAllTextAsync(Path.Combine("Infrastructure", "SqlScripts", "Tarefa", TarefaConstants.UpdateTarefa));

            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            await connection.ExecuteAsync(sqlQuery, entidade);
        }

        public async Task DeleteTarefaAsync(Guid id)
        {
            string sqlQuery = await File.ReadAllTextAsync(Path.Combine("Infrastructure", "SqlScripts", "Tarefa", TarefaConstants.DeleteTarefa));

            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            await connection.ExecuteAsync(sqlQuery, new { Id = id});
        }

    }
}
