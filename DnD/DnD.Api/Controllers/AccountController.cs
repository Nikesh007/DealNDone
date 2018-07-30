using DnD.Api.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace DnD.Api.Controllers
{
    public class AccountController : ApiController
    {
        // GET: Account
        [Route("api/User/Register")]
        [HttpPost]
        public IdentityResult Register(AccountModel model)
        {
            try
            {
                model.UserName = "nik";
                model.Email = "nikesh1408@gmail.com";
                model.Password = "nik";
                var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
                var manager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser() { UserName = model.UserName, Email = model.Email };
                //user.FirstName = model.FirstName;
                //user.LastName = model.LastName;
                manager.PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 3
                };
                IdentityResult result = manager.Create(user, model.Password);



                //if (result != null)

                //{
                //    TestRepository tst = new TestRepository();
                //    tst.InsertUser(model.UserName);
                //}
                return result;
            }
            catch (Exception ex)
            {
                return new IdentityResult();
            }

        }

        [Route("api/User/GetUserList")]
        [HttpGet]
        public dynamic GetUserList()
        {
            //TestRepository tst = new TestRepository();
            //tst.GetUserList();
            return null;
        }
    }
}