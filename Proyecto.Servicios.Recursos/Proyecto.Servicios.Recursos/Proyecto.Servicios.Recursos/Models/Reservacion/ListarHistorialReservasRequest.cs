// <copyright file="ListarHistorialReservasRequest.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

namespace Proyecto.Servicios.Recursos.Models.Reservacion
{
    /// <summary>
    /// Modelo de solicitud para listar el historial de reservas de un catedrático
    /// </summary>
    public class ListarHistorialReservasRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListarHistorialReservasRequest"/> class.
        /// </summary>
        public ListarHistorialReservasRequest()
        {
            this.CatedraticoId = 0;
            this.Estado = null;
            this.FechaDesde = null;
            this.FechaHasta = null;
            this.Pagina = 1;
            this.TamanoPagina = 20;
        }

        /// <summary>
        /// Gets or sets el identificador del catedrático
        /// </summary>
        public int CatedraticoId { get; set; }

        /// <summary>
        /// Gets or sets el estado de la reserva
        /// </summary>
        public string? Estado { get; set; }

        /// <summary>
        /// Gets or sets la fecha inicial del rango de búsqueda
        /// </summary>
        public DateTime? FechaDesde { get; set; }

        /// <summary>
        /// Gets or sets la fecha final del rango de búsqueda
        /// </summary>
        public DateTime? FechaHasta { get; set; }

        /// <summary>
        /// Gets or sets el número de página solicitada
        /// </summary>
        public int Pagina { get; set; }

        /// <summary>
        /// Gets or sets el tamaño de página
        /// </summary>
        public int TamanoPagina { get; set; }
    }
}
