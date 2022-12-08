using Microsoft.AspNetCore.Mvc;

namespace MiPrimerAppWebProgresiva.Controllers
{
    public class EmpresasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
