using System.Globalization;

namespace ClasesComunesClassLibrary.Utilerias;

public static  class DateTimeExtensions
{
    public static string ATextoFechaLarga(this DateTimeOffset fechaUtc, string ianaTimeZoneId)
    {
        try
        {
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(ianaTimeZoneId);
            DateTimeOffset fechaLocal = TimeZoneInfo.ConvertTime(fechaUtc, timeZone);
            
            CultureInfo culturaEs = new CultureInfo("es-MX");
            string formato = "dddd d 'de' MMMM 'de' yyyy 'a las' HH:mm 'hrs'";
            string texto = fechaLocal.ToString(formato, culturaEs);

            // Capitaliza la primera letra (ej. "lunes" -> "Lunes")
            return char.ToUpper(texto[0]) + texto.Substring(1);
        }
        catch (TimeZoneNotFoundException)
        {
            return fechaUtc.ToString("dd/MM/yyyy HH:mm");
        }
    }
    /// <summary>
    /// regresa la fecha en la zona horaria
    /// </summary>
    /// <param name="fechaUtc"></param>
    /// <param name="ianaTimeZoneId"></param>
    /// <returns></returns>
    public static DateTimeOffset AFechaLocalEnZonaHoraria(this DateTimeOffset fechaUtc, string ianaTimeZoneId)
    {
        try
        {
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(ianaTimeZoneId);
            DateTimeOffset fechaLocal = TimeZoneInfo.ConvertTime(fechaUtc, timeZone);


            return fechaLocal;
        }
        catch (TimeZoneNotFoundException)
        {
            return fechaUtc;
        }
    }
}