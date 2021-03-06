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
    public partial class UC_ManageProductCategory : UserControl
    {
        public UC_ManageProductCategory()
        {
            InitializeComponent();
        }


        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelMenu.Controls.Clear();
            panelMenu.Controls.Add(c);
        }

        private void UC_ManageProductCategory_Load(object sender, EventArgs e)
        {
            UC_ManageProduct uC_ManageProduct = new UC_ManageProduct();
            AddControlsToPanel(uC_ManageProduct);
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            UC_ManageProduct uC_ManageProduct = new UC_ManageProduct();
            AddControlsToPanel(uC_ManageProduct);
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            UC_ManageCategory uC_ManageCategory = new UC_ManageCategory();
            AddControlsToPanel(uC_ManageCategory);
        }

        private void btnGroupOption_Click(object sender, EventArgs e)
        {
            UC_ManageOptionGroup uC_ManageOptionGroup = new UC_ManageOptionGroup();
            AddControlsToPanel(uC_ManageOptionGroup);
        }

        private void btnOption_Click(object sender, EventArgs e)
        {
            UC_ManageOption1 uC_ManageOption1 = new UC_ManageOption1();
            AddControlsToPanel(uC_ManageOption1);
        }

        private void btnProductOption_Click(object sender, EventArgs e)
        {
            UC_ManageProductOption uC_ManageProductOption = new UC_ManageProductOption();
            AddControlsToPanel(uC_ManageProductOption);
        }
    }
}
