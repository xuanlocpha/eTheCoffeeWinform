using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.Class
{
    class Option
    {
        public string title { get; set; }
        public int status { get; set; }

        public Option(string Title,int Status)
        {
            title = Title;
            status = Status;
        }
    }
}
