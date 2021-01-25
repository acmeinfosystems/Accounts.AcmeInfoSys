//-----------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="Acme Info Systems">
//     Author: Sreejith Gopinathan
//     Copyright (c) Acme Info Systems. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Accounts.AcmeInfoSys
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            UnityConfig.RegisterComponents();
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}
