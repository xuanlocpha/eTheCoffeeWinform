using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.Class
{
    class ExportInvoice
    {
        public int id { get; set; }
        public int staff_id { get; set; }
        public string create_date { get; set; }
        public int status { get; set; }
        public string name_staff { get; set; }

        public ExportInvoice(int Staff_Id, string Create_Date,int Status)
        {
            staff_id = Staff_Id;
            create_date = Create_Date;
            status = Status;
        }

        public ExportInvoice(DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            staff_id = Convert.ToInt32(row["staff_id"]);
            create_date = row["create_date"].ToString();
            status = Convert.ToInt32(row["status"]);
            name_staff = row["name_staff"].ToString();
        }
    }
}
