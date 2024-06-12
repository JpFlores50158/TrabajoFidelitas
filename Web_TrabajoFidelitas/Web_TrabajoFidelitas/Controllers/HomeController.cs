using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_TrabajoFidelitas.Entiadades;
using Web_TrabajoFidelitas.Models;

namespace Web_TrabajoFidelitas.Controllers
{
    public class HomeController : Controller
    {


        UsuarioModel modelo = new UsuarioModel();
      

        [HttpGet]
        public ActionResult InicioSesion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InicioSesion(Usuario entidad)
        {
            var respuesta = modelo.InicioSesion(entidad);

            if (respuesta.Codigo == 0)
            {
                Session["NombreUsuario"] = respuesta.Dato.nombreUsuario;
                Session["RolUsuario"] = respuesta.Dato.idRol;
                Session["NombreRol"] = respuesta.Dato.nombre_rol;
                Session["CorreoUsuario"] = respuesta.Dato.emailUsuario;
                Session["idUsuario"] = respuesta.Dato.idUsuario;

                return RedirectToAction("PaginaPrincipal", "Inicio");
            }
            else
            {
               

                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }
        [FiltroSeguridad]
        public ActionResult PaginaPrincipal()
        {

            return View();
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}