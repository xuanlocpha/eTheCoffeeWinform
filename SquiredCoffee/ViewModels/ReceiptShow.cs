﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.ViewModels
{
    public class ReceiptShow
    {
        public int id { get; set; }
        public string product_name { get; set; }
        public decimal price { get; set; }
        public int quantity{get;set;}
        public string total { get; set; }
    }
}
