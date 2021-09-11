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
using System.Web.Mvc;

namespace ExpenseManagement.Models.BLs
{
    public class BL_SubExpenseHead
    {
        public static bool Save(SubExpenseHead head, bool IsNew)
        {
            if (IsValid(head))
            {
                SqlParameter[] prm = new SqlParameter[]
                {
                   new SqlParameter("SubExpenseHeadID",head.SubExpenseHeadID),
                   new SqlParameter("SubExpenseHeadName",head.SubExpenseHeadName),
                   new SqlParameter("ExpenseHeadID",head.ExpenseHeadID),
                   new SqlParameter("SubExpenseStatus",head.SubExpenseStatus),
                   new SqlParameter("type",IsNew==true?Actions.Insert:Actions.Update)
                };
                Helper.sp_ExecuteQuery("sp_SubExpenseHead", prm);
                return true;
            }
            else
            {
                return false;
            }
        }
        public static int Delete(int ID)
        {
            SqlParameter[] prm = new SqlParameter[]
                {
                   new SqlParameter("SubExpenseHeadID",ID),
                   new SqlParameter("type",Actions.Delete)
                };
            Helper.sp_ExecuteQuery("sp_SubExpenseHead", prm);
            return 3;
        }
        public static List<SubExpenseHead> Get_SubHeads(SubExpenseHead head = null)
        {
            List<SubExpenseHead> heads = new List<SubExpenseHead>();
            if (head == null)
            {
                head = new SubExpenseHead();
            }
            SqlParameter[] prm = new SqlParameter[]
               {  
                   new SqlParameter("SubExpenseHeadID",head.SubExpenseHeadID),
                   new SqlParameter("SubExpenseHeadName",head.SubExpenseHeadName),
                   new SqlParameter("ExpenseHeadID",head.ExpenseHeadID),
                   new SqlParameter("SubExpenseStatus",head.SubExpenseStatus),
                   new SqlParameter("type",Actions.Select)
               };
            DataTable dt = Helper.sp_Execute_Table("sp_SubExpenseHead", prm);
            foreach (DataRow dr in dt.Rows)
            {
                SubExpenseHead expenseHead = new SubExpenseHead();
                expenseHead.SubExpenseHeadID = Convert.ToInt32(dr["SubExpenseHeadID"]);
                expenseHead.ExpenseHeadID = Convert.ToInt32(dr["ExpenseHeadID"]);
                expenseHead.SubExpenseHeadName = Convert.ToString(dr["SubExpenseHeadName"]);
                expenseHead.ExpenseHeadName = Convert.ToString(dr["ExpenseHeadName"]);
                expenseHead.SubExpenseStatus = Convert.ToInt32(dr["SubExpenseStatus"]);

                heads.Add(expenseHead);
            }
            return heads;
        }
        private static bool IsValid(SubExpenseHead head)
        {
              if (head.SubExpenseHeadID > 0)
                {
                    if (Helper.IsExistOnUpdate("tbl_SubExpenseHead", "SubExpenseHeadName", "SubExpenseHeadID", head.SubExpenseHeadName, head.SubExpenseHeadID.ToString()))
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
                    if (Helper.IsExist("tbl_SubExpenseHead", "SubExpenseHeadName", head.SubExpenseHeadName))
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
     
    }
    public class SubExpenseHead
    {
        public int? SubExpenseHeadID { get; set; }
        [Required]
        public string SubExpenseHeadName { get; set; }
        [Required]
        public int ExpenseHeadID { get; set; }
        [Required]
        public int? SubExpenseStatus { get; set; }
        [DisplayName("Expense Head")]
        public string ExpenseHeadName { get; set; }
        public SelectList Subheadlist { get; set; }

    }
}