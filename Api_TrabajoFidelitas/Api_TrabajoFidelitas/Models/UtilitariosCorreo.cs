using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Api_TrabajoFidelitas.Models
{
    public class UtilitariosCorreo
    {
        public string EnviarCorreo(string destino, string asunto, string contenido)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress(ConfigurationManager.AppSettings["correoElec"]);
                message.To.Add(new MailAddress(destino));
                message.Subject = asunto;
                message.Body = contenido;
                message.Priority = MailPriority.Normal;
                message.IsBodyHtml = true;

                SmtpClient client = new SmtpClient("smtp.office365.com", 587)
                {
                    Credentials = new NetworkCredential(ConfigurationManager.AppSettings["correoElec"],
                                                          ConfigurationManager.AppSettings["passElec"]),
                    EnableSsl = true
                };

                client.Send(message);
                return "Correo enviado con éxito";
            }
            catch (SmtpException ex)
            {
                // Manejo de error específico de SMTP
                Console.WriteLine("Error al enviar el correo: " + ex.Message);
                if (ex.Message.Contains("OutboundSpamException"))
                {
                    return "El correo ha sido bloqueado por el servidor debido a un posible problema de spam.";
                }
                return $"Error al enviar el correo: {ex.Message}";
            }
            catch (Exception ex)
            {
                // Manejo de cualquier otra excepción
                Console.WriteLine("Ocurrió un error: " + ex.Message);
                return $"Ocurrió un error: {ex.Message}";
            }
        }
    }
}