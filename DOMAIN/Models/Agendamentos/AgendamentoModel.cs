using DOMAIN.Models.Horarios;
using DOMAIN.MODELS.BARBEIROS;
using DOMAIN.MODELS.CLIENTES;
using DOMAIN.MODELS.SERVICOS;

namespace DOMAIN.Models.Agendamentos
{
    public class AgendamentoModel
    {
        public int IdAgendamento { get; set ; }
        public int IdBarbeiro { get; set; }
        public int IdCliente { get; set; }
        public int IdServico { get; set; }
        public int IdHorario { get; set; }  
        public DateOnly DataAgendamento { get; set; }
        public bool AgendamentoRealizado { get; set; }
        public BarbeiroModel? Barbeiros { get; set; }
        public ClienteModel? Clientes { get; set; }
        public ServicoModel? Servicos { get; set; }
        public HorarioModel? Horarios { get; set; }

        public AgendamentoModel()
        {
            AgendamentoRealizado = false;
            DataAgendamento = DateOnly.FromDateTime(DateTime.Today);
        }

        public AgendamentoModel(int IdBarbeiro, int IdCliente, int IdServico, int IdHorario, DateOnly DataAgendamento)
        {
            this.IdBarbeiro = IdBarbeiro;
            this.IdCliente = IdCliente;
            this.IdServico = IdServico;
            this.IdHorario = IdHorario;
            this.DataAgendamento = DataAgendamento;
            this.AgendamentoRealizado = false;
        }   
    }
}
