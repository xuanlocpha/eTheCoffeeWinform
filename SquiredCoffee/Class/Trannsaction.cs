using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.Class
{
    class Trannsaction
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string token { get; set; }
        public int order_id { get; set; }
        public string code { get; set; }
        public string type { get; set; }
        public string mode { get; set; }
        public string delivery_method { get; set; }
        public string content { get; set; }
        public string status { get; set; }

        public Trannsaction(int User_Id,string Token,int Order_Id, string Code, string Type, string Mode ,string Delivery_Method, string Content, string Status)
        {
            user_id = User_Id;
            token = Token;
            order_id = Order_Id;
            code = Code;
            type = Type;
            mode = Mode;
            delivery_method = Delivery_Method;
            content = Content;
            status = Status;
        }

        public Trannsaction(DataRow Row)
        {
            id = Convert.ToInt32(Row["id"]);
            user_id = Convert.ToInt32(Row["user_id"]);
            token = code = Row["token"].ToString();
            order_id = Convert.ToInt32(Row["order_id"]);
            code = Row["code"].ToString();
            type = Row["type"].ToString();
            mode = Row["mode"].ToString();
            delivery_method = Row["delivery_method"].ToString();
            status = Row["status"].ToString();
            content = Row["content"].ToString();
        }
    }
}
