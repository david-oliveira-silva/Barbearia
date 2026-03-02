using DOMAIN.MODELS.CLIENTES;
using Microsoft.AspNetCore.Mvc;
using SERVICE.FACHADA.CLIENTES;

namespace WEB.Controllers.CLIENTES
{
    public class ClienteController(ClienteFachada clienteFachada) : Controller
    {
        private readonly ClienteFachada _clienteFachada = clienteFachada;

        [HttpGet]
        public IActionResult UpsertCliente(int idCliente)
        {
            ClienteModel? cliente;

            if (idCliente > 0)
            {
                cliente = _clienteFachada.ClienteExiste(idCliente);
                if (cliente != null) 
                    return View(cliente);
            }

            cliente = new();

            return View(cliente);
        }

        [HttpPost]
        public IActionResult CadastrarCliente(ClienteModel cliente)
        {
            try
            {
                _clienteFachada.Cadastrar(cliente);
                TempData["Sucesso"] = "Cliente cadastrado com sucesso";
                return RedirectToAction("ListarClientes");
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
                return View("UpsertCliente", cliente);
            }
        }

        public IActionResult EditarCliente(ClienteModel cliente)
        {
            try
            {
                _clienteFachada.Atualizar(cliente);
                TempData["Sucesso"] = "Cliente editado com sucesso";
                return RedirectToAction("ListarClientes");
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
                return View("UpsertCliente", cliente);
            }
        }

        [HttpPost]
        public IActionResult ExcluirCliente(ClienteModel cliente)
        {
            try
            {
                _clienteFachada.Excluir(cliente);
                TempData["Sucesso"] = "Cliente deletado com sucesso";
                return RedirectToAction("ListarClientes");

            }
            catch (Exception ex)
            {

                TempData["Erro"] = ex.Message;
                return RedirectToAction("ListarClientes");
            }
        }

        [HttpGet]
        public IActionResult ListarClientes(string nome)
        {
            List<ClienteModel>? cliente;
            if (string.IsNullOrEmpty(nome))
            {
                cliente = _clienteFachada.Listar();
            }
            else
            {
                cliente = [.. _clienteFachada.BuscarClientePorNome(nome) ?? []];
            }
            return View(cliente);
        }
    }
}
