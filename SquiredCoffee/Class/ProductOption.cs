using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.Class
{
    class ProductOption
    {
        public int product_id { get; set; }
        public int option_id { get; set; }
        public string title { get; set; }
        public decimal price { get; set; }
        public int defaults { get; set; }
        public int status { get; set; }

        public ProductOption(int Product_Id,int Option_Id,string Title,decimal Price,int Defaults, int Status)
        {
            product_id = Product_Id;
            option_id = Option_Id;
            title = Title;
            price = Price;
            defaults = Defaults;
            status = Status;
        }
    }
}
