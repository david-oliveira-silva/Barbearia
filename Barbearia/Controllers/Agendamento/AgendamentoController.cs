using DOMAIN.Enuns.Horario;
using DOMAIN.Models.Agendamentos;
using DOMAIN.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using SERVICE.Fachada.Agendamentos;
using SERVICE.Fachada.Horarios;
using SERVICE.FACHADA.BARBEIROS;
using SERVICE.FACHADA.CLIENTES;
using SERVICE.FACHADA.SERVICOS;
namespace WEB.Controllers.Agendamento
{
    public class AgendamentoController(AgendamentoFachada agendamentoFachada,BarbeiroFachada barbeiroFachada,ClienteFachada clienteFachada,ServicosFachada servicoFachada, HorarioFachada horarioFachada) : Controller
    {
        private readonly AgendamentoFachada _agendamentoFachada = agendamentoFachada;
        private readonly BarbeiroFachada _barbeiroFachada = barbeiroFachada;
        private readonly ClienteFachada _clienteFachada = clienteFachada;
        private readonly ServicosFachada _servicoFachada = servicoFachada;   
        private readonly HorarioFachada _horarioFachada = horarioFachada;
        public IActionResult UpsertAgendamento(int idAgendamento)
        {
            ViewModelAgendamento viewModel = new()
            {
                    Barbeiros = _barbeiroFachada.Listar(),
                    Clientes = _clienteFachada.Listar(),
                    Servicos = _servicoFachada.Listar(),
                    Horarios = _horarioFachada.Listar()
            };

            if (idAgendamento > 0)
            {
                viewModel.Agendamento = _agendamentoFachada.AgendamentoExiste(idAgendamento);
                if (viewModel.Agendamento != null)
                {
                    return View(viewModel);
                }
            }
            viewModel.Agendamento = new AgendamentoModel();
            return View(viewModel);
        }

        public IActionResult CadastrarAgendamento(ViewModelAgendamento? viewModel)
        {
            if (viewModel?.Agendamento == null)
            {
                TempData["Erro"] = "Dados inválidos.";
                return RedirectToAction("ListarHorarios");
            }

            try
            {
                _agendamentoFachada.Cadastrar(viewModel.Agendamento);
                TempData["Sucesso"] = "Agendamento cadastrado com sucesso";
                return RedirectToAction("ListarAgendamentos");
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
                return View("UpsertAgendamento", viewModel);
            }
        }

        public IActionResult AtualizarAgendamento(ViewModelAgendamento? viewModel)
        {
            if (viewModel?.Agendamento == null)
            {
                TempData["Erro"] = "Dados inválidos.";
                return RedirectToAction("ListarHorarios");
            }

            try
            {
                _agendamentoFachada.Atualizar(viewModel.Agendamento);
                TempData["Sucesso"] = "Agendamento atualizado com sucesso";
                return RedirectToAction("ListarAgendamentos");
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
                return View("UpsertAgendamento", viewModel);
            }
        }

        public IActionResult ExcluirAgendamento(ViewModelAgendamento? viewModel)
        {
            if (viewModel?.Agendamento == null)
            {
                TempData["Erro"] = "Dados inválidos.";
                return RedirectToAction("ListarHorarios");
            }

            try
            {
                _agendamentoFachada.Excluir(viewModel.Agendamento);
                TempData["Sucesso"] = "Agendamento deletado com sucesso";
                return RedirectToAction("ListarAgendamentos");
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
                return RedirectToAction("ListarAgendamentos");
            }
        }
        public IActionResult ListarAgendamentos()
        {
            List<AgendamentoModel> agendamento = _agendamentoFachada.Listar();
            return View(agendamento);
        }

        [HttpGet]
        public JsonResult HorariosDisponiveis(int idBarbeiro, DateOnly data)
        {   
            int dia = (int)data.DayOfWeek;
            var diaSemanaEnum = (DiaSemana)(dia == 0 ? 7 : dia);
            var cadastrados = _horarioFachada.HorariosDisponiveis(idBarbeiro, diaSemanaEnum);
            var ocupados = _agendamentoFachada.ListarHorariosOcupadosPorData(idBarbeiro, data);
            var idsOcupados = ocupados.Select(a => a.IdHorario).ToList();

            var disponiveis = cadastrados
                .Where(h => !idsOcupados.Contains(h.IdHorario))
                .Select(h => new { 
                    id = h.IdHorario, 
                    texto = $"{h.HorarioInicio:hh\\:mm} às {h.HorarioFim:hh\\:mm}" 
                });

            return Json(disponiveis);
        }
    }
}
