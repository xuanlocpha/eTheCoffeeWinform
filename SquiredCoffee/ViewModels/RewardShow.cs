using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.ViewModels
{
    class RewardShow
    {
        public int id { get; set; }
        public int voucher_id { get; set; }
        public string title { get; set; }
        public string brand_name { get; set; }
        public string content { get; set; }
        public string image { get; set; }
        public int point { get; set; }
        public int quantity { get; set; }
        public int status { get; set; }

        public RewardShow(int Voucher_Id,string Title,string Brand_Name, string Content, string Image, int Point,int Quantity, int Status)
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

        public RewardShow(DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            voucher_id = Convert.ToInt32(row["voucher_id"]); ;
            title = row["title"].ToString();
            brand_name = row["brand_name"].ToString(); ;
            content = row["content"].ToString();
            image = row["image"].ToString();
            point = Convert.ToInt32(row["point"]);
            quantity = Convert.ToInt32(row["quantity"]);
            status = Convert.ToInt32(row["status"]);
        }
    }
}
