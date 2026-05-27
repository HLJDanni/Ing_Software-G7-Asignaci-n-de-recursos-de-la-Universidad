// <copyright file="CatedraticoListadoResponse.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

namespace Proyecto.Servicios.Recursos.Models.Catalogo
{
    /// <summary>
    /// Modelo de respuesta que representa un catedrático en el listado
    /// </summary>
    public class CatedraticoListadoResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatedraticoListadoResponse"/> class.
        /// </summary>
        public CatedraticoListadoResponse()
        {
            this.Id = 0;
            this.NombreUsuario = string.Empty;
            this.NombreCompleto = string.Empty;
            this.CorreoInstitucional = string.Empty;
            this.FechaRegistro = DateTime.MinValue;
            this.FechaUltimoAcceso = null;
            this.Activo = false;
        }

        /// <summary>
        /// Gets or sets el identificador del catedrático
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets el nombre de usuario del catedrático
        /// </summary>
        public string NombreUsuario { get; set; }

        /// <summary>
        /// Gets or sets el nombre completo del catedrático
        /// </summary>
        public string NombreCompleto { get; set; }

        /// <summary>
        /// Gets or sets el correo institucional del catedrático
        /// </summary>
        public string CorreoInstitucional { get; set; }

        /// <summary>
        /// Gets or sets la fecha de registro del catedrático
        /// </summary>
        public DateTime FechaRegistro { get; set; }

        /// <summary>
        /// Gets or sets la fecha del último acceso del catedrático
        /// </summary>
        public DateTime? FechaUltimoAcceso { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets un valor que indica si el catedrático está activo
        /// </summary>
        public bool Activo { get; set; }
    }
}
