// <copyright file="ListarCatedraticosRequest.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

namespace Proyecto.Servicios.Recursos.Models.Catalogo
{
    /// <summary>
    /// Modelo de solicitud para listar catedráticos
    /// </summary>
    public class ListarCatedraticosRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListarCatedraticosRequest"/> class.
        /// </summary>
        public ListarCatedraticosRequest()
        {
            this.SoloActivos = true;
        }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets un valor que indica si solo se listan catedráticos activos
        /// </summary>
        public bool SoloActivos { get; set; }
    }
}
