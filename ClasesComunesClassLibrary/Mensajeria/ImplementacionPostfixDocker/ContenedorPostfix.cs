using System.Net.Mail;
using ClasesComunesClassLibrary.DTOs.Mensajeria;
using ClasesComunesClassLibrary.Mesajeria.Interfaces;
using ClasesComunesClassLibrary.Respuestas;

namespace ClasesComunesClassLibrary.Mensajeria.ImplementacionPostfixDocker;

public class ContenedorPostfix : IMensajeriaCorreoElectronico
{
    public async Task<RespuestaSimple> MandarMensaje(MensajeCorreoDTO mensajeCorreo)
    {
        try
        {
            if (mensajeCorreo.cuentaOrigen == null)
            {
                return RespuestaSimple.Error("No se ha configurado la cuenta de correo origen");
            }

            if (mensajeCorreo.cuentaOrigen.cuentaOrigen == null)
            {
                return RespuestaSimple.Error("No se ha configurado la cuenta de correo origen");
            }
            
            
           


            if (mensajeCorreo.ListaDestinatarios?.Count == 0)
            {
                return RespuestaSimple.Error("No se ham definido ningun destinatario");
            }

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(mensajeCorreo.cuentaOrigen.cuentaOrigen,mensajeCorreo.cuentaOrigen.Displayname);
            mail.To.Add(mensajeCorreo.ListaDestinatarios.First());
            mail.Subject = mensajeCorreo.TituloMenesaje;
            mail.Body = mensajeCorreo.ContenidoMensaje;
            mail.IsBodyHtml = mensajeCorreo.ContenidoMensaje.Contains("<") && mensajeCorreo.ContenidoMensaje.Contains("/>");; // O tu lógica de detección

            using (SmtpClient client = new SmtpClient())
            {
                // IMPORTANT: El host debe ser el nombre del servicio en tu docker-compose
                // o la IP del contenedor 'galeno_mail'
                client.Host = mensajeCorreo.cuentaOrigen.smtpHost;
                client.Port = 25; // El puerto estándar de Postfix dentro del contenedor

                // Al estar en la misma red de Docker, no necesitas SSL ni Credenciales
                client.EnableSsl = false;
                client.UseDefaultCredentials = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                // Enviamos de forma asíncrona ya que tu método es Task
                await client.SendMailAsync(mail);
            }

            return RespuestaSimple.Exito("Correo enviado correctamente a través del relay local");
        }
        catch (Exception e)
        {
            return RespuestaSimple.Error("Error en relay local: " + e.Message);
        }
    }
}