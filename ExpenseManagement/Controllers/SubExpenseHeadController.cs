using ExpenseManagement.Models.BLs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpenseManagement.BasePage;

namespace ExpenseManagement.Controllers
{
    public class SubExpenseHeadController : UserBasePage
    {
        // GET: SubExpenseHead
        public ActionResult SubExpenseHeads()
        {
            var list=  BL_SubExpenseHead.Get_SubHeads();
            return View(list);
        }
        public ActionResult SubExpenseHead(int? ID)
        {
            if (ID>0)
            {
                SubExpenseHead s = new SubExpenseHead();
                s.SubExpenseHeadID = ID;
                SubExpenseHead sh = BL_SubExpenseHead.Get_SubHeads(s)[0];
                return View(sh);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult SubExpenseHead(SubExpenseHead subhead)
        {
            if (ModelState.IsValid)
            {
                if (subhead.SubExpenseHeadID > 0)
                {
                    if (BL_SubExpenseHead.Save(subhead, false) == false)
                    {
                        TempData["bit"] = 4;
                        //ModelState.AddModelError("SubExpenseHeadName","Already Exists");
                        return View();
                    }
                    else
                    {
                        TempData["bit"] = 2;
                        return RedirectToAction("SubExpenseHeads");
                    }
                }
                else
                {
                    if (BL_SubExpenseHead.Save(subhead, true) == false)
                    {
                        TempData["bit"] = 4;
                        //ModelState.AddModelError("SubExpenseHeadName", "Already Exists");
                        return View();
                    }
                    else
                    {
                        TempData["bit"] = 1;
                        return RedirectToAction("SubExpenseHeads");
                    }
                }
               
            }
            else
            {
                return View();
            }
        }
        public ActionResult Delete(int ID)
        {
            BL_SubExpenseHead.Delete(ID);
            TempData["bit"] = 4;
            return RedirectToAction("");
        }
    }
}