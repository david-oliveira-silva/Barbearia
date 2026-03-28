using DOMAIN.Enuns.Horario;
using DOMAIN.Models.Horarios;
using DOMAIN.Validador.Horarios;
using REPOSITORY.Mapeadores.Horarios;
using SERVICE.Processo.Horarios;

namespace SERVICE.Fachada.Horarios
{
    public class HorarioFachada(IHorarioMapeador mapeador)
    {
        protected HorarioValidacao _horarioValidador = new();
        protected HorarioProcesso _horarioProcesso = new(mapeador);

        public void Cadastrar(HorarioModel horario)
        {
            _horarioValidador.AssineRegrasInclusao();

            var resultado = _horarioValidador.Validate(horario);

            if (!resultado.IsValid)
            {
                var mensagem = string.Join(";", resultado.Errors.Select(e => e.ErrorMessage));
                throw new Exception(mensagem);
            }

            _horarioProcesso.Cadastrar(horario);
        }

        public void Atualizar(HorarioModel horario)
        {
            _horarioValidador.AssineRegrasAtualizacao();

            var resultado = _horarioValidador.Validate(horario);

            if (!resultado.IsValid)
            {
                var mensagem = string.Join(";", resultado.Errors.Select(e => e.ErrorMessage));
                throw new ArgumentException(mensagem);
            }
            _horarioProcesso.Atualizar(horario);
        }

        public void Excluir(HorarioModel horario)
        {
            _horarioValidador.AssineRegrasExclusao();

            var resultado = _horarioValidador.Validate(horario);

            if (!resultado.IsValid)
            {
                var mensagem = string.Join(";", resultado.Errors.Select(e => e.ErrorMessage));
                throw new ArgumentException(mensagem);
            }
            _horarioProcesso.Excluir(horario);
        }

        public List<HorarioModel> Listar()
        {
            return _horarioProcesso.Listar();
        }

        public HorarioModel? HorarioExiste(int idHorario)
        {
            return _horarioProcesso.HorarioExiste(idHorario);
        }
        public List<HorarioModel> HorariosDisponiveis(int idBarbeiro, DiaSemana diaSemana)
        {
            return _horarioProcesso.HorariosDisponiveis(idBarbeiro, diaSemana);
        }
    }
}
