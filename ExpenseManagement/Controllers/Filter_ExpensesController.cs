using ExpenseManagement.Models.BLs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseManagement.Controllers
{
    public class Filter_ExpensesController : Controller
    {
        // GET: Filter_Expenses
        public ActionResult FilterExpenses()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Filter(ViewModel model1)
        {
                ViewModel model = new ViewModel();
                Expenses e = new Expenses();
                e.ExpenseHeadID = model1.Expense.ExpenseHeadID;
                e.ExpenseDate = model1.Expense.ExpenseDate;
                model.Expense = e;
                model.Expenses = BL_Expenses.GetExpenses(model.Expense);
                return PartialView("_Filtered_Expenses", model);
        }
    }
}