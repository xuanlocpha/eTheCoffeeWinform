using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.Class
{
    class Assignment
    {
        public int id { get; set; }
        public int staff_id { get; set; }
        public string date { get; set; }
        public string start_time { get; set; }
        public string expiry_time { get; set; }
        public int check_shift { get; set; }
        public int total_min { get; set; }
        public int total_time_late { get; set; }
        public int type { get; set; }
        public string name_staff { get; set; }

        public Assignment(int Staff_Id, string Date, string Start_Time, string Expiry_Time, int Check_Shift, int Total_Min,int Total_Time_Late,int Type)
        {
            staff_id = Staff_Id;
            date = Date;
            start_time = Start_Time;
            expiry_time = Expiry_Time;
            check_shift = Check_Shift;
            total_min = Total_Min;
            total_time_late = Total_Time_Late;
            type = Type;
        }

        public Assignment(DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            staff_id = Convert.ToInt32(row["staff_id"]);
            start_time = row["start_time"].ToString();
            date = row["date"].ToString();
            expiry_time = row["expiry_time"].ToString();
            check_shift = Convert.ToInt32(row["check_shift"]);
            total_min = Convert.ToInt32(row["total_min"]);
            total_time_late = Convert.ToInt32(row["total_time_late"]);
            type = Convert.ToInt32(row["type"]);
            name_staff = row["name_staff"].ToString();
        }
    }
}
