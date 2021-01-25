//-----------------------------------------------------------------------
// <copyright file="AccountDbContext.cs" company="Acme Info Systems">
//     Author: Sreejith Gopinathan
//     Copyright (c) Acme Info Systems. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data.Entity;
using Accounts.AcmeInfoSys.Data.Entities;

namespace Accounts.AcmeInfoSys.Data
{
    /// <summary>
    /// A data context class provides DB Sets for data persistance.
    /// </summary>    
    public class AccountDbContext : DbContext
    {
        /// <summary>
        /// Creates an instance of type AccountDbContext.
        /// </summary>
        public AccountDbContext() : base("DbConnection")
        {
            Database.SetInitializer<AccountDbContext>(null);
        }

        /// <summary>
        /// Get or set Db set of Journal.
        /// </summary>
        public DbSet<Journal> Journals { get; set; }

        /// <summary>
        /// Get or set Db set of User.
        /// </summary>
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("acmedbo");
        }
    }
}