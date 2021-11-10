using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.Class
{
    class Discount
    {
        public int id { get; set; }
        public double discount { get; set; }
        public string product { get; set; }
        public string start_date { get; set; }
        public string expiry_date { get; set; }

        public  Discount(double Discount,string Product,string Start_Date,string Expiry_Date)
        {
            discount = Discount;
            product = Product;
            start_date = Start_Date;
            expiry_date = Expiry_Date;
        }
        

        public Discount(DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            discount = Convert.ToDouble(row["discount"]);
            product = row["products"].ToString();
            start_date = row["start_date"].ToString();
            expiry_date = row["expiry_date"].ToString();
        }
    }
}
