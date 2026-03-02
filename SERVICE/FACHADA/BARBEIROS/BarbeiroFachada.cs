using DOMAIN.MODELS.BARBEIROS;
using DOMAIN.VALIDADOR.BARBEIROS;
using DOMAIN.VALIDADOR.CLIENTES;
using REPOSITORY.MAPEADORES.BARBEIROS;
using SERVICE.PROCESSO.BARBEIRO;


namespace SERVICE.FACHADA.BARBEIROS
{
    public class BarbeiroFachada(IBarbeiroMapeador mapeador)
    {
        protected BarbeiroValidacao _barbeiroValidacao = new();
        protected BarbeiroProcesso _barbeiroProcesso = new(mapeador);
        public void Cadastrar(BarbeiroModel barbeiro)
        {
            _barbeiroValidacao.AssineRegrasInclusao();
            var resultado = _barbeiroValidacao.Validate(barbeiro);

            if (!resultado.IsValid)
            {
                string mensagens = string.Join(";", resultado.Errors.Select(e => e.ErrorMessage));
                throw new ArgumentException(mensagens);
            }

            _barbeiroProcesso.Cadastrar(barbeiro);
        }

        public void Atualizar(BarbeiroModel barbeiro)
        {
            _barbeiroValidacao.AssineRegrasAtualizacao();
            var resultado = _barbeiroValidacao.Validate(barbeiro);

            if (!resultado.IsValid)
            {
                string mensagens = string.Join(";", resultado.Errors.Select(e => e.ErrorMessage));
                throw new ArgumentException(mensagens);
            }
            _barbeiroProcesso.Atualizar(barbeiro);
        }

        public void Excluir(BarbeiroModel barbeiro)
        {
            _barbeiroValidacao.AssineRegrasExclusao();
            var resultado = _barbeiroValidacao.Validate(barbeiro);

            if (!resultado.IsValid)
            {
                var mensagem = string.Join(";", resultado.Errors.Select(e => e.ErrorMessage));
                throw new ArgumentException(mensagem);
            }
            _barbeiroProcesso.Excluir(barbeiro);
        }
        
        public List<BarbeiroModel> Listar()
        {
            return _barbeiroProcesso.Listar();
        }
        public List<BarbeiroModel>? BuscarClientePorNome(string nome)
        {
            return _barbeiroProcesso.BuscarClientePorNome(nome);
        }

        public BarbeiroModel? ClienteExiste(int idBarbeiro)
        {
            return _barbeiroProcesso.ClienteExiste(idBarbeiro);
        }
    }
}
