// <copyright file="ListarLogsNotificacionRequest.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

namespace Proyecto.Servicios.Recursos.Models.Logs
{
    /// <summary>
    /// Modelo de solicitud para listar los logs de notificación asociados a reservas.
    /// </summary>
    public class ListarLogsNotificacionRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListarLogsNotificacionRequest"/> class.
        /// </summary>
        public ListarLogsNotificacionRequest()
        {
            this.ReservaId = null;
            this.SoloFallidos = false;
            this.Pagina = 1;
            this.TamanoPagina = 50;
        }

        /// <summary>
        /// Gets or sets identificador de la reserva.
        /// </summary>
        public int? ReservaId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets indicador para listar únicamente notificaciones fallidas.
        /// </summary>
        public bool SoloFallidos { get; set; }

        /// <summary>
        /// Gets or sets número de página solicitada.
        /// </summary>
        public int Pagina { get; set; }

        /// <summary>
        /// Gets or sets tamaño de la página.
        /// </summary>
        public int TamanoPagina { get; set; }
    }
}
