using DOMAIN.Enuns.Horario;
using DOMAIN.Models.Agendamentos;
using REPOSITORY.Mapeadores.Agendamentos;

namespace SERVICE.Processo.Agendamentos
{
    public class AgendamentoProcesso(IAgendamentoMapeador agendamentoMapeador)
    {
        private readonly IAgendamentoMapeador _agendamentoMapeador = agendamentoMapeador;
        public void Cadastrar(AgendamentoModel agendamento)
        {         
            _agendamentoMapeador.Cadastrar(agendamento);
        }
        public void Atualizar(AgendamentoModel agendamento)
        {
            _agendamentoMapeador.Atualizar(agendamento);
        }
        public void Excluir(AgendamentoModel agendamento)
        {
            _agendamentoMapeador.Excluir(agendamento);
        }
        public List<AgendamentoModel> Listar()
        {
            List<AgendamentoModel> agendamento = [.. _agendamentoMapeador.Listar().OrderBy(a => a.IdAgendamento)];
            return agendamento;
        }

        public AgendamentoModel? AgendamentoExiste(int idAgendamento)
        {
            AgendamentoModel? agendamento = _agendamentoMapeador.Listar().FirstOrDefault(a => a.IdAgendamento == idAgendamento);
            return agendamento;
        }

        public List<AgendamentoModel> HorariosOculpados(int idBarbeiro, DateOnly dia)
        {
            List<AgendamentoModel> horarios = [.._agendamentoMapeador.Listar().Where(a => a.Horarios?.Barbeiros?.IdBarbeiro == idBarbeiro && a.DataAgendamento == dia)];
            return horarios;
        }

    }
}
