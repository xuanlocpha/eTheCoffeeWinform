using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.Class
{
    class Rewards
    {
        public int voucher_id { get; set; }
        public string title { get; set; }
        public string brand_name { get; set; }
        public string content { get; set; }
        public string image { get; set; }
        public int point { get; set; }
        public int quantity { get; set; }
        public int status { get; set; }

        public Rewards(int Voucher_Id,string Title ,string Brand_Name,string Content,string Image,int Point,int Quantity,int Status)
        {
            voucher_id = Voucher_Id;
            title = Title;
            brand_name = Brand_Name;
            content = Content;
            image = Image;
            point = Point;
            quantity = Quantity;
            status = Status;
        }
    }
}
