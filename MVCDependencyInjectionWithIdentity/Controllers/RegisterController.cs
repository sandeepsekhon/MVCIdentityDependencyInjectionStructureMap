using Microsoft.AspNet.Identity.Owin;
using MVCDependencyInjectionWithIdentity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDependencyInjectionWithIdentity.Controllers
{
    public class RegisterController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        private readonly ApplicationDbContext dbContext;
        public RegisterController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, ApplicationDbContext context)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            dbContext = context;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Register
        public ActionResult Index()
        {
            ViewBag.Message = "New Message";
            return View();
        }
    }
}