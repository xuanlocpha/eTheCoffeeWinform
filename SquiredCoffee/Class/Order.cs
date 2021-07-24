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
        public int id_staff { get; set; }
        public int id_table { get; set; }
        public decimal grandtotal { get; set; }
        public int disscount { get; set; }
        public int item_disscount { get; set; }
        public decimal shipping { get; set; }
        public string promo { get; set; }
        public string content { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public int status { get; set; }


        public Order(int Id_Staff, int Id_Table, decimal GrandTotal, int Disscount, int Item_Disscount, decimal Shipping, string Promo, 
                    string Content, string Address, string Phone, int Status)
        {
            id_staff = Id_Staff;
            id_table = Id_Table;
            grandtotal = GrandTotal;
            disscount = Disscount;
            item_disscount = Item_Disscount;
            shipping = Shipping;
            promo = Promo;
            content = Content;
            address = Address;
            phone = Phone;
            status = Status;
        }


        public Order(DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            id_staff = Convert.ToInt32(row["id_staff"]);
            id_table = Convert.ToInt32(row["id_table"]);
            grandtotal = Convert.ToDecimal(row["grandtotal"]);
            disscount = Convert.ToInt32(row["disscount"]); ;
            item_disscount = Convert.ToInt32(row["item_disscount"]); ;
            shipping = Convert.ToDecimal(row["shipping"]); ;
            promo = row["promo"].ToString();
            content = row["content"].ToString();
            address = row["address"].ToString();
            phone = row["phone"].ToString(); 
            status = Convert.ToInt32(row["status"]);
        }
    }
}
