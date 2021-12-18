using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.Class
{
    class Voucher
    {
        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string type { get; set; }
        public string coupon_code { get; set; }
        public string image { get; set; }
        public string qr_code { get; set; }
        public string start_date { get; set; }
        public string expiry_date { get; set; }
        public string discount_unit { get; set; }
        public int discount { get; set; }
        public string apply_for{ get; set; }
        public int quantity_rule { get; set; }
        public decimal price_rule { get; set; }
        public int status { get; set; }


        public Voucher(string Title,string Content,string Type, string Coupon_Code,string Image,string Qr_Code,string Start_Date,string Expiry_Date,string Discount_Unit,int Discount,string Apply_For, int Quantity_Rule, int Price_Rule, int Status)
        {
            title = Title;
            content = Content;
            type = Type;
            coupon_code = Coupon_Code;
            image = Image;
            qr_code = Qr_Code;
            start_date = Start_Date;
            expiry_date = Expiry_Date;
            discount_unit = Discount_Unit;
            discount = Discount;
            apply_for = Apply_For;
            quantity_rule = Quantity_Rule;
            price_rule = Price_Rule;
            status = Status;
        }

        public Voucher(DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            title = row["title"].ToString();
            content = row["content"].ToString();
            type = row["type"].ToString();
            coupon_code = row["coupon_code"].ToString();
            image = row["image"].ToString();
            qr_code = row["qr_code"].ToString();
            start_date = row["start_date"].ToString();
            expiry_date = row["expiry_date"].ToString();
            discount_unit = row["discount_unit"].ToString();
            discount = Convert.ToInt32(row["discount"]);
            apply_for = row["apply_for"].ToString();
            quantity_rule = Convert.ToInt32(row["quantity_rule"]);
            price_rule = Convert.ToDecimal(row["price_rule"]);
            status = Convert.ToInt32(row["status"]); ;
        }
    }
}
