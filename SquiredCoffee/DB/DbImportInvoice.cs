using MySql.Data.MySqlClient;
using SquiredCoffee.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SquiredCoffee.DB
{
    class DbImportInvoice
    {
        
        public static MySqlConnection GetConnection()
        {
            string sql = "SERVER=45.252.251.29;PORT=3306;DATABASE=sodopxlg_koffeeholic;UID=sodopxlg;PASSWORD=05qT1yfRp9;charset=utf8";
            MySqlConnection con = new MySqlConnection(sql);
            try
            {
                con.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySQL Connection! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return con;
        }

        public static List<ImportInvoice> LoadImportInvoice()
        {
            List<ImportInvoice> importInvoiceList = new List<ImportInvoice>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT ii.id,ii.staff_id,ii.total_money,ii.create_date,ii.status,CONCAT(s.first_name,s.last_name) as name_staff FROM import_invoices ii , staffs s WHERE ii.staff_id = s.id");
            foreach (DataRow item in data.Rows)
            {
                ImportInvoice importInvoice = new ImportInvoice(item);
                importInvoiceList.Add(importInvoice);
            }

            return importInvoiceList;
        }

        public static List<ImportInvoice> LoadImportInvoice(string id_staff,string status)
        {
            List<ImportInvoice> importInvoiceList = new List<ImportInvoice>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT ii.id,ii.staff_id,ii.total_money,ii.create_date,ii.status,CONCAT(s.first_name,s.last_name) as name_staff FROM import_invoices ii , staffs s WHERE ii.staff_id = s.id AND ii.staff_id = '" + id_staff+"' AND ii.status = '"+status+"'");
            foreach (DataRow item in data.Rows)
            {
                ImportInvoice importInvoice = new ImportInvoice(item);
                importInvoiceList.Add(importInvoice);
            }

            return importInvoiceList;
        }


        public static List<ImportInvoice> LoadImportInvoiceSearchClick(string @key)
        {
            List<ImportInvoice> importInvoiceList = new List<ImportInvoice>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT ii.id,ii.staff_id,ii.total_money,ii.create_date,ii.status,CONCAT(s.first_name,s.last_name) as name_staff FROM import_invoices ii , staffs s WHERE ii.staff_id = s.id AND ii.status = '" + @key+"' ");
            foreach (DataRow item in data.Rows)
            {
                ImportInvoice importInvoice = new ImportInvoice(item);
                importInvoiceList.Add(importInvoice);
            }

            return importInvoiceList;
        }



        public static List<ImportInvoice> LoadImportInvoiceSearch(string @key)
        {
            List<ImportInvoice> importInvoiceList = new List<ImportInvoice>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT ii.id,ii.staff_id,ii.total_money,ii.create_date,ii.status,CONCAT(s.first_name,s.last_name) as name_staff FROM import_invoices ii , staffs s WHERE ii.staff_id = s.id AND ii.total_money LIKE'%" + @key + "%' ");
            foreach (DataRow item in data.Rows)
            {
                ImportInvoice importInvoice = new ImportInvoice(item);
                importInvoiceList.Add(importInvoice);
            }

            return importInvoiceList;
        }


        public static List<ImportInvoice> LoadImportInvoiceButtonSearch(string @key)
        {
            List<ImportInvoice> importInvoiceList = new List<ImportInvoice>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT ii.id,ii.staff_id,ii.total_money,ii.create_date,ii.status,CONCAT(s.first_name,s.last_name) as name_staff FROM import_invoices ii , staffs s WHERE ii.staff_id = s.id AND ii.create_date = '" + @key+"'");
            foreach (DataRow item in data.Rows)
            {
                ImportInvoice importInvoice = new ImportInvoice(item);
                importInvoiceList.Add(importInvoice);
            }

            return importInvoiceList;
        }


        public static void AddImportInvoice(ImportInvoice std)
        {
            string sql = "INSERT INTO import_invoices (staff_id,total_money,create_date,status) VALUES(@staff_id,@total_money,@create_date,@status)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@staff_id", MySqlDbType.VarChar).Value = std.staff_id;
            cmd.Parameters.Add("@total_money", MySqlDbType.VarChar).Value = std.total_money;
            cmd.Parameters.Add("@create_date", MySqlDbType.VarChar).Value = std.create_date;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Nhập Hàng ( Không Thành Công ) ! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }



        public static void UpdateImportInvoice(ImportInvoice std,string id)
        {
            string sql = "UPDATE import_invoices SET staff_id = @staff_id,total_money = @total_money,create_date = @create_date,status = @status WHERE id = @id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@staff_id", MySqlDbType.VarChar).Value = std.staff_id;
            cmd.Parameters.Add("@total_money", MySqlDbType.VarChar).Value = std.total_money;
            cmd.Parameters.Add("@create_date", MySqlDbType.VarChar).Value = std.create_date;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Không Hoàn Thành ! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static void DeleteImportInvoice(string id)
        {
            string sql = "Delete From import_invoices  WHERE id = @id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Không Hoàn Thành ! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
    }
}
