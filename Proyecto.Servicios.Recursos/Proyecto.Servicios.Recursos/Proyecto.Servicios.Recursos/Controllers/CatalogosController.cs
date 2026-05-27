using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Servicios.Recursos.Models;
using Proyecto.Servicios.Recursos.Models.Catalogo;
using Proyecto.Servicios.Recursos.Models.Logs;
using Proyecto.Servicios.Recursos.Models.Reservacion;
using Proyecto.Servicios.Recursos.Services;

namespace Proyecto.Servicios.Recursos.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogosController : ControllerBase
    {
        [HttpPost]
        [Route("ListarRecursos")]
        [ProducesResponseType(typeof(RespuestaMensaje<List<RecursoResponse>>), StatusCodes.Status200OK)]
        public IActionResult ObtenerRecurso(ListarRecursosRequest solicitud)
        {
            RespuestaMensaje<List<RecursoResponse>> respuesta = new();

            try
            {
                RecursoService catalogo = new();
                respuesta = catalogo.ObtenerCatalogo(solicitud);
            }
            catch (Exception ex)
            {
                respuesta.CodigoError = "999";
                respuesta.MensajeCliente = $"Ha ocurrido un error al obtener el catalogo.";
                respuesta.MensajeTecnico = $"Metodo: {nameof(this.ObtenerRecurso)} Excepción:{ex.ToString()}";
                respuesta.OcurrioError = true;
            }

            return this.Ok(respuesta);
        }

        [HttpPost]
        [Route("ObtenerCatedraticoPorUsuario")]
        [ProducesResponseType(typeof(RespuestaMensaje<List<ObtenerCatedraticoPorUsuarioResponse>>), StatusCodes.Status200OK)]
        public IActionResult ObtenerCatedraticoPorUsuario(ObtenerCatedraticoPorUsuarioRequest solicitud)
        {
            RespuestaMensaje<List<ObtenerCatedraticoPorUsuarioResponse>> respuesta = new();

            try
            {
                CatedraticoService catalogo = new();
                respuesta = catalogo.ObtenerCatalogo(solicitud);
            }
            catch (Exception ex)
            {
                respuesta.CodigoError = "999";
                respuesta.MensajeCliente = $"Ha ocurrido un error al obtener el catalogo.";
                respuesta.MensajeTecnico = $"Metodo: {nameof(this.ObtenerCatedraticoPorUsuario)} Excepción:{ex.ToString()}";
                respuesta.OcurrioError = true;
            }

            return this.Ok(respuesta);
        }

        [HttpPost]
        [Route("ObtenerCatedraticos")]
        [ProducesResponseType(typeof(RespuestaMensaje<List<CatedraticoListadoResponse>>), StatusCodes.Status200OK)]
        public IActionResult ObtenerCatedraticos(ListarCatedraticosRequest solicitud)
        {
            RespuestaMensaje<List<CatedraticoListadoResponse>> respuesta = new();
            try
            {
                CatedraticoService servicio = new();
                respuesta = servicio.ObtenerCatalogo(solicitud);
            }
            catch (Exception ex)
            {
                respuesta.CodigoError = "999";
                respuesta.MensajeCliente = $"Ha ocurrido un error al obtener el catalogo.";
                respuesta.MensajeTecnico = $"Metodo: {nameof(this.ObtenerCatedraticoPorUsuario)} Excepción:{ex.ToString()}";
                respuesta.OcurrioError = true;
            }

            return this.Ok(respuesta);
        }

        [HttpPost]
        [Route("ObtenerCategoria")]
        [ProducesResponseType(typeof(RespuestaMensaje<List<CategoriaResponse>>), StatusCodes.Status200OK)]
        public IActionResult ObtenerCategoria(ListarCatedraticosRequest solicitud)
        {
            RespuestaMensaje<List<CategoriaResponse>> respuesta = new();
            try
            {
                CategoriaService servicio = new();
                respuesta = servicio.ObtenerCategoria();
            }
            catch (Exception ex)
            {
                respuesta.CodigoError = "999";
                respuesta.MensajeCliente = $"Ha ocurrido un error al obtener el catalogo.";
                respuesta.MensajeTecnico = $"Metodo: {nameof(this.ObtenerCatedraticoPorUsuario)} Excepción:{ex.ToString()}";
                respuesta.OcurrioError = true;
            }

            return this.Ok(respuesta);
        }

        [HttpPost]
        [Route("ObtenerCursos")]
        [ProducesResponseType(typeof(RespuestaMensaje<List<CursoResponse>>), StatusCodes.Status200OK)]
        public IActionResult ObtenerCursos(ListarCursosPorCatedraticoRequest solicitud)
        {
            RespuestaMensaje<List<CursoResponse>> respuesta = new();
            try
            {
                CursoService servicio = new();
                respuesta = servicio.ObtenerCurso(solicitud);
            }
            catch (Exception ex)
            {
                respuesta.CodigoError = "999";
                respuesta.MensajeCliente = $"Ha ocurrido un error al obtener el catalogo.";
                respuesta.MensajeTecnico = $"Metodo: {nameof(this.ObtenerCatedraticoPorUsuario)} Excepción:{ex.ToString()}";
                respuesta.OcurrioError = true;
            }

            return this.Ok(respuesta);
        }

        /// <summary>
        /// Metodo para Login.
        /// </summary>
        /// <param name="solicitud">Solicitud de login.</param>
        /// <returns>Respuesta de login.</returns>
        [HttpPost]
        [Route("ListarNotificacion")]
        [ProducesResponseType(typeof(RespuestaMensaje<List<LogNotificacionResponse>>), StatusCodes.Status200OK)]
        public RespuestaMensaje<List<LogNotificacionResponse>> ListarNotificacion(ListarLogsNotificacionRequest solicitud)
        {
            RespuestaMensaje<List<LogNotificacionResponse>> respuesta = new();

            try
            {
                LogService loginServices = new();
                respuesta = loginServices.ListarNotificacionLog(solicitud);
            }
            catch (Exception ex)
            {
                respuesta.CodigoError = "999";
                respuesta.MensajeCliente = "Ha ocurrido un error, intente nuevamente.";
                respuesta.MensajeTecnico = $"Error en: ListarLog Excepción: {ex.ToString()}";
                respuesta.OcurrioError = true;
            }

            return respuesta;
        }

        /// <summary>
        /// Metodo para Login.
        /// </summary>
        /// <param name="solicitud">Solicitud de login.</param>
        /// <returns>Respuesta de login.</returns>
        [HttpPost]
        [Route("ListarMotivo")]
        [ProducesResponseType(typeof(RespuestaMensaje<List<MotivoResponse>>), StatusCodes.Status200OK)]
        public RespuestaMensaje<List<MotivoResponse>> ListarMotivo()
        {
            RespuestaMensaje<List<MotivoResponse>> respuesta = new();

            try
            {
                MotivoService loginServices = new();
                respuesta = loginServices.ListarMotivo();
            }
            catch (Exception ex)
            {
                respuesta.CodigoError = "999";
                respuesta.MensajeCliente = "Ha ocurrido un error, intente nuevamente.";
                respuesta.MensajeTecnico = $"Error en: ListarLog Excepción: {ex.ToString()}";
                respuesta.OcurrioError = true;
            }

            return respuesta;
        }
    }
}
