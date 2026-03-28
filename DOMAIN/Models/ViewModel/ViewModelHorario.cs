using DOMAIN.Models.Horarios;
using DOMAIN.MODELS.BARBEIROS;

namespace DOMAIN.Models.ViewModelHorario
{
    public class ViewModelHorario
    {
        public HorarioModel? Horario { get; set; }
        public List<BarbeiroModel> Barbeiros { get; set; } = [];
    }
}
