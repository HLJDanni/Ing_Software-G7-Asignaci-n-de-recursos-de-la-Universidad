// <copyright file="LogNotificacionResponse.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

namespace Proyecto.Servicios.Recursos.Models.Logs
{
    /// <summary>
    /// Modelo de respuesta que representa un registro de notificación asociado a una reserva.
    /// </summary>
    public class LogNotificacionResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogNotificacionResponse"/> class.
        /// </summary>
        public LogNotificacionResponse()
        {
            this.Id = 0;
            this.ReservaId = 0;
            this.TipoEvento = string.Empty;
            this.FechaEnvio = DateTime.MinValue;
            this.Exitoso = false;
            this.MensajeError = string.Empty;
        }

        /// <summary>
        /// Gets or sets identificador del log de notificación.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets identificador de la reserva asociada.
        /// </summary>
        public int ReservaId { get; set; }

        /// <summary>
        /// Gets or sets tipo de evento notificado.
        /// </summary>
        public string TipoEvento { get; set; }

        /// <summary>
        /// Gets or sets fecha de envío de la notificación.
        /// </summary>
        public DateTime FechaEnvio { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets indicador de si la notificación fue exitosa.
        /// </summary>
        public bool Exitoso { get; set; }

        /// <summary>
        /// Gets or sets mensaje de error en caso de fallo.
        /// </summary>
        public string MensajeError { get; set; }
    }
}
