//-----------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Acme Info Systems">
//     Author: Sreejith Gopinathan
//     Copyright (c) Acme Info Systems. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Web.Mvc;
using System.Web.Security;
using Accounts.AcmeInfoSys.Data.Repositories;

namespace Accounts.AcmeInfoSys.Controllers
{
    [Authorize]
    public class HomeController : BaseController<HomeController>
    {
        private readonly IUserRepository userRepository;

        public HomeController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            //var ticketData = ((FormsIdentity) User.Identity).Ticket.GetStructuredUserData();
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}