using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_TrabajoFidelitas.Controllers
{
    public class CitaController : Controller
    {
        public ActionResult MostrarCitas()
        {
            return View();
        }
        public ActionResult NuevoCita()
        {
            return View();
        }
        public ActionResult ActualizarCita()
        {
            return View();
        }
    }
}