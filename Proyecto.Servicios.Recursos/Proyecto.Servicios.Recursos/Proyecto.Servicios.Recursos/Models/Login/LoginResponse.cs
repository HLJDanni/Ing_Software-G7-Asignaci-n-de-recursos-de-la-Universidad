// <copyright file="LoginResponse.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

namespace Proyecto.Servicios.Recursos.Models.Login
{
    public class LoginResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginResponse"/> class.
        /// </summary>
        public LoginResponse()
        {
            this.Token = string.Empty;
        }

        /// <summary>
        /// Gets or sets token.
        /// </summary>
        public string Token { get; set; }
    }
}
