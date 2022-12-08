using Microsoft.AspNetCore.Mvc;

namespace MiPrimerAppWebProgresiva.Controllers
{
    public class PaginaErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
