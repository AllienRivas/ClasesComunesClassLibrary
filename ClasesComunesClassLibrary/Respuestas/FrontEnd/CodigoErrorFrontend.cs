namespace ClasesComunesClassLibrary.Respuestas;

public enum CodigoErrorFrontend
{
       Ninguno = 0,

        // --- 100-199: ACCESO Y SEGURIDAD (Críticos - Bloqueantes) ---
        CredencialesInvalidas = 100,   // no se proporcionaron credenciales validas
        SesionExpirada = 101,          // Redirigir a Login
        PermisosInsuficientes = 102,   // Usuario no tiene el rol necesario
        TokenInvalido = 103,           // Error de firma de JWT o similar
        UsuarioBloqueado = 104,        // Por reintentos fallidos
        DobleFactorRequerido = 105,    // Necesita validación extra (OTP/SMS)
        IpNoAutorizada = 106,          // Restricción por ubicación física

        // --- 200-299: VALIDACIÓN DE DATOS (Leves - Con Timer) ---
        DatosInvalidos = 200,          // Errores de formato (Regex, nulos)
        CampoRequerido = 201,          // Olvidó llenar un input obligatorio
        LongitudExcedida = 202,        // Texto muy largo para la base de datos
        FormatoArchivoNoValido = 203,  // Subió un .exe en vez de .pdf
        ArchivoMuyPesado = 204,        // Superó el límite de MB

        // --- 300-399: LÓGICA DE NEGOCIO (Intermedios - Requieren Confirmación) ---
        ElementoDuplicado = 300,       // Ya existe un registro con ese DNI/Email
        StockInsuficiente = 301,       // No hay productos para vender
        SaldoInsuficiente = 302,       // No tiene fondos
        DependenciaActiva = 303,       // No se puede borrar porque tiene hijos vinculados
        OperacionNoPermitida = 304,    // Ej: Intentar cancelar una factura ya pagada
        LimiteAlcanzado = 305,         // Ej: Máximo de 5 usuarios por cuenta

        // --- 400-499: INTEGRACIONES EXTERNAS (Advertencias) ---
        ErrorServicioExterno = 400,    // El API del SAT o de Pagos falló
        TimeoutExterno = 401,          // El proveedor tardó demasiado
        ErrorEnPasarelaPagos = 402,    // Tarjeta rechazada o error de banco

        // --- 500-599: INFRAESTRUCTURA Y CRÍTICOS (Críticos - Muy fijos) ---
        ErrorBaseDeDatos = 500,        // Timeout o caída del SQL
        ServicioNoDisponible = 501,    // El microservicio está offline
        ErrorDesconocido = 599,        // Catch (Exception ex) genérico
        MantenimientoProgramado = 503  // Sistema en modo lectura solamente
}