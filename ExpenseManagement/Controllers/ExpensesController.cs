using ExpenseManagement.Models.BLs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpenseManagement.BasePage;
namespace ExpenseManagement.Controllers
{
    public class ExpensesController : UserBasePage
    {

        public ActionResult ExpenseList()
        {

            return View(BL_Expenses.GetExpenses());
        }
        [HttpPost]
        public ActionResult Expense(Expenses expenses)
        {
            if (ModelState.IsValid)
            {
                if (expenses.ExpenseID > 0)
                {
                    BL_Expenses.Save(expenses, false);
                    
                }
                else
                {
                    BL_Expenses.Save(expenses, true);
                    
                }
                ModelState.Clear();
                return RedirectToAction("ExpenseList");
            }
            else
            {
                //int? ID = null;
                //return RedirectToAction("Expense",new {ID=ID});
                return View("Expense");
            }
        }
        public ActionResult Expense(int? id)
        {
            Expenses expenses = new Expenses();
            if (id>0)
            {
               expenses.ExpenseID = id;
               expenses = BL_Expenses.GetExpenses(expenses)[0];
               return View(expenses);
            }
            else
            {
                return View(expenses);
            }
            
        }

        public ActionResult Delete(int id)
        {

            BL_Expenses.Delete(id);
            return RedirectToAction("ExpenseList");
        }
    }
}
