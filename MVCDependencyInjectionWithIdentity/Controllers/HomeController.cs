using MVCDependencyInjectionWithIdentity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDependencyInjectionWithIdentity.Controllers
{
    public class HomeController : Controller
    {

        private readonly IMessageProvider messageProvider;

        public HomeController(IMessageProvider provider)
        {
            messageProvider = provider;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = messageProvider.GetMessage();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}