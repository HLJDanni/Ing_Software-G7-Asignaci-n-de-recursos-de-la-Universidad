// <copyright file="Login.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

using Microsoft.Extensions.Configuration;
using Proyecto.Servicios.Recursos.Models.Login;
using Proyecto.Servicios.Recursos.Services;

namespace Pruebas.Recursos
{
    public class Login
    {
        private readonly IConfiguration config;
        private readonly JwtService jwtService;
        private readonly LoginServices loginServices;

        public Login()
        {
            this.config = ObtenerConfiguracionJwt();
            this.jwtService = new(this.config);
            this.loginServices = new(this.jwtService);
        }

        [Fact]
        public void Login_CuandoUsuarioEsValido_GeneraTokenReal()
        {
            var solicitud = new LoginRequest
            {
                User = "admin",
                Password = "1234",
            };

            // Act  ← aquí se consume el método real
            var respuesta = this.loginServices.Login(solicitud);

            // Assert
            Assert.NotNull(respuesta);
            Assert.False(respuesta.OcurrioError);
            Assert.NotNull(respuesta.Modelo);
            Assert.False(string.IsNullOrEmpty(respuesta.Modelo.Token));
        }

        [Fact]
        public void Login_CuandoUsuarioEsInvalido()
        {
            var solicitud = new LoginRequest
            {
                User = "admin2",
                Password = "1234",
            };

            var respuesta = this.loginServices.Login(solicitud);

            Assert.True(respuesta.OcurrioError);
        }

        private static IConfiguration ObtenerConfiguracionJwt()
        {
            var configData = new Dictionary<string, string>
            {
                { "Jwt:Key", "Efta2vIvlUlkB14FSZf1QZNRtQOTLC2VH3duGK+ndmhCBuOLYyTS/lUgeqQvJly7JEqJudeOzyFPmx7lcII7Qw==" },
                { "Jwt:Issuer", "Producto" },
                { "Jwt:Audience", "ProductoUsuarios" },
                { "Jwt:ExpireMinutes", "60" }
            };

#pragma warning disable CS8620 // El argumento no se puede usar para el parámetro debido a las diferencias en la nulabilidad de los tipos de referencia.
            return new ConfigurationBuilder()
                .AddInMemoryCollection(configData)
                .Build();
#pragma warning restore CS8620 // El argumento no se puede usar para el parámetro debido a las diferencias en la nulabilidad de los tipos de referencia.
        }
    }
}
