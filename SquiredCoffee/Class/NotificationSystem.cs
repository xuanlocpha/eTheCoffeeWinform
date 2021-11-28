using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.Class
{
    class NotificationSystem
    {
        public int id { get; set; }
        public int id_staff { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string create_date { get; set; }
        public int status { get; set; }
        public string name_staff { get; set; }

        public NotificationSystem(int Id_Staff, string Title, string Content, string Create_Date, int Status)
        {
            id_staff = Id_Staff;
            title = Title;
            content = Content;
            create_date = Create_Date;
            status = Status;
        }


        public NotificationSystem(DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            id_staff = Convert.ToInt32(row["id_staff"]);
            title = row["title"].ToString();
            content = row["content"].ToString();
            create_date = row["create_date"].ToString();
            status = Convert.ToInt32(row["status"]);
            name_staff = row["name_Staff"].ToString();
        }
    }
}
