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
    public partial class CartItems : UserControl
    {
        public string ItemId { get; set; }

       

     

        public CartItems()
        {
            InitializeComponent();
        }

        private void CartItems_Load(object sender, EventArgs e)
        {

        }
        private void s(object sender, PaintEventArgs e)
        {

        }

        private void CartItems_Click(object sender, EventArgs e)
        {
            if(gunaGradientButton_Valid.Visible == false)
            {
                gunaGradientButton_Valid.Visible = true;
                gunaLinePanel_Valid.Visible = true;
            }
            else
            {
                gunaGradientButton_Valid.Visible = false;
                gunaLinePanel_Valid.Visible = false;
            }
        }

        private void gunaLinePanel_Valid_Click(object sender, EventArgs e)
        {
            if (gunaGradientButton_Valid.Visible == false)
            {
                gunaGradientButton_Valid.Visible = true;
                gunaLinePanel_Valid.Visible = true;
            }
            else
            {
                gunaGradientButton_Valid.Visible = false;
                gunaLinePanel_Valid.Visible = false;
            }
        }

        private void gunaLinePanel_Valid_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
