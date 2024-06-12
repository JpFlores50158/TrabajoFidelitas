using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_TrabajoFidelitas.Models;

namespace Web_TrabajoFidelitas.Controllers
{
    [FiltroSeguridad]
    public class ClienteController : Controller
    {

        public ActionResult MostrarClientes()
        {
            return View();
        }
        public ActionResult NuevoCliente()
        {
            return View();
        }
        public ActionResult ActualizarCliente()
        {
            return View();
        }

       
    }
}