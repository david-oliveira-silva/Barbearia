using FluentValidation;

namespace DOMAIN.VALIDADOR
{
    public abstract class ValidadorAbstratoCadastro<T> : AbstractValidator<T> where T : class
    {
        protected ValidadorAbstratoCadastro() { }
        public abstract void AssineRegrasInclusao();
        public abstract void AssineRegrasAtualizacao();
        public abstract void AssineRegrasExclusao();
    }
}
