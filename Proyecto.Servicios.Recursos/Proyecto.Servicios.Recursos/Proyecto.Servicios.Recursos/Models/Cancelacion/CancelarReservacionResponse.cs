// <copyright file="CancelarReservacionResponse.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

namespace Proyecto.Servicios.Recursos.Models.Cancelacion
{
    /// <summary>
    /// Cancelar reservacion response.
    /// </summary>
    public class CancelarReservacionResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CancelarReservacionResponse"/> class.
        /// </summary>
        public CancelarReservacionResponse()
        {
            this.CancelacionExitosa = false;
        }

        /// <summary>
        /// Gets or sets a value indicating whether cancelacion exitosa.
        /// </summary>
        public bool CancelacionExitosa { get; set; }
    }
}
