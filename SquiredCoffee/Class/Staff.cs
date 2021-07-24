using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.Class
{
    class Staff
    {
        public string employee_code { get; set; }
        public string full_name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string gender { get; set; }
        public string birthday { get; set; }
        public string image { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public int role_id { get; set; }
        public int status { get; set; }


        public Staff(string Employee_Code, string Full_Name, string UserName, string Password, string Gender, string BirthDay,string Image,  string Phone, string Address, string Email, int Role_Id, int Status)
        {
            employee_code = Employee_Code;
            full_name = Full_Name;
            username = UserName;
            password = Password;
            gender = Gender;
            birthday = BirthDay;
            image = Image;
            phone = Phone;
            address = Address;
            email = Email;
            role_id = Role_Id;
            status = Status;
        }
    }
}
