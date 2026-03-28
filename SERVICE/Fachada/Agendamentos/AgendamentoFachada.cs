using DOMAIN.Enuns.Horario;
using DOMAIN.INTERFACES;
using DOMAIN.Models.Agendamentos;
using DOMAIN.Validador.Agendamentos;
using REPOSITORY.Mapeadores.Agendamentos;
using SERVICE.Processo.Agendamentos;

namespace SERVICE.Fachada.Agendamentos
{
    public class AgendamentoFachada(IAgendamentoMapeador mapeador)
    {
        protected AgendamentoValidacao _agendamentoValidacao = new();
        protected AgendamentoProcesso _agendamentoProcesso = new(mapeador);
        
         public void Cadastrar(AgendamentoModel agendamento)
        {
            _agendamentoValidacao.AssineRegrasInclusao();

            var resultado = _agendamentoValidacao.Validate(agendamento);

            if (!resultado.IsValid)
            {
                string mensagens = string.Join(";", resultado.Errors.Select(e => e.ErrorMessage));
                throw new ArgumentException(mensagens);
            }
            _agendamentoProcesso.Cadastrar(agendamento);
        }

        public void Atualizar(AgendamentoModel agendamento)
        {
            _agendamentoValidacao.AssineRegrasAtualizacao();
            var resultado = _agendamentoValidacao.Validate(agendamento);
            if (!resultado.IsValid)
            {
                string mensagens = string.Join(";", resultado.Errors.Select(e => e.ErrorMessage));
                throw new ArgumentException(mensagens);
            }
            _agendamentoProcesso.Atualizar(agendamento);
        }

        public void Excluir(AgendamentoModel agendamento)
        {
            _agendamentoValidacao.AssineRegrasExclusao();
            var resultado = _agendamentoValidacao.Validate(agendamento);
            if (!resultado.IsValid)
            {
                string mensagens = string.Join(";", resultado.Errors.Select(e => e.ErrorMessage));
                throw new ArgumentException(mensagens);
            }
            _agendamentoProcesso.Excluir(agendamento);
        }

        public List<AgendamentoModel> Listar()
        {
            return _agendamentoProcesso.Listar();
        }

        public List<AgendamentoModel> ListarHorariosOcupadosPorData(int idBarbeiro, DateOnly data)
        {
            return _agendamentoProcesso.ListarHorariosOcupadosPorData(idBarbeiro, data);
        }

        public AgendamentoModel? AgendamentoExiste(int idAgendamento)
        {
            return _agendamentoProcesso.AgendamentoExiste(idAgendamento);
        }
    }
}
