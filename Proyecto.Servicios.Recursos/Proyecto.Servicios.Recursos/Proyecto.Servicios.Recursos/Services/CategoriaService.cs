// <copyright file="CategoriaService.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

using Proyecto.Servicios.Recursos.Models;
using Proyecto.Servicios.Recursos.Models.Catalogo;
using System.Data;

namespace Proyecto.Servicios.Recursos.Services
{
    public class CategoriaService
    {
        private readonly ConexíonBD conexion;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoriaService"/> class.
        /// </summary>
        public CategoriaService()
        {
            this.conexion = new();
        }

        public RespuestaMensaje<List<CategoriaResponse>> ObtenerCategoria()
        {
            RespuestaMensaje<List<CategoriaResponse>> respuesta = new();

            try
            {
                DataTable dt = new();
                this.conexion.EjecutarSPRetornaTabla(SPs.ListarCategorias, null);

                if (this.conexion.ExisteErrores())
                {
                    respuesta.OcurrioError = true;
                    respuesta.CodigoError = "999";
                    respuesta.MensajeCliente = "Ha ocurrido un error al consultar los catalogos.";
                    respuesta.MensajeTecnico = $"Metodo: {nameof(this.ObtenerCategoria)} Excepción:{this.conexion.ObtenerErrorMensaje()}";
                    return respuesta;
                }

                dt = this.conexion.ObtenerResultadoSP();
                if (dt?.Rows.Count > 0)
                {
                    respuesta.Modelo = new();
                    foreach (DataRow dr in dt.Rows)
                    {
                        CategoriaResponse nuevo = new();
                        nuevo.Id = dr?["Id"] == DBNull.Value ? 0 : Convert.ToInt32(dr?["Id"] ?? 0);
                        nuevo.TotalRecursos = dr?["TotalRecursos"] == DBNull.Value ? 0 : Convert.ToInt32(dr?["TotalRecursos"] ?? 0);
                        nuevo.Descripcion = dr?["Descripcion"] == DBNull.Value ? string.Empty : dr?["Descripcion"].ToString() ?? string.Empty;
                        nuevo.Nombre = dr?["Nombre"] == DBNull.Value ? string.Empty : dr?["Nombre"].ToString() ?? string.Empty;
                        respuesta.Modelo.Add(nuevo);
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta.CodigoError = "999";
                respuesta.MensajeCliente = $"Ha ocurrido un error al obtener el catalogo.";
                respuesta.MensajeTecnico = $"Metodo: {nameof(this.ObtenerCategoria)} Excepción:{ex.ToString()}";
                respuesta.OcurrioError = true;
            }

            return respuesta;
        }
    }
}
