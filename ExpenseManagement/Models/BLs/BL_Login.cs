using ExpenseManagement.Models.Custom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExpenseManagement.Models.BLs
{
    public class BL_Login
    {
        public DataTable GetUsers(Login u = null)
        {
            if (u == null)
            {
                u = new Login();
            }
            SqlParameter[] prm = new SqlParameter[]
            {
                new SqlParameter("UserName",u.UserName),
                new SqlParameter("UserPassword",u.UserPassword),
                new SqlParameter("type",Actions.Select)
            };
            return  Helper.sp_Execute_Table("sp_User", prm);
        }
    }
    public class Login
    {
        public int? UserID { get; set; }
        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [DisplayName("Password")]
        [Required(ErrorMessage = "Please Enter Correct Password")]
        public string UserPassword { get; set; }
    }
}