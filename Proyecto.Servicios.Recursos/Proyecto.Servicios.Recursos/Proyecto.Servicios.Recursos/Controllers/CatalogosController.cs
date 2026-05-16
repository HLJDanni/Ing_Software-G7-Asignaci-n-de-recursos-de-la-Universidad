using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Servicios.Recursos.Models;
using Proyecto.Servicios.Recursos.Models.Catalogo;
using Proyecto.Servicios.Recursos.Models.Reservacion;
using Proyecto.Servicios.Recursos.Services;

namespace Proyecto.Servicios.Recursos.Controllers
{
    [Authorize]
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
    }
}
