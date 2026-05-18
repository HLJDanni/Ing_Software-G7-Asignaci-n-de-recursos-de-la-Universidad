// <copyright file="RecursoResponse.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

namespace Proyecto.Servicios.Recursos.Models.Reservacion
{
    /// <summary>
    /// Modelo de respuesta que representa un recurso
    /// </summary>
    public class RecursoResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecursoResponse"/> class.
        /// </summary>
        public RecursoResponse()
        {
            this.Id = 0;
            this.Nombre = string.Empty;
            this.Codigo = string.Empty;
            this.CategoriaId = 0;
            this.NombreCategoria = string.Empty;
            this.Capacidad = 0;
            this.Ubicacion = string.Empty;
            this.Activo = false;
        }

        /// <summary>
        /// Gets or sets el identificador del recurso
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets el nombre del recurso
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets el código del recurso
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// Gets or sets el identificador de la categoría
        /// </summary>
        public int CategoriaId { get; set; }

        /// <summary>
        /// Gets or sets el nombre de la categoría
        /// </summary>
        public string NombreCategoria { get; set; }

        /// <summary>
        /// Gets or sets la capacidad del recurso
        /// </summary>
        public int Capacidad { get; set; }

        /// <summary>
        /// Gets or sets la ubicación del recurso
        /// </summary>
        public string Ubicacion { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets un valor que indica si el recurso está activo
        /// </summary>
        public bool Activo { get; set; }
    }
}
