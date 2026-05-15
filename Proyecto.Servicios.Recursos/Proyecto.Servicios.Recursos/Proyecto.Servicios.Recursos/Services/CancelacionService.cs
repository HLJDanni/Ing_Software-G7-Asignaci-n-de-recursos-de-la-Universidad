// <copyright file="CancelacionService.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

using System.Data;
using Proyecto.Servicios.Recursos.Models;
using Proyecto.Servicios.Recursos.Models.Cancelacion;
using Proyecto.Servicios.Recursos.Models.Catalogo;

namespace Proyecto.Servicios.Recursos.Services
{
    public class CancelacionService
    {
        private readonly ConexíonBD conexion;

        /// <summary>
        /// Initializes a new instance of the <see cref="CancelacionService"/> class.
        /// </summary>
        public CancelacionService()
        {
            this.conexion = new();
        }

        [Obsolete]
        public RespuestaMensaje<CancelarReservacionResponse> CancelarReserva(CancelarReservacionRequest solicitud)
        {
            RespuestaMensaje<CancelarReservacionResponse> respuesta = new();

            try
            {
                Dictionary<string, object> parametros = new();
                parametros.Add("ReservaId", solicitud.IdReserva);
                parametros.Add("CatedraticoId", solicitud.IdCatedratico);

                DataTable dt = new();
                this.conexion.EjecutarSP("sp_CancelarReserva", parametros);

                if (this.conexion.ExisteErrores())
                {
                    respuesta.OcurrioError = true;
                    respuesta.CodigoError = "999";
                    respuesta.MensajeCliente = "Ha ocurrido un error al cancelar la reserva.";
                    respuesta.MensajeTecnico = $"Metodo: {nameof(this.CancelarReserva)} Excepción: {this.conexion.ObtenerErrorMensaje()}";
                    return respuesta;
                }

                respuesta.Modelo = new();
                respuesta.Modelo.CancelacionExitosa = true;
            }
            catch (Exception ex)
            {
                respuesta.CodigoError = "999";
                respuesta.MensajeCliente = $"Ha ocurrido un error al cancelar la reserva.";
                respuesta.MensajeTecnico = $"Metodo: {nameof(this.CancelarReserva)} Excepción:{ex.ToString()}";
                respuesta.OcurrioError = true;
            }

            return respuesta;
        }
    }
}
