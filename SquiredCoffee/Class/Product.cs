using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.Class
{
    class Product
    {
        //public int id { get; set; }
        public int category_id { get; set; }
        public string title { get; set; }
        public decimal price { get; set; }
        public string image { get; set; }
        public string content { get; set; }
        public int status { get; set; }


        private int iD;
        public int id
        {
            get { return iD; }
            set { iD = value; }
        }

        public Product(int Category_Id, string Title, decimal Price, string Image, string Content, int Status)
        {
            category_id = Category_Id;
            title = Title;
            price = Price;
            image = Image;
            content = Content;
            status = Status;
        }

        public Product(DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            category_id = Convert.ToInt32(row["category_id"]);
            title = row["title"].ToString();
            price = Convert.ToDecimal(row["price"]);
            image = row["image"].ToString();
            content = row["content"].ToString();
            status = Convert.ToInt32(row["status"]);
        }  
    }
}
