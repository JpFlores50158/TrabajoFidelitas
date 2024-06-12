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
        public ConfirmacionUsuarios IniciarSesionUsuario(Usuarios entidad)
        {
            var respuesta = new ConfirmacionUsuarios();

            try
            {
                using (var db = new ProyPrograAvanEntities())
                {
                    var datos = db.IniciarSesionUsuario(entidad.correo_electronico, entidad.contrasena).FirstOrDefault();

                    if (datos != null)
                    {
                        if (datos.Temporal && DateTime.Now > datos.Vencimiento)
                        {
                            respuesta.Codigo = -1;
                            respuesta.Detalle = "Su contraseña temporal ha caducado";
                        }
                        else
                        {
                            respuesta.Codigo = 0;
                            respuesta.Detalle = string.Empty;
                            respuesta.Dato = datos;
                        }
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
    }
}
