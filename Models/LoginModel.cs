//-----------------------------------------------------------------------
// <copyright file="LoginModel.cs" company="Acme Info Systems">
//     Author: Sreejith Gopinathan
//     Copyright (c) Acme Info Systems. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Accounts.AcmeInfoSys.Models
{
    /// <summary>
    /// A DTO object to pass user credetials.
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// Get or set username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Get or set password.
        /// </summary>
        public string Password { get; set; }
    }
}