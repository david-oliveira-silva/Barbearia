using System.ComponentModel.DataAnnotations;

namespace DOMAIN.MODELS
{
    public class Pessoa
    {
        [Required]
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }

        public Pessoa()
        {

        }
        public Pessoa(string? Nome, string? Cpf, string? Email, string? Telefone)
        {
            this.Nome = Nome;
            this.Cpf = Cpf;
            this.Email = Email;
            this.Telefone = Telefone;
        }
    }
}
