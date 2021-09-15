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
        public int product_id { get; set; }
        public int order_id { get; set; }
        public string item_detail { get; set; }
        public int quantity{ get; set; }
        public decimal total_product { get; set; } 
        public string content { get; set; }
        public string title { get; set; }
        public decimal price { get; set; }

   public Order_Items(int Order_Id, int Product_Id,string Item_Detail, int Quantity,decimal Total_Product, string Content)
        {
            product_id = Product_Id;
            order_id = Order_Id;
            item_detail = Item_Detail;
            quantity = Quantity;
            total_product = Total_Product;
            content = Content;
        }

        public Order_Items(DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            product_id = Convert.ToInt32(row["product_id"]);
            order_id = Convert.ToInt32(row["order_id"]);
            item_detail = row["item_detail"].ToString();
            quantity = Convert.ToInt32(row["quantity"]);
            total_product = Convert.ToDecimal(row["total_product"]);
            content = row["content"].ToString();
            title = row["title"].ToString();
            price = Convert.ToDecimal(row["price"]);
        }
    }
}
