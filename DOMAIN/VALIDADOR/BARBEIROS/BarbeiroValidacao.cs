using DOMAIN.MODELS.BARBEIROS;
using FluentValidation;

namespace DOMAIN.VALIDADOR.BARBEIROS
{
    public class BarbeiroValidacao : ValidadorAbstratoCadastro<BarbeiroModel>
    {
        public override void AssineRegrasInclusao()
        {
            RuleFor(barbeiro => barbeiro.Nome)
                 .NotEmpty().WithMessage("Nome não pode ser vazio")
                 .Length(2, 100).WithMessage("O nome deve ter entre 2 e 100 caracteres.");

            RuleFor(barbeiro => barbeiro.Email)
                .EmailAddress().WithMessage("Email invalido");

            RuleFor(barbeiro => barbeiro.Telefone)
                .NotEmpty().WithMessage("O telefone não pode ser vazio")
                .Length(15).WithMessage("Digite um telefone válido (DDD + Número).");

            RuleFor(barbeiro => barbeiro.Salario)
                .GreaterThanOrEqualTo(0).WithMessage("Salario não pode ser negativo");
        }

        public override void AssineRegrasAtualizacao()
        {
            RuleFor(barbeiro => barbeiro.Nome)
                .NotEmpty().WithMessage("Nome não pode ser vazio")
                .Length(2, 100).WithMessage("O nome deve ter entre 2 e 100 caracteres.");

            RuleFor(barbeiro => barbeiro.Email)
                .EmailAddress().WithMessage("Email invalido");

            RuleFor(barbeiro => barbeiro.Telefone)
                .NotEmpty().WithMessage("O telefone não pode ser vazio")
               .Length(15).WithMessage("Digite um telefone válido (DDD + Número).");

            RuleFor(barbeiro => barbeiro.Salario)
                .GreaterThanOrEqualTo(0).WithMessage("Salario não pode ser negativo");
        }

        public override void AssineRegrasExclusao()
        {
            RuleFor(barbeiro => barbeiro.IdBarbeiro)
                .GreaterThan(0)
                .WithMessage("É necessário informar uma código válido para realizar a exclusão.");
        }   
    }
}
