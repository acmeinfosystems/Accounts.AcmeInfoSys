//-----------------------------------------------------------------------
// <copyright file="UnityConfig.cs" company="Acme Info Systems">
//     Author: Sreejith Gopinathan
//     Copyright (c) Acme Info Systems. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Unity;
using Unity.Mvc5;
using System.Web.Mvc;
using Accounts.AcmeInfoSys.Data;
using Accounts.AcmeInfoSys.Data.Repositories;
using Accounts.AcmeInfoSys.Data.Repositories.Implementations;

namespace Accounts.AcmeInfoSys
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<AccountDbContext>();

            container.RegisterType<IJournalRepository, JournalRepository>();

            container.RegisterType<IUserRepository, UserRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}