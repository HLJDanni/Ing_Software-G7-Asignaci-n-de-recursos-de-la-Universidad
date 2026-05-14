using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Servicios.Recursos.Interfaces;
using Proyecto.Servicios.Recursos.Models;
using Proyecto.Servicios.Recursos.Models.Catalogo;
using Proyecto.Servicios.Recursos.Services;

namespace Proyecto.Servicios.Recursos.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogosController : ControllerBase
    {
        [HttpGet]
        [Route("Catedraticos")]
        [ProducesResponseType(typeof(RespuestaMensaje<List<Catedratico>>), StatusCodes.Status200OK)]
        public IActionResult ObtenerCatedraticos()
        {
            RespuestaMensaje<List<Catedratico>> respuesta = new();

            try
            {
                ICatalogo<Catedratico> catalogo = new CatedraticoService();
               respuesta = catalogo.ObtenerCatalogo();
            }
            catch (Exception ex)
            {
                respuesta.CodigoError = "999";
                respuesta.MensajeCliente = $"Ha ocurrido un error al obtener el catalogo.";
                respuesta.MensajeTecnico = $"Metodo: {nameof(this.ObtenerCatedraticos)} Excepción:{ex.ToString()}";
                respuesta.OcurrioError = true;
            }

            return this.Ok(respuesta);
        }

        [HttpGet]
        [Route("Categoria")]
        [ProducesResponseType(typeof(RespuestaMensaje<List<Categoria>>), StatusCodes.Status200OK)]
        public IActionResult ObtenerCategoria()
        {
            RespuestaMensaje<List<Categoria>> respuesta = new();

            try
            {
                ICatalogo<Categoria> catalogo = new CategoriaService();
                respuesta = catalogo.ObtenerCatalogo();
            }
            catch (Exception ex)
            {
                respuesta.CodigoError = "999";
                respuesta.MensajeCliente = $"Ha ocurrido un error al obtener el catalogo.";
                respuesta.MensajeTecnico = $"Metodo: {nameof(this.ObtenerCategoria)} Excepción:{ex.ToString()}";
                respuesta.OcurrioError = true;
            }

            return this.Ok(respuesta);
        }

        [HttpGet]
        [Route("Curso")]
        [ProducesResponseType(typeof(RespuestaMensaje<List<Curso>>), StatusCodes.Status200OK)]
        public IActionResult ObtenerCurso()
        {
            RespuestaMensaje<List<Curso>> respuesta = new();

            try
            {
                ICatalogo<Curso> catalogo = new CursoService();
                respuesta = catalogo.ObtenerCatalogo();
            }
            catch (Exception ex)
            {
                respuesta.CodigoError = "999";
                respuesta.MensajeCliente = $"Ha ocurrido un error al obtener el catalogo.";
                respuesta.MensajeTecnico = $"Metodo: {nameof(this.ObtenerCurso)} Excepción:{ex.ToString()}";
                respuesta.OcurrioError = true;
            }

            return this.Ok(respuesta);
        }

        [HttpGet]
        [Route("Motivo")]
        [ProducesResponseType(typeof(RespuestaMensaje<List<Motivo>>), StatusCodes.Status200OK)]
        public IActionResult ObtenerMotivo()
        {
            RespuestaMensaje<List<Motivo>> respuesta = new();

            try
            {
                ICatalogo<Motivo> catalogo = new MotivoService();
                respuesta = catalogo.ObtenerCatalogo();
            }
            catch (Exception ex)
            {
                respuesta.CodigoError = "999";
                respuesta.MensajeCliente = $"Ha ocurrido un error al obtener el catalogo.";
                respuesta.MensajeTecnico = $"Metodo: {nameof(this.ObtenerMotivo)} Excepción:{ex.ToString()}";
                respuesta.OcurrioError = true;
            }

            return this.Ok(respuesta);
        }

        [HttpGet]
        [Route("Recurso")]
        [ProducesResponseType(typeof(RespuestaMensaje<List<Recurso>>), StatusCodes.Status200OK)]
        public IActionResult ObtenerRecurso()
        {
            RespuestaMensaje<List<Recurso>> respuesta = new();

            try
            {
                ICatalogo<Recurso> catalogo = new RecursoService();
                respuesta = catalogo.ObtenerCatalogo();
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
    }
}
