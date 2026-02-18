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
            var resultado = _clienteValidador.Validate(cliente);
            if (!resultado.IsValid)
            {
                string mensagens = string.Join("; ", resultado.Errors.Select(e => e.ErrorMessage));
                throw new ArgumentException(mensagens);
            }
            _clienteProcesso.Cadastrar(cliente);
        }

        public void Atualizar(ClienteModel cliente)
        {
            _clienteValidador.AssineRegrasAtualizacao();
            var resultado = _clienteValidador.Validate(cliente);

            if (!resultado.IsValid)
            {
                string mensagens = string.Join("; ", resultado.Errors.Select(e => e.ErrorMessage));
                throw new ArgumentException(mensagens);
            }

            _clienteProcesso.Atualizar(cliente);
        }

        public void Excluir(ClienteModel cliente)
        {
            _clienteValidador.AssineRegrasExclusao();
            var resultado = _clienteValidador.Validate(cliente);

            if (!resultado.IsValid)
            {
                string mensagens = string.Join("; ", resultado.Errors.Select(e => e.ErrorMessage));
                throw new ArgumentException(mensagens);
            }
            _clienteProcesso.Excluir(cliente);
        }
        public List<ClienteModel> Listar()
        {
            return _clienteProcesso.Listar();
        }

        public ClienteModel? ClienteExiste(int idCliente)
        {
            return _clienteProcesso.ClienteExiste(idCliente);
        }
    }
}
