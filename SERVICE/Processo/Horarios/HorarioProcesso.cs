using DOMAIN.Models.Horarios;
using REPOSITORY.Mapeadores.Horarios;

namespace SERVICE.Processo.Horarios
{
    public class HorarioProcesso(IHorarioMapeador horarioMapeador)
    {
        private readonly IHorarioMapeador _horarioMapeador = horarioMapeador;

        public void Cadastrar(HorarioModel horario)
        {
            _horarioMapeador.Cadastrar(horario);
        }

        public void Atualizar(HorarioModel horario)
        {
            _horarioMapeador.Atualizar(horario);
        }

        public void Excluir(HorarioModel horario)
        {
            _horarioMapeador.Excluir(horario);
        }

        public List<HorarioModel> Listar()
        {
            List<HorarioModel> horarios = _horarioMapeador.Listar();
            return [..horarios.OrderBy(h => h.IdHorario)];
        }

        public HorarioModel? HorarioExiste(int idHorario)
        {
            HorarioModel? horario = _horarioMapeador.Listar().FirstOrDefault(h => h.IdHorario == idHorario);
            return horario;
        }
    }
}
