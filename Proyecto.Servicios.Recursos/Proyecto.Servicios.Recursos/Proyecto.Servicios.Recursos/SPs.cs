namespace Proyecto.Servicios.Recursos
{
    public static class SPs
    {
        /// <summary>
        /// Listar historial de reservas.
        /// </summary>
        public const string ListarHistorialReservas = "sp_ListarHistorialReservas";

        /// <summary>
        /// Cancelar reservas.
        /// </summary>
        public const string CancelarReserva = "sp_CancelarReserva";

        /// <summary>
        /// Completar reservas vencidas.
        /// </summary>
        public const string CompletarReservasVencidas = "sp_CompletarReservasVencidas";

        /// <summary>
        /// Consultar disponibilidad de recurso.
        /// </summary>
        public const string ConsultarDisponibilidadRecurso = "sp_ConsultarDisponibilidadRecurso";

        /// <summary>
        /// Crear reservas.
        /// </summary>
        public const string CrearReserva = "sp_CrearReserva";

        /// <summary>
        /// Listar Recursos.
        /// </summary>
        public const string ListarRecursos = "sp_ListarRecursos";

        /// <summary>
        /// Obtener Catredrativo por usuario.
        /// </summary>
        public const string ObtenerCatedraticoPorUsuario = "sp_ObtenerCatedraticoPorUsuario";

        /// <summary>
        /// Registrar login exitoso.
        /// </summary>
        public const string RegistrarLoginExitoso = "sp_RegistrarLoginExitoso";

        /// <summary>
        /// Registrar login fallido.
        /// </summary>
        public const string RegistrarLoginFallido = "sp_RegistrarLoginFallido";

        /// <summary>
        /// Registrar login fallido.
        /// </summary>
        public const string RegistrarLogNotificacion = "sp_RegistrarLogNotificacion";
    }
}
