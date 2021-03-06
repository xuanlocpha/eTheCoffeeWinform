using SquiredCoffee.DB;
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
    public partial class CartItem : UserControl
    {
        public string ItemId { get; set; }

        public string ItemName
        {
            get { return lblItemName.Text; }
            set { lblItemName.Text = value; }
        }

        public string ItemPrice
        {
            get { return lblPrice.Text; }
            set { lblPrice.Text = value; }
        }

        public string ItemQuantity
        {
            get { return lblQuantity.Text; }
            set { lblQuantity.Text = value; }
        }
        public string ItemDiscount
        {
            get { return lblDiscount.Text; }
            set { lblDiscount.Text = value; }
        }

        FormSale _parent;

        public CartItem(FormSale parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void btnQuantity_Click(object sender, EventArgs e)
        {
            DbOrderItem.DeleteOrderItem(ItemId.ToString());
            _parent.clearOrder1();
            _parent.LoadOrderItem();
        }
    }
}
