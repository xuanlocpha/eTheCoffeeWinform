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
    public partial class ItemDetailOption : UserControl
    {

        public string ItemId { get; set; }

        public string ItemNameOption
        {
            get { return lblNameOption.Text; }
            set { lblNameOption.Text = value; }
        }

        public string ItemTitle
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }

        public string ItemPrice
        {
            get { return lblPrice.Text; }
            set { lblPrice.Text = value; }
        }
        public ItemDetailOption()
        {
            InitializeComponent();
        }
    }
}
