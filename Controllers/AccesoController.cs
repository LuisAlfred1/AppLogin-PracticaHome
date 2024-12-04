using AppLogin.Data;
using AppLogin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
namespace AppLogin.Controllers
{
    public class AccesoController : Controller
    {
        private readonly AppDBContext _context;

        public AccesoController(AppDBContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Registrarse()
        {

            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Registrarse(UsuarioVM modelo)
        {
            if(modelo.Clave != modelo.ConfirmarClave)
            {
                ViewData["Mensaje"] = "Las contraseñas no coinciden";
                return View();
            }

            Usuario usuario = new Usuario()
            {
                NombreCompleto = modelo.NombreCompleto,
                Correo = modelo.Correo,
                Clave = modelo.Clave
            };

            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();

            if (usuario.IdUsuario != 0) return RedirectToAction("Login", "Acceso");
            ViewData["Mensaje"] = "No se puede crear el usuario";
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity!.IsAuthenticated) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM modelo)
        {
            Usuario? usuario_encontrado = await _context.Usuarios
                .Where(u=>
                u.Correo==modelo.Correo &&
                u.Clave==modelo.Clave).FirstAsync();

            if(usuario_encontrado == null)
            {
                ViewData["Mensaje"] = "No se encontraron coincidencias";
            }
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,usuario_encontrado.NombreCompleto)
            };

            ClaimsIdentity claimsIdentity = new(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
            };
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
                );

            return RedirectToAction("Index","Home");
        }


    }
}
