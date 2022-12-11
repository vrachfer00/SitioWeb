using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SitioWeb.Models
{
    public class UsuariosModel
    {
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "Debe utilizar el formato de correo electrónico")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatorio")]
        public string Clave { get; set; }
    }
}
