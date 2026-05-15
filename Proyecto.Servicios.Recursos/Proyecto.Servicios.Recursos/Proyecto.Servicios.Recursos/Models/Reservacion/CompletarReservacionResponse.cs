// <copyright file="CompletarReservacionResponse.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

namespace Proyecto.Servicios.Recursos.Models.Reservacion
{
    public class CompletarReservacionResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompletarReservacionResponse"/> class.
        /// </summary>
        public CompletarReservacionResponse()
        {
            this.ReservasCompletadas = false;
        }

        /// <summary>
        /// Gets or sets a value indicating whether reserva completadas.
        /// </summary>
        public bool ReservasCompletadas { get; set; }
    }
}
