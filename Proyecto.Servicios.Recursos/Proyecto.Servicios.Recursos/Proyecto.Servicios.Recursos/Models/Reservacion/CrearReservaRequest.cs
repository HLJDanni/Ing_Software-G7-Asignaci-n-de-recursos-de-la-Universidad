// <copyright file="CrearReservaRequest.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

namespace Proyecto.Servicios.Recursos.Models.Reservacion
{
    /// <summary>
    /// Modelo de solicitud para crear una reserva de recurso
    /// </summary>
    public class CrearReservaRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CrearReservaRequest"/> class.
        /// </summary>
        public CrearReservaRequest()
        {
            this.RecursoId = 0;
            this.CatedraticoId = 0;
            this.FechaInicio = DateTime.MinValue;
            this.FechaFin = DateTime.MinValue;
            this.MotivoId = 0;
            this.CursoId = 0;
        }

        /// <summary>
        /// Gets or sets el identificador del recurso
        /// </summary>
        public int RecursoId { get; set; }

        /// <summary>
        /// Gets or sets el identificador del catedrático
        /// </summary>
        public int CatedraticoId { get; set; }

        /// <summary>
        /// Gets or sets la fecha de inicio de la reserva
        /// </summary>
        public DateTime FechaInicio { get; set; }

        /// <summary>
        /// Gets or sets la fecha de fin de la reserva
        /// </summary>
        public DateTime FechaFin { get; set; }

        /// <summary>
        /// Gets or sets el identificador del motivo de la reserva
        /// </summary>
        public int MotivoId { get; set; }

        /// <summary>
        /// Gets or sets el identificador del curso asociado a la reserva
        /// </summary>
        public int CursoId { get; set; }
    }
}
