namespace ClasesComunesClassLibrary.Respuestas;

public class RespuestaGenericaFrontEnd<T> : RespuestaGenerica<T>
{
    /// <summary>
    /// Si es true, el SweetAlert debe mostrar el botón de confirmar y no cerrarse solo.
    /// Si es false, se puede usar el timer.
    /// </summary>
    public bool EsCritico { get; set; }

    /// <summary>
    /// Codigo de error para retornar al frontend
    /// </summary>
    public CodigoErrorFrontend CodigoErrorFrontend { get; set; }

   
    public RespuestaGenericaFrontEnd(bool error, string mensaje, T data, bool esErrorCritico, CodigoErrorFrontend codigoErrorFrontend ) 
        : base(error, mensaje, data)
    {
        this.EsCritico = esErrorCritico;
        this.CodigoErrorFrontend = codigoErrorFrontend;
    }
    
    /// <summary>
    /// Método estático para errores que requieren atención inmediata (fijos).
    /// </summary>
    public static RespuestaGenericaFrontEnd<T> ErrorCritico(string mensaje, CodigoErrorFrontend  codigoErrorFrontend)
    {
        return new RespuestaGenericaFrontEnd<T>(error: true, mensaje: mensaje, data: default, esErrorCritico: true,  codigoErrorFrontend);
    }
    
    /// <summary>
    /// Método estático para errores leves (con timer).
    /// </summary>
    public static RespuestaGenericaFrontEnd<T> ErrorNormal(string mensaje, CodigoErrorFrontend  codigoErrorFrontend)
    {
        return new RespuestaGenericaFrontEnd<T>(error: true, mensaje: mensaje, data: default, esErrorCritico: false,  codigoErrorFrontend);
    }
}