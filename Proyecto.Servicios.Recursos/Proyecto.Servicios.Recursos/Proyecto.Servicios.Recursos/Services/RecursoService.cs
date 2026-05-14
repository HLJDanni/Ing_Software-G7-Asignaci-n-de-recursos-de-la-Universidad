// <copyright file="RecursoService.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

using System.Data;
using Proyecto.Servicios.Recursos.Interfaces;
using Proyecto.Servicios.Recursos.Models;
using Proyecto.Servicios.Recursos.Models.Catalogo;

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
                this.conexion.EjecutarSPRetornaTabla("NombreSP", null);

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
    }
}
