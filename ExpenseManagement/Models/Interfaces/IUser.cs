using ExpenseManagement.Models.BLs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Models.Interfaces
{
    interface IUser
    {
        public bool Save(User u,bool? IsNew=true);
        public List<User> GetUsers(User u=null);
        public int Delete(int ID);
    }
}
