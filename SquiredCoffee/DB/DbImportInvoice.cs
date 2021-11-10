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
            string sql = "SERVER=45.252.251.29;PORT=3306;DATABASE=sodopxlg_koffeeholic;UID=sodopxlg;PASSWORD=05qT1yfRp9";
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

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT ii.id,ii.staff_id,ii.stockproduct_id,ii.supplier_id,ii.quantity,ii.unit,ii.unit_price,ii.start_date,ii.expiry_date,ii.status,sp.title as nameStockProduct, s.name_supplier as nameSupplier FROM import_invoice ii INNER JOIN stock_products sp ON ii.stockproduct_id = sp.id  INNER JOIN suppliers s ON ii.supplier_id = s.id  ");
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

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT ii.id,ii.staff_id,ii.stockproduct_id,ii.supplier_id,ii.quantity,ii.unit,ii.unit_price,ii.start_date,ii.expiry_date,ii.status,sp.title as nameStockProduct, s.name_supplier as nameSupplier FROM import_invoice ii INNER JOIN stock_products sp ON ii.stockproduct_id = sp.id  INNER JOIN suppliers s ON ii.supplier_id = s.id  WHERE ii.status = '" + @key+"' ");
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

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT ii.id,ii.staff_id,ii.stockproduct_id,ii.supplier_id,ii.quantity,ii.unit,ii.unit_price,ii.start_date,ii.expiry_date,ii.status,sp.title as nameStockProduct, s.name_supplier as nameSupplier FROM import_invoice ii INNER JOIN stock_products sp ON ii.stockproduct_id = sp.id  INNER JOIN suppliers s ON ii.supplier_id = s.id  WHERE sp.title LIKE'%" + @key + "%' OR s.name_supplier LIKE'%" + @key + "%'");
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

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT ii.id,ii.staff_id,ii.stockproduct_id,ii.supplier_id,ii.quantity,ii.unit,ii.unit_price,ii.start_date,ii.expiry_date,ii.status,sp.title as nameStockProduct, s.name_supplier as nameSupplier FROM import_invoice ii INNER JOIN stock_products sp ON ii.stockproduct_id = sp.id  INNER JOIN suppliers s ON ii.supplier_id = s.id  WHERE ii.start_date = '" + @key+"'");
            foreach (DataRow item in data.Rows)
            {
                ImportInvoice importInvoice = new ImportInvoice(item);
                importInvoiceList.Add(importInvoice);
            }

            return importInvoiceList;
        }


        public static void AddImportInvoice(ImportInvoice std)
        {
            string sql = "INSERT INTO import_invoice (staff_id,stockproduct_id,supplier_id,quantity,unit,unit_price,start_date,expiry_date,status) VALUES(@staff_id,@stockproduct_id,@supplier_id,@quantity,@unit,@unit_price,@start_date,@expiry_date,@status)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@staff_id", MySqlDbType.VarChar).Value = std.staff_id;
            cmd.Parameters.Add("@stockproduct_id", MySqlDbType.VarChar).Value = std.stockproduct_id;
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


        public static bool CheckCreateImportInvoice(ImportInvoice std)
        {
            AddImportInvoice(std);
            string sql = "select * from import_invoice where staff_id = @staff_id and stockproduct_id = @stockproduct_id and supplier_id = @supplier_id  and quantity = @quantity and unit = @unit and unit_price = @unit_price and start_date = @start_date and expiry_date = @expiry_date and status = @status";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@staff_id", MySqlDbType.VarChar).Value = std.staff_id;
            cmd.Parameters.Add("@stockproduct_id", MySqlDbType.VarChar).Value = std.stockproduct_id;
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

    }
}
