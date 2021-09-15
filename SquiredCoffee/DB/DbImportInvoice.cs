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
            string sql = "datasource=localhost;port=3306;username=root;password=;database=coffeeshop";
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

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT ii.id,ii.stockproduct_id,ii.supplier_id,ii.quantity,ii.unit,ii.unit_price,ii.start_date,ii.expiry_date,ii.status,sp.title as nameStockProduct, s.name_supplier as nameSupplier FROM import_invoice ii INNER JOIN stock_products sp ON ii.stockproduct_id = sp.id  INNER JOIN suppliers s ON ii.supplier_id = s.id  ");
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

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT ii.id,ii.stockproduct_id,ii.supplier_id,ii.quantity,ii.unit,ii.unit_price,ii.start_date,ii.expiry_date,ii.status,sp.title as nameStockProduct, s.name_supplier as nameSupplier FROM import_invoice ii INNER JOIN stock_products sp ON ii.stockproduct_id = sp.id  INNER JOIN suppliers s ON ii.supplier_id = s.id  WHERE ii.status = '"+@key+"' ");
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

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT ii.id,ii.stockproduct_id,ii.supplier_id,ii.quantity,ii.unit,ii.unit_price,ii.start_date,ii.expiry_date,ii.status,sp.title as nameStockProduct, s.name_supplier as nameSupplier FROM import_invoice ii INNER JOIN stock_products sp ON ii.stockproduct_id = sp.id  INNER JOIN suppliers s ON ii.supplier_id = s.id  WHERE sp.title LIKE'%" + @key + "%' OR s.name_supplier LIKE'%" + @key + "%'");
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

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT ii.id,ii.stockproduct_id,ii.supplier_id,ii.quantity,ii.unit,ii.unit_price,ii.start_date,ii.expiry_date,ii.status,sp.title as nameStockProduct, s.name_supplier as nameSupplier FROM import_invoice ii INNER JOIN stock_products sp ON ii.stockproduct_id = sp.id  INNER JOIN suppliers s ON ii.supplier_id = s.id  WHERE ii.start_date = '"+@key+"'");
            foreach (DataRow item in data.Rows)
            {
                ImportInvoice importInvoice = new ImportInvoice(item);
                importInvoiceList.Add(importInvoice);
            }

            return importInvoiceList;
        }


        public static void AddImportInvoice(ImportInvoice std)
        {
            string sql = "INSERT INTO import_invoice (stockproduct_id,supplier_id,quantity,unit,unit_price,start_date,expiry_date,status) VALUES(@stockproduct_id,@supplier_id,@quantity,@unit,@unit_price,@start_date,@expiry_date,@status)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
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
                MessageBox.Show("Nhập Hàng Thành Công ( Thành Công ) ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Nhập Hàng ( Không Thành Công ) ! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
    }
}
