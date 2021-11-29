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
    class DbImportInvoiceItem
    {
        public static MySqlConnection GetConnection()
        {
            string sql = "SERVER=45.252.251.21;PORT=3306;DATABASE=sodopxlg_koffeeholic;UID=sodopxlg;PASSWORD=05qT1yfRp9;charset=utf8";
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


        public static List<ImportInvoiceItem> LoadImportInvoice()
        {
            List<ImportInvoiceItem> importInvoiceItemList = new List<ImportInvoiceItem>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT ii.id,ii.staff_id,ii.stockproduct_id,ii.supplier_id,ii.quantity,ii.unit,ii.unit_price,ii.start_date,ii.expiry_date,ii.status,sp.title as nameStockProduct, s.name_supplier as nameSupplier FROM import_invoice ii INNER JOIN stock_products sp ON ii.stockproduct_id = sp.id  INNER JOIN suppliers s ON ii.supplier_id = s.id  ");
            foreach (DataRow item in data.Rows)
            {
                ImportInvoiceItem importInvoiceItem = new ImportInvoiceItem(item);
                importInvoiceItemList.Add(importInvoiceItem);
            }

            return importInvoiceItemList;
        }

        public static List<ImportInvoiceItem> LoadImportInvoiceItem(string import_invoice_id)
        {
            List<ImportInvoiceItem> importInvoiceItemList = new List<ImportInvoiceItem>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT ii.id,ii.import_invoice_id,ii.stock_product_id,ii.supplier_id,ii.quantity,ii.unit,ii.unit_price,ii.start_date,ii.expiry_date,ii.status,sp.title as nameStockProduct, s.name_supplier as nameSupplier FROM import_invoice_items ii INNER JOIN stock_products sp ON ii.stock_product_id = sp.id  INNER JOIN suppliers s ON ii.supplier_id = s.id  WHERE ii.import_invoice_id = '" + import_invoice_id+"'");
            foreach (DataRow item in data.Rows)
            {
                ImportInvoiceItem importInvoiceItem = new ImportInvoiceItem(item);
                importInvoiceItemList.Add(importInvoiceItem);
            }

            return importInvoiceItemList;
        }

        public static void AddImportInvoice(ImportInvoiceItem std)
        {
            string sql = "INSERT INTO import_invoice_items (import_invoice_id,stock_product_id,supplier_id,quantity,unit,unit_price,start_date,expiry_date,status) VALUES(@import_invoice_id,@stock_product_id,@supplier_id,@quantity,@unit,@unit_price,@start_date,@expiry_date,@status)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@import_invoice_id", MySqlDbType.VarChar).Value = std.import_invoice_id;
            cmd.Parameters.Add("@stock_product_id", MySqlDbType.VarChar).Value = std.stock_product_id;
            cmd.Parameters.Add("@supplier_id", MySqlDbType.VarChar).Value = std.supplier_id;
            cmd.Parameters.Add("@quantity", MySqlDbType.VarChar).Value = std.quantity;
            cmd.Parameters.Add("@unit", MySqlDbType.VarChar).Value = std.unit;
            cmd.Parameters.Add("@unit_price", MySqlDbType.VarChar).Value = std.unit_price;
            cmd.Parameters.Add("@start_date", MySqlDbType.VarChar).Value = std.start_date;
            cmd.Parameters.Add("@expiry_date", MySqlDbType.VarChar).Value = std.expiry_date;
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


        public static bool CheckCreateImportInvoice(ImportInvoiceItem std)
        {
            AddImportInvoice(std);
            string sql = "select * from import_invoice_items where import_invoice_id = @import_invoice_id and stock_product_id = @stock_product_id and supplier_id = @supplier_id  and quantity = @quantity and unit = @unit and unit_price = @unit_price and start_date = @start_date and expiry_date = @expiry_date and status = @status";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@import_invoice_id", MySqlDbType.VarChar).Value = std.import_invoice_id;
            cmd.Parameters.Add("@stock_product_id", MySqlDbType.VarChar).Value = std.stock_product_id;
            cmd.Parameters.Add("@supplier_id", MySqlDbType.VarChar).Value = std.supplier_id;
            cmd.Parameters.Add("@quantity", MySqlDbType.VarChar).Value = std.quantity;
            cmd.Parameters.Add("@unit", MySqlDbType.VarChar).Value = std.unit;
            cmd.Parameters.Add("@unit_price", MySqlDbType.VarChar).Value = std.unit_price;
            cmd.Parameters.Add("@start_date", MySqlDbType.VarChar).Value = std.start_date;
            cmd.Parameters.Add("@expiry_date", MySqlDbType.VarChar).Value = std.expiry_date;
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


      
        public static void DeleteImportInvoice(string id)
        {
            string sql = "Delete From import_invoice_items  WHERE id = @id";
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
