using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SquiredCoffee.CustomControls
{
    public partial class ItemDetailTopping : UserControl
    {

        public string ItemId { get; set; }

        public string ItemNameTopping
        {
            get { return lblNameTopping.Text; }
            set { lblNameTopping.Text = value; }
        }

        public string ItemPriceTopping
        {
            get { return lblPriceTopping.Text; }
            set { lblPriceTopping.Text = value; }
        }
        public ItemDetailTopping()
        {
            InitializeComponent();
        }

      
    }
}
