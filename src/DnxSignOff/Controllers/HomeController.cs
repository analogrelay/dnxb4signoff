using Microsoft.AspNet.Mvc;
using System;

namespace DnxSignOff.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() => View();
    }
}