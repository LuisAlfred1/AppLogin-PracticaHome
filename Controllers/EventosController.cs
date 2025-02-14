using Microsoft.AspNetCore.Mvc;

namespace AppLogin.Controllers
{
    public class EventosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
