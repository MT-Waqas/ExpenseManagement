using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ExpenseManagement.Models
{

    public static class Helper
    {
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());

        public static void sp_ExecuteQuery(string sp, SqlParameter[] prm)
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

        public static DataTable sp_Execute_Table(string storeprocedure, SqlParameter[] prm)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(storeprocedure, con);
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

        public static List<T> DataTableToList<T>(this DataTable table) where T : new()
        {
            List<T> list = new List<T>();
            var typeProperties = typeof(T).GetProperties().Select(propertyInfo => new
            {
                PropertyInfo = propertyInfo,
                Type = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType
            }).ToList();

            foreach (var row in table.Rows.Cast<DataRow>())
            {
                T obj = new T();
                foreach (var typeProperty in typeProperties)
                {
                    object value = row[typeProperty.PropertyInfo.Name];
                    object safeValue = value == null || DBNull.Value.Equals(value)
                        ? null
                        : Convert.ChangeType(value, typeProperty.Type);

                    typeProperty.PropertyInfo.SetValue(obj, safeValue, null);
                }
                list.Add(obj);
            }
            return list;
        }
        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890abcdefghijklmnopqrstuvwxyz1234567890";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890abcdefghijklmnopqrstuvwxyz1234567890";
            byte[] cipherBytes = Convert.FromBase64String(cipherText.Replace(" ", "+"));

            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
    public class AlreadyExist
    {
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());

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