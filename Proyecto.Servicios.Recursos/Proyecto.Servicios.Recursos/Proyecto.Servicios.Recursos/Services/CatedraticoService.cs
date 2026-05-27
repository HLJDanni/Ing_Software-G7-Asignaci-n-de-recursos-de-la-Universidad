// <copyright file="CatedraticoService.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

using System.Data;
using Proyecto.Servicios.Recursos.Models;
using Proyecto.Servicios.Recursos.Models.Catalogo;
using Proyecto.Servicios.Recursos.Models.Reservacion;

namespace Proyecto.Servicios.Recursos.Services
{
    public class CatedraticoService
    {
        private readonly ConexíonBD conexion;

        /// <summary>
        /// Initializes a new instance of the <see cref="CatedraticoService"/> class.
        /// </summary>
        public CatedraticoService()
        {
            this.conexion = new();
        }

        public RespuestaMensaje<List<ObtenerCatedraticoPorUsuarioResponse>> ObtenerCatalogo(ObtenerCatedraticoPorUsuarioRequest solicitud)
        {
            RespuestaMensaje<List<ObtenerCatedraticoPorUsuarioResponse>> respuesta = new();

            try
            {
                Dictionary<string, object> parametros = new();
                parametros.Add("NombreUsuario", solicitud.NombreUsuario);

                DataTable dt = new();
                this.conexion.EjecutarSPRetornaTabla(SPs.ObtenerCatedraticoPorUsuario, parametros);

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
                        ObtenerCatedraticoPorUsuarioResponse nuevo = new();
                        nuevo.Id = dr?["Id"] == DBNull.Value ? 0 : Convert.ToInt32(dr?["Id"] ?? 0);
                        nuevo.NombreUsuario = dr?["NombreUsuario"] == DBNull.Value ? string.Empty : dr?["NombreUsuario"].ToString() ?? string.Empty;
                        nuevo.HashContrasena = dr?["HashContrasena"] == DBNull.Value ? string.Empty : dr?["HashContrasena"].ToString() ?? string.Empty;
                        nuevo.NombreCompleto = dr?["NombreCompleto"] == DBNull.Value ? string.Empty : dr?["NombreCompleto"].ToString() ?? string.Empty;
                        nuevo.CorreoInstitucional = dr?["CorreoInstitucional"] == DBNull.Value ? string.Empty : dr?["CorreoInstitucional"].ToString() ?? string.Empty;
                        nuevo.FechaUltimoAcceso = dr?["FechaUltimoAcceso"] == DBNull.Value ? default(DateTime) : Convert.ToDateTime(dr?["FechaUltimoAcceso"] ?? default(DateTime));
                        nuevo.IntentosFallidos = dr?["IntentosFallidos"] == DBNull.Value ? 0 : Convert.ToInt32(dr?["IntentosFallidos"] ?? 0);
                        nuevo.BloqueadoHasta = dr?["BloqueadoHasta"] == DBNull.Value ? default(DateTime) : Convert.ToDateTime(dr?["BloqueadoHasta"] ?? default(DateTime));
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

        public RespuestaMensaje<List<CatedraticoListadoResponse>> ObtenerCatalogo(ListarCatedraticosRequest solicitud)
        {
            RespuestaMensaje<List<CatedraticoListadoResponse>> respuesta = new();

            try
            {
                Dictionary<string, object> parametros = new();
                parametros.Add("SoloActivos", solicitud.SoloActivos ? "1" : "0");

                DataTable dt = new();
                this.conexion.EjecutarSPRetornaTabla(SPs.ObtenerCatedratico, parametros);

                if (this.conexion.ExisteErrores())
                {
                    respuesta.OcurrioError = true;
                    respuesta.CodigoError = "999";
                    respuesta.MensajeCliente = "Ha ocurrido un error al consultar los catalogos.";
                    respuesta.MensajeTecnico = $"Metodo: {nameof(this.ObtenerCatalogo)} Excepción:{this.conexion.ObtenerErrorMensaje()}";
                    return respuesta;
                }

                dt = this.conexion.ObtenerResultadoSP();
                if (dt?.Rows.Count > 0)
                {
                    respuesta.Modelo = new();
                    foreach (DataRow dr in dt.Rows)
                    {
                        CatedraticoListadoResponse nuevo = new();
                        nuevo.Id = dr?["Id"] == DBNull.Value ? 0 : Convert.ToInt32(dr?["Id"] ?? 0);
                        nuevo.NombreUsuario = dr?["NombreUsuario"] == DBNull.Value ? string.Empty : dr?["NombreUsuario"].ToString() ?? string.Empty;
                        nuevo.NombreCompleto = dr?["NombreCompleto"] == DBNull.Value ? string.Empty : dr?["NombreCompleto"].ToString() ?? string.Empty;
                        nuevo.CorreoInstitucional = dr?["CorreoInstitucional"] == DBNull.Value ? string.Empty : dr?["CorreoInstitucional"].ToString() ?? string.Empty;
                        nuevo.FechaUltimoAcceso = dr?["FechaUltimoAcceso"] == DBNull.Value ? default(DateTime) : Convert.ToDateTime(dr?["FechaUltimoAcceso"] ?? default(DateTime));
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
    }
}
