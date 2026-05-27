// <copyright file="ListarCursosPorCatedraticoRequest.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

namespace Proyecto.Servicios.Recursos.Models.Catalogo
{
    /// <summary>
    /// Modelo de solicitud para listar los cursos asociados a un catedrático.
    /// </summary>
    public class ListarCursosPorCatedraticoRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListarCursosPorCatedraticoRequest"/> class.
        /// </summary>
        public ListarCursosPorCatedraticoRequest()
        {
            this.CatedraticoId = 0;
        }

        /// <summary>
        /// Gets or sets identificador del catedrático.
        /// </summary>
        public int CatedraticoId { get; set; }
    }
}
