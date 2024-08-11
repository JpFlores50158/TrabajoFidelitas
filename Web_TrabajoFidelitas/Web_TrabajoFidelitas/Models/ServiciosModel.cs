using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;
using Web_TrabajoFidelitas.Entidades;

namespace Web_TrabajoFidelitas.Models
{
    public class ServiciosModel
    {
        // ---------------------- MOSTRAR -----------------------
        public ConfirmacionServicios ConsultarServicios()
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Servicio/ConsultarServicios";
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionServicios>().Result;
                else
                    return null;
            }
        }


        public ConfirmacionServicios AgregarServicio(Servicios entidad)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Servicio/AgregarServicios";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PostAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionServicios>().Result;
                else
                    return null;
            }
        }

        // --------------------- ACTUALIZAR ---------------------
        public ConfirmacionServicios ActualizarServicio(Servicios entidad)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Servicio/ActualizarServicios";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PutAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionServicios>().Result;
                else
                    return null;
            }
        }

        public ConfirmacionServicios TraerServicio(long id)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Servicio/TraerServicio?id=" + id;
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionServicios>().Result;
                else
                    return null;
            }
        }

        // ---------------------- ELIMINAR ----------------------
        public ConfirmacionServicios EliminarServicio(long id)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Servicio/EliminarServicios?id=" + id;
                var respuesta = client.DeleteAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionServicios>().Result;
                else
                    return null;
            }
        }
    }
}
