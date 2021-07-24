using SquiredCoffee.UC_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SquiredCoffee
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            UC_Home uC_Home = new UC_Home();
            AddControlsToPanel(uC_Home);
        }

        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelMenu.Controls.Clear();
            panelMenu.Controls.Add(c);
        }


        private void btnHome_Click(object sender, EventArgs e)
        {
            sidePanel.Height = btnHome.Height;
            sidePanel.Top = btnHome.Top;
            UC_Home uC_Home = new UC_Home();
            AddControlsToPanel(uC_Home);
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            sidePanel.Height = btnManage.Height;
            sidePanel.Top = btnManage.Top;
            UC_ManageSysterms uC_Manage = new UC_ManageSysterms();
            AddControlsToPanel(uC_Manage);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
           
        }
    }
}
