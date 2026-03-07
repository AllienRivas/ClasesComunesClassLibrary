

using System;
using System.Globalization;


namespace ClasesComunesClassLibrary.Utilerias;
public class CurpHelper
{
    public static DateOnly? ExtraerFechaNacimiento(string curp)
    {
        // 1. Validación de longitud mínima (16 caracteres para alcanzar el dígito del siglo)
        if (string.IsNullOrWhiteSpace(curp) || curp.Length < 16) return null;

        curp = curp.ToUpper();

        try
        {
            // Extraer YYMMDD (posiciones 5 a 10, índice 4)
            string fechaFragmento = curp.Substring(4, 6);
            
            // Intentar parsear a DateTime primero para validar la existencia de la fecha
            if (!DateTime.TryParseExact(fechaFragmento, "yyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaBase))
            {
                return null;
            }

            int año = fechaBase.Year;

            // 2. Lógica del Siglo según el carácter 17 (índice 16)
            // Si el carácter 17 es una letra (A-Z), nació en el siglo XXI (2000+)
            // Si es un número (0-9), nació en el siglo XX (1900+)
            char digitoSiglo = curp[16];
            bool esSigloXXI = !char.IsDigit(digitoSiglo);

            if (esSigloXXI && año < 2000)
            {
                año += 100; // Ajustamos de 19xx a 20xx
            }
            else if (!esSigloXXI && año >= 2000)
            {
                año -= 100; // Ajustamos de 20xx a 19xx (por si el sistema parseó mal)
            }

            return new DateOnly(año, fechaBase.Month, fechaBase.Day);
        }
        catch
        {
            return null;
        }
    }
}