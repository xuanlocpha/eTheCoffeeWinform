using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.Class
{
    class ProductTopping
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public int topping_id { get; set; }
        public int status { get; set; }

        public ProductTopping(int Product_Id,int Topping_Id,int Status)
        {
            product_id = Product_Id;
            topping_id = Topping_Id;
            status = Status;
        }

        public ProductTopping(DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            product_id = Convert.ToInt32(row["product_id"]);
            topping_id = Convert.ToInt32(row["topping_id"]);
            status = Convert.ToInt32(row["status"]);
        }
    }
}
