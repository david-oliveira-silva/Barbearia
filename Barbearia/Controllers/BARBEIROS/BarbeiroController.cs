using DOMAIN.MODELS.BARBEIROS;
using Microsoft.AspNetCore.Mvc;
using REPOSITORY.MAPEADORES.BARBEIROS;
using SERVICE.FACHADA.BARBEIROS;
namespace WEB.Controllers.BARBEIROS
{
    public class BarbeiroController(BarbeiroFachada barbeiroFachada) : Controller
    {
        private readonly BarbeiroFachada _barbeiraFachada = barbeiroFachada;

        public IActionResult UpsertBarbeiro(int idBarbeiro)
        {
            BarbeiroModel? barbeiro;
            if (idBarbeiro > 0)
            {
                barbeiro = _barbeiraFachada.ClienteExiste(idBarbeiro);
                if (barbeiro != null)
                    return View(barbeiro);
            }
            barbeiro = new();
            return View(barbeiro);
        }

        public IActionResult CadastrarBarbeiro(BarbeiroModel barbeiro)
        {
            try
            {
                _barbeiraFachada.Cadastrar(barbeiro);
                TempData["Sucesso"] = "Barbeiro cadastrado com sucesso";
                return RedirectToAction("ListarBarbeiros");
            }
            catch(Exception ex)
            {
                TempData["Erro"] = ex.Message;
                return View("UpsertBarbeiro", barbeiro);
            }
        }

        public IActionResult AtualizarBarbeiro(BarbeiroModel barbeiro)
        {
            try
            {
                _barbeiraFachada.Atualizar(barbeiro);
                TempData["Sucesso"] = "Barbeiro atualizado com sucesso";
                return RedirectToAction("ListarBarbeiros");
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
                return View("UpsertBarbeiro", barbeiro);
            }
        }

        public IActionResult ExcluirBarbeiro(BarbeiroModel barbeiro)
        {
            try
            {
                _barbeiraFachada.Excluir(barbeiro);
                TempData["Sucesso"] = "Barbeiro deletado com sucesso";
                return RedirectToAction("ListarBarbeiros");
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
                return RedirectToAction("ListarBarbeiros");
            }
        }

        public IActionResult ListarBarbeiros(string nome)
        {
            List<BarbeiroModel>? barbeiros;
            if (string.IsNullOrEmpty(nome))
            {
                barbeiros = _barbeiraFachada.Listar();
            }
            else
            {
                barbeiros = _barbeiraFachada.BuscarClientePorNome(nome);
            }

            return View(barbeiros);
        }
    }
}
