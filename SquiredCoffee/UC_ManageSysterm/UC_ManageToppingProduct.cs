using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SquiredCoffee.UC_ManageSysterm
{
    public partial class UC_ManageToppingProduct : UserControl
    {
        public UC_ManageToppingProduct()
        {
            InitializeComponent();
            UC_ManageTopping1 uC_ManageTopping1 = new UC_ManageTopping1();
            AddControlsToPanel(uC_ManageTopping1);
        }
        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelMenu.Controls.Clear();
            panelMenu.Controls.Add(c);
        }

        private void btnTopping_Click(object sender, EventArgs e)
        {
            UC_ManageTopping1 uC_ManageTopping1 = new UC_ManageTopping1();
            AddControlsToPanel(uC_ManageTopping1);
        }

        private void btnToppingProduct_Click(object sender, EventArgs e)
        {
            UC_ManageProductTopping uC_ManageProductTopping= new UC_ManageProductTopping();
            AddControlsToPanel(uC_ManageProductTopping);
        }
    }
}
