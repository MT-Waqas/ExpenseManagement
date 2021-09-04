
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExpenseManagement.Models.Custom
{
    public class custom
    {
    //    public static UInt64 Get_Total(List<SaleItems> p)
    //    {
    //         UInt64 cordersTotal = 0;
    //        foreach (var item in p)
    //        {
    //            cordersTotal += (Convert.ToUInt64(item.Quantity)) * (Convert.ToUInt64(item.SalePrice));
    //        }
    //        return cordersTotal;
    //    }
    //    public static UInt64 Get_PurchasePrice_Total(List<SaleItems> p)
    //    {
    //        UInt64 purchasepriceTotal = 0;
    //        foreach (var item in p)
    //        {
    //            purchasepriceTotal += (Convert.ToUInt64(item.Quantity)) * (Convert.ToUInt64(item.SalePrice));
    //        }
    //        return purchasepriceTotal;
    //    }
    //    public static bool AlreadyExist(List<SaleItems> p,int MedicineID)
    //    {
    //       bool IsNotExists = true;
    //        foreach (var item in p)
    //        {
    //            if (item.MedicineID==MedicineID)
    //            {
    //                IsNotExists = false;
    //            }
    //        }
    //        return IsNotExists;
    //    }
    //    public static SaleItems GetItem(int MedicineID)
    //    {
    //        Purchase purchase = BL_Stock.GetMedicine(null, Convert.ToInt32(MedicineID));
    //        SaleItems items = new SaleItems();
    //        items.MedicineID = purchase.MedicineID;
    //        items.MedicineName = purchase.MedicineName;
    //        items.CompanyID = purchase.CompanyID;
    //        items.CompanyName = purchase.CompanyName;
    //        items.Quantity = 1;
    //        items.AvailableStock = purchase.Quantity;
    //        items.SalePrice = purchase.SalePrice;
    //        items.PurchasePrice = purchase.PurchasePrice;
    //        return items;
    //    }
    //    public static string GetTotal(List<Purchase> li)
    //    {
    //        //li = TempData["cart"] as List<Purchase>;
    //        decimal total = 0;
    //        for (int i = 0; i < li.Count; i++)
    //        {
    //            total += (li[i].PurchasePrice * li[i].Quantity);
    //        }
    //      return  total.ToString("0.0");
    //    }
    //    public static bool CheckBeforeDeletion(string ColumnName,string Value)
    //    {
    //        SqlParameter[] prm = new SqlParameter[]
    //        {
    //            new SqlParameter(ColumnName,Value)
    //        };
    //        DataTable dt = Helper.sp_Execute_Table("sp_Check_Befor_Delete", prm);
    //        if (Convert.ToInt32(dt.Rows[0]["Counted"])==0)
    //        {
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }
    //public static Filteration load_Comp(Company cmp)
    //    {
    //        Filteration filter = new Filteration();

    //        filter.CompanyIDD = Convert.ToInt32(cmp.CompanyID);
    //        filter.CompanyName = cmp.CompanyName;
    //        filter.Address = cmp.Address;
    //        filter.Contact = cmp.Contact;
    //        filter.Credit = cmp.Credit;

    //        return filter;
    //    }
    //    public static Filteration2 load_Cust(Customer Cust)
    //    {
    //        Filteration2 filteration2 = new Filteration2();
    //        filteration2.CustomerIDD = Convert.ToInt32(Cust.CustomerID);
    //        filteration2.CustomerName = Cust.CustomerName;
    //        filteration2.Address = Cust.Address;
    //        filteration2.Contact = Cust.Contact;
    //        filteration2.Balance = Cust.Balance;
    //        return filteration2;
    //    }
    }
}