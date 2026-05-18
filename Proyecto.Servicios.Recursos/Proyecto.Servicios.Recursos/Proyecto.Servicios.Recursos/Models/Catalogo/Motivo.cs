// <copyright file="Motivo.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

namespace Proyecto.Servicios.Recursos.Models.Catalogo
{
    public class Motivo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Motivo"/> class
        /// </summary>
        public Motivo()
        {
            this.Id = 0;
            this.Nombre = string.Empty;
        }

        /// <summary>
        /// Gets or sets identificador único del motivo
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets nombre del motivo
        /// </summary>
        public string Nombre { get; set; }
    }
}
