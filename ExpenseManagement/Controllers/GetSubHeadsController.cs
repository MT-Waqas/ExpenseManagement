using ExpenseManagement.Models.BLs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpenseManagement.BasePage;

namespace ExpenseManagement.Controllers
{
    public class GetSubHeadsController : UserBasePage
    {
        // GET: GetSubHeads
        public ActionResult GetHeads(int eid)
        {
            SubExpenseHead e = new SubExpenseHead();
            e.ExpenseHeadID = eid;
            e.Subheadlist =new SelectList(BL_SubExpenseHead.Get_SubHeads(e), "SubExpenseHeadID", "SubExpenseHeadName") ;
            return PartialView("_Subhead",e);
        }
    }
}