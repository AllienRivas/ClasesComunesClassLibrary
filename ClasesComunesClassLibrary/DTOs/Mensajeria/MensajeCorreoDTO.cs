using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesComunesClassLibrary.DTOs.Mensajeria
{
    public  class MensajeCorreoDTO
    {

        /// <summary>
        /// Lista de cadenas de los destinatarios
        /// </summary>
        public List<string> ListaDestinatarios { get; set; }

        /// <summary>
        /// Titulo del mensaje
        /// </summary>
        public string TituloMenesaje { get; set; }

        /// <summary>
        /// Cuerpo de mensaje del correo
        /// </summary>
        public string ContenidoMensaje { get; set; }

        /// <summary>
        /// Propiedada con una lista de rutas completas de archivos que se ajuntaran al mensaje
        /// Ej.
        ///    c:/MiArchivo.txt
        ///    d:/Archvio2.docx
        /// </summary>
        public List<string> ListaArchivosAdjuntos { get; set; }


        public CuentaCorreoOrigenDTO cuentaOrigen { get; set; }

    }
}
