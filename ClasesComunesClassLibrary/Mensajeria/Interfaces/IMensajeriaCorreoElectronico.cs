using ClasesComunesClassLibrary.DTOs.Mensajeria;
using ClasesComunesClassLibrary.Respuestas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesComunesClassLibrary.Mesajeria.Interfaces
{
    public interface IMensajeriaCorreoElectronico
    {
        Task<RespuestaSimple> MandarMensaje(MensajeCorreoDTO mensajeCorreo);
    }
}
