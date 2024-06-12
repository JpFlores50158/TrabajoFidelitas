using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_TrabajoFidelitas.Models;

namespace Web_TrabajoFidelitas.Controllers
{
    [FiltroSeguridad]
    public class SucursalController : Controller
    {

        public ActionResult MostrarSucursales()
        {
            return View();
        }
        public ActionResult NuevoSucursal()
        {
            return View();
        }
        public ActionResult ActualizarSucursal()
        {
            return View();
        }

       
    }
}