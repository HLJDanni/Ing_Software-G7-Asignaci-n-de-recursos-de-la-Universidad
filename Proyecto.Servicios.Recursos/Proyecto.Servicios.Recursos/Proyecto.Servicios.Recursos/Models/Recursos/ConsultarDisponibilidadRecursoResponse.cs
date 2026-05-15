// <copyright file="ConsultarDisponibilidadRecursoResponse.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

namespace Proyecto.Servicios.Recursos.Models.Recursos
{
    /// <summary>
    /// Modelo de respuesta para la consulta de disponibilidad de un recurso
    /// </summary>
    public class ConsultarDisponibilidadRecursoResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsultarDisponibilidadRecursoResponse"/> class.
        /// </summary>
        public ConsultarDisponibilidadRecursoResponse()
        {
            this.Id = 0;
            this.FechaInicio = DateTime.MinValue;
            this.FechaFin = DateTime.MinValue;
            this.Estado = string.Empty;
            this.CatedraticoId = 0;
            this.NombreCatedratico = string.Empty;
            this.Motivo = string.Empty;
            this.CursoId = 0;
            this.CodigoCurso = string.Empty;
        }

        /// <summary>
        /// Gets or sets identificador de la reserva
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets fecha de inicio de la reserva
        /// </summary>
        public DateTime FechaInicio { get; set; }

        /// <summary>
        /// Gets or sets fecha de finalización de la reserva
        /// </summary>
        public DateTime FechaFin { get; set; }

        /// <summary>
        /// Gets or sets estado actual de la reserva
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// Gets or sets identificador del catedrático
        /// </summary>
        public int CatedraticoId { get; set; }

        /// <summary>
        /// Gets or sets nombre completo del catedrático
        /// </summary>
        public string NombreCatedratico { get; set; }

        /// <summary>
        /// Gets or sets motivo de la reserva
        /// </summary>
        public string Motivo { get; set; }

        /// <summary>
        /// Gets or sets identificador del curso
        /// </summary>
        public int CursoId { get; set; }

        /// <summary>
        /// Gets or sets código del curso
        /// </summary>
        public string CodigoCurso { get; set; }
    }
}
