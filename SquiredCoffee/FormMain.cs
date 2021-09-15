using SquiredCoffee.UC_Controls;
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

namespace SquiredCoffee
{
    public partial class FormMain : Form
    {
        public string fullName;
        public string roleName;
        public int id_staff;

        private readonly FormLogin _parent;
        public FormMain(/*FormLogin parent*/)
        {
            InitializeComponent();
            UC_Home uC_Home = new UC_Home();
            AddControlsToPanel(uC_Home);
            //_parent = parent;
        }

        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelMenu.Controls.Clear();
            panelMenu.Controls.Add(c);
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            sidePanel.Height = btnWareHouse.Height;
            sidePanel.Top = btnWareHouse.Top;
            UC_ManageSysterms uC_Manage = new UC_ManageSysterms();
            AddControlsToPanel(uC_Manage);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //_parent.clear1();
            //FormLogin f = new FormLogin();
            //f.ShowDialog();
            this.Close();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            sidePanel.Height = btnStaff.Height;
            sidePanel.Top = btnStaff.Top;
            UC_ManageStaff uC_ManageStaff = new UC_ManageStaff();
            AddControlsToPanel(uC_ManageStaff);
        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {
            sidePanel.Height = btnHome.Height;
            sidePanel.Top = btnHome.Top;
            UC_Home uC_Home = new UC_Home();
            AddControlsToPanel(uC_Home);
        }

        private void btnManageCategory_Click(object sender, EventArgs e)
        {
            sidePanel.Height = btnManageCategory.Height;
            sidePanel.Top = btnManageCategory.Top;
            UC_ManageCategory uC_ManageCategory = new UC_ManageCategory();
            AddControlsToPanel(uC_ManageCategory);
        }

        private void btnManageProduct_Click(object sender, EventArgs e)
        {
            sidePanel.Height = btnManageProduct.Height;
            sidePanel.Top = btnManageProduct.Top;
            UC_ManageProduct uC_MnanageProduct = new UC_ManageProduct();
            AddControlsToPanel(uC_MnanageProduct);
        }

        private void btnRole_Click(object sender, EventArgs e)
        {
            sidePanel.Height = btnRole.Height;
            sidePanel.Top = btnRole.Top;
            UC_ManageRole uC_ManageRole = new UC_ManageRole();
            AddControlsToPanel(uC_ManageRole);
        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            sidePanel.Height = btnDiscount.Height;
            sidePanel.Top = btnDiscount.Top;
            UC_ManageDiscount uC_ManageDiscount = new UC_ManageDiscount();
            AddControlsToPanel(uC_ManageDiscount);
        }

        private void btnOptionGroup_Click(object sender, EventArgs e)
        {
            sidePanel.Height =btnOptionGroup.Height;
            sidePanel.Top = btnOptionGroup.Top;
            UC_ManageOption uC_ManageOption = new UC_ManageOption();
            AddControlsToPanel(uC_ManageOption);
        }

        private void btnTopping_Click(object sender, EventArgs e)
        {
            sidePanel.Height = btnTopping.Height;
            sidePanel.Top = btnTopping.Top;
            UC_ManageTopping uC_ManageTopping = new UC_ManageTopping();
            AddControlsToPanel(uC_ManageTopping);
        }

        private void btnVoucher_Click(object sender, EventArgs e)
        {
            sidePanel.Height = btnVoucher.Height;
            sidePanel.Top = btnVoucher.Top;
            UC_ManageVoucher uC_ManageVoucher = new UC_ManageVoucher();
            AddControlsToPanel(uC_ManageVoucher);
        }

        private void btnWareHouse_Click(object sender, EventArgs e)
        {
            sidePanel.Height = btnWareHouse.Height;
            sidePanel.Top = btnWareHouse.Top;
            UC_ManageWareHouse uC_ManageWareHouse = new UC_ManageWareHouse();
            AddControlsToPanel(uC_ManageWareHouse);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            lblNameStaff.Text = fullName;
            lblRoleName.Text = roleName;
        }
    }
}
