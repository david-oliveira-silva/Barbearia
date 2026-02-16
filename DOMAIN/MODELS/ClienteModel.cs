namespace DOMAIN.MODELS
{
    public class ClienteModel
    {
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }

        public ClienteModel() { }

        public ClienteModel(string? nome, string? cpf, string? email, string? telefone)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Telefone = telefone;
        }
    }
}
