﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_TrabajoFidelitas.Models;

namespace Web_TrabajoFidelitas.Controllers
{
    [FiltroSeguridad]
    public class ReporteController : Controller
    {
        public ActionResult MostrarReportes()
        {
            return View();
        }
        
    }
}