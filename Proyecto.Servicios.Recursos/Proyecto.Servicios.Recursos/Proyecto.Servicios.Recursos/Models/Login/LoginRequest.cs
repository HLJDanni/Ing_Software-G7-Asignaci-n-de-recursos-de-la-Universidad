// <copyright file="LoginRequest.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

namespace Proyecto.Servicios.Recursos.Models.Login
{
    public class LoginRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginRequest"/> class.
        /// </summary>
        public LoginRequest()
        {
            this.User = string.Empty;
            this.Password = string.Empty;
        }

        /// <summary>
        /// Gets or sets usuario.
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Gets or sets password.
        /// </summary>
        public string Password { get; set; }
    }
}
