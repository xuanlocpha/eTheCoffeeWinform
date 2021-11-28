using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.Class
{
    class ImportInvoice
    {
        public int id { get; set; }
        public int staff_id { get; set; }
        public decimal total_money { get; set; }
        public string create_date { get; set; }
        public int status { get; set; }
        public string name_staff { get; set; }

        public ImportInvoice(int Staff_Id, decimal Total_Money, string Create_Date, int Status)
        {
            staff_id = Staff_Id;
            total_money = Total_Money;
            create_date = Create_Date;
            status = Status;
        }

        public ImportInvoice(DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            staff_id = Convert.ToInt32(row["staff_id"]);
            total_money = Convert.ToInt32(row["total_money"]);
            create_date = row["create_date"].ToString();
            status = Convert.ToInt32(row["status"]);
            name_staff = row["name_staff"].ToString();
        }
    }
}
