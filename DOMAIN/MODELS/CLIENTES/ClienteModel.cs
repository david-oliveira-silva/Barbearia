using System.ComponentModel.DataAnnotations;

namespace DOMAIN.MODELS.CLIENTES
{
    public class ClienteModel: Pessoa
    {
        [Key]
        public int IdCliente { get; set; }

        public ClienteModel()
        {

        }
        public ClienteModel(string? nome, string? cpf, string? email, string? telefone):base(nome,cpf,email,telefone)
        {

        }
    }
}
