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
        public string content { get; set; }
        public string title { get; set; }
        public decimal price { get; set; }
        public decimal price_discount { get; set; }

        public Order_Items(int Product_Id,string Item_Detail, int Order_Id, int Quantity,decimal Price, string Content)
        {
            product_id = Product_Id;
            order_id = Order_Id;
            item_detail = Item_Detail;
            quantity = Quantity;
            content = Content;
            price = Price;
        }

        public Order_Items(DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            product_id = Convert.ToInt32(row["product_id"]);
            item_detail = row["item_detail"].ToString();
            order_id = Convert.ToInt32(row["order_id"]);
            quantity = Convert.ToInt32(row["quantity"]);
            price = Convert.ToDecimal(row["price"]);
            content = row["content"].ToString();
            title = row["title"].ToString();
            //price_discount = Convert.ToDecimal(row["price_discount"]);
        }
    }
}
