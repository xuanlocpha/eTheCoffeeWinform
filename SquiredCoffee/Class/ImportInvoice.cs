using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.Class
{
    class ImportInvoice
    {
        public int id { get; set; }
        public int staff_id { get; set; }
        public int stockproduct_id { get; set; }
        public int supplier_id { get; set; }
        public int quantity { get; set; }
        public string unit { get; set; }
        public decimal unit_price { get; set; }
        public string start_date { get; set; }
        public string expiry_date { get; set; }
        public int status { get; set; }
        public string nameStockProduct { get; set; }
        public string nameSupplier { get; set; }


        public ImportInvoice(int Staff_Id,int StockProduct_Id, int Supplier_Id, int Quantity, string Unit, decimal Unit_Price, string Start_Date, string Expiry_Date, int Status)
        {
            staff_id = Staff_Id;
            stockproduct_id = StockProduct_Id;
            supplier_id = Supplier_Id;
            quantity = Quantity;
            unit = Unit;
            unit_price = Unit_Price;
            start_date = Start_Date;
            expiry_date = Expiry_Date;
            status = Status;
        }

        public ImportInvoice(DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            staff_id = Convert.ToInt32(row["staff_id"]);
            stockproduct_id = Convert.ToInt32(row["stockproduct_id"]);
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
