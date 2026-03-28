using DOMAIN.Models.Agendamentos;
using DOMAIN.Models.Horarios;
using DOMAIN.MODELS.BARBEIROS;
using DOMAIN.MODELS.CLIENTES;
using DOMAIN.MODELS.SERVICOS;

namespace DOMAIN.Models.ViewModel
{
    public class ViewModelAgendamento
    {
        public AgendamentoModel? Agendamento { get; set; }
        public List<HorarioModel> Horarios { get; set; } = [];
        public List<ClienteModel> Clientes { get; set; } = [];
        public List<ServicoModel> Servicos { get; set; } = [];
        public List<BarbeiroModel> Barbeiros { get; set; } = [];
    }
}
