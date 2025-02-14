using Microsoft.AspNetCore.Mvc;

namespace AppLogin.Controllers
{
    public class NotasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
