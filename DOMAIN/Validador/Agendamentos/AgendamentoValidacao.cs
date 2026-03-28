using DOMAIN.Models.Agendamentos;
using DOMAIN.VALIDADOR;
using FluentValidation;

namespace DOMAIN.Validador.Agendamentos
{
    public class AgendamentoValidacao : ValidadorAbstratoCadastro<AgendamentoModel>
    {
        public override void AssineRegrasInclusao()
        {
            RuleFor(agendamento => agendamento.IdCliente)
                .GreaterThan(0).WithMessage("É necessário informar um cliente válido para realizar o agendamento.");

            RuleFor(agendamento => agendamento.IdBarbeiro)
                .GreaterThan(0).WithMessage("É necessário informar um barbeiro válido para realizar o agendamento.");

            RuleFor(agendamento => agendamento.IdServico)
                .GreaterThan(0).WithMessage("É necessário informar um serviço válido para realizar o agendamento.");

            RuleFor(agendamento => agendamento.IdHorario)
                .GreaterThan(0).WithMessage("É necessário informar um horário válido para realizar o agendamento.");

        }
        public override void AssineRegrasAtualizacao()
        {
            RuleFor(agendamento => agendamento.IdCliente)
                .GreaterThan(0).WithMessage("É necessário informar um cliente válido para realizar o agendamento.");

            RuleFor(agendamento => agendamento.IdBarbeiro)
                .GreaterThan(0).WithMessage("É necessário informar um barbeiro válido para realizar o agendamento.");

            RuleFor(agendamento => agendamento.IdServico)
                .GreaterThan(0).WithMessage("É necessário informar um serviço válido para realizar o agendamento.");

            RuleFor(agendamento => agendamento.IdHorario)
                .GreaterThan(0).WithMessage("É necessário informar um horário válido para realizar o agendamento.");
        }
        public override void AssineRegrasExclusao()
        {
            RuleFor(agendamento => agendamento.IdAgendamento)
                .GreaterThan(0)
                .WithMessage("É necessário informar um código válido para realizar a exclusão.");
        }

        
    }
}
