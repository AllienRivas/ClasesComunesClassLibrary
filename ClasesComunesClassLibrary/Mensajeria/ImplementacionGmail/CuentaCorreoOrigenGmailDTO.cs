using ClasesComunesClassLibrary.Mesajeria.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ClasesComunesClassLibrary.Mensajeria.ImplementacionGmail;




public class CuentaCorreoOrigenGmailDTO:ICuentaCorreoOrigen
{
    private readonly IConfiguration _configuration;

    public CuentaCorreoOrigenGmailDTO(IConfiguration configuration)
    {
        _configuration = configuration;

        this.cuentaOrigen = _configuration["CustomSettings:cuentaOrigen"];
        this.contraseña = _configuration["CustomSettings:constrasenaApp"];
        this.puerto = int.Parse(_configuration["CustomSettings:puerto"] ?? "0");
        this.smtpHost = _configuration["CustomSettings:smtpHost"];
        this.SSL = bool.Parse(_configuration["CustomSettings:SSL"] ?? "false");
        this.Displayname = $"{_configuration["CustomSettings:displayname"]}";
        
    }


    public string cuentaOrigen { get; set; }
    public string contraseña { get; set; }
    public string smtpHost { get; set; }
    public int puerto { get; set; }
    public bool SSL { get; set; }
    public string Displayname { get; set; }
}