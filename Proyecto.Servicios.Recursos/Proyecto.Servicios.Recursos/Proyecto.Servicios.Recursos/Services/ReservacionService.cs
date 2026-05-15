// <copyright file="ReservacionService.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

using Proyecto.Servicios.Recursos.Models;
using Proyecto.Servicios.Recursos.Models.Cancelacion;
using Proyecto.Servicios.Recursos.Models.Catalogo;
using Proyecto.Servicios.Recursos.Models.Reservacion;
using System.Data;

namespace Proyecto.Servicios.Recursos.Services
{
    /// <summary>
    /// Servicio para reservaciones.
    /// </summary>
    public class ReservacionService
    {
        private readonly ConexíonBD conexion;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReservacionService"/> class.
        /// </summary>
        public ReservacionService()
        {
            this.conexion = new();
        }

        [Obsolete]
        public RespuestaMensaje<CompletarReservacionResponse> CompletarReservasVencidas()
        {
            RespuestaMensaje<CompletarReservacionResponse> respuesta = new();

            try
            {
                DataTable dt = new();
                this.conexion.EjecutarSP("sp_CompletarReservasVencidas", null);

                if (this.conexion.ExisteErrores())
                {
                    respuesta.OcurrioError = true;
                    respuesta.CodigoError = "999";
                    respuesta.MensajeCliente = "Ha ocurrido un error al completar las reservas vencidas.";
                    respuesta.MensajeTecnico = $"Metodo: {nameof(this.CompletarReservasVencidas)} Excepción: {this.conexion.ObtenerErrorMensaje()}";
                    return respuesta;
                }

                respuesta.Modelo = new();
                respuesta.Modelo.ReservasCompletadas = true;
            }
            catch (Exception ex)
            {
                respuesta.CodigoError = "999";
                respuesta.MensajeCliente = $"Ha ocurrido un error al completar las reservas vencidas.";
                respuesta.MensajeTecnico = $"Metodo: {nameof(this.CompletarReservasVencidas)} Excepción:{ex.ToString()}";
                respuesta.OcurrioError = true;
            }

            return respuesta;
        }


        [Obsolete]
        public RespuestaMensaje<CrearReservaResponse> CrearReservacion(CrearReservaRequest solicitud)
        {
            RespuestaMensaje<CrearReservaResponse> respuesta = new();

            try
            {
                DataTable dt = new();
                Dictionary<string, object> parametros = new();
                parametros.Add("FechaInicio", solicitud.FechaInicio);
                parametros.Add("MotivoId", solicitud.MotivoId);
                parametros.Add("RecursoId", solicitud.RecursoId);
                parametros.Add("CatedraticoId", solicitud.CatedraticoId);
                parametros.Add("CursoId", solicitud.CursoId);
                parametros.Add("FechaFin", solicitud.FechaFin);
                this.conexion.EjecutarSPRetornaEntero("sp_CrearReserva", parametros, "ReservaId");

                if (this.conexion.ExisteErrores())
                {
                    respuesta.OcurrioError = true;
                    respuesta.CodigoError = "999";
                    respuesta.MensajeCliente = "Ha ocurrido un error al crear una reservación.";
                    respuesta.MensajeTecnico = $"Metodo: {nameof(this.CrearReservacion)} Excepción: {this.conexion.ObtenerErrorMensaje()}";
                    return respuesta;
                }

                respuesta.Modelo = new();
                respuesta.Modelo.ReservaId = this.conexion.ObtenerValorEntero();
            }
            catch (Exception ex)
            {
                respuesta.CodigoError = "999";
                respuesta.MensajeCliente = $"Ha ocurrido un error al crear una reservación.";
                respuesta.MensajeTecnico = $"Metodo: {nameof(this.CrearReservacion)} Excepción:{ex.ToString()}";
                respuesta.OcurrioError = true;
            }

            return respuesta;
        }
    }
}
