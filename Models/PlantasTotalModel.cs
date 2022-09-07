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

        [Required(ErrorMessage = "El campo Simbionte es obligatorio")]
        public string Simbionte { get; set; }

        [Required(ErrorMessage = "El campo Nodula es obligatorio")]
        public string Nodula { get; set; }

        public string tipoImagen { get; set; } = null!;

        public string Imagen { get; set; } = null!;

    }

    public class PlantasNodulan
    {
        //Aquí declaro las variables para PlantasNodulan
        [Required(ErrorMessage = "El campo Id de Nódulo es obligatorio")]
        public string IdNodulo { get; set; }

        [Required(ErrorMessage = "El campo Individuo es obligatorio")]
        public int Indiv { get; set; }

        public string NombreCientificoPlanta { get; set; }

        [Required(ErrorMessage = "El campo Cantidad de nodos es obligatorio")]
        public int CantidadNodos { get; set; }

        [Required(ErrorMessage = "El campo Forma de nodo es obligatorio")]
        public string FormaNodo { get; set; }

        [Required(ErrorMessage = "El campo Tipo de nodo es obligatorio")]
        public string TipoNodo { get; set; }

        [Required(ErrorMessage = "El campo Tamaño de nodo es obligatorio")]
        public int TamanoNodo { get; set; }

        [Required(ErrorMessage = "El campo Fecha es obligatorio")]
        public string Fecha { get; set; } //No se si string puede ser fecha

        [Required(ErrorMessage = "El campo Proyecto es obligatorio")]
        public string Proyecto { get; set; }

        [Required(ErrorMessage = "El campo Permiso es obligatorio")]
        public string Permiso { get; set; }

        [Required(ErrorMessage = "El campo Permiso es obligatorio")]
        public string FiloBacteria { get; set; }

        [Required(ErrorMessage = "El campo Género de bacteria es obligatorio")]
        public string GeneroBacteria { get; set; }

        [Required(ErrorMessage = "El campo Rhizobio es obligatorio")]
        public string Rhizobio { get; set; }

        [Required(ErrorMessage = "El campo Gram es obligatorio")]
        public string Gram { get; set; }

        [Required(ErrorMessage = "El campo Secuencia es obligatorio")]
        public string Secuencia { get; set; }

        public int IDPlanta { get; set; }

        public string TipoFoto { get; set; } = null!;

        public string FotoNodulo { get; set; } = null!;
    }

    //Prueba de modelo combinado QUE NO SIRVE
    public class ViewModel
    {
        public IEnumerable<PlantasTotalModel> PlantasTotal { get; set; }
        public IEnumerable<PlantasNodulan> PlantasNodulan { get; set; }
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
