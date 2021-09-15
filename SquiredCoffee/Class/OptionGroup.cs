using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.Class
{
    class OptionGroup
    {
        public int id { get; set; }
        public string title { get; set; }
        public int status { get; set; }

        public OptionGroup(string Title, int Status)
        {
            title = Title;
            status = Status;
        }

        public OptionGroup(DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            title = row["title"].ToString();
            status = Convert.ToInt32(row["status"]);
        }
    }
}
