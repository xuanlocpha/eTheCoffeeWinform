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
    class DbExportInvoiceItem
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

        public static void AddExportInvoice(ExportInvoiceItems std)
        {
            string sql = "INSERT INTO export_invoice_items (export_invoice_id,stock_product_id,quantity,unit,create_date,status) VALUES(@export_invoice_id,@stock_product_id,@quantity,@unit,@create_date,@status)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@export_invoice_id", MySqlDbType.VarChar).Value = std.export_invoice_id;
            cmd.Parameters.Add("@stock_product_id", MySqlDbType.VarChar).Value = std.stock_product_id;
            cmd.Parameters.Add("@quantity", MySqlDbType.VarChar).Value = std.quantity;
            cmd.Parameters.Add("@unit", MySqlDbType.VarChar).Value = std.unit;
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

        public static void DeleteExportInvoiceItems(string id)
        {
            string sql = "DELETE FROM export_invoice_items  WHERE id = '" + id + "'";
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

        public static bool CheckCreateExportInvoice(ExportInvoiceItems std)
        {
            AddExportInvoice(std);
            string sql = "select * from import_invoice_items where  stock_product_id = @stock_product_id AND quantity = @quantity AND unit = @unit AND create_date = @create_date AND status = @status";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@export_invoice_id", MySqlDbType.VarChar).Value = std.export_invoice_id;
            cmd.Parameters.Add("@stock_product_id", MySqlDbType.VarChar).Value = std.stock_product_id;
            cmd.Parameters.Add("@quantity", MySqlDbType.VarChar).Value = std.quantity;
            cmd.Parameters.Add("@unit", MySqlDbType.VarChar).Value = std.unit;
            cmd.Parameters.Add("@create_date", MySqlDbType.VarChar).Value = std.create_date;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet tbl = new DataSet();
            adp.Fill(tbl);
            int i = tbl.Tables[0].Rows.Count;
            if (i > 0)
            {
                return true;  // data exist
            }
            else
            {
                return false; //data not exist
            }
        }


        public static List<ExportInvoiceItems> LoadExportInvoiceItem(string key)
        {
            List<ExportInvoiceItems> exportInvoiceItemsList = new List<ExportInvoiceItems>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT ii.id,ii.export_invoice_id,ii.stock_product_id,ii.quantity,ii.unit,ii.create_date,ii.status,sp.title as nameStockProduct FROM export_invoice_items ii INNER JOIN stock_products sp ON ii.stock_product_id = sp.id  WHERE ii.export_invoice_id = '" + key + "'");
            foreach (DataRow item in data.Rows)
            {
                ExportInvoiceItems exportInvoiceItems = new ExportInvoiceItems(item);
                exportInvoiceItemsList.Add(exportInvoiceItems);
            }

            return exportInvoiceItemsList;
        }
    }
}
