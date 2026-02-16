using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers.CLIENTES
{
    public class ClienteController : Controller
    {
        [HttpGet]
        public IActionResult ListarClientes()
        {
            return View();
        }
    }
}
