using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Web_TrabajoFidelitas.Entidades;

namespace Web_TrabajoFidelitas.Models
{
    public class ReporteModel
    {
        public async Task<byte[]> ObtenerReporteAsync()
        {
            using (var client = new HttpClient())
            {
                // Configura la URL del endpoint
                string url = "http://localhost:5024/api/conexionDocker/TotalCitas";

                // Realiza la solicitud GET al endpoint
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    // Lee el contenido del archivo como un array de bytes
                    return await response.Content.ReadAsByteArrayAsync();
                }
                else
                {
                    // Maneja el caso en que la solicitud no fue exitosa
                    throw new Exception($"Error al obtener el reporte: {response.ReasonPhrase}");
                }
            }
        }

        // PRIMERA ACTION DE DOCKER
        public async Task<byte[]> ObtenerTodasCitas()
        {
            using (var client = new HttpClient())
            {
                // Configura la URL del endpoint
                string url = "http://localhost:5024/api/Reporte/conexionDocker/TotalCitas";

                // Realiza la solicitud GET al endpoint
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    // Lee el contenido del archivo como un array de bytes
                    return await response.Content.ReadAsByteArrayAsync();
                }
                else
                {
                    // Maneja el caso en que la solicitud no fue exitosa
                    throw new Exception($"Error al obtener el reporte: {response.ReasonPhrase}");
                }
            }
        }

        // SEGUNDA ACTION DE DOCKER
        public async Task<byte[]> ObtenerTodasCitasSegunSucursal(long idSucursal)
        {
            using (var client = new HttpClient())
            {
                // Configura la URL del endpoint
                string url = "http://localhost:5024/api/Reporte/conexionDocker/TotalCitasPorSucursal?idSucursal=" + idSucursal;

                // Realiza la solicitud GET al endpoint
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    // Lee el contenido del archivo como un array de bytes
                    return await response.Content.ReadAsByteArrayAsync();
                }
                else
                {
                    // Maneja el caso en que la solicitud no fue exitosa
                    throw new Exception($"Error al obtener el reporte: {response.ReasonPhrase}");
                }
            }
        }

        // TERCERA ACTION DE DOCKER
        public async Task<byte[]> ObtenerTodasCitasSegunMes(int mes)
        {
            using (var client = new HttpClient())
            {
                // Configura la URL del endpoint
                string url = "http://localhost:5024/api/Reporte/conexionDocker/TotalCitasPorMes?mes=" + mes;

                // Realiza la solicitud GET al endpoint
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    // Lee el contenido del archivo como un array de bytes
                    return await response.Content.ReadAsByteArrayAsync();
                }
                else
                {
                    // Maneja el caso en que la solicitud no fue exitosa
                    throw new Exception($"Error al obtener el reporte: {response.ReasonPhrase}");
                }
            }
        }

        // CUARTA ACTION DE DOCKER
        public async Task<byte[]> ObtenerTodasCitasSegunFecha(DateTime fecha)
        {
            using (var client = new HttpClient())
            {
                // Configura la URL del endpoint
                string url = "http://localhost:5024/api/Reporte/conexionDocker/TotalCitasPorSemana?fecha=" + fecha;

                // Realiza la solicitud GET al endpoint
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    // Lee el contenido del archivo como un array de bytes
                    return await response.Content.ReadAsByteArrayAsync();
                }
                else
                {
                    // Maneja el caso en que la solicitud no fue exitosa
                    throw new Exception($"Error al obtener el reporte: {response.ReasonPhrase}");
                }
            }
        }

    }
}