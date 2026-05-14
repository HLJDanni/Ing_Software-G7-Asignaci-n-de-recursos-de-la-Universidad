// <copyright file="Recurso.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

namespace Proyecto.Servicios.Recursos.Models.Catalogo
{
    public class Recurso
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Recurso"/> class
        /// </summary>
        public Recurso()
        {
            this.Id = 0;
            this.Nombre = string.Empty;
            this.Codigo = string.Empty;
            this.CategoriaId = 0;
            this.Capacidad = 0;
            this.Ubicacion = string.Empty;
            this.Activo = true;
        }

        /// <summary>
        /// Gets or sets identificador único del recurso
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets nombre del recurso
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets código del recurso
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// Gets or sets identificador de la categoría asociada al recurso
        /// </summary>
        public int CategoriaId { get; set; }

        /// <summary>
        /// Gets or sets capacidad máxima del recurso
        /// </summary>
        public int Capacidad { get; set; }

        /// <summary>
        /// Gets or sets ubicación física del recurso
        /// </summary>
        public string Ubicacion { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets valor que indica si el recurso se encuentra activo
        /// </summary>
        public bool Activo { get; set; }
    }
}
