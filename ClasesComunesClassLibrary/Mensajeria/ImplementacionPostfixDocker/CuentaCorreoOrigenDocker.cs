using ClasesComunesClassLibrary.Mesajeria.Interfaces;

namespace ClasesComunesClassLibrary.Mensajeria.ImplementacionPostfixDocker;

public class CuentaCorreoOrigenDocker:ICuentaCorreoOrigen
{
    public string cuentaOrigen { get; set; }
    public string contraseña { get; set; }
    public string smtpHost { get; set; }
    public int puerto { get; set; }
    public bool SSL { get; set; }
    public string Displayname { get; set; }

    
}