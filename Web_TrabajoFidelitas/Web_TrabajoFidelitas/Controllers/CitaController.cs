using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_TrabajoFidelitas.Entidades;
using Web_TrabajoFidelitas.Models;

namespace Web_TrabajoFidelitas.Controllers
{
    [FiltroSeguridad]
    public class CitaController : Controller
    {
        CitasModel model = new CitasModel();

        [HttpGet]
        public ActionResult MostrarCitas()
        {
            var respuesta = model.TraerCita();
            if (respuesta.Codigo == 0)
            {
                return View(respuesta.Datos);
            }
            else
            {
                return View(new List<Citas>());
            }
        }
        public ActionResult NuevoCita()
        {
            return View();
        }
        [HttpGet]
        public ActionResult EditarCita(long id)
        {
            var respuesta = model.ConsultarCita(id);
            return View(respuesta.Dato);
        }
        [HttpPost]
        public ActionResult EditarCita(Citas entidad)
        {
            var respuesta = model.Editarcita(entidad);
            if (respuesta.Codigo == 0)
            {
                return RedirectToAction("MostrarCitas");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult InactivarCita(long id)
        {
            var respuesta = model.sp_EliminarCita(id);

            if (respuesta.Codigo == 0)
            {
                return RedirectToAction("MostrarCitas");
            }
            else
            {
                return View();
            }
        }
    }
}