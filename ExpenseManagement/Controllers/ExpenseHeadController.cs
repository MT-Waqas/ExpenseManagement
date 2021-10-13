using ExpenseManagement.Models.BLs;
using ExpenseManagement.Models.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpenseManagement.BasePage;

namespace ExpenseManagement.Controllers
{
    public class ExpenseHeadController : UserBasePage
    {
        // GET: ExpenseHead

        public ActionResult Index()
        {
            ExpenseHead h = new ExpenseHead();
            h.UserID = Convert.ToInt32(Session["UserID"]);
            List<ExpenseHead> expenseHeads = BL_Expense_Head.GetHeads(h);
            return View("ExpenseHeadList", expenseHeads);
        }
        public ActionResult ExpenseHead(int? ID)
        {
            if (ID > 0)
            {
                ExpenseHead e = new ExpenseHead();
                e.ExpensHeadID = ID;
                ExpenseHead expense = BL_Expense_Head.GetHeads(e)[0];
                return View("ExpenseHead", expense);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult ExpenseHead(ExpenseHead expenseHead)
        {
            if (ModelState.IsValid)
            {
                expenseHead.UserID = Convert.ToInt32(Session["UserID"]);
                if (expenseHead.ExpensHeadID > 0)
                {
                    if (BL_Expense_Head.Save(expenseHead, false))
                    {
                        TempData["bit"] = 2;
                        ModelState.Clear();
                        return RedirectToAction("Index", "ExpenseHead");
                    }
                    else
                    {
                        TempData["bit"] = 4;
                        return View("ExpenseHead");
                    }
                }
                else
                {
                    if (BL_Expense_Head.Save(expenseHead, true)==true)
                    {
                        TempData["bit"] = 1;
                        ModelState.Clear();
                        return RedirectToAction("Index", "ExpenseHead");

                    }
                    else
                    {
                        TempData["bit"] = 4;
                        return View("ExpenseHead");
                    }
                }
            }
            else
            {
                return View("ExpenseHead");
            }
        }
        public ActionResult Delete (int ID)
        {
            TempData["bit"] = 3;
            BL_Expense_Head.Delete(ID);
            return RedirectToAction("Index");
        }
    }
}