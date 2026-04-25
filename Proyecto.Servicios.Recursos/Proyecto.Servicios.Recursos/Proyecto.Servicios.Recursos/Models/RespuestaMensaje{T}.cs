// <copyright file="RespuestaMensaje{T}.cs" company="Proyecto Final">
// Copyright (c) Proyecto Final. All rights reserved.
// </copyright>

namespace Proyecto.Servicios.Recursos.Models
{
    /// <summary>
    /// Respuesta de consulta.
    /// </summary>
    /// <typeparam name="T">Modelo.</typeparam>
    public class RespuestaMensaje<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RespuestaMensaje{T}"/> class.
        /// </summary>
        public RespuestaMensaje()
        {
            this.OcurrioError = false;
            this.MensajeTecnico = string.Empty;
            this.MensajeCliente = string.Empty;
            this.CodigoError = string.Empty;
            this.Modelo = default!;
        }

        /// <summary>
        /// Gets or sets a value indicating whether confirmación si ocurrio un error.
        /// </summary>
        public bool OcurrioError { get; set; }

        /// <summary>
        /// Gets or sets mensaje de cliente.
        /// </summary>
        public string MensajeCliente { get; set; }

        /// <summary>
        /// Gets or sets mensaje técnico.
        /// </summary>
        public string MensajeTecnico { get; set; }

        /// <summary>
        /// Gets or sets codigo de error.
        /// </summary>
        public string CodigoError { get; set; }

        /// <summary>
        /// Gets or sets modelo.
        /// </summary>
        public T Modelo { get; set; }
    }
}
