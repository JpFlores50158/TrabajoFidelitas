using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_TrabajoFidelitas.Models;

namespace Web_TrabajoFidelitas.Controllers
{
    [FiltroSeguridad]
    public class AutomovilController : Controller
    {
        public ActionResult MostrarAutomoviles()
        {
            return View();
        }
        public ActionResult NuevoAutomovil()
        {
            return View();
        }
        public ActionResult ActualizarAutomovil()
        {
            return View();
        }
    }
}