﻿using System.ComponentModel.DataAnnotations;

namespace AppLogin.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        public string NombreCompleto { get; set; }

        public string Correo { get; set; }

        public string Clave { get; set; }
    }
}