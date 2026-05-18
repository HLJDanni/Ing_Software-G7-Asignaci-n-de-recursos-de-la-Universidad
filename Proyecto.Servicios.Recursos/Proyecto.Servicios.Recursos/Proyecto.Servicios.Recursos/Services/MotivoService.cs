// <copyright file="MotivoService.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

namespace Proyecto.Servicios.Recursos.Services
{
    public class MotivoService
    {
        private readonly ConexíonBD conexion;

        /// <summary>
        /// Initializes a new instance of the <see cref="MotivoService"/> class.
        /// </summary>
        public MotivoService()
        {
            this.conexion = new();
        }
    }
}
