// <copyright file="Curso.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

namespace Proyecto.Servicios.Recursos.Models.Catalogo
{
    public class Curso
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Curso"/> class
        /// </summary>
        public Curso()
        {
            this.Id = 0;
            this.Codigo = string.Empty;
            this.Nombre = string.Empty;
            this.CatedraticoId = 0;
        }

        /// <summary>
        /// Gets or sets identificador único del curso
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets código del curso
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// Gets or sets nombre del curso
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets identificador del catedrático asignado al curso
        /// </summary>
        public int CatedraticoId { get; set; }
    }
}
