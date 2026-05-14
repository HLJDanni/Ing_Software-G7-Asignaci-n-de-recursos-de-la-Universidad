// <copyright file="CatedraticoService.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

using System.Data;
using Proyecto.Servicios.Recursos.Interfaces;
using Proyecto.Servicios.Recursos.Models;
using Proyecto.Servicios.Recursos.Models.Catalogo;

namespace Proyecto.Servicios.Recursos.Services
{
    public class CatedraticoService : ICatalogo<Catedratico>
    {
        private readonly ConexíonBD conexion;

        /// <summary>
        /// Initializes a new instance of the <see cref="CatedraticoService"/> class.
        /// </summary>
        public CatedraticoService()
        {
            this.conexion = new();
        }

        [Obsolete]
        public RespuestaMensaje<List<Catedratico>> ObtenerCatalogo()
        {
            RespuestaMensaje<List<Catedratico>> respuesta = new();

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
                        Catedratico nuevo = new();
                        nuevo.Id = dr?["Id"] == DBNull.Value ? 0 : Convert.ToInt32(dr?["Id"] ?? 0);
                        nuevo.NombreCompleto = dr?["NombreCompleto"] == DBNull.Value ? string.Empty : dr?["NombreCompleto"].ToString() ?? string.Empty;

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
