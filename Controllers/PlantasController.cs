using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SitioWeb.Datos;
using SitioWeb.Models;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

using Microsoft.AspNetCore.Authorization;



namespace SitioWeb.Controllers
{
    public class PlantasController : Controller
    {
        PlantasDatos _PlantasDatos = new PlantasDatos();

        public IActionResult Principal() //Vista de la página principal 
        {
            ViewBag.Subfamilias = _PlantasDatos.ListarSubfamilias();
            return View();
        }

        public IActionResult Login() //Vista de la página de Inicio de Sesión
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string usuario, string clave) //Recibe los parámetros para iniciar sesión, las cookies trabajan con métodos asíncronos
        {

            UsuariosModel objeto = new UsuarioDatos().EncontrarUsuario(usuario,clave);

            if(objeto.Nombre != null) //Validar que los datos sean correctos
            {
                var claims = new List<Claim> //El usuario tiene varias propiedades tipo Claims
                {
                    new Claim(ClaimTypes.Name, objeto.Nombre),
                    new Claim("Usuario", objeto.Usuario)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity)); //Se pasan todas las propiedades del esquema de logueo

                return RedirectToAction("Listar", "Plantas");
            }

            ModelState.AddModelError("Clave", "Usuario o contraseña incorrectos");
            return View();
            
        }

        public async Task<IActionResult> CerrarSesion() //Devuelve a la página principal
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);//Permite eliminar la cookie creada y así restringir el acceso a las páginas
            return RedirectToAction("Principal", "Plantas");
        }

        public IActionResult InfoPlanta(int ID) //Vista de información sobre una planta
        {
            var oDetalle = _PlantasDatos.ObtenerPlanta(ID);
            return View(oDetalle);
        }

        [HttpGet]
        public IActionResult ListarFamilias(string id) //Vista de las especies de plantas existentes por subfamilia
        {
            var ListaPlantas = _PlantasDatos.ListarPlantasPorSubfamilia(id);
            return View(ListaPlantas);
        }

        [Authorize] //Solo se puede ingresar a esta vista si tiene autorización
        public IActionResult Listar() //Vista de todas las plantas y su respectiva información, esta vista está disponible solo para el usuario con permisos
        {
            var oLista = _PlantasDatos.Listar();
            return View(oLista);
        }

        [Authorize] //Solo se puede ingresar a esta vista si tiene autorización
        public IActionResult Detalles(int ID) //Vista de todos los datos de una planta específica, , esta vista está disponible solo para el usuario con permisos
        {
            var oDetalle = _PlantasDatos.ObtenerPlanta(ID);
            return View(oDetalle);
        }

        [Authorize] //Solo se puede ingresar a esta vista si tiene autorización
        public IActionResult Guardar() //Este método devuelve solo la vista de guardar, esta vista está disponible solo para el usuario con permisos
        {
            return View();
        }


        [HttpPost]
        public IActionResult GuardarConImagen(PlantasTotalModel objs)  //Método recibe los datos para guardarlos en la BD
        {
            //Validación de campos vacíos
            if (!ModelState.IsValid)
                return View();

            var respuesta = _PlantasDatos.GuardarConImagen(objs);
            return Ok();
        }

        [Authorize] //Solo se puede ingresar a esta vista si tiene autorización
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

        [Authorize] //Solo se puede ingresar a esta vista si tiene autorización
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
