// <copyright file="CancelarReservacionRequest.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

namespace Proyecto.Servicios.Recursos.Models.Cancelacion
{
    /// <summary>
    /// Cancelar reservacion solicitud.
    /// </summary>
    public class CancelarReservacionRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CancelarReservacionRequest"/> class.
        /// </summary>
        public CancelarReservacionRequest()
        {
            this.IdReserva = 0;
            this.IdCatedratico = 0;
        }

        /// <summary>
        /// Gets or sets id de reserva.
        /// </summary>
        public int IdReserva { get; set; }

        /// <summary>
        /// Gets or sets id de catedratico.
        /// </summary>
        public int IdCatedratico { get; set; }
    }
}
