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

        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "El campo contraseña es obligatorio")]
        public string Clave { get; set; }
    }
}
