// <copyright file="CategoriaResponse.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

namespace Proyecto.Servicios.Recursos.Models.Catalogo
{
    /// <summary>
    /// Modelo de respuesta que representa una categoría de recursos con su total asociado.
    /// </summary>
    public class CategoriaResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoriaResponse"/> class.
        /// </summary>
        public CategoriaResponse()
        {
            this.Id = 0;
            this.Nombre = string.Empty;
            this.Descripcion = string.Empty;
            this.TotalRecursos = 0;
        }

        /// <summary>
        /// Gets or sets identificador de la categoría.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets nombre de la categoría.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets descripción de la categoría.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Gets or sets total de recursos asociados a la categoría.
        /// </summary>
        public int TotalRecursos { get; set; }
    }
}
