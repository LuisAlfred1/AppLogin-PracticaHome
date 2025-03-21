using System.ComponentModel.DataAnnotations;

namespace AppLogin.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }

        // Cambiar el tipo a DateTime (solo fecha)
        [DataType(DataType.Date)]
        public DateTime FechaLimite { get; set; }
        public string Prioridad { get; set; }

    }
}
