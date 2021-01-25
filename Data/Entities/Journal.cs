//-----------------------------------------------------------------------
// <copyright file="JournalEntry.cs" company="Acme Info Systems">
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
    public class Journal
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
        [StringLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Get or set particulars.
        /// </summary>
        [Required]
        [StringLength(4000)]
        public string Particulars { get; set; }

        /// <summary>
        /// Get or set entry.
        /// </summary>
        [Required]
        [StringLength(2)]
        public string Entry { get; set; }

        /// <summary>
        /// Get or set amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Get or set transaction date.
        /// </summary>
        public DateTime TransactionDate { get; set; }

        /// <summary>
        /// Get or set is verified.
        /// </summary>
        public bool IsVerified { get; set; }

        /// <summary>
        /// Get or set created user name.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string CreatedBy { get; set; }        

        /// <summary>
        /// Get or set created date.
        /// </summary>        
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Get or set updated user name.
        /// </summary>        
        [StringLength(100)]
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Get or set updated date.
        /// </summary>
        public Nullable<DateTime> UpdatedOn { get; set; }
    }
}