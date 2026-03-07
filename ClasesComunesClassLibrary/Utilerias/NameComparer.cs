using System.Globalization;
using System.Text;

namespace ClasesComunesClassLibrary.Utilerias;

 public static class NameComparer
    {
   
        public static double GetSimilarity(string s, string t)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t)) return 0;
            if (s == t) return 1.0;

            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            for (int i = 0; i <= n; d[i, 0] = i++) ;
            for (int j = 0; j <= m; d[0, j] = j++) ;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;
                    d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1), d[i - 1, j - 1] + cost);
                }
            }

            // Calculamos el porcentaje: 1.0 es idéntico, 0.0 es totalmente diferente
            return 1.0 - ((double)d[n, m] / Math.Max(s.Length, t.Length));
        }
        
        public static bool ValidateOfficialName(string userInput, string officialSource, out string errorMessage)
        {
            errorMessage = string.Empty;
    
            // Normalizamos ambos (usando el método NormalizeString del paso anterior)
            string cleanUser = NormalizeString(userInput);
            string cleanOfficial = NormalizeString(officialSource);

            double similarity = GetSimilarity(cleanUser, cleanOfficial);

            if (similarity >= 0.95) // Casi perfecto
            {
                return true; 
            }
            else if (similarity >= 0.70) // Aceptable pero con advertencia opcional
            {
                return true;
            }
            else
            {
                errorMessage = $"El nombre ingresado no coincide suficientemente con el registro oficial (Similitud: {similarity:P0}).";
                return false;
            }
        }
        
        private static string NormalizeString(string text)
        {
            // Elimina espacios y convierte a minúsculas
            string temp = text.Replace(" ", "").ToLowerInvariant();

            // Separa los caracteres de sus acentos (FormD)
            string normalizedString = temp.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            foreach (char c in normalizedString)
            {
                // Solo conserva caracteres que no sean "marcas de acento"
                UnicodeCategory category = CharUnicodeInfo.GetUnicodeCategory(c);
                if (category != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }

            // Regresa a la forma normal compacta
            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
    }