
using System.Configuration;

using System.Net.Http;
using System.Net.Http.Json;

using Web_TrabajoFidelitas.Entidades;


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
        public Confirmacion RegistrarUsuario(Usuario entidad)
        {
            using (var client = new HttpClient())
            {
                url += "Usuarios/RegistrarUsuario";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PostAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Confirmacion>().Result;
                else
                    return null;
            }
        }
       
    }

}
