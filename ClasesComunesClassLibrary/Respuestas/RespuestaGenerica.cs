using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesComunesClassLibrary.Respuestas
{
    public class RespuestaGenerica<T>
    {

        /// <summary>
        /// Datos de la respuesta.
        /// </summary>
        public T data { get; }  = default;

        /// <summary>
        /// Valor que indica si la petición fue exitosa.
        /// </summary>
        public bool error { get; set; }


        /// <summary>
        /// Un mensaje entendible para el usuario final respecto a la respuesta.
        /// Por ejemplo, en caso de un error se puede indicar de forma generl el 
        /// porqué se presentó ese error o falló la petición.
        /// </summary>
        public string mensaje { get; set; }

        public RespuestaGenerica( bool error, string mensaje, T data)
        {
            this.data = data;
            this.error = error;
            this.mensaje = mensaje;
        }

        /// <summary>
        /// Crea un RespuestaGenerica de tipo T que represente una respuesta exitosa.
        /// </summary>
        /// <param name="data">Datos a regresar en el response.</param>
        /// <param name="mensaje">
        /// Algún mensaje indicando que se realizó exitosamente la petición/request.
        /// </param>
        public static RespuestaGenerica<T> Ok(T data, string mensaje = null)
        {         
            return  new RespuestaGenerica<T>(error: false, data: data, mensaje: mensaje); 
        }

        /// <summary>
        /// Crea un RespuestaGenerica de tipo T que representa una respuesta
        /// con error, que no se realizó correctamente.
        /// </summary>
        /// <param name="mensaje">
        /// Mensaje de error para el usuario final indicando que fue lo que salió
        /// mal en la petición.
        /// </param>
        /// <param name="errors">
        /// Mensajes de error más detallados de que fue lo que salió mal.
        /// </param>
        public static RespuestaGenerica<T> Error(string mensaje)
        {
          return  new RespuestaGenerica<T>(error: true, mensaje: mensaje, data: default);
        }




    }
}
