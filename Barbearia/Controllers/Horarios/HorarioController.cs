using DOMAIN.Models.Horarios;
using DOMAIN.Models.ViewModelHorario;
using Microsoft.AspNetCore.Mvc;
using SERVICE.Fachada.Horarios;
using SERVICE.FACHADA.BARBEIROS;

namespace WEB.Controllers.Horarios
{
    public class HorarioController(HorarioFachada horarioFachada, BarbeiroFachada barbeiroFachada) : Controller
    {
        private readonly HorarioFachada _horarioFachada = horarioFachada;
        private readonly BarbeiroFachada _barbeiroFachada = barbeiroFachada;
        public IActionResult UpsertHorario(int idHorario)
        {
            ViewModelHorario viewModel = new()
            {
                Barbeiros = _barbeiroFachada.Listar()
            };

            if (idHorario > 0)
            {
                viewModel.Horario = _horarioFachada.HorarioExiste(idHorario);

                if (viewModel.Horario == null)
                {
                    TempData["Erro"] = "Horário não encontrado.";
                    return RedirectToAction("ListarHorarios");
                }
            }
            else
            {
                viewModel.Horario = new HorarioModel();
            }
            return View(viewModel);
        }

        public IActionResult CadastrarHorario(ViewModelHorario? viewModel)
        {
            if (viewModel?.Horario == null)
            {
                TempData["Erro"] = "Dados inválidos.";
                return RedirectToAction("ListarHorarios");
            }

            try
            {
                _horarioFachada.Cadastrar(viewModel.Horario);
                TempData["Sucesso"] = "Horário cadastrada com sucesso";
                return RedirectToAction("ListarHorarios");
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
                return View("UpsertHorario", viewModel);
            }
        }

        public IActionResult AtualizarHorario(ViewModelHorario? viewModel)
        {
            if (viewModel?.Horario == null)
            {
                TempData["Erro"] = "Dados inválidos.";
                return RedirectToAction("ListarHorarios");
            }

            try
            {
                _horarioFachada.Atualizar(viewModel.Horario);
                TempData["Sucesso"] = "Horário atualizado com sucesso";
                return RedirectToAction("ListarHorarios");
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
                return View("UpsertHorario", viewModel);
            }
        }

        public IActionResult ExcluirHorario(HorarioModel horario)
        {
            try
            {
                _horarioFachada.Excluir(horario);
                TempData["Sucesso"] = "Horário excluido com sucesso";
                return RedirectToAction("ListarHorarios");
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
                return RedirectToAction("ListarHorarios");
            }
        }

        public IActionResult ListarHorarios()
        {
            List<HorarioModel> horarios = _horarioFachada.Listar();
            return View(horarios);
        }

        public IActionResult HorariosDisponiveis(int idBarbeiro, int diaSemana)
        {
            var horarios = _horarioFachada.HorariosDisponiveis(idBarbeiro, (DOMAIN.Enuns.Horario.DiaSemana)diaSemana);
            return View(horarios);
        }
    }
}

