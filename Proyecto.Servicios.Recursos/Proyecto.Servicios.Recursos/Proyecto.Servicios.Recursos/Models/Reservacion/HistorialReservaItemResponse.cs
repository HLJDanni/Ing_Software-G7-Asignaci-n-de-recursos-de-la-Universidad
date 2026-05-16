// <copyright file="HistorialReservaItemResponse.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

namespace Proyecto.Servicios.Recursos.Models.Reservacion
{
    /// <summary>
    /// Modelo que representa un registro del historial de reservas
    /// </summary>
    public class HistorialReservaItemResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HistorialReservaItemResponse"/> class.
        /// </summary>
        public HistorialReservaItemResponse()
        {
            this.Id = 0;
            this.RecursoId = 0;
            this.NombreRecurso = string.Empty;
            this.CodigoRecurso = string.Empty;
            this.FechaInicio = DateTime.MinValue;
            this.FechaFin = DateTime.MinValue;
            this.Estado = string.Empty;
            this.MotivoId = 0;
            this.Motivo = string.Empty;
            this.CursoId = 0;
            this.CodigoCurso = string.Empty;
            this.NombreCurso = string.Empty;
            this.FechaCreacion = DateTime.MinValue;
        }

        /// <summary>
        /// Gets or sets el identificador de la reserva
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets el identificador del recurso
        /// </summary>
        public int RecursoId { get; set; }

        /// <summary>
        /// Gets or sets el nombre del recurso
        /// </summary>
        public string NombreRecurso { get; set; }

        /// <summary>
        /// Gets or sets el código del recurso
        /// </summary>
        public string CodigoRecurso { get; set; }

        /// <summary>
        /// Gets or sets la fecha de inicio de la reserva
        /// </summary>
        public DateTime FechaInicio { get; set; }

        /// <summary>
        /// Gets or sets la fecha de fin de la reserva
        /// </summary>
        public DateTime FechaFin { get; set; }

        /// <summary>
        /// Gets or sets el estado de la reserva
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// Gets or sets el identificador del motivo
        /// </summary>
        public int MotivoId { get; set; }

        /// <summary>
        /// Gets or sets el nombre del motivo
        /// </summary>
        public string Motivo { get; set; }

        /// <summary>
        /// Gets or sets el identificador del curso
        /// </summary>
        public int? CursoId { get; set; }

        /// <summary>
        /// Gets or sets el código del curso
        /// </summary>
        public string CodigoCurso { get; set; }

        /// <summary>
        /// Gets or sets el nombre del curso
        /// </summary>
        public string NombreCurso { get; set; }

        /// <summary>
        /// Gets or sets la fecha de creación de la reserva
        /// </summary>
        public DateTime FechaCreacion { get; set; }
    }
}
