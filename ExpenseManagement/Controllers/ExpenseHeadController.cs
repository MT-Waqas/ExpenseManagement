using ExpenseManagement.Models.BLs;
using ExpenseManagement.Models.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseManagement.Controllers
{
    public class ExpenseHeadController : Controller
    {
        // GET: ExpenseHead

        public ActionResult Index()
        {
            List<ExpenseHead> expenseHeads = BL_Expense_Head.GetHeads();
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
                if (expenseHead.ExpensHeadID > 0)
                {
                    BL_Expense_Head.Save(expenseHead,false);
                    ModelState.AddModelError("ExpenseHeadName", Msg.Message);
                    if (Msg.Message != "")
                    {
                        return View("ExpenseHead");
                    }
                }
                else
                {
                    BL_Expense_Head.Save(expenseHead,true);
                    ModelState.AddModelError("ExpenseHeadName",Msg.Message);
                    if (Msg.Message!=""&&Msg.Message!=null)
                    {
                        return View("ExpenseHead");
                    }
                }
                ModelState.Clear();
                return RedirectToAction("Index", "ExpenseHead");
            }
            else
            {
                return View("ExpenseHead");
            }
        }
        public ActionResult Delete (int ID)
        {
             BL_Expense_Head.Delete(ID);
            return RedirectToAction("Index");
        }
    }
}