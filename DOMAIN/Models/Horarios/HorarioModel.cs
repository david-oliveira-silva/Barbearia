using DOMAIN.Enuns.Horario;
using DOMAIN.MODELS.BARBEIROS;

namespace DOMAIN.Models.Horarios
{
    public class HorarioModel
    {
        public int IdHorario { get; set; }
        public int IdBarbeiro { get; set; }
        public DiaSemana DiaSemana { get; set; }
        public TimeSpan HorarioInicio { get; set; }
        public TimeSpan HorarioFim { get; set; }
        public Ativo Ativo { get; set; }
        public BarbeiroModel? Barbeiros { get; set; }

        public HorarioModel()
        {
            Ativo = Ativo.ATIVO;
        }

        public HorarioModel(int IdBarbeiro, DiaSemana DiaSemana, TimeSpan HorarioInicio, TimeSpan HorarioFim, Ativo Ativo)
        {
            this.IdBarbeiro = IdBarbeiro;
            this.DiaSemana = DiaSemana;
            this.HorarioInicio = HorarioInicio;
            this.HorarioFim = HorarioFim;
            this.Ativo = Ativo;
        }
    }
}
