using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers.API
{
    public class LivrosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
