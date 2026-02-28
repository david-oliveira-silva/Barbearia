using DOMAIN.INTERFACES;
using DOMAIN.MODELS.CLIENTES;

namespace REPOSITORY.MAPEADORES.Clientes
{
    public interface IClienteMapeador: IMapeador<ClienteModel>
    {
        List<ClienteModel>? BuscarClientePorNome(string nome);
    }
}
