using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseManagement.Controllers
{
    public class dummyController : Controller
    {
        // GET: dummy
        public ActionResult Index()
        {
            return View();
        }
    }
}