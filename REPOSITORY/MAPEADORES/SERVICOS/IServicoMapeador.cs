using DOMAIN.INTERFACES;
using DOMAIN.MODELS.SERVICOS;

namespace REPOSITORY.MAPEADORES.SERVICOS
{
    public interface IServicoMapeador:IMapeador<ServicoModel>
    {
        List<ServicoModel> BuscarServicoPorNome(string nome);
    }
}
