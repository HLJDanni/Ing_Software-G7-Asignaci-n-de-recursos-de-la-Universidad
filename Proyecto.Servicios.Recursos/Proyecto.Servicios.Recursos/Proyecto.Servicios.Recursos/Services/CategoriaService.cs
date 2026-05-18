// <copyright file="CategoriaService.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

using Proyecto.Servicios.Recursos.Models.Catalogo;

namespace Proyecto.Servicios.Recursos.Services
{
    public class CategoriaService
    {
        private readonly ConexíonBD conexion;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoriaService"/> class.
        /// </summary>
        public CategoriaService()
        {
            this.conexion = new();
        }
    }
}
