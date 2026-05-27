// <copyright file="LogService.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

using Proyecto.Servicios.Recursos.Models;
using Proyecto.Servicios.Recursos.Models.Catalogo;
using Proyecto.Servicios.Recursos.Models.Logs;
using System.Data;

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

        public RespuestaMensaje<List<LogNotificacionResponse>> ListarNotificacionLog(ListarLogsNotificacionRequest solicitud)
        {
            RespuestaMensaje<List<LogNotificacionResponse>> respuesta = new();

            try
            {
                Dictionary<string, object> parametros = new();
                parametros.Add("Pagina", solicitud.Pagina);
                parametros.Add("TamanoPagina", solicitud.TamanoPagina);
                parametros.Add("ReservaId", solicitud?.ReservaId ?? 0);
                parametros.Add("SoloFallidos", solicitud?.SoloFallidos ?? false);

                DataTable dt = new();
                this.conexion.EjecutarSPRetornaTabla(SPs.ListarLogsNotificacion, parametros);

                if (this.conexion.ExisteErrores())
                {
                    respuesta.OcurrioError = true;
                    respuesta.CodigoError = "999";
                    respuesta.MensajeCliente = "Ha ocurrido un error al consultar los catalogos.";
                    respuesta.MensajeTecnico = $"Metodo: {nameof(this.ListarNotificacionLog)} Excepción:{this.conexion.ObtenerErrorMensaje()}";
                    return respuesta;
                }

                dt = this.conexion.ObtenerResultadoSP();
                if (dt?.Rows.Count > 0)
                {
                    respuesta.Modelo = new();
                    foreach (DataRow dr in dt.Rows)
                    {
                        LogNotificacionResponse nuevo = new();
                        nuevo.Id = dr?["Id"] == DBNull.Value ? 0 : Convert.ToInt32(dr?["Id"] ?? 0);
                        nuevo.FechaEnvio = dr?["FechaEnvio"] == DBNull.Value ? default(DateTime) : Convert.ToDateTime(dr?["FechaEnvio"] ?? default(DateTime));
                        nuevo.Exitoso = dr?["Exitoso"] == DBNull.Value ? false : Convert.ToBoolean(dr?["Exitoso"] ?? false);
                        nuevo.TipoEvento = dr?["TipoEvento"] == DBNull.Value ? string.Empty : dr?["TipoEvento"].ToString() ?? string.Empty;
                        nuevo.MensajeError = dr?["MensajeError"] == DBNull.Value ? string.Empty : dr?["MensajeError"].ToString() ?? string.Empty;
                        nuevo.ReservaId = dr?["ReservaId"] == DBNull.Value ? 0 : Convert.ToInt32(dr?["ReservaId"] ?? 0);
                        respuesta.Modelo.Add(nuevo);
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta.CodigoError = "999";
                respuesta.MensajeCliente = $"Ha ocurrido un error al obtener el catalogo.";
                respuesta.MensajeTecnico = $"Metodo: {nameof(this.ListarNotificacionLog)} Excepción:{ex.ToString()}";
                respuesta.OcurrioError = true;
            }

            return respuesta;
        }
    }
}
