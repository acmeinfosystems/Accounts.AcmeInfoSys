//-----------------------------------------------------------------------
// <copyright file="ApiController.cs" company="Acme Info Systems">
//     Author: Sreejith Gopinathan
//     Copyright (c) Acme Info Systems. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Net;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Accounts.AcmeInfoSys.Models;
using Accounts.AcmeInfoSys.Data.Repositories;
using System.Collections.Specialized;
using FormsAuthenticationExtensions;
using System.Collections.Generic;
using Accounts.AcmeInfoSys.Data.Entities;

namespace Accounts.AcmeInfoSys.Controllers
{
    [Authorize]
    public class ApiController : BaseController<ApiController>
    {
        private readonly IUserRepository userRepository;
        private readonly IJournalRepository journalRepository;

        public ApiController(IUserRepository userRepository, IJournalRepository journalRepository)
        {
            this.userRepository = userRepository;
            this.journalRepository = journalRepository;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult CheckLogin(LoginModel login)
        {
            User user = null;

            using (userRepository)
            {
                user = userRepository.GetAll(x =>
                        x.Username.Equals(login.Username, StringComparison.CurrentCultureIgnoreCase)
                        && x.Password.Equals(login.Password) && x.IsActive).FirstOrDefault();
            }
            if (user != null)
            {
                var ticketData = new NameValueCollection
                {
                    { "Username", user.Username },
                    { "Id", user.Id.ToString() }
                };
                new FormsAuthentication().SetAuthCookie(user.Name, false, ticketData);
                return Json(user);
            }
            else
            {
                Response.SuppressFormsAuthenticationRedirect = true;
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized, "Login attempt failed! Incorrect Username/Password.");
            }
        }

        public ActionResult GetJournalEntries()
        {
            IEnumerable<Journal> journals = null;

            using (journalRepository)
            {
                journals = journalRepository.GetAll();
            }
            if (journals == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            else
            {
                var list = journals.OrderByDescending(x => x.TransactionDate)
                    .Select(x => new 
                    { 
                        Id = x.Id, 
                        Name = x.Name, 
                        Entry = x.Entry, 
                        IsVerified = x.IsVerified, 
                        Amount = x.Amount,
                        Particulars = x.Particulars,
                        Date = x.TransactionDate.ToString("MM-dd-yyyy") 
                    }).ToList();

                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult SaveJournalEntry(Journal journal)
        {
            string username = User.Identity.Name;

            if (journal.Id > 0)
            {
                using (journalRepository)
                {
                    Journal oldEntry = journalRepository.Get(journal.Id);

                    if (oldEntry == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Journal Entry not Found!");
                    }
                    
                    oldEntry.TransactionDate = journal.TransactionDate;
                    oldEntry.Name = journal.Name;
                    oldEntry.Amount = journal.Amount;
                    oldEntry.Entry = journal.Entry;
                    oldEntry.Particulars = journal.Particulars;
                    oldEntry.UpdatedBy = username;
                    oldEntry.UpdatedOn = DateTime.Now;

                    //journalRepository.Update(oldEntry);
                    journal = oldEntry;
                }
            }
            else
            {
                using (journalRepository)
                {
                    journal.CreatedBy = username;
                    journal.CreatedOn = DateTime.Now;
                    journal.IsVerified = true;

                    //journal = journalRepository.Add(journal);
                }
            }
            if (journal != null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "An Error occured while saving Journal Entry!");
            }
        }
    }// class ends
}// namespace ends