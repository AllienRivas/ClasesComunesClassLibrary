
using ClasesComunesClassLibrary.DTOs.Mensajeria;
using ClasesComunesClassLibrary.Mesajeria.Interfaces;
using ClasesComunesClassLibrary.Respuestas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ClasesComunesClassLibrary.Mensajeria.ImplementacionGmail
{
    public class Gmail : IMensajeriaCorreoElectronico
    {
        public async Task<RespuestaSimple> MandarMensaje(MensajeCorreoDTO mensajeCorreo)
        {
            try
            {
                if (mensajeCorreo.cuentaOrigen == null)
                {
                    return RespuestaSimple.Error("No se ha configurado la cuenta de correo origen");
                }


                if (mensajeCorreo.ListaDestinatarios?.Count == 0)
                {
                    return RespuestaSimple.Error("No se ham definido ningun destinatario");
                }


                MailMessage mail = new MailMessage(new MailAddress(mensajeCorreo.cuentaOrigen.cuentaOrigen, mensajeCorreo.cuentaOrigen.cuentaOrigen), new MailAddress(mensajeCorreo.ListaDestinatarios.First(), mensajeCorreo.ListaDestinatarios.First()));

                mail.Body = mensajeCorreo.ContenidoMensaje;
                mail.Subject = mensajeCorreo.TituloMenesaje;
                mail.IsBodyHtml = mensajeCorreo.ContenidoMensaje.Contains("<") && mensajeCorreo.ContenidoMensaje.Contains("/>");

                mail.BodyEncoding = UTF8Encoding.UTF8;
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                SmtpClient client = new SmtpClient();

                client.Port = mensajeCorreo.cuentaOrigen.puerto;

                if (mensajeCorreo.cuentaOrigen.SSL == true)
                    client.EnableSsl = true;

                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = mensajeCorreo.cuentaOrigen.smtpHost;


                client.Credentials = new NetworkCredential(mensajeCorreo.cuentaOrigen.cuentaOrigen, mensajeCorreo.cuentaOrigen.contraseña);


                //Se forza a ignaora el certificado 04/04/2025 con nuevo servidor de correo
                ServicePointManager.ServerCertificateValidationCallback =
                  (sender, cert, chain, sslPolicyErrors) => true;

                client.Send(mail);


                return RespuestaSimple.Exito("Correo enviado correctamente");




            }
            catch (Exception e)
            {

                return RespuestaSimple.Error("Hubo un error al enviar el correo" + e.Message);

            }
        }

    }
}
