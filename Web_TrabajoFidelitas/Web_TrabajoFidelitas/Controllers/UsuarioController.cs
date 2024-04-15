using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Web_TrabajoFidelitas.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public ActionResult IniciarSesion()
        {
            return View();
        }



        [HttpGet]
        public ActionResult RegistrarUsuario()
        {
            return View();
        }




        [HttpGet]
        public ActionResult RecuperarAcceso()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MostrarCitaUsuario()
        {
            return View();
        }


    }
}