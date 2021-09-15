using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.ViewModels
{
    class OptionShow
    {
        public int id { get; set; }
        public string title { get; set; }
        public int option_group_id { get; set; }
        public int status { get; set; }


        public OptionShow(DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            title = row["title"].ToString();
            option_group_id = Convert.ToInt32(row["option_group_id"]);
            status = Convert.ToInt32(row["status"]);
        }
    }
}
