// <copyright file="CursoResponse.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

namespace Proyecto.Servicios.Recursos.Models.Catalogo
{
    /// <summary>
    /// Modelo de respuesta que representa un curso asociado a un catedrático.
    /// </summary>
    public class CursoResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CursoResponse"/> class.
        /// </summary>
        public CursoResponse()
        {
            this.Id = 0;
            this.Codigo = string.Empty;
            this.Nombre = string.Empty;
            this.CatedraticoId = 0;
        }

        /// <summary>
        /// Gets or sets identificador del curso.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets código del curso.
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// Gets or sets nombre del curso.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets identificador del catedrático propietario del curso.
        /// </summary>
        public int CatedraticoId { get; set; }
    }
}
