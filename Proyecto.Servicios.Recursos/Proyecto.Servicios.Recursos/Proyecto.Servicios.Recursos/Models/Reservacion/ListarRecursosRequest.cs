// <copyright file="ListarRecursosRequest.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

namespace Proyecto.Servicios.Recursos.Models.Reservacion
{
    /// <summary>
    /// Modelo de solicitud para listar recursos según filtros opcionales
    /// </summary>
    public class ListarRecursosRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListarRecursosRequest"/> class.
        /// </summary>
        public ListarRecursosRequest()
        {
            this.CategoriaId = null;
            this.CapacidadMinima = null;
            this.Ubicacion = null;
            this.SoloActivos = true;
        }

        /// <summary>
        /// Gets or sets el identificador de la categoría del recurso
        /// </summary>
        public int? CategoriaId { get; set; }

        /// <summary>
        /// Gets or sets la capacidad mínima requerida del recurso
        /// </summary>
        public int? CapacidadMinima { get; set; }

        /// <summary>
        /// Gets or sets la ubicación del recurso
        /// </summary>
        public string? Ubicacion { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets un valor que indica si solo se listan recursos activos
        /// </summary>
        public bool SoloActivos { get; set; }
    }
}
