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
        [HttpGet]
        public ActionResult NuevoSucursal()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NuevoSucursal(Sucursal entidad)
        {
            var respuesta = model.AgregarSucursal(entidad);
            if (respuesta.Codigo == 0)
            {
                return RedirectToAction("MostrarSucursales");
            }
            else
            {
                return View(new List<Sucursal>());
            }
        }
        [HttpGet]
        public ActionResult ActualizarSucursal(long id)
        {
            var respuesta = model.TraerSucursal(id);
            return View(respuesta.Dato);
        }
        [HttpPost]
        public ActionResult ActualizarSucursal(Sucursal entidad)
        {
            var respuesta = model.ActualizarSucursal(entidad);
            if (respuesta.Codigo == 0)
            {
                return RedirectToAction("MostrarSucursales");
            }
            else
            {
                return View();
            }
        }
   
        [HttpGet]
        public ActionResult InactivarSucursal(long id)
        {
            var respuesta = model.InactivarSucursal(id);

            if (respuesta.Codigo == 0)
            {
                return RedirectToAction("MostrarSucursales");
            }
            else
            {
                return View();
            }
        }


    }
}