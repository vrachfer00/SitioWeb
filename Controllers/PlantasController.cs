using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SitioWeb.Datos;
using SitioWeb.Models;

namespace SitioWeb.Controllers
{
    public class PlantasController : Controller
    {
        PlantasDatos _PlantasDatos = new PlantasDatos();

        public IActionResult Principal() //Vista de la página principal 
        {
            return View();
        }

        public IActionResult InfoPlanta(int ID) //Vista de información sobre una planta
        {
            var oDetalle = _PlantasDatos.ObtenerPlanta(ID);
            return View(oDetalle);
        }

        public IActionResult ListarFamilias(string ID) //Vista de las especies de plantas existentes por subfamilia
        {
            var ListarFamilia = _PlantasDatos.ObtenerSubfamilia(ID);
            return View(ListarFamilia);
        }

        public IActionResult Listar() //Vista de todas las plantas y su respectiva información, esta vista está disponible solo para el usuario con permisos
        {
            var oLista = _PlantasDatos.Listar();
            return View(oLista);
        }

        public IActionResult Detalles(int ID) //Vista de todos los datos de una planta específica, , esta vista está disponible solo para el usuario con permisos
        {
            var oDetalle = _PlantasDatos.ObtenerPlanta(ID);
            return View(oDetalle);
        }

        public IActionResult Guardar() //Este método devuelve solo la vista de guardar, esta vista está disponible solo para el usuario con permisos
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(PlantasTotalModel oContacto)  //Método recibe los datos para guardarlos en la BD
        {
            //Validación de campos vacíos
            if (!ModelState.IsValid)
                return View();

            var respuesta = _PlantasDatos.Guardar(oContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int ID) //Este método muestra la vista editar, esta vista está disponible solo para el usuario con permisos
        {
            var ocontacto = _PlantasDatos.ObtenerPlanta(ID);
            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Editar(PlantasTotalModel oContacto) //Este método permite editar la info de una planta
        {
            //Validación de campos vacíos
            if (!ModelState.IsValid)
                return View();

            var respuesta = _PlantasDatos.Editar(oContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int ID) //Este método muestra la vista eliminar
        {
            var ocontacto = _PlantasDatos.ObtenerPlanta(ID);
            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Eliminar(PlantasTotalModel oContacto) //Este método permite eliminar la info de una planta, esta vista está disponible solo para el usuario con permisos
        {

            var respuesta = _PlantasDatos.Eliminar(oContacto.ID);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }





    }
}
