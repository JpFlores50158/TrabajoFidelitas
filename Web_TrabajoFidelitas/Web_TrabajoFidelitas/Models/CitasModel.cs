using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using Web_TrabajoFidelitas.Entidades;

namespace Web_TrabajoFidelitas.Models
{
        public class CitasModel
        {
            public ConfirmacionCita TraerCita()
            {
                using (var client = new HttpClient())
                {
                    string url = ConfigurationManager.AppSettings["urlWebApi"] + "Citas/TraerCita";
                    var respuesta = client.GetAsync(url).Result;

                    if (respuesta.IsSuccessStatusCode)
                        return respuesta.Content.ReadFromJsonAsync<ConfirmacionCita>().Result;
                    else
                        return null;
                }
            }

         public ConfirmacionCita ConsultarCita(long id)
            {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Citas/ConsultarCita?id=" + id;
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionCita>().Result;
                else
                    return null;
            }
         }

        public ConfirmacionCita Editarcita(Citas entidad)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Citas/EditarCita";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PutAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionCita>().Result;
                else
                    return null;
            }
        }

        public ConfirmacionCita sp_EliminarCita(long id)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Citas/sp_EliminarCita?id=" + id;
                var respuesta = client.DeleteAsync(url).Result;
                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionCita>().Result;
                else
                    return null;
            }
        }


    }

       
}