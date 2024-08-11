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
    public class ServiciosController : ApiController
    {
        [HttpGet]
        [Route("Servicio/ConsultarServicios")]
        public ConfirmacionServicios ConsultarServicios()


        {
            var respuesta = new ConfirmacionServicios();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var datos = db.sp_GetServicios().ToList();

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

        [HttpPost]
        [Route("Servicio/AgregarServicios")]
        public ConfirmacionServicios AgregarServicio(Servicios entidad)
        {
            var respuesta = new ConfirmacionServicios();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var resp = db.AgregarServicio(entidad.NombreServicio, entidad.PrecioServicio, entidad.DescripcionServicio);

                    if (resp > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se pudo agregar";
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

        [Route("Servicio/TraerServicio")]
        [HttpGet]
        public ConfirmacionServicios TraerServicio(long id)
        {
            var respuesta = new ConfirmacionServicios();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var datos = db.ObtenerServicioPorId(id).FirstOrDefault();

                    if (datos != null)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                        respuesta.Dato = datos;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se encontró la información respectiva";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presentó un error en el sistema";
            }

            return respuesta;
        }

        [HttpPut]
        [Route("Servicio/ActualizarServicios")]
        public ConfirmacionServicios ActualizarServicio(Servicios entidad)
        {
            var respuesta = new ConfirmacionServicios();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var resp = db.ActualizarServicio(entidad.IdServicio,entidad.NombreServicio,entidad.PrecioServicio,entidad.DescripcionServicio,entidad.Estado);

                    if (resp > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se pudo agregar";
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

        [HttpDelete]
        [Route("Servicio/EliminarServicios")]
        public ConfirmacionServicios EliminarServicio(long id)
        {
            var respuesta = new ConfirmacionServicios();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var resp = db.InactivarServicio(id);

                    if (resp > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "El producto no se pudo eliminar";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presentó un error en el sistema";
            }

            return respuesta;
        }
    }
}

