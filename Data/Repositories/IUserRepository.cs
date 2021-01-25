//-----------------------------------------------------------------------
// <copyright file="IUserRepository.cs" company="Acme Info Systems">
//     Author: Sreejith Gopinathan
//     Copyright (c) Acme Info Systems. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Accounts.AcmeInfoSys.Data.Entities;

namespace Accounts.AcmeInfoSys.Data.Repositories
{
    /// <summary>
    /// Abstracts the CRUD operation methods of User entity objects.
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
    }
}
