using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.Class
{
    class Option
    {
        public int id { get; set; }
        public string title { get; set; }
        public int option_group_id { get; set; }
        public int status { get; set; }
        public string name_product_option { get; set; }
        public decimal price { get; set; }
        public int default_product_option { get;set;}

        public Option(string Title, int Option_Group_Id, int Status)
        {
            title = Title;
            option_group_id = Option_Group_Id;
            status = Status;
        }

        public Option(DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            title = row["title"].ToString();
            option_group_id = Convert.ToInt32(row["option_group_id"]);
            status = Convert.ToInt32(row["status"]);
            name_product_option = row["name_product_option"].ToString();
            price = Convert.ToDecimal(row["price"]);
            default_product_option = Convert.ToInt32(row["default_product_option"]);
        }


       
    }
}
