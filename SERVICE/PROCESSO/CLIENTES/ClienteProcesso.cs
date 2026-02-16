using DOMAIN.MODELS;
using REPOSITORY.MAPEADORES.Clientes;

namespace SERVICE.PROCESSO.CLIENTES
{
    public class ClienteProcesso(IClienteMapeador clienteMapeador)
    {

        private readonly IClienteMapeador _clienteMapeador = clienteMapeador;

        public void Cadastrar(ClienteModel cliente)
        {
            cliente.Nome = cliente.Nome?.Trim();
            cliente.Telefone = cliente.Telefone?.Trim();
            cliente.Email = cliente.Email?.Trim();
            _clienteMapeador.Cadastrar(cliente);
        }

        public void Atualizar(ClienteModel cliente)
        {
            if (cliente is not null)
            {
                cliente.Nome = cliente.Nome?.Trim();
                cliente.Telefone = cliente.Telefone?.Trim();
                cliente.Email = cliente.Email?.Trim();
                _clienteMapeador.Atualizar(cliente);
            }
            throw new ArgumentNullException("Cliente não encontrado");
        }

        public void Excluir(ClienteModel cliente)
        {
            if (cliente is  null)
            {
                throw new ArgumentNullException("Cliente não encontrado");
            }
            _clienteMapeador.Excluir(cliente);
        }

        public List<ClienteModel> Listar()
        {
            List<ClienteModel> clientes = _clienteMapeador.Listar();
            return [..clientes.OrderBy(c => c.IdCliente)];
        }
    }
}
