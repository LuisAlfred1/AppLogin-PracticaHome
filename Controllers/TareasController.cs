using AppLogin.Data;
using AppLogin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppLogin.Controllers
{
    public class TareasController : Controller
    {
        private readonly AppDBContext _context;

        public TareasController(AppDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult GuardarTarea([FromBody] Tarea tarea)
        {
            // Asegurarse de que solo se guarda la fecha sin la hora
            tarea.FechaLimite = tarea.FechaLimite.Date;

            if (ModelState.IsValid)
            {
                _context.Tareas.Add(tarea);
                _context.SaveChanges();
                return Ok(new { mensaje = "Tarea guardada correctamente" });
            }
            return BadRequest("Datos inválidos");
        }

        [HttpGet]
        public IActionResult ObtenerTareas()
        {
            var tareas = _context.Tareas.ToList();
            return Ok(tareas);
        }

        [HttpDelete]
        public IActionResult EliminarTarea(int id)
        {
            var tarea = _context.Tareas.Find(id);
            if (tarea == null)
            {
                return NotFound();
            }
            _context.Tareas.Remove(tarea);
            _context.SaveChanges();
            return Ok(new { mensaje = "Tarea eliminada correctamente" });
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
