// <copyright file="Recursos.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

using Proyecto.Servicios.Recursos.Models.Catalogo;
using Proyecto.Servicios.Recursos.Models.Recursos;
using Proyecto.Servicios.Recursos.Services;

namespace Pruebas.Recursos;

public class Recursos
{
    [Fact]
    public void CancelarReservacion()
    {
        var solicitud = new ConsultarDisponibilidadRecursoRequest
        {
            RecursoId = 1,
            FechaDesde = DateTime.Now,
            FechaHasta = DateTime.Now
        };

        RecursoService servicio = new();
        var respuesta = servicio.ConsultarDisponibilidadRecurso(solicitud);

        // Assert
        Assert.NotNull(respuesta);
        Assert.False(respuesta.OcurrioError);
    }
}
