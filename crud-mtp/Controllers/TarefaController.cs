using crud_mtp.Models;
using crud_mtp.Models.Services;
using crud_mtp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ServiceStack;

namespace crud_mtp.Controllers
{
    public class TarefaController : Controller
    {
        private readonly ILogger<TarefaController> _logger;
        private readonly ITarefaService _tarefaService;

        public TarefaController(ILogger<TarefaController> logger, ITarefaService tarefaService)
        {
            _logger = logger;
            _tarefaService = tarefaService;
        }

        public IActionResult Index() => View();

        [HttpGet]
        public async Task<IActionResult> GetAllTarefas()
        {
            try
            {
                var tarefas = await _tarefaService.GetAllTarefasAsync();
                var tarefasOrdenadas = tarefas.OrderBy(tarefa => tarefa.Concluido);

                return Ok(tarefasOrdenadas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Houve um erro ao realizar a consulta de tarefas.");
                return BadRequest();
            }
        }


        [HttpPost]
        public async Task<IActionResult> InsertTarefa(TarefaViewModel viewModel)
        {
            try
            {
                var entidade = new Tarefa();
                entidade.PopulateWith(viewModel);

                await _tarefaService.InsertTarefaAsync(entidade);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Houve um erro ao salvar a tarefa.");
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTarefa(TarefaViewModel viewModel)
        {
            try
            {
                var entidade = new Tarefa();
                entidade.PopulateWith(viewModel);

                await _tarefaService.UpdateTarefaAsync(entidade);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Houve um erro ao atualizar a tarefa.");
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTarefa(Guid id)
        {
            try
            {
                await _tarefaService.DeleteTarefaAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Houve um erro ao excluir a tarefa.");
                return BadRequest();
            }
        }
    }
}
