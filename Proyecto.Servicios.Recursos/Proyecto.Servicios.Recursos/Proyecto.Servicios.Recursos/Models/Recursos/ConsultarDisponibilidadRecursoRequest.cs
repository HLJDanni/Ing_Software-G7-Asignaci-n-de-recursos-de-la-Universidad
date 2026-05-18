// <copyright file="ConsultarDisponibilidadRecursoRequest.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

namespace Proyecto.Servicios.Recursos.Models.Recursos
{
    /// <summary>
    /// Modelo de solicitud para consultar la disponibilidad de un recurso
    /// </summary>
    public class ConsultarDisponibilidadRecursoRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsultarDisponibilidadRecursoRequest"/> class.
        /// </summary>
        public ConsultarDisponibilidadRecursoRequest()
        {
            this.RecursoId = 0;
            this.FechaDesde = DateTime.MinValue;
            this.FechaHasta = DateTime.MinValue;
        }

        /// <summary>
        /// Gets or sets identificador del recurso
        /// </summary>
        public int RecursoId { get; set; }

        /// <summary>
        /// Gets or sets fecha inicial del rango de búsqueda
        /// </summary>
        public DateTime FechaDesde { get; set; }

        /// <summary>
        /// Gets or sets fecha final del rango de búsqueda
        /// </summary>
        public DateTime FechaHasta { get; set; }
    }
}
