using Api_TrabajoFidelitas.Entidades;
using Api_TrabajoFidelitas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api_TrabajoFidelitas.Controllers
{
    public class SucursalesController : ApiController
    {

        [HttpGet]
        [Route("Sucursal/ConsultarSucursal")]
        public ConfirmacionSucursal ConsultarSucursal()
        {
            var respuesta = new ConfirmacionSucursal();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var datos = db.ConsultarSucursales().ToList();

                    if (datos.Count > 0)
                    {


                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                        respuesta.Datos = datos;

                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se encontro informacion";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presentó un error en el sistema,InicioSesion";
            }

            return respuesta;
        }
    }
}
