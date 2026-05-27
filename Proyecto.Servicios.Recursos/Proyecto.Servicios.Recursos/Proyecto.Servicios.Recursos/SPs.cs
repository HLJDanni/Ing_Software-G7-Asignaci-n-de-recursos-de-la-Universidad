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
        /// Obtener Catredrativo por usuario.
        /// </summary>
        public const string ObtenerCatedratico = "sp_ListarCatedraticos";

        /// <summary>
        /// Obtener Catredrativo por usuario.
        /// </summary>
        public const string ListarCategorias = "sp_ListarCategorias";

        /// <summary>
        /// Obtener Cursos por usuario.
        /// </summary>
        public const string ListarCursosPorCatedratico = "sp_ListarCursosPorCatedratico";

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

        /// <summary>
        /// Listar Notifiación.
        /// </summary>
        public const string ListarLogsNotificacion = "sp_ListarLogsNotificacion";

        /// <summary>
        /// Listar motivos.
        /// </summary>
        public const string ListarMotivos = "sp_ListarMotivos";
    }
}
