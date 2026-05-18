using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Servicios.Recursos.Models;
using Proyecto.Servicios.Recursos.Models.Login;
using Proyecto.Servicios.Recursos.Services;

namespace Proyecto.Servicios.Recursos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly JwtService jwtService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginController"/> class.
        /// </summary>
        /// <param name="jwtService">Servicio de jwt.</param>
        public LoginController(JwtService jwtService)
        {
            this.jwtService = jwtService;
        }

        /// <summary>
        /// Metodo para Login.
        /// </summary>
        /// <param name="solicitud">Solicitud de login.</param>
        /// <returns>Respuesta de login.</returns>
        [HttpPost(Name = "api/Login")]
        public RespuestaMensaje<LoginResponse> Login(LoginRequest solicitud)
        {
            RespuestaMensaje<LoginResponse> respuesta = new();

            try
            {
                LoginServices loginServices = new(this.jwtService);
                respuesta = loginServices.Login(solicitud);
            }
            catch (Exception ex)
            {
                respuesta.CodigoError = "999";
                respuesta.MensajeCliente = "Ha ocurrido un error, intente nuevamente.";
                respuesta.MensajeTecnico = $"Error en: api/Login Excepción: {ex.ToString()}";
                respuesta.OcurrioError = true;
            }

            return respuesta;
        }
    }
}
