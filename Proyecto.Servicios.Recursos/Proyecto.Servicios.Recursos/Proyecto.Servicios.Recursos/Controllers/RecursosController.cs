// <copyright file="RecursosController.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Servicios.Recursos.Models;
using Proyecto.Servicios.Recursos.Models.Cancelacion;
using Proyecto.Servicios.Recursos.Models.Recursos;
using Proyecto.Servicios.Recursos.Services;

namespace Proyecto.Servicios.Recursos.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RecursosController : ControllerBase
    {
        [HttpPost]
        [Route("ConsultarDisponibilidadRecurso")]
        [ProducesResponseType(typeof(RespuestaMensaje<List<ConsultarDisponibilidadRecursoResponse>>), StatusCodes.Status200OK)]
        public IActionResult CancelarReservacion(ConsultarDisponibilidadRecursoRequest solicitud)
        {
            RespuestaMensaje<List<ConsultarDisponibilidadRecursoResponse>> respuesta = new();

            try
            {
                RecursoService servicio = new();
                respuesta = servicio.ConsultarDisponibilidadRecurso(solicitud);
            }
            catch (Exception ex)
            {
                respuesta.CodigoError = "999";
                respuesta.MensajeCliente = $"Ha ocurrido un error al consultar disponibilidad de recurso..";
                respuesta.MensajeTecnico = $"Metodo: {nameof(this.CancelarReservacion)} Excepción:{ex.ToString()}";
                respuesta.OcurrioError = true;
            }

            return this.Ok(respuesta);
        }
    }
}
