using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.Class
{
    class Staff
    {
        public int id { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string gender { get; set; }
        public string birthday { get; set; }
        public string image { get; set; }
        public string phone { get; set; }
        //public string address { get; set; }
        public string email { get; set; }
        public int role_id { get; set; }
        public int status { get; set; }
        public string title { get; set; }


        public Staff(string Last_Name, string First_Name ,string UserName, string Password, string Gender, string BirthDay,string Image,  string Phone/*, string Address*/, string Email, int Role_Id, int Status)
        {
            username = UserName;
            password = Password;
            last_name = Last_Name;
            first_name = First_Name;
            gender = Gender;
            birthday = BirthDay;
            image = Image;
            phone = Phone;
            //address = Address;
            email = Email;
            role_id = Role_Id;
            status = Status;
        }

        public Staff(DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            last_name = row["last_name"].ToString();
            first_name = row["first_name"].ToString();
            username = row["username"].ToString();
            password = row["password"].ToString();
            gender = row["gender"].ToString();
            birthday = row["birthday"].ToString();
            image = row["image"].ToString();
            phone = row["phone"].ToString();
            email = row["email"].ToString();
            role_id = Convert.ToInt32(row["role_id"]);
            status = Convert.ToInt32(row["status"]);
            title = row["title"].ToString();
        }
    }
}
