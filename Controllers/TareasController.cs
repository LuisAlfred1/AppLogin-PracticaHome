using AppLogin.Data;
using AppLogin.Models;
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
