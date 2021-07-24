using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.Class
{
    class Rewards
    {
        public string title { get; set; }
        public string content { get; set; }
        public string image { get; set; }
        public string start_date { get; set; }
        public string expiry_date { get; set; }
        public int point { get; set; }
        public int status { get; set; }

        public Rewards(string Title ,string Content,string Image,string Start_Date,string Expiry_Date,int Point,int Status)
        {
            title = Title;
            content = Content;
            image = Image;
            start_date = Start_Date;
            expiry_date = Expiry_Date;
            point = Point;
            status = Status;
        }
    }
}
