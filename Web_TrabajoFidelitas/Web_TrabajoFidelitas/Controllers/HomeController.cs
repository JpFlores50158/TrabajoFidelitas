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
        [FiltroSeguridad]
        public ActionResult Index()
        {
            return View();
        }

      
    }
}