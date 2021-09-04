using ExpenseManagement.Models.Custom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseManagement.Models.BLs
{
    public class BL_Expenses
    {
        public static void Save(Expenses expenses, bool IsNew)
        {
            
                SqlParameter[] prm = new SqlParameter[]
                {
                    new SqlParameter("ExpenseID",expenses.ExpenseID),
                    new SqlParameter("ExpenseHeadID",expenses.ExpenseHeadID),
                     new SqlParameter("ExpenseAmount",expenses.ExpenseAmount),
                    new SqlParameter("ExpenseDate",expenses.ExpenseDate),
                    new SqlParameter("Description",expenses.Description),
                    new SqlParameter("type",IsNew==true?Actions.Insert:Actions.Update)
                };
                Helper.sp_ExecuteQuery("sp_Expenses",prm);
        }
        public static List<Expenses> GetExpenses(Expenses expenses=null)
        {
            if (expenses==null)
            {
                expenses = new Expenses();
            }
            List<Expenses> expensess = new List<Expenses>();
            SqlParameter[] prm = new SqlParameter[]
            {
                    new SqlParameter("@ExpenseID",expenses.ExpenseID),
                    new SqlParameter("ExpenseHeadID",expenses.ExpenseHeadID),
                    new SqlParameter("ExpenseDate",expenses.ExpenseDate),
                    new SqlParameter("type",Actions.Select)
            };
           DataTable dt= Helper.sp_Execute_Table("sp_Expenses", prm);
            foreach (DataRow dr in dt.Rows)
            {
                Expenses expenses1 = new Expenses();
                expenses1.ExpenseID = Convert.ToInt32(dr["ExpenseID"]);
                expenses1.ExpenseHeadID = Convert.ToInt32(dr["ExpenseHeadID"]);
                expenses1.ExpenseAmount = Convert.ToDecimal(dr["ExpenseAmount"]);
                expenses1.ExpenseHeadName = Convert.ToString(dr["ExpenseHeadName"]);
                expenses1.ExpenseDate = (dr["ExpenseDate"]) as DateTime?;
                expenses1.Description = Convert.ToString(dr["Description"]);
                expensess.Add(expenses1);
            }
            return expensess;
        }
         public static void Delete(int ID)
        {
            SqlParameter[] prm = new SqlParameter[]
                {
                new SqlParameter("ExpenseID",ID),
                new SqlParameter("type",Actions.Delete)
                };
            Helper.sp_ExecuteQuery("sp_Expenses",prm);
        }
    }
    public class Expenses
    {
        public int? ExpenseID { get; set; }
        [Required]
        public int? ExpenseHeadID { get; set; }
        public string ExpenseHeadName { get; set; }
        [Required]
        public decimal? ExpenseAmount { get; set; }
        [Required]
        public DateTime? ExpenseDate { get; set; }
        [Required]
        public string Description { get; set; }
        public SelectList _Expense_Heads { get; set; }

    }

}