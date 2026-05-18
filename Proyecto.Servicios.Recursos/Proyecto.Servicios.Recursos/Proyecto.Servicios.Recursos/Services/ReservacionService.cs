// <copyright file="ReservacionService.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

using System.Data;
using Proyecto.Servicios.Recursos.Models;
using Proyecto.Servicios.Recursos.Models.Reservacion;

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

        public RespuestaMensaje<CompletarReservacionResponse> CompletarReservasVencidas()
        {
            RespuestaMensaje<CompletarReservacionResponse> respuesta = new();

            try
            {
                DataTable dt = new();
                this.conexion.EjecutarSP(SPs.CompletarReservasVencidas, null);

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
                this.conexion.EjecutarSPRetornaEntero(SPs.CrearReserva, parametros, "ReservaId");

                LogService serviciolog = new();
                if (this.conexion.ExisteErrores())
                {
                    respuesta.OcurrioError = true;
                    respuesta.CodigoError = "999";
                    respuesta.MensajeCliente = "Ha ocurrido un error al crear una reservación.";
                    respuesta.MensajeTecnico = $"Metodo: {nameof(this.CrearReservacion)} Excepción: {this.conexion.ObtenerErrorMensaje()}";

                    serviciolog.RegistrarLogNotificacion(0, "Creación de reserva", false, $"Ocurrio un error al hacer reserva: {this.conexion.ObtenerErrorMensaje()}");
                    return respuesta;
                }

                respuesta.Modelo = new();
                respuesta.Modelo.ReservaId = this.conexion.ObtenerValorEntero();

                serviciolog.RegistrarLogNotificacion(respuesta.Modelo.ReservaId, "Creación de reserva", true, $"Registro de reserva exitoso.");
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

        public RespuestaMensaje<List<HistorialReservaItemResponse>> ListarHistorialReservas(ListarHistorialReservasRequest solicitud)
        {
            RespuestaMensaje<List<HistorialReservaItemResponse>> respuesta = new();

            try
            {
                Dictionary<string, object> parametros = new();
                if (solicitud.FechaDesde.HasValue)
                {
                    parametros.Add("FechaDesde", solicitud.FechaDesde.Value);
                }

                parametros.Add("CatedraticoId", solicitud.CatedraticoId);

                if (solicitud.FechaHasta.HasValue)
                {
                    parametros.Add("FechaHasta", solicitud.FechaHasta.Value);
                }

                if (solicitud?.Estado != null)
                {
                    parametros.Add("Estado", solicitud.Estado);
                }

                if (solicitud?.Pagina != null)
                {
                    parametros.Add("Pagina", solicitud.Pagina);
                }

                if (solicitud?.TamanoPagina != null)
                {
                    parametros.Add("TamanoPagina", solicitud.TamanoPagina);
                }

                DataTable dt = new();
#pragma warning disable CS0612 // El tipo o el miembro están obsoletos
                this.conexion.EjecutarSPRetornaTabla(SPs.ListarHistorialReservas, parametros);
#pragma warning restore CS0612 // El tipo o el miembro están obsoletos

                if (this.conexion.ExisteErrores())
                {
                    respuesta.OcurrioError = true;
                    respuesta.CodigoError = "999";
                    respuesta.MensajeCliente = "Ha ocurrido un error al consultar disponibilidad de recurso.";
                    respuesta.MensajeTecnico = $"Metodo: {nameof(this.ListarHistorialReservas)} Excepción:{this.conexion.ObtenerErrorMensaje()}";
                    return respuesta;
                }

                if (dt?.Rows.Count > 0)
                {
                    respuesta.Modelo = new();
                    foreach (DataRow dr in dt.Rows)
                    {
                        HistorialReservaItemResponse nuevo = new();
                        nuevo.Id = dr?["Id"] == DBNull.Value ? 0 : Convert.ToInt32(dr?["Id"] ?? 0);
                        nuevo.RecursoId = dr?["RecursoId"] == DBNull.Value ? 0 : Convert.ToInt32(dr?["RecursoId"] ?? 0);
                        nuevo.NombreRecurso = dr?["NombreRecurso"] == DBNull.Value ? string.Empty : dr?["NombreRecurso"].ToString() ?? string.Empty;
                        nuevo.CodigoRecurso = dr?["CodigoRecurso"] == DBNull.Value ? string.Empty : dr?["CodigoRecurso"].ToString() ?? string.Empty;
                        nuevo.FechaInicio = dr?["FechaInicio"] == DBNull.Value ? default(DateTime) : Convert.ToDateTime(dr?["FechaInicio"] ?? default(DateTime));
                        nuevo.FechaFin = dr?["FechaFin"] == DBNull.Value ? default(DateTime) : Convert.ToDateTime(dr?["FechaFin"] ?? default(DateTime));
                        nuevo.Estado = dr?["Estado"] == DBNull.Value ? string.Empty : dr?["Estado"].ToString() ?? string.Empty;
                        nuevo.MotivoId = dr?["MotivoId"] == DBNull.Value ? 0 : Convert.ToInt32(dr?["MotivoId"] ?? 0);
                        nuevo.Motivo = dr?["Motivo"] == DBNull.Value ? string.Empty : dr?["Motivo"].ToString() ?? string.Empty;
                        nuevo.CursoId = dr?["CursoId"] == DBNull.Value ? 0 : Convert.ToInt32(dr?["CursoId"] ?? 0);
                        nuevo.CodigoCurso = dr?["CodigoCurso"] == DBNull.Value ? string.Empty : dr?["CodigoCurso"].ToString() ?? string.Empty;
                        nuevo.NombreCurso = dr?["NombreCurso"] == DBNull.Value ? string.Empty : dr?["NombreCurso"].ToString() ?? string.Empty;
                        nuevo.FechaCreacion = dr?["FechaCreacion"] == DBNull.Value ? default(DateTime) : Convert.ToDateTime(dr?["FechaCreacion"] ?? default(DateTime));

                        respuesta.Modelo.Add(nuevo);
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta.CodigoError = "999";
                respuesta.MensajeCliente = $"Ha ocurrido un error al consultar disponibilidad de recurso..";
                respuesta.MensajeTecnico = $"Metodo: {nameof(this.ListarHistorialReservas)} Excepción:{ex.ToString()}";
                respuesta.OcurrioError = true;
            }

            return respuesta;
        }
    }
}
