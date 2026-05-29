// <copyright file="Catalogos.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

using Proyecto.Servicios.Recursos.Models.Catalogo;
using Proyecto.Servicios.Recursos.Models.Logs;
using Proyecto.Servicios.Recursos.Models.Reservacion;
using Proyecto.Servicios.Recursos.Services;

namespace Pruebas.Recursos;

public class Catalogos
{
    [Fact]
    public void ListarRecursos()
    {
        var solicitud = new ListarRecursosRequest
        {
            SoloActivos = true,
        };

        RecursoService catalogo = new();
        var respuesta = catalogo.ObtenerCatalogo(solicitud);

        // Assert
        Assert.NotNull(respuesta);
        Assert.False(respuesta.OcurrioError);
        Assert.NotNull(respuesta.Modelo);
    }

    [Fact]
    public void ObtenerCatedraticoPorUsuario()
    {
        var solicitud = new ObtenerCatedraticoPorUsuarioRequest
        {
            NombreUsuario = "FulanitoM",
        };

        CatedraticoService catalogo = new();
        var respuesta = catalogo.ObtenerCatalogo(solicitud);

        // Assert
        Assert.NotNull(respuesta);
        Assert.False(respuesta.OcurrioError);
        Assert.NotNull(respuesta.Modelo);
    }

    [Fact]
    public void ObtenerCatedraticos()
    {
        var solicitud = new ListarCatedraticosRequest
        {
            SoloActivos = true,
        };

        CatedraticoService servicio = new();
        var respuesta = servicio.ObtenerCatalogo(solicitud);

        // Assert
        Assert.NotNull(respuesta);
        Assert.False(respuesta.OcurrioError);
        Assert.NotNull(respuesta.Modelo);
    }

    [Fact]
    public void ObtenerCategoria()
    {
        CategoriaService servicio = new();
        var respuesta = servicio.ObtenerCategoria();

        // Assert
        Assert.NotNull(respuesta);
        Assert.False(respuesta.OcurrioError);
        Assert.NotNull(respuesta.Modelo);
    }

    [Fact]
    public void ObtenerCursos()
    {
        var solicitud = new ListarCursosPorCatedraticoRequest
        {
            CatedraticoId = 1,
        };

        CursoService servicio = new();
        var respuesta = servicio.ObtenerCurso(solicitud);

        // Assert
        Assert.NotNull(respuesta);
        Assert.False(respuesta.OcurrioError);
        Assert.NotNull(respuesta.Modelo);
    }

    [Fact]
    public void ListarNotificacion()
    {
        var solicitud = new ListarLogsNotificacionRequest
        {
            SoloFallidos = false,
        };

        LogService loginServices = new();
        var respuesta = loginServices.ListarNotificacionLog(solicitud);

        // Assert
        Assert.NotNull(respuesta);
        Assert.False(respuesta.OcurrioError);
    }

    [Fact]
    public void ListarMotivo()
    {
        MotivoService loginServices = new();
        var respuesta = loginServices.ListarMotivo();

        // Assert
        Assert.NotNull(respuesta);
        Assert.False(respuesta.OcurrioError);
        Assert.NotNull(respuesta.Modelo);
    }
}
