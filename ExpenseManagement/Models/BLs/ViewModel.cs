using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseManagement.Models.BLs
{
    public class ViewModel
    {
        public List<Expenses> Expenses { get; set; }
        public Expenses Expense { get; set; }
    }
}