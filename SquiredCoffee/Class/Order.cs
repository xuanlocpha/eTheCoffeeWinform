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
        public int user_id { get; set; }
        public int address_id { get; set; }
        public decimal subtotal { get; set; }
        public decimal voucher_discount { get; set; }
        public decimal shipping_discount { get; set; }
        public decimal shipping { get; set; }
        public string promo { get; set; }
        public decimal grandtotal { get; set; }
        public string content { get; set; }
        public int status { get; set; }

       


        public Order(string Table_Number, int Staff_Id,int User_Id,int Address_Id,decimal Subtotal,decimal Voucher_Discount,decimal Shipping_Discount, decimal Shipping, string Promo, decimal Grandtotal,string Content, int Status)
        {
            table_number = Table_Number;
            staff_id = Staff_Id;
            user_id = User_Id;
            address_id = Address_Id;
            subtotal = Subtotal;
            voucher_discount = Voucher_Discount;
            shipping_discount = Shipping_Discount;
            shipping = Shipping;
            promo = Promo;
            grandtotal = Grandtotal;
            content = Content;
            status = Status;
        }


      

        public Order(DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            table_number = row["table_number"].ToString();
            staff_id = Convert.ToInt32(row["staff_id"]);
            user_id = Convert.ToInt32(row["user_id"]);
            address_id = Convert.ToInt32(row["address_id"]);
            subtotal = Convert.ToDecimal(row["subtotal"]);
            voucher_discount = Convert.ToDecimal(row["voucher_discount"]);
            shipping_discount= Convert.ToDecimal(row["shipping_discount"]);
            shipping = Convert.ToDecimal(row["shipping"]);
            promo = row["promo"].ToString();
            grandtotal = Convert.ToDecimal(row["grandtotal"]);
            content = row["content"].ToString();
            status = Convert.ToInt32(row["status"]);
        }
    }
}
