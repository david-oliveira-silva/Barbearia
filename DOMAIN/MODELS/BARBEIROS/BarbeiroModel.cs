using System.ComponentModel.DataAnnotations;

namespace DOMAIN.MODELS.BARBEIROS
{
    public class BarbeiroModel:Pessoa
    {
        [Key]
        public int IdBarbeiro { get; set; }

        public BarbeiroModel(string? nome, string? cpf, string? email, string? telefone) : base(nome, cpf, email, telefone)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Telefone = telefone;
        }
    }
}
