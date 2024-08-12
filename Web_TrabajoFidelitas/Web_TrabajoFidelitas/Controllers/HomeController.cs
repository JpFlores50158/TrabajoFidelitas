using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_TrabajoFidelitas.Entidades;
using Web_TrabajoFidelitas.Models;

namespace Web_TrabajoFidelitas.Controllers
{
    public class HomeController : Controller
    {
        SucursalModel modelSu = new SucursalModel();

        [FiltroSeguridad]
        public ActionResult Index()
        {
            CitasModel modelCi = new CitasModel();
            AutomovilModel modelAuto = new AutomovilModel();
            ClienteModel modelCl = new ClienteModel();
            CargarViewBagSucursal();
            MesesDropDown();
            var respuestaCi = modelCi.TraerCita();
            var respAuto = modelAuto.ConsultarAutomoviles();
            var respCl = modelCl.ConsultarClientes();
            ViewBag.CantCitas = respuestaCi.Datos.Count();
            ViewBag.CantAutos = respAuto.Datos.Count();
            ViewBag.CantClientes = respCl.Datos.Count();

            return View();
        }
        private void CargarViewBagSucursal()
        {
            var respuesta = modelSu.ConsultarSucursal();
            var sucursales = new List<SelectListItem>();

            sucursales.Add(new SelectListItem { Text = "Seleccione una sucursal", Value = "" });
            foreach (var item in respuesta.Datos)
                sucursales.Add(new SelectListItem { Text = item.nombreSucursal, Value = item.idSucursal.ToString() });

            ViewBag.Sucursales = sucursales;
        }

        public void MesesDropDown()
        {
            var meses = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "Escoge el Mes" },
                new SelectListItem { Value = "1", Text = "Enero" },
                new SelectListItem { Value = "2", Text = "Febrero" },
                new SelectListItem { Value = "3", Text = "Marzo" },
                new SelectListItem { Value = "4", Text = "Abril" },
                new SelectListItem { Value = "5", Text = "Mayo" },
                new SelectListItem { Value = "6", Text = "Junio" },
                new SelectListItem { Value = "7", Text = "Julio" },
                new SelectListItem { Value = "8", Text = "Agosto" },
                new SelectListItem { Value = "9", Text = "Septiembre" },
                new SelectListItem { Value = "10", Text = "Octubre" },
                new SelectListItem { Value = "11", Text = "Noviembre" },
                new SelectListItem { Value = "12", Text = "Diciembre" }
             };

            ViewBag.Meses = meses;
        }
    }
}