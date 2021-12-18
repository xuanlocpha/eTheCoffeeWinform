using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.Class
{
    class ExportInvoiceItems
    {
        public int id { get; set; }
        public int export_invoice_id { get; set; }
        public int stock_product_id { get; set; }
        public int quantity { get; set; }
        public string unit { get; set; }
        public string create_date { get; set; }
        public int status { get; set; }
        public string nameStockProduct { get; set; }

        public ExportInvoiceItems(int Export_Invoice_Id, int Stock_Product_Id, int Quantity, string Unit, string Create_Date, int Status)
        {
            export_invoice_id = Export_Invoice_Id;
            stock_product_id = Stock_Product_Id;
            quantity = Quantity;
            unit = Unit;
            create_date = Create_Date;
            status = Status;
        }

        public ExportInvoiceItems(DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            export_invoice_id = Convert.ToInt32(row["export_invoice_id"]);
            stock_product_id = Convert.ToInt32(row["stock_product_id"]);
            quantity = Convert.ToInt32(row["quantity"]);
            unit = row["unit"].ToString();
            create_date = row["create_date"].ToString();
            status = Convert.ToInt32(row["status"]);
            nameStockProduct = row["nameStockProduct"].ToString();
        }
    }
}
