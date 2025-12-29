using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace ClasesComunesClassLibrary.Cifrado
{
    public class PasswordHelper
    {
        // Método para cifrar una contraseña
        public static string HashPassword(string plainPassword)
        {
            // Genera el hash con un costo de 12 (por defecto)
            return BCrypt.Net.BCrypt.HashPassword(plainPassword);
        }

        // Método para verificar una contraseña
        public static bool VerifyPassword(string plainPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
        }
    }
}
