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
    public partial class UC_ManageWareHouse : UserControl
    {
        public UC_ManageWareHouse()
        {
            InitializeComponent();
        }


        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelMenu.Controls.Clear();
            panelMenu.Controls.Add(c);
        }

        private void UC_ManageWareHouse_Load(object sender, EventArgs e)
        {
            UC_ManageSupplier uC_ManageSupplier = new UC_ManageSupplier();
            AddControlsToPanel(uC_ManageSupplier);
        }
        private void btnManageStockProduct_Click(object sender, EventArgs e)
        {
            UC_ManageStockProduct uC_ManageStockProduct = new UC_ManageStockProduct();
            AddControlsToPanel(uC_ManageStockProduct);
        }

        private void btnManageImportInvoice_Click(object sender, EventArgs e)
        {
            UC_ManageImportInvoice uC_ManageImportInvoice = new UC_ManageImportInvoice();
            AddControlsToPanel(uC_ManageImportInvoice);
        }
    }
}
