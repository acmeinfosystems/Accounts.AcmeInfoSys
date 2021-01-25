//-----------------------------------------------------------------------
// <copyright file="UserEntry.cs" company="Acme Info Systems">
//     Author: Sreejith Gopinathan
//     Copyright (c) Acme Info Systems. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;

namespace Accounts.AcmeInfoSys.Data.Entities
{
    /// <summary>
    /// Entity class represents a row in Journal table in the database.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Get or set unique id.
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// Get or set name.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Get or set username.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        /// <summary>
        /// Get or set username.
        /// </summary>
        [Required]
        [StringLength(500)]
        public string Password { get; set; }

        /// <summary>
        /// Get or set created date.
        /// </summary>        
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Get or set updated date.
        /// </summary>        
        public Nullable<DateTime> UpdatedOn { get; set; }

        /// <summary>
        /// Get or set is active.
        /// </summary>
        public bool IsActive { get; set; }
    }
}