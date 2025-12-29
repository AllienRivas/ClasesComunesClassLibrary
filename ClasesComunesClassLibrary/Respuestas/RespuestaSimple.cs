using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesComunesClassLibrary.Respuestas
{
    /// <summary>
    /// Clase para representar una respuesta simple a un proceso
    /// </summary>
    public class RespuestaSimple
    {
        /// <summary>
        /// Propiedad para retornar si el proceso ocurrio con error o no
        /// </summary>
        public bool error { get; set; }

        /// <summary>
        /// Propiedad para retornar un mensaje
        /// </summary>
        public string mensaje { get; set; }


        /// <summary>
        /// Metodo para regresar una clase de respuesta exitosa con un mensaje
        /// </summary>
        /// <param name="mensaje">
        /// Mensaje de exito del proceso
        /// </param>
        /// <returns>RespuestaSimple con éxito</returns>
        public static RespuestaSimple Exito(string mensaje)
        {
            return new RespuestaSimple() { error = false, mensaje = mensaje };
        }

        /// <summary>
        /// Metodo para regresar una clase de respuesta fallida con un mensaje
        /// </summary>
        /// <param name="mensaje">
        /// Mensaje del error del proceso
        /// </param>
        /// <returns>RespuestaSimple con éxito</returns>
        public static RespuestaSimple Error(string mensaje)
        {
            return new RespuestaSimple() { error = true, mensaje = mensaje };
        }

    }
}
