using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Web_TrabajoFidelitas.Entidades;
using Web_TrabajoFidelitas.Models;
namespace Web_TrabajoFidelitas.Controllers
{
    [FiltroSeguridad]
    public class ServicioController : Controller
    {
        ServiciosModel model = new ServiciosModel();
        AuditoriaModel modelA = new AuditoriaModel();

        public ActionResult MostrarServicios()
        {
            var respuesta = model.ConsultarServicios();
            if (respuesta.Codigo == 0)
            {


                return View(respuesta.Datos);
            }
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View(new List<Servicios>());
            }
        }
        // ---------------------- REGISTRO ----------------------
        [HttpGet]
        public ActionResult NuevoServicio()
        {
            CargarViewBagServicios();
            return View();
        }
        [HttpPost]
        public ActionResult NuevoServicio(Servicios entidad)
        {
            var respuesta = model.AgregarServicio(entidad);
            if (respuesta.Codigo == 0)
            {
                Auditoria au = new Auditoria();
                au.TableName = "Servicios";
                au.Action = "INSERT";
                au.Usuario = Session["NombreUsuario"].ToString();
                modelA.AgregarAuditoria(au);
                return RedirectToAction("MostrarServicios");
            }
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View(new List<Servicios>());
            }
        }

        // ---------------------- ACTUALIZAR ---------------------
        [HttpGet]
        public ActionResult ActualizarServicio(long id)
        {
            var respuesta = model.TraerServicio(id);
            CargarViewBagServicios();
            return View(respuesta.Dato);
        }
        [HttpPost]
        public ActionResult ActualizarServicio(Servicios entidad)
        {
            var respuesta = model.ActualizarServicio(entidad);
            if (respuesta.Codigo == 0)
            {
                Auditoria au = new Auditoria();
                au.TableName = "Servicios";
                au.Action = "UPDATE";
                au.Usuario = Session["NombreUsuario"].ToString();
                modelA.AgregarAuditoria(au);
                return RedirectToAction("MostrarServicios");
            }
            else
            {
                return View();
            }
        }
       

        // ---------------------- ELIMINAR ---------------------

        [HttpGet]
        public ActionResult EliminarServicio(long id)
        {
            var respuesta = model.EliminarServicio(id);

            if (respuesta.Codigo == 0)
            {
                Auditoria au = new Auditoria();
                au.TableName = "Servicios";
                au.Action = "INACTIVAR";
                au.Usuario = Session["NombreUsuario"].ToString();
                modelA.AgregarAuditoria(au);
                return RedirectToAction("MostrarServicios");
            }
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }

        private void CargarViewBagServicios()
        {
            var respuesta = model.ConsultarServicios();
            var servicio = new List<SelectListItem>();

            servicio.Add(new SelectListItem { Text = "Seleccione una categoría", Value = "" });
            foreach (var item in respuesta.Datos)
                servicio.Add(new SelectListItem { Text = item.NombreServicio, Value = item.IdServicio.ToString() });

            ViewBag.servicio = servicio;
        }
    }
}