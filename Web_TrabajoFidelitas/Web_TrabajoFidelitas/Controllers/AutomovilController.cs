using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_TrabajoFidelitas.Controllers
{
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