// <copyright file="LoginServices.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

using Proyecto.Servicios.Recursos.Models;
using Proyecto.Servicios.Recursos.Models.Login;

namespace Proyecto.Servicios.Recursos.Services;

public class LoginServices
{
    /// <summary>
    /// Servicio de Jwt
    /// </summary>
    private readonly JwtService jwtService;

    /// <summary>
    /// Initializes a new instance of the <see cref="LoginServices"/> class.
    /// </summary>
    /// <param name="jwtService">Servicio JWT.</param>
    public LoginServices(JwtService jwtService)
    {
        this.jwtService = jwtService;
    }

    public RespuestaMensaje<LoginResponse> Login(LoginRequest solicitud)
    {
        RespuestaMensaje<LoginResponse> respuesta = new();

        if (respuesta == null)
        {
            respuesta = this.GenerarMensajeError(
                    "Solicitud tiene información nula",
                    "Solicitud tiene información nula");
            return respuesta;
        }

        if (string.IsNullOrEmpty(solicitud.User) || string.IsNullOrEmpty(solicitud.Password))
        {
            respuesta = this.GenerarMensajeError(
                    "Usuario o contraseña viene nula",
                    "Usuario o contraseña viene nula");
            return respuesta;
        }

        if (solicitud.User == "admin" && solicitud.Password == "1234")
        {
            var token = this.jwtService.GenerarToken(solicitud.User);
            LoginResponse respuestaToken = new();
            respuestaToken.Token = token;
            respuesta.Modelo = respuestaToken;
            return respuesta;
        }
        else
        {
            respuesta = this.GenerarMensajeError(
                   "Usuario o contraseña incorrectos",
                   "Usuario o contraseña incorrectos");
            return respuesta;
        }
    }

    private RespuestaMensaje<LoginResponse> GenerarMensajeError(string mensajeCliente, string mensajeTecnico, string codigo = "999")
    {
        RespuestaMensaje<LoginResponse> respuesta = new();
        respuesta.MensajeCliente = mensajeCliente;
        respuesta.MensajeTecnico = mensajeTecnico;
        respuesta.OcurrioError = true;
        respuesta.CodigoError = codigo;
        return respuesta;
    }
}
