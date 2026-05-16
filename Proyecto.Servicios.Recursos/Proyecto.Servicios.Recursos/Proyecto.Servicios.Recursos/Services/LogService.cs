// <copyright file="LogService.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

using Proyecto.Servicios.Recursos.Models;

namespace Proyecto.Servicios.Recursos.Services
{
    public class LogService
    {
        private readonly ConexíonBD conexion;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogService"/> class.
        /// </summary>
        public LogService()
        {
            this.conexion = new();
        }

        /// <summary>
        /// Registra un log de notificación.
        /// </summary>
        /// <param name="reservaId">Id de reserva-</param>
        /// <param name="tipoEvento">Tipo de evento.</param>
        /// <param name="exitoso">Es Exitoso.</param>
        /// <param name="mensajeError">Mensaje de error.</param>
        /// <returns>Log registrado.</returns>
        public RespuestaMensaje<bool> RegistrarLogNotificacion(int reservaId, string tipoEvento, bool exitoso, string mensajeError)
        {
            RespuestaMensaje<bool> respuesta = new();

            try
            {
                Dictionary<string, object> parametros = new();
                parametros.Add("ReservaId", reservaId);
                parametros.Add("TipoEvento", tipoEvento);
                parametros.Add("Exitoso", exitoso);
                parametros.Add("MensajeError", mensajeError);
                this.conexion.EjecutarSP(SPs.RegistrarLogNotificacion, parametros);

                if (this.conexion.ExisteErrores())
                {
                    respuesta.OcurrioError = true;
                    respuesta.CodigoError = "999";
                    respuesta.MensajeCliente = "Ha ocurrido un error al completar las reservas vencidas.";
                    respuesta.MensajeTecnico = $"Metodo: {nameof(this.RegistrarLogNotificacion)} Excepción: {this.conexion.ObtenerErrorMensaje()}";
                    return respuesta;
                }

                respuesta.Modelo = new();
                respuesta.Modelo = true;
            }
            catch (Exception ex)
            {
                respuesta.CodigoError = "999";
                respuesta.MensajeCliente = $"Ha ocurrido un error al obtener el catalogo.";
                respuesta.MensajeTecnico = $"Metodo: {nameof(this.RegistrarLogNotificacion)} Excepción:{ex.ToString()}";
                respuesta.OcurrioError = true;
            }

            return respuesta;
        }
    }
}
