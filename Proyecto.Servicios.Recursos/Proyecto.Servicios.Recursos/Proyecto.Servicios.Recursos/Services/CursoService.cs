using System.Data;
using Proyecto.Servicios.Recursos.Interfaces;
using Proyecto.Servicios.Recursos.Models;
using Proyecto.Servicios.Recursos.Models.Catalogo;

namespace Proyecto.Servicios.Recursos.Services
{
    public class CursoService : ICatalogo<Curso>
    {
        private readonly ConexíonBD conexion;

        /// <summary>
        /// Initializes a new instance of the <see cref="CursoService"/> class.
        /// </summary>
        public CursoService()
        {
            this.conexion = new();
        }

        [Obsolete]
        public RespuestaMensaje<List<Curso>> ObtenerCatalogo()
        {
            RespuestaMensaje<List<Curso>> respuesta = new();

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
                        Curso nuevo = new();
                        nuevo.Id = dr?["Id"] == DBNull.Value ? 0 : Convert.ToInt32(dr?["Id"] ?? 0);
                        nuevo.Nombre = dr?["Nombre"] == DBNull.Value ? string.Empty : dr?["Nombre"].ToString() ?? string.Empty;
                        nuevo.Codigo = dr?["Codigo"] == DBNull.Value ? string.Empty : dr?["Codigo"].ToString() ?? string.Empty;
                        nuevo.CatedraticoId = dr?["CatedraticoId"] == DBNull.Value ? 0 : Convert.ToInt32(dr?["CatedraticoId"] ?? 0);
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
