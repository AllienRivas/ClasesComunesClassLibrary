using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesComunesClassLibrary.Mesajeria.Interfaces;

namespace ClasesComunesClassLibrary.DTOs.Mensajeria
{
    public class CuentaCorreoOrigenDTO : ICuentaCorreoOrigen
    {
        public string cuentaOrigen { get; set; }
        public string contraseña { get; set; }
        public string smtpHost { get; set; }
        public int puerto { get; set; }
        public bool SSL { get; set; }

        public string Displayname { get; set; }
    }
}
