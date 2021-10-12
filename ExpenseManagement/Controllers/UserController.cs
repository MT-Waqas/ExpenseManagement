using ExpenseManagement.Models.BLs;
using ExpenseManagement.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpenseManagement.BasePage;

namespace ExpenseManagement.Controllers
{
    public class UserController : UserBasePage
    {
        private IUser UserRepository;
        public UserController()
        {
            this.UserRepository = new BL_User();
        }
        // GET: User
        public ActionResult UserList()
        {
            return View();
        }
        public ActionResult User_(int? ID = null)
        {
            User u = new User();
            if (ID != null)
            {
                u.UserID = ID;
                u = UserRepository.GetUsers(u)[0];
                return PartialView("User_", u);
            }
            else
            {
                var list = UserRepository.GetUsers();
                return PartialView("_Users_Partial", list);
            }

        }
        [HttpPost]
        public ActionResult User_(User u)
        {
            if (ModelState.IsValid)
            {
                if (u.UserID > 0)
                {
                    UserRepository.Save(u, false);
                    return Json(2, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    UserRepository.Save(u);
                    return Json(1, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(3,JsonRequestBehavior.AllowGet);
            }
            
        }
        public ActionResult Delete(int ID)
        {
            if (ID > 0)
            {
                UserRepository.Delete(ID);
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(2);
            }

        }
        public ActionResult UserForm()
        {
            return PartialView("User_",new User());
        }
    }
}