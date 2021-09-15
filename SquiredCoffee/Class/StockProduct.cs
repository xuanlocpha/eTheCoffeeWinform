using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.Class
{
    class StockProduct
    {
        public int id { get; set; }
        public string title { get; set; }
        public int quantity { get; set; }
        public string unit { get; set; }
        public int status { get; set; }


        public StockProduct(string Title, int Quantity, string Unit, int Status)
        {
            title = Title;
            quantity = Quantity;
            unit = Unit;
            status = Status;
        }

    
        public StockProduct(DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            title = row["title"].ToString();
            quantity = Convert.ToInt32(row["quantity"]);
            unit = row["unit"].ToString();
            status = Convert.ToInt32(row["status"]);
        }
    }
}
