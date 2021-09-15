using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.Class
{
    class Order_Option
    {
        public int id { get; set; }
        public int id_order_item { get; set; }
        public int id_product_option { get; set; }

        public Order_Option(int Id_Order_Item,int Id_Product_Option)
        {
            id_order_item = Id_Order_Item;
            id_product_option = Id_Product_Option;
        }
    }
}
