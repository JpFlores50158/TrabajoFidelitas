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
    public class CitasController : ApiController
    {
        [HttpGet]
        [Route("Citas/TraerCita")]
        public ConfirmacionCita TraerCita()
        {
            var respuesta = new ConfirmacionCita();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var datos = db.ConsultarCitas().ToList();

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

        [Route("Citas/ConsultarCita")]
        [HttpGet]
        public ConfirmacionCita ConsultarCita(long id)
        {
            var respuesta = new ConfirmacionCita();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var datos = db.ConsultarCita(id).FirstOrDefault();

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
        [Route("Citas/EditarCita")]
        public ConfirmacionCita EditarCita(Cita entidad)
        {
            var respuesta = new ConfirmacionCita();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var resp = db.EditarCita(entidad.idCita, entidad.idCliente, entidad.idAutomovil, entidad.idSucursal, entidad.idServicio, entidad.fechaHora, entidad.comentarios, entidad.estado);

                    if (resp > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se pudo editar";
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


        [HttpDelete]
        [Route("Citas/sp_EliminarCita")]
        public ConfirmacionCita sp_EliminarCita(long id)
        {
            var respuesta = new ConfirmacionCita();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {

                    var resp = db.sp_EliminarCita(id);

                    if (resp > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = "Cita inactivada exitosamente";
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se pudo inactivar la Cita";
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
        [HttpPost]
        [Route("Citas/AgregarCita")]
        public ConfirmacionCita AgregarCita(Cita entidad)
        {
            var respuesta = new ConfirmacionCita();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var resp = db.AgregarCita(entidad.idCliente, entidad.idAutomovil, entidad.idSucursal, entidad.idServicio,entidad.fechaHora, entidad.comentarios);

                    if (resp > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se pudo editar";
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

        [HttpGet]
        [Route("Citas/ConsultarCitasPorSucursal")]
        public ConfirmacionCita ConsultarCitasPorSucursal(int idSucursal)
        {
            var respuesta = new ConfirmacionCita();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var datos = db.ConsultarCitasporSucursal(idSucursal).ToList();

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
        [HttpDelete]
        [Route("Citas/EliminarCitaTotal")]
        public ConfirmacionCita EliminarCitaTotal(long id)
        {
            var respuesta = new ConfirmacionCita();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {

                    var resp = db.EliminarCitaTotal(id);

                    if (resp > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = "Cita inactivada exitosamente";
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se pudo inactivar la Cita";
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
