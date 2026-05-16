// <copyright file="ObtenerCatedraticoPorUsuarioRequest.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

namespace Proyecto.Servicios.Recursos.Models.Catalogo
{
    /// <summary>
    /// Modelo de solicitud para obtener un catedrático por nombre de usuario
    /// </summary>
    public class ObtenerCatedraticoPorUsuarioRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ObtenerCatedraticoPorUsuarioRequest"/> class.
        /// </summary>
        public ObtenerCatedraticoPorUsuarioRequest()
        {
            this.NombreUsuario = string.Empty;
        }

        /// <summary>
        /// Gets or sets el nombre de usuario del catedrático
        /// </summary>
        public string NombreUsuario { get; set; }
    }
}
