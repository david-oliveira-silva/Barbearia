using System.ComponentModel.DataAnnotations;

namespace DOMAIN.MODELS.SERVICOS
{
    public class ServicoModel
    {
        [Key]
        public int IdServico { get; set; }
        public string? Nome { get; set; }
        public decimal Valor { get; set; }
        public int TempoMedio { get; set; }

        public ServicoModel()
        {

        }
        public ServicoModel(string? nome, decimal valor, int tempoMedio)
        {
            Nome = nome;
            Valor = valor;
            TempoMedio = tempoMedio;
        }
    }
}
