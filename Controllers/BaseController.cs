//-----------------------------------------------------------------------
// <copyright file="BaseController.cs" company="Acme Info Systems">
//     Author: Sreejith Gopinathan
//     Copyright (c) Acme Info Systems. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using log4net;
using System.Web.Mvc;

namespace Accounts.AcmeInfoSys.Controllers
{
    /// <summary>
    /// A base controller for all other controllers across the application.
    /// </summary>
    /// <typeparam name="T">A type of System.Web.Mvc.Controller</typeparam>
    public class BaseController<T> : Controller where T : Controller
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(T));

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;

            // Log error to NLog
            logger.Error(filterContext.Exception.Message, filterContext.Exception);

            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml"
            };
        }
    }
}