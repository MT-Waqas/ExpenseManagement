using ExpenseManagement.Models.Custom;
using ExpenseManagement.Models.Interfaces;
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
    public class BL_User : IUser
    {
        public bool Save(User u, bool? IsNew = true)
        {
            u.UserPassword = Helper.Encrypt(u.UserPassword);
            SqlParameter[] prm = new SqlParameter[]
                        {
                new SqlParameter("UserID",u.UserID),
                new SqlParameter("UserName",u.UserName),
                new SqlParameter("UserPassword",u.UserPassword),
                new SqlParameter("UserStatus",u.UserStatus),
                new SqlParameter("UserRole",u.UserRole),
                new SqlParameter("type",IsNew==true?Actions.Insert:Actions.Update)
                        };
            Helper.sp_ExecuteQuery("sp_User", prm);
            return true;
        }
        public int Delete(int ID)
        {
            SqlParameter[] prm = new SqlParameter[]
            {
                new SqlParameter("UserID",ID),
                new SqlParameter("type",Actions.Delete)
            };
            Helper.sp_ExecuteQuery("sp_User", prm);
            return 3;
        }

        public List<User> GetUsers(User u = null)
        {
            if (u == null)
            {
                u = new User();
            }
            SqlParameter[] prm = new SqlParameter[]
            {
                new SqlParameter("UserID",u.UserID),
                new SqlParameter("UserName",u.UserName),
                new SqlParameter("UserStatus",u.UserStatus),
                new SqlParameter("UserRole",u.UserRole),
                new SqlParameter("type",Actions.Select)
            };
            DataTable dt = Helper.sp_Execute_Table("sp_User", prm);
            List<User> ulist = new List<User>();
            foreach (DataRow dr in dt.Rows)
            {
                User u1 = new User();
                u1.UserID = Convert.ToInt32(dr["UserID"]);
                u1.UserName = Convert.ToString(dr["UserName"]);
                u1.UserStatus = (int?)(dr["UserStatus"]);
                u1.UserRole = (int?)(dr["UserRole"]);
                ulist.Add(u1);
            }
            return ulist;
        }
    }
    public class User
    {
        public int? UserID { get; set; }
        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [DisplayName("Password")]
        [Required(ErrorMessage ="Please Enter Correct Password")]
        public string UserPassword { get; set; }
        [Required]
        [DisplayName("Status")]
        public int? UserStatus { get; set; }
        [Required]
        [DisplayName("User Role")]
        public int? UserRole { get; set; }

    }
}