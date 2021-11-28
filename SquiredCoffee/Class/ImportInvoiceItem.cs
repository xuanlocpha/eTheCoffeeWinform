using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.Class
{
    class ImportInvoiceItem
    {
        public int id { get; set; }
        public int import_invoice_id { get; set; }
        public int stock_product_id { get; set; }
        public int supplier_id { get; set; }
        public int quantity { get; set; }
        public string unit { get; set; }
        public decimal unit_price { get; set; }
        public string start_date { get; set; }
        public string expiry_date { get; set; }
        public int status { get; set; }
        public string nameStockProduct { get; set; }
        public string nameSupplier { get; set; }


        public ImportInvoiceItem(int Import_Invoice_Id, int Stock_Product_Id, int Supplier_Id, int Quantity, string Unit, decimal Unit_Price, string Start_Date, string Expiry_Date, int Status)
        {
            import_invoice_id = Import_Invoice_Id;
            stock_product_id = Stock_Product_Id;
            supplier_id = Supplier_Id;
            quantity = Quantity;
            unit = Unit;
            unit_price = Unit_Price;
            start_date = Start_Date;
            expiry_date = Expiry_Date;
            status = Status;
        }

        public ImportInvoiceItem(DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            import_invoice_id = Convert.ToInt32(row["import_invoice_id"]);
            stock_product_id = Convert.ToInt32(row["stock_product_id"]);
            supplier_id = Convert.ToInt32(row["supplier_id"]);
            quantity = Convert.ToInt32(row["quantity"]);
            unit = row["unit"].ToString();
            unit_price = Convert.ToDecimal(row["unit_price"]);
            start_date = row["start_date"].ToString();
            expiry_date = row["expiry_date"].ToString();
            status = Convert.ToInt32(row["status"]);
            nameStockProduct = row["nameStockProduct"].ToString();
            nameSupplier = row["nameSupplier"].ToString();
        }
    }
}
