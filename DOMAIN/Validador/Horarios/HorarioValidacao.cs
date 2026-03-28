using DOMAIN.Models.Horarios;
using DOMAIN.VALIDADOR;
using FluentValidation;

namespace DOMAIN.Validador.Horarios
{
    public class HorarioValidacao : ValidadorAbstratoCadastro<HorarioModel>
    {
        public override void AssineRegrasInclusao()
        {
            RuleFor(horario => horario.HorarioInicio)
                .NotEmpty().WithMessage("O horário de início é obrigatório.")
                .LessThan(horario => horario.HorarioFim)
                .WithMessage("O horário de início deve ser menor que o horário de término.");

            RuleFor(horario => horario.HorarioFim)
                .NotEmpty().WithMessage("O horário de término é obrigatório.");

            RuleFor(horario => horario.IdBarbeiro)
                .GreaterThan(0)
                .WithMessage("Não foi possível encontrar o barbeiro");
        }
        public override void AssineRegrasAtualizacao()
        {
            RuleFor(horario => horario.HorarioInicio)
               .NotEmpty().WithMessage("O horário de início é obrigatório.")
               .LessThan(horario => horario.HorarioFim)
               .WithMessage("O horário de início deve ser menor que o horário de término.");

            RuleFor(horario => horario.HorarioFim)
                .NotEmpty().WithMessage("O horário de término é obrigatório.");
        }

        public override void AssineRegrasExclusao()
        {
            RuleFor(horario => horario.IdHorario)
               .GreaterThan(0)
               .WithMessage("É necessário informar uma código válido para realizar a exclusão.");
        }
    }
}
