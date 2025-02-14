using Microsoft.AspNetCore.Mvc;

namespace AppLogin.Controllers
{
    public class TareasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
