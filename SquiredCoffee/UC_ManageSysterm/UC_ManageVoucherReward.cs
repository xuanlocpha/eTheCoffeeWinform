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
    public partial class UC_ManageVoucherReward : UserControl
    {
        public UC_ManageVoucherReward()
        {
            InitializeComponent();
            UC_ManageVoucher uC_ManageVoucher = new UC_ManageVoucher();
            AddControlsToPanel(uC_ManageVoucher);
        }

        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelMenu.Controls.Clear();
            panelMenu.Controls.Add(c);
        }

        private void btnVoucher_Click(object sender, EventArgs e)
        {
            UC_ManageVoucher uC_ManageVoucher = new UC_ManageVoucher();
            AddControlsToPanel(uC_ManageVoucher);
        }

        private void btnReward_Click(object sender, EventArgs e)
        {
            UC_ManageReward uC_ManageReward = new UC_ManageReward();
            AddControlsToPanel(uC_ManageReward);
        }

        private void btnDiscountProduct_Click(object sender, EventArgs e)
        {
            UC_ManageDiscount uC_ManageDiscount = new UC_ManageDiscount();
            AddControlsToPanel(uC_ManageDiscount);
        }
    }
}
