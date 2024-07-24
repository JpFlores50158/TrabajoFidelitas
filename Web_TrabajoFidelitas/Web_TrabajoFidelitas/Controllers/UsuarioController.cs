using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Web_TrabajoFidelitas.Entidades;
using Web_TrabajoFidelitas.Models;

namespace Web_TrabajoFidelitas.Controllers
{
    public class UsuarioController : Controller
    {

        UsuarioModel modelo = new UsuarioModel();

        AuditoriaModel modelA = new AuditoriaModel();
        [HttpGet]
        public ActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IniciarSesion(Usuario entidad)
        {
            var respuesta = modelo.InicioSesion(entidad);

            if (respuesta.Codigo == 0)
            {
                Auditoria au = new Auditoria();
                au.TableName = "Citas";
                au.Action = "InactivarSucursal";
                modelA.AgregarAuditoria(au);
                Session["NombreUsuario"] = respuesta.Dato.nombreUsuario;
                Session["RolUsuario"] = respuesta.Dato.idRol;
                Session["NombreRol"] = respuesta.Dato.nombreRol;
                Session["CorreoUsuario"] = respuesta.Dato.emailUsuario;
                Session["idUsuario"] = respuesta.Dato.idUsuario;

                return RedirectToAction("Index", "Home");
            }
            else
            {


                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }



        [HttpGet]
        public ActionResult RegistrarUsuario()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegistrarUsuario(Usuario entidad)
        {
            var respuesta = modelo.RegistrarUsuario(entidad);

            if (respuesta.Codigo == 0)
                return RedirectToAction("IniciarSesion", "Usuario");
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
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

        [FiltroSeguridad]
        [HttpGet]
        public ActionResult CerrarSesion()
        {
            Session.Clear();
            return RedirectToAction("IniciarSesion", "Usuario");
        }
    }
}