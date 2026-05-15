using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Servicios.Recursos.Interfaces;
using Proyecto.Servicios.Recursos.Models;
using Proyecto.Servicios.Recursos.Models.Cancelacion;
using Proyecto.Servicios.Recursos.Models.Catalogo;
using Proyecto.Servicios.Recursos.Models.Reservacion;
using Proyecto.Servicios.Recursos.Services;

namespace Proyecto.Servicios.Recursos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservacionController : ControllerBase
    {
        [HttpPost]
        [Route("CancelarReservacion")]
        [ProducesResponseType(typeof(RespuestaMensaje<CancelarReservacionResponse>), StatusCodes.Status200OK)]
        [Obsolete]
        public IActionResult CancelarReservacion(CancelarReservacionRequest solicitud)
        {
            RespuestaMensaje<CancelarReservacionResponse> respuesta = new();

            try
            {
                CancelacionService servicio = new();
                respuesta = servicio.CancelarReserva(solicitud);
            }
            catch (Exception ex)
            {
                respuesta.CodigoError = "999";
                respuesta.MensajeCliente = $"Ha ocurrido un error al cancelar la reserva.";
                respuesta.MensajeTecnico = $"Metodo: {nameof(this.CancelarReservacion)} Excepción:{ex.ToString()}";
                respuesta.OcurrioError = true;
            }

            return this.Ok(respuesta);
        }

        [HttpPost]
        [Route("CompletarReservasVencidas")]
        [ProducesResponseType(typeof(RespuestaMensaje<CompletarReservacionResponse>), StatusCodes.Status200OK)]
        [Obsolete]
        public IActionResult CompletarReservasVencidas()
        {
            RespuestaMensaje<CompletarReservacionResponse> respuesta = new();

            try
            {
                ReservacionService servicio = new();
                respuesta = servicio.CompletarReservasVencidas();
            }
            catch (Exception ex)
            {
                respuesta.CodigoError = "999";
                respuesta.MensajeCliente = $"Ha ocurrido un error al completar la reservacion.";
                respuesta.MensajeTecnico = $"Metodo: {nameof(this.CompletarReservasVencidas)} Excepción:{ex.ToString()}";
                respuesta.OcurrioError = true;
            }

            return this.Ok(respuesta);
        }

        [HttpPost]
        [Route("CrearReservacion")]
        [ProducesResponseType(typeof(RespuestaMensaje<CrearReservaResponse>), StatusCodes.Status200OK)]
        [Obsolete]
        public IActionResult CrearReservacion(CrearReservaRequest solicitud)
        {
            RespuestaMensaje<CrearReservaResponse> respuesta = new();

            try
            {
                ReservacionService servicio = new();
                respuesta = servicio.CrearReservacion(solicitud);
            }
            catch (Exception ex)
            {
                respuesta.CodigoError = "999";
                respuesta.MensajeCliente = $"Ha ocurrido un error  al crear una reservación.";
                respuesta.MensajeTecnico = $"Metodo: {nameof(this.CompletarReservasVencidas)} Excepción:{ex.ToString()}";
                respuesta.OcurrioError = true;
            }

            return this.Ok(respuesta);
        }
    }
}
