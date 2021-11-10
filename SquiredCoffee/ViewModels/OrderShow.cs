using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.ViewModels
{
    class OrderShow
    {
        public int id { get; set; }
        public string display_name { get; set; }
        public string address { get; set; }
        public decimal grand_total { get; set; }
        public decimal shipping { get; set; }
        public int status { get; set; }

        public OrderShow(DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            display_name = row["display_name"].ToString();
            address = row["address"].ToString();
            grand_total = Convert.ToDecimal(row["grand_total"]);
            status = Convert.ToInt32(row["status"]);
            shipping = Convert.ToDecimal(row["shipping"]);
        }
    }
}
