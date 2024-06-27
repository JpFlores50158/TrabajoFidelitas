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
    public class SucursalController : Controller
    {
        SucursalModel model = new SucursalModel();

        [HttpGet]
        public ActionResult MostrarSucursales()
        {
            var respuesta = model.ConsultarSucursal();
            if (respuesta.Codigo == 0)
            {
                return View(respuesta.Datos);
            }
            else
            {
                return View(new List<Sucursal>());
            }
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