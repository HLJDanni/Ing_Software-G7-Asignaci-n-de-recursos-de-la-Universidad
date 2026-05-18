// <copyright file="Categoria.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

namespace Proyecto.Servicios.Recursos.Models.Catalogo
{
    public class Categoria
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Categoria"/> class
        /// </summary>
        public Categoria()
        {
            this.Id = 0;
            this.Nombre = string.Empty;
            this.Descripcion = string.Empty;
        }

        /// <summary>
        /// Gets or sets identificador único de la categoría
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets nombre de la categoría
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets descripción de la categoría
        /// </summary>
        public string Descripcion { get; set; }
    }
}
