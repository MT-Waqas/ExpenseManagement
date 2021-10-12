using ExpenseManagement.Models.BLs;
using ExpenseManagement.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseManagement.Controllers
{
    public class AccountController : Controller
    {
        private BL_Login _Login;
        // GET: Account
        public AccountController()
        {
            _Login = new BL_Login();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login obj)
        {
            if (ModelState.IsValid)
            {
                DataTable dt = _Login.GetUsers(obj);
                if (dt.Rows.Count > 0)
                {
                    Session["UserID"] = Convert.ToInt32(dt.Rows[0]["UserID"]) ;
                    Session["UserName"] = obj.UserName;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["bit"] = 1;
                    return View();
                }
            }
            else
                return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            Session["UserID"] = null;
            return View("Login");
        }
    }
}