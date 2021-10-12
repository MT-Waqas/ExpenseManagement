using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpenseManagement.BasePage;

namespace ExpenseManagement.Controllers
{
    public class DashBoardController : UserBasePage
    {
        // GET: DashBoard
        public ActionResult Index()
        {
            return View();
        }
    }
}