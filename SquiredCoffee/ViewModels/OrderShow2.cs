using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.ViewModels
{
    class OrderShow2
    {
        public int id { get; set; }
        public int table_number { get; set; }
        public int staff_id { get; set; }
        public int user_id { get; set; }
        public int address_id { get; set; }
        public decimal subtotal { get; set; }
        public decimal voucher_discount { get; set; }
        public decimal shipping_discount { get; set; }
        public decimal shipping { get; set; }
        public decimal grandtotal { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string user_name { get; set; }
        public string mode { get; set; }
        public string address { get; set; }
        public string created_at { get; set; }

        public OrderShow2(DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            table_number = Convert.ToInt32(row["table_number"]);
            staff_id = Convert.ToInt32(row["staff_id"]);
            user_id = Convert.ToInt32(row["user_id"]);
            address_id = Convert.ToInt32(row["address_id"]);
            subtotal = Convert.ToDecimal(row["subtotal"]);
            voucher_discount = Convert.ToDecimal(row["voucher_discount"]);
            shipping_discount = Convert.ToDecimal(row["shipping_discount"]);
            shipping = Convert.ToDecimal(row["shipping"]);
            grandtotal = Convert.ToDecimal(row["grandtotal"]);
            first_name = row["first_name"].ToString();
            last_name = row["last_name"].ToString();
            user_name = row["user_name"].ToString();
            mode = row["mode"].ToString();
            address = row["address"].ToString();
            created_at = row["created_at"].ToString();
        }
    }
}
