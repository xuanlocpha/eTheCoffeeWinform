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
        public int product_id { get; set; }
        public string start_date { get; set; }
        public string expiry_date { get; set; }
        public string title_product { get; set; }
        public int status { get; set; }

        public  Discount(double Discount,int Product_Id,string Start_Date,string Expiry_Date,int Status)
        {
            discount = Discount;
            product_id = Product_Id;
            start_date = Start_Date;
            expiry_date = Expiry_Date;
            status = Status;
        }

        public Discount(DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            discount = Convert.ToDouble(row["discount"]);
            product_id = Convert.ToInt32(row["product_id"]);
            start_date = row["start_date"].ToString();
            expiry_date = row["expiry_date"].ToString();
            title_product = row["title_product"].ToString();
            status = Convert.ToInt32(row["status"]);
        }
    }
}
