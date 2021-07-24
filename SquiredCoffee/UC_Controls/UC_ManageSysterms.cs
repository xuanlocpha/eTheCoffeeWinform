using SquiredCoffee.UC_ManageSysterm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SquiredCoffee.UC_Controls
{
    public partial class UC_ManageSysterms : UserControl
    {
        public UC_ManageSysterms()
        {
            InitializeComponent();
            UC_Category uC_Category = new UC_Category();
            AddControlsToPanel(uC_Category);
        }

        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelManage.Controls.Clear();
            panelManage.Controls.Add(c);
        }

        private void lblCategory_Click(object sender, EventArgs e)
        {
            UC_Category uC_Category = new UC_Category();
            AddControlsToPanel(uC_Category);
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblRole_Click(object sender, EventArgs e)
        {
            UC_Role uC_Role = new UC_Role();
            AddControlsToPanel(uC_Role);
        }

        private void lblProduct_Click(object sender, EventArgs e)
        {
            UC_Product uC_Product = new UC_Product();
            AddControlsToPanel(uC_Product);
        }

        private void lblStaff_Click(object sender, EventArgs e)
        {
            UC_Staff uC_Staff = new UC_Staff();
            AddControlsToPanel(uC_Staff);
        }

        private void lblUser_Click(object sender, EventArgs e)
        {
            UC_User uC_User = new UC_User();
            AddControlsToPanel(uC_User);
        }

        private void lblOption_Click(object sender, EventArgs e)
        {
            UC_Option uC_Option = new UC_Option();
            AddControlsToPanel(uC_Option);
        }

        private void lblOptionProduct_Click(object sender, EventArgs e)
        {
            UC_ProductOption uC_ProductOption = new UC_ProductOption();
            AddControlsToPanel(uC_ProductOption);
        }

        private void lblTable_Click(object sender, EventArgs e)
        {
            UC_Table uC_Table = new UC_Table();
            AddControlsToPanel(uC_Table);
        }

        private void lblReward_Click(object sender, EventArgs e)
        {
            UC_Reward uC_Reward= new UC_Reward();
            AddControlsToPanel(uC_Reward);
        }

        private void lblVoucher_Click(object sender, EventArgs e)
        {
            UC_Voucher uC_Voucher = new UC_Voucher();
            AddControlsToPanel(uC_Voucher);
        }
    }
}
