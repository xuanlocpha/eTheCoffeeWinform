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
        public int order_id { get; set; }
        public string code { get; set; }
        public string type { get; set; }
        public string mode { get; set; }
        public string content { get; set; }
        public string status { get; set; }

        public Trannsaction(int Order_Id, string Code, string Type, string Mode, string Content, string Status)
        {
            order_id = Order_Id;
            code = Code;
            type = Type;
            mode = Mode;
            content = Content;
            status = Status;
        }

        public Trannsaction(DataRow Row)
        {
            id = Convert.ToInt32(Row["id"]);
            order_id = Convert.ToInt32(Row["order_id"]);
            code = Row["code"].ToString();
            type = Row["type"].ToString();
            mode = Row["mode"].ToString();
            status = Row["status"].ToString();
        }
    }
}
