namespace crud_mtp.Models.ViewModels
{
    public class TarefaViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Concluido { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public string DataAtualizacaoStr => DataAtualizacao.ToString("dd/MM/yyyy");
    }
}
