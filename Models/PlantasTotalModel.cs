using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SitioWeb.Models
{
    public class PlantasTotalModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "El campo Nombre Científico es obligatorio")]
        public string NombreCientifico { get; set; }

        [Required(ErrorMessage = "El campo Género es obligatorio")]
        public string GeneroHosp { get; set; }

        [Required(ErrorMessage = "El campo Nombre Común es obligatorio")]
        public string NombreComun { get; set; }

        [Required(ErrorMessage = "El campo Subfamilia es obligatorio")]
        public string Subfamilia { get; set; }

        [Required(ErrorMessage = "El campo Tipo de Hojas es obligatorio")]
        public string TipoHojas { get; set; }

        [Required(ErrorMessage = "El campo Morfología de hojas es obligatorio")]
        public string MorfoHojas { get; set; }

        [Required(ErrorMessage = "El campo Posición de hojas es obligatorio")]
        public string PosHojas { get; set; }

        [Required(ErrorMessage = "El campo Posición de foliolos es obligatorio")]
        public string PosFoliolos { get; set; }

        [Required(ErrorMessage = "El campo Color de flor es obligatorio")]
        public string ColorFlor { get; set; }

        [Required(ErrorMessage = "El campo Tipo de flor es obligatorio")]
        public string TipoFlor { get; set; }

        [Required(ErrorMessage = "El campo Pétalos es obligatorio")]
        public int Petalos { get; set; }

        [Required(ErrorMessage = "El campo Espinas es obligatorio")]
        public string Espinas { get; set; }

        [Required(ErrorMessage = "El campo Amenazado es obligatorio")]
        public string Amenazado { get; set; }

        [Required(ErrorMessage = "El campo Color de raíz es obligatorio")]
        public string ColorRaiz { get; set; }

        [Required(ErrorMessage = "El campo Nodula es obligatorio")]
        public string Nodula { get; set; }

        public string tipoImagen { get; set; }

        public string Imagen { get; set; }


    }

    public class InfoPlantaSubfamilia
    {
        public int ID { get; set; }
        public string NombreCientifico { get; set; }
        public string NombreComun { get; set; }
    }

    public class PlantasPorSubfamilia
    {
        public string Subfamilia { get; set; }
        public List<InfoPlantaSubfamilia> Plantas { get; set; }
    }
}
