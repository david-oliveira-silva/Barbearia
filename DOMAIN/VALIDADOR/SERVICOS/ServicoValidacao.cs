using DOMAIN.MODELS.SERVICOS;
using FluentValidation;

namespace DOMAIN.VALIDADOR.SERVICOS
{
    public class ServicoValidacao : ValidadorAbstratoCadastro<ServicoModel>
    {

        public override void AssineRegrasInclusao()
        {
            RuleFor(servico => servico.Nome)
                .NotEmpty()
                .WithMessage("Nome não pode ser vazio");

            RuleFor(servico => servico.Valor)
                .GreaterThanOrEqualTo(0)
                .WithMessage("O valor não pode ser negativo");

            RuleFor(servico => servico.TempoMedio)
                .GreaterThan(0)
                .WithMessage("O tempo médio tem que ser maior que 0");
        }
        public override void AssineRegrasAtualizacao()
        {
            RuleFor(servico => servico.Nome)
                 .NotEmpty()
                 .WithMessage("Nome não pode ser vazio");

            RuleFor(servico => servico.Valor)
                .GreaterThanOrEqualTo(0)
                .WithMessage("O valor não pode ser negativo");

            RuleFor(servico => servico.TempoMedio)
                .GreaterThan(0)
                .WithMessage("O tempo médio tem que ser maior que 0");
        }

        public override void AssineRegrasExclusao()
        {
            RuleFor(servico => servico.IdServico)
                .GreaterThan(0)
                .WithMessage("É necessário informar um código válido para realizar a exclusão.");
        }      
    }
}
