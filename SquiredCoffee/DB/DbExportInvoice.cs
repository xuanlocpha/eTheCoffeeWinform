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
    class DbExportInvoice
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


        public static void AddExportInvoice(ExportInvoice std)
        {
            string sql = "INSERT INTO export_invoices (staff_id,create_date,status) VALUES(@staff_id,@create_date,@status)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@staff_id", MySqlDbType.VarChar).Value = std.staff_id;
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


        public static void UpdateExportInvoice(string id ,string status)
        {
            string sql = "UPDATE export_invoices SET status = '"+status+"' WHERE id = '"+id+"'";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
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


        public static void DeleteExportInvoice(string id)
        {
            string sql = "DELETE FROM export_invoices  WHERE id = '"+id+"'";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
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

        public static List<ExportInvoice> LoadExportInvoice(string key,string status)
        {
            List<ExportInvoice> exportInvoiceList = new List<ExportInvoice>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT ii.id,ii.staff_id,ii.create_date,ii.status,CONCAT(s.first_name,s.last_name) as name_staff FROM export_invoices ii , staffs s WHERE  ii.staff_id = '"+key+"' AND ii.status = '"+status+"' AND ii.staff_id = s.id");
            foreach (DataRow item in data.Rows)
            {
                ExportInvoice exportInvoice = new ExportInvoice(item);
                exportInvoiceList.Add(exportInvoice);
            }

            return exportInvoiceList;
        }
    }
}
