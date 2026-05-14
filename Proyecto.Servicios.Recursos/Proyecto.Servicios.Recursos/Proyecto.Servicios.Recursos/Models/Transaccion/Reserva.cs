// <copyright file="Reserva.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

namespace Proyecto.Servicios.Recursos.Models.Transaccion
{
    public class Reserva
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Reserva"/> class
        /// </summary>
        public Reserva()
        {
            this.Id = 0;
            this.RecursoId = 0;
            this.CatedraticoId = 0;
            this.FechaInicio = DateTime.MinValue;
            this.FechaFin = DateTime.MinValue;
            this.MotivoId = 0;
            this.CursoId = 0;
            this.Estado = string.Empty;
            this.FechaCreacion = DateTime.Now;
            this.RowVersion = Array.Empty<byte>();
        }

        /// <summary>
        /// Gets or sets identificador único de la reserva
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets identificador del recurso reservado
        /// </summary>
        public int RecursoId { get; set; }

        /// <summary>
        /// Gets or sets identificador del catedrático que realiza la reserva
        /// </summary>
        public int CatedraticoId { get; set; }

        /// <summary>
        /// Gets or sets fecha y hora de inicio de la reserva
        /// </summary>
        public DateTime FechaInicio { get; set; }

        /// <summary>
        /// Gets or sets fecha y hora de finalización de la reserva
        /// </summary>
        public DateTime FechaFin { get; set; }

        /// <summary>
        /// Gets or sets identificador del motivo de la reserva
        /// </summary>
        public int MotivoId { get; set; }

        /// <summary>
        /// Gets or sets identificador del curso asociado a la reserva
        /// </summary>
        public int CursoId { get; set; }

        /// <summary>
        /// Gets or sets estado actual de la reserva
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// Gets or sets fecha de creación de la reserva
        /// </summary>
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// Gets or sets versión de la fila para control de concurrencia
        /// </summary>
        public byte[] RowVersion { get; set; }
    }
}
