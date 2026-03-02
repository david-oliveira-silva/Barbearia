using System.Text.RegularExpressions;
using DOMAIN.MODELS.BARBEIROS;
using REPOSITORY.MAPEADORES.BARBEIROS;

namespace SERVICE.PROCESSO.BARBEIRO
{
    public class BarbeiroProcesso(IBarbeiroMapeador barbeiroMapeador)
    {
        private readonly IBarbeiroMapeador _barbeiroMapeador = barbeiroMapeador;

        public void Cadastrar(BarbeiroModel barbeiro)
        {
            barbeiro.Nome = barbeiro.Nome?.ToUpper().Trim();
            barbeiro.Telefone = Regex.Replace(barbeiro.Telefone ?? "", @"\D", "");
            barbeiro.Email = barbeiro.Email?.ToUpper().Trim();
            barbeiro.Cpf = barbeiro.Cpf?.Replace(".", "").Replace("-", "");
            _barbeiroMapeador.Cadastrar(barbeiro);
        }

        public void Atualizar(BarbeiroModel barbeiro)
        {
            if (barbeiro == null)
            {
                throw new ArgumentNullException(nameof(barbeiro), "Barbeiro não pode ser nulo para atualização.");
            }

            barbeiro.Nome = barbeiro.Nome?.ToUpper().Trim();
            barbeiro.Telefone = Regex.Replace(barbeiro.Telefone ?? "", @"\D", "");
            barbeiro.Email = barbeiro.Email?.ToUpper().Trim();
            barbeiro.Cpf = barbeiro.Cpf?.Replace(".", "").Replace("-", "");
            barbeiro.Salario = 0;
            _barbeiroMapeador.Atualizar(barbeiro);

        }

        public void Excluir(BarbeiroModel barbeiro)
        {
            ArgumentNullException.ThrowIfNull(barbeiro);
            _barbeiroMapeador.Excluir(barbeiro);
        }

        public List<BarbeiroModel> Listar()
        {
            List<BarbeiroModel> barbeiro = _barbeiroMapeador.Listar();
            return [.. barbeiro.OrderBy(b => b.IdBarbeiro)];
        }

        public List<BarbeiroModel>? BuscarClientePorNome(string nome)
        {
            nome = nome.ToUpper().Trim();
            List<BarbeiroModel>? cliente = _barbeiroMapeador.BuscarBarbeiroPorNome(nome);
            return cliente;
        }

        public BarbeiroModel? ClienteExiste(int idBarbeiro)
        {
            BarbeiroModel? cliente = _barbeiroMapeador.Listar().FirstOrDefault(c => c.IdBarbeiro == idBarbeiro);
            return cliente;
        }
    }
}
