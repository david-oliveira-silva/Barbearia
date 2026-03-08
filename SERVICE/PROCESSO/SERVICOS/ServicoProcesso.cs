using DOMAIN.MODELS.SERVICOS;
using REPOSITORY.MAPEADORES.SERVICOS;

namespace SERVICE.PROCESSO.SERVICOS
{
    public class ServicoProcesso(IServicoMapeador servicoMapeador)
    {
        private readonly IServicoMapeador _servicoMapeador = servicoMapeador;

        public void Cadastrar(ServicoModel servico)
        {
            servico.Nome = servico.Nome?.ToUpper().Trim();
            _servicoMapeador.Cadastrar(servico);
        }

        public void Atualizar(ServicoModel servico)
        {
            servico.Nome = servico.Nome?.ToUpper().Trim();
            _servicoMapeador.Atualizar(servico);
        }

        public void Excluir(ServicoModel servico)
        {
            ArgumentNullException.ThrowIfNull(servico);
            _servicoMapeador.Excluir(servico);
        }

        public List<ServicoModel> Listar()
        {
            List<ServicoModel> servicos = [.._servicoMapeador.Listar().OrderBy(s => s.IdServico)];
            return servicos;
        }

        public List<ServicoModel> BuscarServicoPorNome(string nome)
        {
            nome = nome.ToUpper().Trim();
            List<ServicoModel> servicos = _servicoMapeador.BuscarServicoPorNome(nome);
            return servicos;
        }

        public ServicoModel? ServicoExiste(int idServico)
        {
            ServicoModel? servico = _servicoMapeador.Listar().FirstOrDefault(s => s.IdServico == idServico);
            return servico;
        }
    }
}
