// <copyright file="MotivoResponse.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

namespace Proyecto.Servicios.Recursos.Models.Catalogo
{
    /// <summary>
    /// Modelo de respuesta que representa un motivo de reserva.
    /// </summary>
    public class MotivoResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MotivoResponse"/> class.
        /// </summary>
        public MotivoResponse()
        {
            this.Id = 0;
            this.Nombre = string.Empty;
        }

        /// <summary>
        /// Gets or sets identificador del motivo.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets nombre del motivo.
        /// </summary>
        public string Nombre { get; set; }
    }
}
