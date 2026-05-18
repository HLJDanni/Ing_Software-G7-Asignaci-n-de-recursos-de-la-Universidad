// <copyright file="ObtenerCatedraticoPorUsuarioResponse.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

namespace Proyecto.Servicios.Recursos.Models.Catalogo
{
    /// <summary>
    /// Modelo de respuesta para la obtención de un catedrático por nombre de usuario
    /// </summary>
    public class ObtenerCatedraticoPorUsuarioResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ObtenerCatedraticoPorUsuarioResponse"/> class.
        /// </summary>
        public ObtenerCatedraticoPorUsuarioResponse()
        {
            this.Id = 0;
            this.NombreUsuario = string.Empty;
            this.HashContrasena = string.Empty;
            this.NombreCompleto = string.Empty;
            this.CorreoInstitucional = string.Empty;
            this.FechaUltimoAcceso = null;
            this.IntentosFallidos = 0;
            this.BloqueadoHasta = null;
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
        /// Gets or sets el hash de la contraseña del catedrático
        /// </summary>
        public string HashContrasena { get; set; }

        /// <summary>
        /// Gets or sets el nombre completo del catedrático
        /// </summary>
        public string NombreCompleto { get; set; }

        /// <summary>
        /// Gets or sets el correo institucional del catedrático
        /// </summary>
        public string CorreoInstitucional { get; set; }

        /// <summary>
        /// Gets or sets la fecha del último acceso del catedrático
        /// </summary>
        public DateTime? FechaUltimoAcceso { get; set; }

        /// <summary>
        /// Gets or sets la cantidad de intentos fallidos de inicio de sesión
        /// </summary>
        public int IntentosFallidos { get; set; }

        /// <summary>
        /// Gets or sets la fecha hasta la cual el catedrático se encuentra bloqueado
        /// </summary>
        public DateTime? BloqueadoHasta { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets un valor que indica si el catedrático está activo
        /// </summary>
        public bool Activo { get; set; }
    }
}
