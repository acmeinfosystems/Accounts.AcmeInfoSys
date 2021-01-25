//-----------------------------------------------------------------------
// <copyright file="IJournalRepository.cs" company="Acme Info Systems">
//     Author: Sreejith Gopinathan
//     Copyright (c) Acme Info Systems. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Accounts.AcmeInfoSys.Data.Entities;

namespace Accounts.AcmeInfoSys.Data.Repositories.Implementations
{
    /// <summary>
    /// Abstracts the CRUD operation methods of Journal entity objects.
    /// </summary>
    public class JournalRepository : Repository<Journal>, IJournalRepository
    {
        /// <summary>
        /// Creates a new instance of type JournalRepository.
        /// </summary>
        /// <param name="context">AccountDbContext</param>
        public JournalRepository(AccountDbContext context) : base(context)
        {
        }
    }
}