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
    public class SucursalModel
    {
        public ConfirmacionSucursal ConsultarSucursal()
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Sucursal/ConsultarSucursal";
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionSucursal>().Result;
                else
                    return null;
            }
        }
    }
}