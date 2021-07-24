using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.Class
{
    class Category
    {
        public int id { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public int status { get; set; }

        public Category(string Title)
        {
            title = Title;
        }

        public Category(DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            title = row["title"].ToString();
            type = row.Field<string>("type");
            status = Convert.ToInt32(row["status"]);
        }
    }
}
