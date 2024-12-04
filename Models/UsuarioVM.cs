using System.ComponentModel.DataAnnotations;

namespace AppLogin.Models
{
    public class UsuarioVM
    {
        public int IdUsuario { get; set; }

        public string NombreCompleto { get; set; }

        [EmailAddress(ErrorMessage = "Correo Inválido")]
        public string Correo { get; set; }

        public string Clave { get; set; }

        public string ConfirmarClave { get; set; }
    }
}
