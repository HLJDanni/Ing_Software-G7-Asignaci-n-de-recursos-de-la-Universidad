// <copyright file="LoginServices.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

using Proyecto.Servicios.Recursos.Models;
using Proyecto.Servicios.Recursos.Models.Login;

namespace Proyecto.Servicios.Recursos.Services;

public class LoginServices
{
    private readonly ConexíonBD conexion;

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
        this.conexion = new();
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
            this.AgregarLoginExitoso(1); // Cuando exista login se cambia por id de login

            return respuesta;
        }
        else
        {
            this.RegistrarLoginFallido(1); // Cuando exista login se cambia por id de login

            respuesta = this.GenerarMensajeError(
                   "Usuario o contraseña incorrectos",
                   "Usuario o contraseña incorrectos");
            return respuesta;
        }
    }

    private RespuestaMensaje<bool> AgregarLoginExitoso(int catedraticoId)
    {
        RespuestaMensaje<bool> respuesta = new();

        try
        {
            Dictionary<string, object> parametros = new();
            parametros.Add("CatedraticoId", catedraticoId);
            this.conexion.EjecutarSP(SPs.RegistrarLoginExitoso, parametros);

            if (this.conexion.ExisteErrores())
            {
                respuesta.OcurrioError = true;
                respuesta.CodigoError = "999";
                respuesta.MensajeCliente = "Ha ocurrido un error al crear una reservación.";
                respuesta.MensajeTecnico = $"Metodo: {nameof(this.AgregarLoginExitoso)} Excepción: {this.conexion.ObtenerErrorMensaje()}";
                return respuesta;
            }

            respuesta.Modelo = new();
            respuesta.Modelo = true;
        }
        catch (Exception ex)
        {
            respuesta.CodigoError = "999";
            respuesta.MensajeCliente = $"Ha ocurrido un error al obtener el catalogo.";
            respuesta.MensajeTecnico = $"Metodo: {nameof(this.AgregarLoginExitoso)} Excepción:{ex.ToString()}";
            respuesta.OcurrioError = true;
        }

        return respuesta;
    }

    private RespuestaMensaje<bool> RegistrarLoginFallido(int catedraticoId)
    {
        RespuestaMensaje<bool> respuesta = new();

        try
        {
            Dictionary<string, object> parametros = new();
            parametros.Add("CatedraticoId", catedraticoId);
            this.conexion.EjecutarSP(SPs.RegistrarLoginFallido, parametros);

            if (this.conexion.ExisteErrores())
            {
                respuesta.OcurrioError = true;
                respuesta.CodigoError = "999";
                respuesta.MensajeCliente = "Ha ocurrido un error al crear una reservación.";
                respuesta.MensajeTecnico = $"Metodo: {nameof(this.RegistrarLoginFallido)} Excepción: {this.conexion.ObtenerErrorMensaje()}";
                return respuesta;
            }

            respuesta.Modelo = new();
            respuesta.Modelo = true;
        }
        catch (Exception ex)
        {
            respuesta.CodigoError = "999";
            respuesta.MensajeCliente = $"Ha ocurrido un error al obtener el catalogo.";
            respuesta.MensajeTecnico = $"Metodo: {nameof(this.RegistrarLoginFallido)} Excepción:{ex.ToString()}";
            respuesta.OcurrioError = true;
        }

        return respuesta;
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
