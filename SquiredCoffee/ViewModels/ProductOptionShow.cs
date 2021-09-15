using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.ViewModels
{
    class ProductOptionShow
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public int option_id { get; set; }
        public string title { get; set; }
        public decimal price { get; set; }
        public int defaults { get; set; }
        public int status { get; set; }
        public string name_product { get; set; }
        public string name_option { get; set; }

        public ProductOptionShow(int Product_Id, int Option_Id, string Title, decimal Price, int Defaults, int Status)
        {
            product_id = Product_Id;
            option_id = Option_Id;
            title = Title;
            price = Price;
            defaults = Defaults;
            status = Status;
        }

        public ProductOptionShow(DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            product_id = Convert.ToInt32(row["product_id"]);
            option_id = Convert.ToInt32(row["option_id"]);
            title = row["title"].ToString();
            price = Convert.ToDecimal(row["price"]);
            defaults = Convert.ToInt32(row["defaults"]);
            status = Convert.ToInt32(row["status"]);
            name_option = row["name_option"].ToString();
            name_product = row["name_product"].ToString();
        }
    }
}
