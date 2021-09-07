using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExpenseManagement.Models
{
    public class Helper
    {
        static SqlConnection con=new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
        public static void sp_ExecuteQuery(string sp,SqlParameter[] prm)
        {
            SqlCommand cmd = new SqlCommand(sp, con);
            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddRange(prm);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                con.Close();
                throw;
            }
        }
        public static bool IsExistOnUpdate(string TableName, string ColumnName1, string ColumnName2, string Value1, string Value2)
        {

            string query = "select * from " + TableName + " where " + ColumnName1 + "='" + Value1 + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                if (dt.Rows[0][ColumnName2].ToString() == Value2)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (dt.Rows.Count > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static DataTable sp_Execute_Table(string storeprocedure,SqlParameter[] prm)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(storeprocedure,con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(prm);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            catch (Exception e)
            {
                con.Close();
            }
            return dt;
        }
        public static bool IsExistOnUpdate(string TableName, string ColumnName1, string ColumnName2, string ColumnName3, string Value1, string Value2, string Value3)
        {
            string query = "select * from " + TableName + " where " + ColumnName1 + "='" + Value1 + "' and " + ColumnName2 + "='" + Value2 + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                if (dt.Rows[0][ColumnName3].ToString() == Value3)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (dt.Rows.Count > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsExist(string TableName, string ColumnName1, string ColumnName2, string ColumnName3, string ColumnName4, string Value1, string Value2, string Value3, string Value4)
        {
            string query = "select * from " + TableName + " where " + ColumnName1 + "='" + Value1 + "' and " + ColumnName2 + "='" + Value2 + "' and " + ColumnName3 + "='" + Value3 + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                if (dt.Rows[0][ColumnName3].ToString() == Value4)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (dt.Rows.Count > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsExist(string TableName, string ColumnName1, string ColumnName2, string ColumnName3, string Value1, string Value2, string Value3)
        {
            string query = "select * from " + TableName + " where " + ColumnName1 + "='" + Value1 + "' and " + ColumnName2 + "='" + Value2 + "' and " + ColumnName3 + "='" + Value3 + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsExist(string TableName, string ColumnName1, string ColumnName2, string Value1, string Value2)
        {
            string query = "select * from " + TableName + " where " + ColumnName1 + "='" + Value1 + "' and " + ColumnName2 + "='" + Value2 + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsExist(string TableName, string ColumnName, string Value)
        {
            string query = "select * from " + TableName + " where " + ColumnName + "='" + Value + "'";
            //SqlParameter[] prm = new SqlParameter("@Value", Value);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            //cmd.Parameters.Add(prm);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                    return true;
            }
            else
            {
                return false;
            }
        }
    }
}