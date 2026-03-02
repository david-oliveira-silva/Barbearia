using System.ComponentModel.DataAnnotations;

namespace DOMAIN.MODELS.BARBEIROS
{
    public class BarbeiroModel:Pessoa
    {
        [Key]
        public int IdBarbeiro { get; set; }
        public decimal Salario { get; set; }

        public BarbeiroModel()
        {

        }
        public BarbeiroModel(string? nome, string? cpf, string? email, string? telefone, decimal Salario) : base(nome, cpf, email, telefone)
        {
            this.Salario = Salario;
        }
    }
}
