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
    public partial class btnProductList : UserControl
    {
        public string ItemId { get; set; }

        public string ItemName
        {
            get { return lblNameProduct.Text; }
            set { lblNameProduct.Text = value; }
        }

        public string ItemPrice
        {
            get { return lblPrice.Text; }
            set { lblPrice.Text = value; }
        }

        public btnProductList()
        {
            InitializeComponent();
        }

        private void btnProductList_Click(object sender, EventArgs e)
        {
            if (guna2GradientButton1.Visible == false)
            {
                guna2GradientButton1.Visible = true;
                gunaLinePanel1.Visible = true;
            }
            else
            {
                guna2GradientButton1.Visible = false;
                gunaLinePanel1.Visible = false;
            }
        }

        private void gunaLinePanel1_Click(object sender, EventArgs e)
        {
            if (guna2GradientButton1.Visible == false)
            {
                guna2GradientButton1.Visible = true;
                gunaLinePanel1.Visible = true;
            }
            else
            {
                guna2GradientButton1.Visible = false;
                gunaLinePanel1.Visible = false;
            }
        }
    }
}
