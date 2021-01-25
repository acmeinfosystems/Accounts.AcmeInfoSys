//-----------------------------------------------------------------------
// <copyright file="IJournalRepository.cs" company="Acme Info Systems">
//     Author: Sreejith Gopinathan
//     Copyright (c) Acme Info Systems. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Accounts.AcmeInfoSys.Data.Entities;

namespace Accounts.AcmeInfoSys.Data.Repositories
{
    /// <summary>
    /// Abstracts the CRUD operation methods of Journal entity objects.
    /// </summary>
    public interface IJournalRepository : IRepository<Journal>
    {
    }
}
