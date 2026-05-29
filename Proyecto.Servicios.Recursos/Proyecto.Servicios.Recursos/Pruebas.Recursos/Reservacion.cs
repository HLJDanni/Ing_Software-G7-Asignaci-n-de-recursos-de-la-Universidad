// <copyright file="Reservacion.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

using Proyecto.Servicios.Recursos.Models.Cancelacion;
using Proyecto.Servicios.Recursos.Models.Recursos;
using Proyecto.Servicios.Recursos.Models.Reservacion;
using Proyecto.Servicios.Recursos.Services;

namespace Pruebas.Recursos;

public class Reservacion
{
    [Fact]
    public void CancelarReservacionNoEncontrada()
    {
        var solicitud = new CancelarReservacionRequest
        {
            IdReserva = 100,
            IdCatedratico = 100
        };

        CancelacionService servicio = new();
        var respuesta = servicio.CancelarReserva(solicitud);

        // Assert
        Assert.NotNull(respuesta);
        Assert.True(respuesta.OcurrioError);
    }

    [Fact]
    public void CompletarReservasVencidas()
    {
        ReservacionService servicio = new();
        var respuesta = servicio.CompletarReservasVencidas();

        // Assert
        Assert.NotNull(respuesta);
        Assert.False(respuesta.OcurrioError);
    }

    [Fact]
    public void CrearReservacion()
    {
        var solicitud = new CrearReservaRequest
        {
            RecursoId = 1,
            CatedraticoId = 1,
            FechaInicio = DateTime.Now.AddDays(1),
            FechaFin = DateTime.Now.AddDays(2),
            MotivoId = 1,
            CursoId = 1,
        };

        ReservacionService servicio = new();
        var respuesta = servicio.CrearReservacion(solicitud);

        // Assert
        Assert.NotNull(respuesta);
        Assert.False(respuesta.OcurrioError);
        Assert.NotNull(respuesta.Modelo);
    }

    [Fact]
    public void ListarHistorialReservas()
    {
        var solicitud = new ListarHistorialReservasRequest
        {
            CatedraticoId = 1,
        };

        ReservacionService servicio = new();
        var respuesta = servicio.ListarHistorialReservas(solicitud);

        // Assert
        Assert.NotNull(respuesta);
        Assert.False(respuesta.OcurrioError);
        Assert.NotNull(respuesta.Modelo);
    }
}
