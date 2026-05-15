// <copyright file="RecursoService.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

using Proyecto.Servicios.Recursos.Interfaces;
using Proyecto.Servicios.Recursos.Models;
using Proyecto.Servicios.Recursos.Models.Catalogo;
using Proyecto.Servicios.Recursos.Models.Recursos;
using System.Data;

namespace Proyecto.Servicios.Recursos.Services
{
    public class RecursoService : ICatalogo<Recurso>
    {
        private readonly ConexíonBD conexion;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecursoService"/> class.
        /// </summary>
        public RecursoService()
        {
            this.conexion = new();
        }

        [Obsolete]
        public RespuestaMensaje<List<Recurso>> ObtenerCatalogo()
        {
            RespuestaMensaje<List<Recurso>> respuesta = new();

            try
            {
                DataTable dt = new();
                this.conexion.EjecutarSPRetornaTabla("sp_ListarRecursos", null);

                if (this.conexion.ExisteErrores())
                {
                    respuesta.OcurrioError = true;
                    respuesta.CodigoError = "999";
                    respuesta.MensajeCliente = "Ha ocurrido un error al consultar los catalogos.";
                    respuesta.MensajeTecnico = $"Metodo: {nameof(this.ObtenerCatalogo)} Excepción:{this.conexion.ObtenerErrorMensaje()}";
                    return respuesta;
                }

                if (dt?.Rows.Count > 0)
                {
                    respuesta.Modelo = new();
                    foreach (DataRow dr in dt.Rows)
                    {
                        Recurso nuevo = new();
                        nuevo.Id = dr?["Id"] == DBNull.Value ? 0 : Convert.ToInt32(dr?["Id"] ?? 0);
                        nuevo.Nombre = dr?["Nombre"] == DBNull.Value ? string.Empty : dr?["Nombre"].ToString() ?? string.Empty;
                        nuevo.CategoriaId = dr?["CategoriaId"] == DBNull.Value ? 0 : Convert.ToInt32(dr?["CategoriaId"] ?? 0);
                        nuevo.Codigo = dr?["Codigo"] == DBNull.Value ? string.Empty : dr?["Codigo"].ToString() ?? string.Empty;
                        nuevo.Capacidad = dr?["Capacidad"] == DBNull.Value ? 0 : Convert.ToInt32(dr?["Capacidad"] ?? 0);
                        nuevo.Ubicacion = dr?["Ubicacion"] == DBNull.Value ? string.Empty : dr?["Ubicacion"].ToString() ?? string.Empty;
                        nuevo.Activo = dr?["Activo"] == DBNull.Value ? false : Convert.ToBoolean(dr?["Activo"] ?? false);
                        respuesta.Modelo.Add(nuevo);
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta.CodigoError = "999";
                respuesta.MensajeCliente = $"Ha ocurrido un error al obtener el catalogo.";
                respuesta.MensajeTecnico = $"Metodo: {nameof(this.ObtenerCatalogo)} Excepción:{ex.ToString()}";
                respuesta.OcurrioError = true;
            }

            return respuesta;
        }

        [Obsolete]
        public RespuestaMensaje<List<ConsultarDisponibilidadRecursoResponse>> ConsultarDisponibilidadRecurso(ConsultarDisponibilidadRecursoRequest solicitud)
        {
            RespuestaMensaje<List<ConsultarDisponibilidadRecursoResponse>> respuesta = new();

            try
            {
                Dictionary<string, object> parametros = new();
                parametros.Add("FechaDesde", solicitud.FechaDesde);
                parametros.Add("RecursoId", solicitud.RecursoId);
                parametros.Add("FechaHasta", solicitud.FechaHasta);

                DataTable dt = new();
                this.conexion.EjecutarSPRetornaTabla("sp_ConsultarDisponibilidadRecurso", parametros);

                if (this.conexion.ExisteErrores())
                {
                    respuesta.OcurrioError = true;
                    respuesta.CodigoError = "999";
                    respuesta.MensajeCliente = "Ha ocurrido un error al consultar disponibilidad de recurso.";
                    respuesta.MensajeTecnico = $"Metodo: {nameof(this.ConsultarDisponibilidadRecurso)} Excepción:{this.conexion.ObtenerErrorMensaje()}";
                    return respuesta;
                }

                if (dt?.Rows.Count > 0)
                {
                    respuesta.Modelo = new();
                    foreach (DataRow dr in dt.Rows)
                    {
                        ConsultarDisponibilidadRecursoResponse nuevo = new();
                        nuevo.Id = dr?["Id"] == DBNull.Value ? 0 : Convert.ToInt32(dr?["Id"] ?? 0);
                        nuevo.Estado = dr?["Estado"] == DBNull.Value ? string.Empty : dr?["Estado"].ToString() ?? string.Empty;
                        nuevo.CursoId = dr?["CursoId"] == DBNull.Value ? 0 : Convert.ToInt32(dr?["CursoId"] ?? 0);
                        nuevo.FechaFin = dr?["FechaFin"] == DBNull.Value ? default(DateTime) : Convert.ToDateTime(dr?["FechaFin"] ?? default(DateTime));
                        nuevo.NombreCatedratico = dr?["NombreCatedratico"] == DBNull.Value ? string.Empty : dr?["NombreCatedratico"].ToString() ?? string.Empty;
                        nuevo.CodigoCurso = dr?["CodigoCurso"] == DBNull.Value ? string.Empty : dr?["CodigoCurso"].ToString() ?? string.Empty;
                        nuevo.CatedraticoId = dr?["CatedraticoId"] == DBNull.Value ? 0 : Convert.ToInt32(dr?["CatedraticoId"] ?? 0);
                        nuevo.FechaInicio = dr?["FechaInicio"] == DBNull.Value ? default(DateTime) : Convert.ToDateTime(dr?["FechaInicio"] ?? default(DateTime));
                        nuevo.Motivo = dr?["Motivo"] == DBNull.Value ? string.Empty : dr?["Motivo"].ToString() ?? string.Empty;
                        respuesta.Modelo.Add(nuevo);
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta.CodigoError = "999";
                respuesta.MensajeCliente = $"Ha ocurrido un error al consultar disponibilidad de recurso..";
                respuesta.MensajeTecnico = $"Metodo: {nameof(this.ConsultarDisponibilidadRecurso)} Excepción:{ex.ToString()}";
                respuesta.OcurrioError = true;
            }

            return respuesta;
        }

    }
}
