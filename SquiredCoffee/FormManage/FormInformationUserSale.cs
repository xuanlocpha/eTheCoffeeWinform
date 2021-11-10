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
    public partial class FormInformationUserSale : Form
    {
        public FormInformationUserSale()
        {
            InitializeComponent();
            UC_SearchInformationUser uC_SearchInformationUser = new UC_SearchInformationUser();
            AddControlsToPanel(uC_SearchInformationUser);
        }
        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelMenu.Controls.Clear();
            panelMenu.Controls.Add(c);
        }



        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            UC_SearchInformationUser uC_SearchInformationUser = new UC_SearchInformationUser();
            AddControlsToPanel(uC_SearchInformationUser);
        }
    }
}
