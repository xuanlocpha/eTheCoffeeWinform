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

namespace SquiredCoffee.FormManage
{
    public partial class FormVoucherDiscount : Form
    {
        FormSale _parent;
        public FormVoucherDiscount(FormSale parent)
        {
            InitializeComponent();
            _parent = parent;
            UC_ShowVoucher uC_ShowVoucher = new UC_ShowVoucher();
            AddControlsToPanel(uC_ShowVoucher);
        }

        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelMenu.Controls.Clear();
            panelMenu.Controls.Add(c);
        }

        private void btnVoucher_Click(object sender, EventArgs e)
        {
            UC_ShowVoucher uC_ShowVoucher = new UC_ShowVoucher();
            AddControlsToPanel(uC_ShowVoucher);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            UC_ShowVoucher uC_ShowVoucher = new UC_ShowVoucher();
            AddControlsToPanel(uC_ShowVoucher);
            btnVoucher.Checked = true;
            _parent.checkBtn();
            this.Close();
        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            UC_ShowDiscount uC_ShowDiscount = new UC_ShowDiscount();
            AddControlsToPanel(uC_ShowDiscount);
        }
    }
}
