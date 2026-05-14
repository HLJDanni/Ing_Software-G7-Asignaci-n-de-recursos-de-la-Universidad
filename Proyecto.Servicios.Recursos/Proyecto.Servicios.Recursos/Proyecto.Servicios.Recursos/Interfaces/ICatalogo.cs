// <copyright file="ICatalogo.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

using Proyecto.Servicios.Recursos.Models;

namespace Proyecto.Servicios.Recursos.Interfaces
{
    public interface ICatalogo<T>
    {
        RespuestaMensaje<List<T>> ObtenerCatalogo();
    }
}
