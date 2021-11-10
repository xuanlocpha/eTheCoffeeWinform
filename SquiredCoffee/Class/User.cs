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
        public string display_name { get; set; }
        public string gender { get; set; }
        public string birthday { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string image { get; set; }
        public int point { get; set; }
        public int total_point { get; set; }
        public int level { get; set; }
        public string bar_code { get; set; }
        public int status { get; set; }
        public string password { get; set; }
       
        public User(string Display_Name,string Gender,string Birthday,string Email, string Phone,string Image,int Point, int Total_Point,int Level,string Bar_Code,int Status,string Password)
        {
            display_name = Display_Name;
            gender = Gender;
            birthday = Birthday;
            email = Email;
            phone = Phone;
            image = Image;
            point = Point;
            total_point = Total_Point;
            level = Level;
            bar_code = Bar_Code;
            status = Status;
            password = Password;
        }

        public User(DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            display_name = row["display_name"].ToString();
            gender = row["gender"].ToString();
            birthday = row["birthday"].ToString();
            email = row["email"].ToString();
            phone = row["phone"].ToString();
            image = row["image"].ToString();
            point = Convert.ToInt32(row["point"]);
            total_point = Convert.ToInt32(row["total_point"]);
            level = Convert.ToInt32(row["level"]);
            bar_code = row["bar_code"].ToString();
            status = Convert.ToInt32(row["status"]);
            password = row["password"].ToString();
        }

    }
}
