using ExpenseManagement.Models.BLs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpenseManagement.BasePage;

namespace ExpenseManagement.Controllers
{
    public class Filter_ExpensesController : UserBasePage
    {
        // GET: Filter_Expenses
        public ActionResult FilterExpenses()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Filter(Expenses expenses)
        {
            expenses.ExpensesList = BL_Expenses.GetExpenses(expenses);
            expenses.IsFiltering = true;
            return PartialView("_Filtered_Expenses", expenses);
        }
    }
}