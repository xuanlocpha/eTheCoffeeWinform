using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.Class
{
    class User
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int point { get; set; }

        public User( string First_Name, string Last_Name, string Gender, string Email, string Phone, int Point)
        {
            first_name = First_Name;
            last_name = Last_Name;
            gender = Gender;
            email = Email;
            phone = Phone;
            point = Point;
        }

        public User(DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            first_name = row["first_name"].ToString();
            last_name = row["last_name"].ToString();
            gender = row["gender"].ToString();
            email = row["email"].ToString();
            phone = row["phone"].ToString();
            point = Convert.ToInt32(row["point"]);
        }

    }
}
