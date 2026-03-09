using DOMAIN.MODELS.SERVICOS;
using DOMAIN.VALIDADOR.SERVICOS;
using REPOSITORY.MAPEADORES.SERVICOS;
using SERVICE.PROCESSO.SERVICOS;

namespace SERVICE.FACHADA.SERVICOS
{
    public class ServicosFachada(IServicoMapeador mapeador)
    {
        protected ServicoValidacao _servicoValidador = new();
        protected ServicoProcesso _servicoProcesso = new(mapeador);

        public void Cadastrar(ServicoModel servico)
        {
            _servicoValidador.AssineRegrasInclusao();
            var resultado = _servicoValidador.Validate(servico);

            if (!resultado.IsValid)
            {
                string mensagens = string.Join(";", resultado.Errors.Select(e => e.ErrorMessage));
                throw new ArgumentException(mensagens);
            }

            _servicoProcesso.Cadastrar(servico);
        }

        public void Atualizar(ServicoModel servico)
        {
            _servicoValidador.AssineRegrasAtualizacao();

            var resultado = _servicoValidador.Validate(servico);

            if (!resultado.IsValid)
            {
                string mensagens = string.Join("", resultado.Errors.Select(e => e.ErrorMessage));
                throw new ArgumentException(mensagens);
            }

            _servicoProcesso.Atualizar(servico);
        }

        public void Excluir(ServicoModel servico)
        {
            _servicoValidador.AssineRegrasExclusao();

            var resultado = _servicoValidador.Validate(servico);

            if (!resultado.IsValid)
            {
                string mensagens = string.Join("", resultado.Errors.Select(e => e.ErrorMessage));
                throw new ArgumentException(mensagens);
            }

            _servicoProcesso.Excluir(servico);
        }

        public List<ServicoModel> Listar()
        {
            return _servicoProcesso.Listar();
        }

        public List<ServicoModel> BuscarServicoPorNome(string nome)
        {
            return _servicoProcesso.BuscarServicoPorNome(nome);
        }

        public ServicoModel? ServicoExiste(int idServico)
        {
            return _servicoProcesso.ServicoExiste(idServico);
        }
    }
}
