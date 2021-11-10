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
    public partial class UC_ManageStaffRole : UserControl
    {
        public UC_ManageStaffRole()
        {
            InitializeComponent();
        }

        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelMenu.Controls.Clear();
            panelMenu.Controls.Add(c);
        }

        private void UC_ManageStaffRole_Load(object sender, EventArgs e)
        {
            UC_ManageStaff uC_ManageStaff = new UC_ManageStaff();
            AddControlsToPanel(uC_ManageStaff);
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            UC_ManageStaff uC_ManageStaff = new UC_ManageStaff();
            AddControlsToPanel(uC_ManageStaff);
        }

        private void btnRole_Click(object sender, EventArgs e)
        {
            UC_ManageRole uC_ManageRole = new UC_ManageRole();
            AddControlsToPanel(uC_ManageRole);
        }
    }
}
