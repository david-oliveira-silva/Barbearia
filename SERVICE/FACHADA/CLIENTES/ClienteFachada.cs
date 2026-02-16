using DOMAIN.MODELS;
using DOMAIN.VALIDADOR.CLIENTES;
using REPOSITORY.MAPEADORES.Clientes;
using SERVICE.PROCESSO.CLIENTES;

namespace SERVICE.FACHADA.CLIENTES
{
    public class ClienteFachada(IClienteMapeador mapeador)
    {
        protected ClienteValidacao _clienteValidador = new();
        protected ClienteProcesso _clienteProcesso = new(mapeador);

        public void Cadastrar(ClienteModel cliente)
        {
            _clienteValidador.AssineRegrasInclusao();
            _clienteProcesso.Cadastrar(cliente);
        }

        public void Atualizar(ClienteModel cliente)
        {
            _clienteValidador.AssineRegrasAtualizacao();
            _clienteProcesso.Atualizar(cliente);
        }

        public void Excluir(ClienteModel cliente)
        {
            _clienteValidador.AssineRegrasExclusao();
            _clienteProcesso.Excluir(cliente);
        }
        public List<ClienteModel> Listar()
        {
            return _clienteProcesso.Listar();
        }
    }
}
