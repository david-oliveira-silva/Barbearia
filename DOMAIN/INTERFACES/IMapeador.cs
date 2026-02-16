namespace DOMAIN.INTERFACES
{
    public interface IMapeador<T>
    {
        void Cadastrar(T item);
        void Atualizar(T item);
        void Excluir(T item);
        List<T> Listar();
    }
}
