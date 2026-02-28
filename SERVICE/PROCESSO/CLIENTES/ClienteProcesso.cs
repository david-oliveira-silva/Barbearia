using DOMAIN.MODELS.CLIENTES;
using REPOSITORY.MAPEADORES.Clientes;
using System.Text.RegularExpressions;

namespace SERVICE.PROCESSO.CLIENTES
{
    public class ClienteProcesso(IClienteMapeador clienteMapeador)
    {

        private readonly IClienteMapeador _clienteMapeador = clienteMapeador;

        public void Cadastrar(ClienteModel cliente)
        {
            cliente.Nome = cliente.Nome?.ToUpper().Trim();
            cliente.Telefone = Regex.Replace(cliente.Telefone ?? "", @"\D", "");
            cliente.Email = cliente.Email?.ToUpper().Trim();
            cliente.Cpf = cliente.Cpf?.Replace(".", "").Replace("-", "");
            _clienteMapeador.Cadastrar(cliente);
        }

        public void Atualizar(ClienteModel cliente, Exception argumentNullException)
        {
            if (cliente is not null)
            {
                cliente.Nome = cliente.Nome?.ToUpper().Trim();
                cliente.Telefone = Regex.Replace(cliente.Telefone ?? "", @"\D", "");
                cliente.Email = cliente.Email?.ToUpper().Trim();
                cliente.Cpf = cliente.Cpf?.Replace(".", "").Replace("-", "");
                _clienteMapeador.Atualizar(cliente);
            }
            else
            {
                throw argumentNullException;
            }
        }

        public void Excluir(ClienteModel cliente)
        {
            ArgumentNullException.ThrowIfNull(cliente);
            _clienteMapeador.Excluir(cliente);
        }

        public List<ClienteModel> Listar()
        {
            List<ClienteModel> clientes = _clienteMapeador.Listar();
            return [.. clientes.OrderBy(c => c.IdCliente)];
        }

        public List<ClienteModel>? BuscarClientePorNome(string nome)
        {
            nome = nome.ToUpper().Trim();
            List<ClienteModel>? cliente = _clienteMapeador.BuscarClientePorNome(nome);
            return cliente;
        }

        public ClienteModel? ClienteExiste(int idCliente)
        {
            ClienteModel? cliente = _clienteMapeador.Listar().FirstOrDefault(c => c.IdCliente == idCliente);
            return cliente;
        }
    }
}
