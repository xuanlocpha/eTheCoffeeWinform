using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.Class
{
    class Voucher
    {
        public string title { get; set; }
        public string content { get; set; }
        public string coupen_code { get; set; }
        public string image { get; set; }
        public string qr_code { get; set; }
        public string start_date { get; set; }
        public string expiry_date { get; set; }
        public string disscount_unit { get; set; }
        public decimal disscount { get; set; }
        public int minimum_order { get; set; }
        public int status { get; set; }


        public Voucher(string Title,string Content,string Coupen_Code,string Image,string Qr_Code,string Start_Date,string Expiry_Date,string Disscount_Unit,decimal Disscount,int Minimum_Order,int Status)
        {
            title = Title;
            content = Content;
            coupen_code = Coupen_Code;
            image = Image;
            qr_code = Qr_Code;
            start_date = Start_Date;
            expiry_date = Expiry_Date;
            disscount_unit = Disscount_Unit;
            disscount = Disscount;
            minimum_order = Minimum_Order;
            status = Status;
        }
    }
}
