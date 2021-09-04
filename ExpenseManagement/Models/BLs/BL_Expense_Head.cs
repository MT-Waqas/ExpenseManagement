
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using ExpenseManagement.Models.Custom;
using ExpenseManagement.Models;

namespace ExpenseManagement.Models.BLs
{
    public class BL_Expense_Head
    {
        public static bool Save(ExpenseHead head, bool IsNew)
        {
            if (IsValid(head))
            {
                SqlParameter[] prm = new SqlParameter[]
                {
                   new SqlParameter("ExpensHeadID",head.ExpensHeadID),
                   new SqlParameter("ExpenseHeadName",head.ExpenseHeadName),
                   new SqlParameter("Status",head.Status),
                   new SqlParameter("type",IsNew==true?Actions.Insert:Actions.Update)
                };
                Helper.sp_ExecuteQuery("sp_ExpenseHead", prm);
                return true;
            }
            else
            {
                return false;
            }
        }
        private static bool IsValid(ExpenseHead head)
        {
            if (head.ExpensHeadID > 0)
            {
                if (Helper.IsExistOnUpdate("tbl_ExpenseHead", "ExpenseHeadName", "IsDelete", "ExpensHeadID", head.ExpenseHeadName, "0", head.ExpensHeadID.ToString()))
                {
                    Custom.Msg.Message = "Expense Head Name Aready Exists";
                    return false;
                }
                else
                {
                    Custom.Msg.Message = "";
                    return true;
                }

            }
            else
            {
                if (Helper.IsExist("tbl_ExpenseHead", "ExpenseHeadName", "IsDelete", head.ExpenseHeadName, "0"))
                {
                    Custom.Msg.Message = "Expense Head Name Aready Exists";
                    return false;
                }
                else
                {
                    Custom.Msg.Message = "";
                    return true;
                }
            }


        }

        //public static void Update(ExpenseHead head)
        //{
        //    if (IsValid(head))
        //    {
        //        SqlParameter[] prm = new SqlParameter[]
        //       {
        //           new SqlParameter("ExpensHeadID",head.ExpensHeadID),
        //           new SqlParameter("ExpenseHeadName",head.ExpenseHeadName),
        //           new SqlParameter("Status",head.Status),
        //           new SqlParameter("type",Actions.Update)
        //       };
        //        Helper.sp_ExecuteQuery("sp_ExpenseHead", prm);
        //    }
        //    else
        //    {

        //    }
        //}
        public static int Delete(int ID)
        {
            //if (custom.CheckBeforeDeletion("ExpensHeadID", Convert.ToString(ID)))
            //{
            SqlParameter[] prm = new SqlParameter[]
                {
                   new SqlParameter("ExpensHeadID",ID),
                   new SqlParameter("type",Actions.Delete)
                };
            Helper.sp_ExecuteQuery("sp_ExpenseHead", prm);
            return 3;
            //}
            //else
            //{
            //    Msg.Message = "Data Exists Against this Record.So If You Want to Delete The Record Delete the Relevant Records";
            //    return 4;
            //}

        }
        public static List<ExpenseHead> GetHeads(ExpenseHead head = null)
        {
            List<ExpenseHead> heads = new List<ExpenseHead>();
            if (head == null)
            {
                head = new ExpenseHead();
            }
            SqlParameter[] prm = new SqlParameter[]
               {
                   new SqlParameter("ExpensHeadID",head.ExpensHeadID),
                   new SqlParameter("ExpenseHeadName",head.ExpenseHeadName),
                   new SqlParameter("Status",head.Status),
                   new SqlParameter("type",Actions.Select)
               };
            DataTable dt = Helper.sp_Execute_Table("sp_ExpenseHead", prm);
            foreach (DataRow dr in dt.Rows)
            {
                ExpenseHead expenseHead = new ExpenseHead();
                expenseHead.ExpensHeadID = Convert.ToInt32(dr["ExpensHeadID"]);
                expenseHead.ExpenseHeadName = Convert.ToString(dr["ExpenseHeadName"]);
                expenseHead.Status = Convert.ToInt32(dr["Status"]);

                heads.Add(expenseHead);
            }
            return heads;
        }
    }
    public class ExpenseHead
    {

        public int? ExpensHeadID { get; set; }
        [Required(ErrorMessage = "Please Enter the Expense Head Name")]
        public string ExpenseHeadName { get; set; }
        [Required(ErrorMessage = "Please Select the Status")]
        public int? Status { get; set; }
        public int IsDeleted { get; set; }
    }
}