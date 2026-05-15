// <copyright file="CrearReservaResponse.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

namespace Proyecto.Servicios.Recursos.Models.Reservacion
{
    /// <summary>
    /// Modelo de respuesta para la creación de una reserva
    /// </summary>
    public class CrearReservaResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CrearReservaResponse"/> class.
        /// </summary>
        public CrearReservaResponse()
        {
            this.ReservaId = 0;
        }

        /// <summary>
        /// Gets or sets el identificador generado de la reserva
        /// </summary>
        public int ReservaId { get; set; }
    }
}
