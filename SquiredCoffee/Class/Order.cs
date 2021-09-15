using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.Class
{
    class Order
    {
        public int id { get; set; }
        public string table_number { get; set; }
        public int staff_id { get; set; }
        public decimal subtotal { get; set; }
        public int discount { get; set; }
        public int item_discount { get; set; }
        public decimal shipping { get; set; }
        public string promo { get; set; }
        public decimal grandtotal { get; set; }
        public string content { get; set; }
        public int status { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
       


        public Order(string Table_Number, int Staff_Id, decimal Subtotal, int Discount, int Item_Discount, decimal Shipping, string Promo, decimal Grandtotal,
                    string Content, int Status, string Address, string Phone)
        {
            table_number = Table_Number;
            staff_id = Staff_Id;
            subtotal = Subtotal;
            discount = Discount;
            item_discount = Item_Discount;
            shipping = Shipping;
            promo = Promo;
            grandtotal = Grandtotal;
            content = Content;
            status = Status;
            address = Address;
            phone = Phone;
        }


      

        public Order(DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            table_number = row["table_number"].ToString();
            staff_id = Convert.ToInt32(row["staff_id"]);
            subtotal = Convert.ToDecimal(row["subtotal"]);
            discount = Convert.ToInt32(row["discount"]); ;
            item_discount = Convert.ToInt32(row["item_discount"]); ;
            shipping = Convert.ToDecimal(row["shipping"]); ;
            promo = row["promo"].ToString();
            grandtotal = Convert.ToDecimal(row["grandtotal"]);
            content = row["content"].ToString();
            status = Convert.ToInt32(row["status"]);
            address = row["address"].ToString();
            phone = row["phone"].ToString(); 
        }
    }
}
