using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Web;
using Web_TrabajoFidelitas.Entiadades;
using static Web_TrabajoFidelitas.Entiadades.Usuario;

namespace Web_TrabajoFidelitas.Models
{
    public class UsuarioModel
    {
        public string url = ConfigurationManager.AppSettings["urlWebApi"];
        public ConfirmacionUsuarios InicioSesion(Usuario entidad)
        {
            using (var client = new HttpClient())
            {
                url += "Usuarios/InicioSesion";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PostAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionUsuarios>().Result;
                else
                    return null;
            }
        }

    }
}