using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_TrabajoFidelitas.Models;
using Web_TrabajoFidelitas.Entidades;
using System.Reflection;

namespace Web_TrabajoFidelitas.Controllers
{
    [FiltroSeguridad]
    public class ReporteController : Controller
    {
        private readonly ReporteModel _reporteModel;
        ReporteModel modelRe = new ReporteModel();

        public ReporteController()
        {
            _reporteModel = new ReporteModel();
        }

        public async Task<ActionResult> MostrarReportes()
        {
           
            CitasModel modelCi = new CitasModel();
            AutomovilModel modelAuto = new AutomovilModel();
            ClienteModel modelCl = new ClienteModel();


            var respuesta = modelCi.CitaSemanaActual();
            if (respuesta.Codigo == 0)
            {
                var respuestaCi = modelCi.TraerCita();
                var respAuto = modelAuto.ConsultarAutomoviles();
                var respCl = modelCl.ConsultarClientes();
                ViewBag.CantCitas = respuestaCi.Datos.Count();
                ViewBag.CantAutos = respAuto.Datos.Count();
                ViewBag.CantClientes = respCl.Datos.Count();

                return View(respuesta.Datos);
            }
            else
            {
                var respuestaCi = modelCi.TraerCita();
                var respAuto = modelAuto.ConsultarAutomoviles();
                var respCl = modelCl.ConsultarClientes();
                ViewBag.CantCitas = respuestaCi.Datos.Count();
                ViewBag.CantAutos = respAuto.Datos.Count();
                ViewBag.CantClientes = respCl.Datos.Count();
                return View(new List<Citas>());
            }

            return View();
        }


        // PRIMER ACTION DE DOCKER / PARA TRAER TODAS LAS CITAS
        // =================================================================
        [HttpGet]
        public async Task<ActionResult> TraerTodoDocker()
        {
            try
            {
                var respuesta = await _reporteModel.ObtenerTodasCitas();
                if (respuesta != null)
                {
                    // Return the file as a download
                    return File(respuesta, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "CitasTotales.xlsx");
                }
                else
                {
                    return new HttpStatusCodeResult(400, "No se pudo generar el reporte.");
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones, por ejemplo, loguear el error
                return new HttpStatusCodeResult(500, $"Ocurrió un error: {ex.Message}");
            }
        }

        // SEGUNDO ACTION DE DOCKER / PARA TRAER TODAS LAS CITAS SEGUN LA SUCURSAL
        // =================================================================
        [HttpGet]
        public async Task<ActionResult> TraerTodoDockerSegunSucursal(long idSucursal)
        {
            try
            {
                var respuesta = await _reporteModel.ObtenerTodasCitasSegunSucursal(idSucursal);
                if (respuesta != null)
                {
                    // Return the file as a download
                    return File(respuesta, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "CitasTotales.xlsx");
                }
                else
                {
                    return new HttpStatusCodeResult(400, "No se pudo generar el reporte.");
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones, por ejemplo, loguear el error
                return new HttpStatusCodeResult(500, $"Ocurrió un error: {ex.Message}");
            }
        }

        // TERCER ACTION DE DOCKER / PARA TRAER TODAS LAS CITAS SEGUN EL NUMERO DEL MES
        // =================================================================
        [HttpGet]
        public async Task<ActionResult> TraerTodoDockerSegunMes(int mes)
        {
            try
            {
                var respuesta = await _reporteModel.ObtenerTodasCitasSegunMes(mes);
                if (respuesta != null)
                {
                    // Return the file as a download
                    return File(respuesta, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "CitasTotales.xlsx");
                }
                else
                {
                    return new HttpStatusCodeResult(400, "No se pudo generar el reporte.");
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones, por ejemplo, loguear el error
                return new HttpStatusCodeResult(500, $"Ocurrió un error: {ex.Message}");
            }
        }

        // CUARTO ACTION DE DOCKER / PARA TRAER TODAS LAS CITAS SEGUN UNA FECHA EN ESPECIFICO
        // =================================================================
        [HttpGet]
        public async Task<ActionResult> TraerTodoDockerSegunFecha(DateTime fecha)
        {
            try
            {
                var respuesta = await _reporteModel.ObtenerTodasCitasSegunFecha(fecha);
                if (respuesta != null)
                {
                    // Return the file as a download
                    return File(respuesta, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "CitasTotales.xlsx");
                }
                else
                {
                    return new HttpStatusCodeResult(400, "No se pudo generar el reporte.");
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones, por ejemplo, loguear el error
                return new HttpStatusCodeResult(500, $"Ocurrió un error: {ex.Message}");
            }
        }
        [HttpPost]
        public ActionResult Grafico()
        {
            var data = modelRe.Grafico();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Grafico2()
        {
            var data = modelRe.Grafico2();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Grafico3()
        {
            var data = modelRe.Grafico3();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Grafico4(DateTime fechaInicio, DateTime fechaFin)
        {
            var data = modelRe.Grafico4(fechaInicio, fechaFin);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}