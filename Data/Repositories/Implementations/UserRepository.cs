//-----------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="Acme Info Systems">
//     Author: Sreejith Gopinathan
//     Copyright (c) Acme Info Systems. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Accounts.AcmeInfoSys.Data.Entities;

namespace Accounts.AcmeInfoSys.Data.Repositories.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        /// <summary>
        /// Creates a new instance of type User.
        /// </summary>
        /// <param name="context">AccountDbContext</param>
        public UserRepository(AccountDbContext context) : base(context)
        {
        }
    }
}