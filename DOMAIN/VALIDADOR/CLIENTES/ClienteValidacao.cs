using DOMAIN.MODELS;
using FluentValidation;

namespace DOMAIN.VALIDADOR.CLIENTES
{
    public class ClienteValidacao : ValidadorAbstratoCadastro<ClienteModel>
    {

        public override void AssineRegrasInclusao()
        {
            RuleFor(cliente => cliente.Nome)
                .NotEmpty().WithMessage("Nome não pode ser vazio")
                .Length(2,100).WithMessage("O nome deve ter entre 2 e 100 caracteres.");

            RuleFor(cliente => cliente.Email)
                .EmailAddress().WithMessage("Email invalido");

            RuleFor(cliente => cliente.Telefone)
                .NotEmpty().WithMessage("O telefone não pode ser vazio");
        }
        public override void AssineRegrasAtualizacao()
        {
            RuleFor(cliente => cliente.Nome)
                .NotEmpty().WithMessage("Nome não pode ser vazio")
                .Length(2, 100).WithMessage("O nome deve ter entre 2 e 100 caracteres.");

            RuleFor(cliente => cliente.Email)
                .EmailAddress().WithMessage("Email invalido");

            RuleFor(cliente => cliente.Telefone)
                .NotEmpty().WithMessage("O telefone não pode ser vazio");
        }

        public override void AssineRegrasExclusao()
        {
            RuleFor(cliente => cliente.IdCliente)
                .GreaterThan(0)
                .WithMessage("É necessário informar uma matrícula válida para realizar a exclusão.");
        }  
    }
}
