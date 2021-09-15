using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.ViewModels
{
    class ProductToppingShow
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public int topping_id { get; set; }
        public int status { get; set; }
        public string name_product { get; set; }
        public string name_topping { get; set; }

        public ProductToppingShow(DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            product_id = Convert.ToInt32(row["product_id"]);
            topping_id = Convert.ToInt32(row["topping_id"]);
            status = Convert.ToInt32(row["status"]);
            name_product = row["name_product"].ToString();
            name_topping = row["name_topping"].ToString();
        }
    }
}
