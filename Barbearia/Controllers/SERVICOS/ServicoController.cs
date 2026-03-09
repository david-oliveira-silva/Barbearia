using DOMAIN.MODELS.SERVICOS;
using Microsoft.AspNetCore.Mvc;
using SERVICE.FACHADA.SERVICOS;

namespace WEB.Controllers.SERVICOS
{
    public class ServicoController(ServicosFachada servicosFachada) : Controller
    {
        private readonly ServicosFachada _servicoFachada = servicosFachada;

        [HttpGet]
        public IActionResult UpsertServico(int idServico)
        {
            ServicoModel? servico;

            if (idServico > 0)
            {
                servico = _servicoFachada.ServicoExiste(idServico);

                if (servico != null)
                    return View(servico);
            }

            servico = new();
            return View(servico);
        }

        [HttpPost]
        public IActionResult CadastrarServico(ServicoModel servico)
        {
            try
            {
                _servicoFachada.Cadastrar(servico);
                TempData["Sucesso"] = "Serviço cadastrado com sucesso";
                return RedirectToAction("ListarServicos");
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
                return View("UpsertServico", servico);
            }
        }

        [HttpPost]
        public IActionResult AtualizarServico(ServicoModel servico)
        {
            try
            {
                _servicoFachada.Atualizar(servico);
                TempData["Sucesso"] = "Serviço Atualizado com sucesso";
                return RedirectToAction("ListarServicos");
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
                return View("UpsertServico", servico);
            }
        }

        public IActionResult ExcluirServico(ServicoModel servico)
        {
            try
            {
                _servicoFachada.Excluir(servico);
                TempData["Sucesso"] = "Serviço excluido com sucesso";
                return RedirectToAction("ListarServicos");
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
                return RedirectToAction("ListarServicos");
            }
        }

        [HttpGet]
        public IActionResult ListarServicos(string nome)
        {
            List<ServicoModel> servicos;
            if (string.IsNullOrEmpty(nome))
            {
                servicos = _servicoFachada.Listar();
            }
            else
            {
                servicos = _servicoFachada.BuscarServicoPorNome(nome);
            }
            return View(servicos);
        }
    }
}
