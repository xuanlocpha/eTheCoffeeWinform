using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.ViewModels
{
    class ProductShowTop
    {

        public int id { get; set; }
        public int category_id { get; set; }
        public string title { get; set; }
        public decimal price { get; set; }
        public string image { get; set; }
        public string content { get; set; }
        public int status { get; set; }
        public string title_category { get; set; }

        public ProductShowTop(DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            category_id = Convert.ToInt32(row["category_id"]);
            title = row["title"].ToString();
            price = Convert.ToDecimal(row["price"]);
            image = row["image"].ToString();
            content = row["content"].ToString();
            status = Convert.ToInt32(row["status"]);
            title_category = row["title_category"].ToString();
        }
    }
}
