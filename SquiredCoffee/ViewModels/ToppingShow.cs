using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.ViewModels
{
    class ToppingShow
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public int status { get; set; }


        public ToppingShow(DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            title = row["title"].ToString();
            description = row["description"].ToString();
            price = Convert.ToDecimal(row["price"]);
            status = Convert.ToInt32(row["status"]);
        }
    }
}
