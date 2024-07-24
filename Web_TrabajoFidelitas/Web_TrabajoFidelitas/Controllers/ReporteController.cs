using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_TrabajoFidelitas.Models;

namespace Web_TrabajoFidelitas.Controllers
{
    public class ReporteController : Controller
    {
        public async Task<ActionResult> MostrarReportes()
        {
            ReporteModel model = new ReporteModel();

            try
            {
                var reporteBytes = await model.ObtenerReporteAsync();

                return File(reporteBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Reporte.xlsx");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Error");
            }
        }
    }
}