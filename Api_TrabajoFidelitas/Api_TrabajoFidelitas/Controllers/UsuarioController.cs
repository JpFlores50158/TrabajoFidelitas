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
    public class UsuarioController : ApiController
    {
        [HttpPost]
        [Route("Usuarios/InicioSesion")]
        public ConfirmacionUsuarios IniciarSesionUsuario(Usuario entidad)
        {
            var respuesta = new ConfirmacionUsuarios();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var datos = db.IniciarSesionUsuario(entidad.emailUsuario, entidad.contrasenaUsuario).FirstOrDefault();

                    if (datos != null)
                    {
                     
                      
                            respuesta.Codigo = 0;
                            respuesta.Detalle = string.Empty;
                            respuesta.Dato = datos;
                        
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se pudo validar su información en el inicio sesion";
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
        [Route("Usuarios/RegistrarUsuario")]
        public Confirmacion RegistrarUsuario(Usuario entidad)
        {
            var respuesta = new Confirmacion();

            try
            {
                using (var db = new MotoresBritanicosEntities())
                {
                    var resp = db.RegistrarUsuario(entidad.contrasenaUsuario,entidad.nombreUsuario,entidad.emailUsuario);

                    if (resp > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "Su información ya se encuentra registrada";
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
