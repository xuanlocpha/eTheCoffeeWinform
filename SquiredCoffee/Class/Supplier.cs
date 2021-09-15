using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.Class
{
    class Supplier
    {
        public int id { get; set; }
        public string name_supplier { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public int status { get; set; }


        public Supplier(string Name_Supplier, string Address, string Phone, string Email, int Status)
        {
            name_supplier = Name_Supplier;
            address = Address;
            phone = Phone;
            email = Email;
            status = Status;
        }

        public Supplier (DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            name_supplier = row["name_supplier"].ToString();
            address = row["address"].ToString();
            phone = row["phone"].ToString();
            email = row["email"].ToString();
            status = Convert.ToInt32(row["status"]);
        }
    }
}
