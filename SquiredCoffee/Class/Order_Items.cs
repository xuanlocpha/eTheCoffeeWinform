using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.Class
{
    class Order_Items
    {
        public int id { get; set; }
        public int id_order { get; set; }
        public int id_product { get; set; }
        public int count { get; set; }
        public decimal price { get; set; }
        public decimal provisional { get; set; }
        public string created_at { get; set; }

        public Order_Items(int Id_Order, int Id_Product, int Count, decimal Price, decimal Provisional)
        {
            id_order = Id_Order;
            id_product = Id_Product;
            count = Count;
            price = Price;
            provisional = Provisional;
        }

        public Order_Items(DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            id_order = Convert.ToInt32(row["id_order"]);
            id_product = Convert.ToInt32(row["id_product"]);
            count = Convert.ToInt32(row["count"]);
            price = Convert.ToDecimal(row["id"]);
            provisional = Convert.ToDecimal(row["provisional"]);
            created_at = row["created_at"].ToString();
        }
    }
}
