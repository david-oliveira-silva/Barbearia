using DOMAIN.INTERFACES;
using DOMAIN.MODELS.BARBEIROS;

namespace REPOSITORY.MAPEADORES.BARBEIROS
{
    public interface IBarbeiroMapeador:IMapeador<BarbeiroModel>
    {
        List<BarbeiroModel> BuscarBarbeiroPorNome(string nome);
    }
}
