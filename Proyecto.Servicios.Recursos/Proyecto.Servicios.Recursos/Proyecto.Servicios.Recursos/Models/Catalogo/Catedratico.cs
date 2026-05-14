// <copyright file="Catedratico.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

namespace Proyecto.Servicios.Recursos.Models.Catalogo
{
    public class Catedratico
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Catedratico"/> class
        /// </summary>
        public Catedratico()
        {
            this.Id = 0;
            this.NombreCompleto = string.Empty;
            this.CorreoInstitucional = string.Empty;
            this.Activo = true;
        }

        /// <summary>
        /// Gets or sets identificador único del catedrático
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets nombre completo del catedrático
        /// </summary>
        public string NombreCompleto { get; set; }

        /// <summary>
        /// Gets or sets correo institucional del catedrático
        /// </summary>
        public string CorreoInstitucional { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets valor que indica si el catedrático se encuentra activo
        /// </summary>
        public bool Activo { get; set; }
    }
}
