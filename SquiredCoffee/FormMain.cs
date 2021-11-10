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

        private readonly FormLoginSysterm _parent;
        public FormMain(FormLoginSysterm parent)
        {
            InitializeComponent();
            UC_Dashbroad uC_Dashbroad = new UC_Dashbroad();
            AddControlsToPanel(uC_Dashbroad);
            _parent = parent;
        }

        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelMenu.Controls.Clear();
            panelMenu.Controls.Add(c);
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            
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
            UC_ManageStaffRole uC_ManageStaffRole = new UC_ManageStaffRole();
            AddControlsToPanel(uC_ManageStaffRole);
        }

        private void btnVoucher_Click(object sender, EventArgs e)
        {
           
            UC_ManageVoucherReward uC_ManageVoucherReward = new UC_ManageVoucherReward();
            AddControlsToPanel(uC_ManageVoucherReward);
        }

        private void btnWareHouse_Click(object sender, EventArgs e)
        {
          
            UC_ManageWareHouse uC_ManageWareHouse = new UC_ManageWareHouse();
            AddControlsToPanel(uC_ManageWareHouse);
            uC_ManageWareHouse.staff_id = id_staff;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            lblNameStaff.Text = fullName;
            lblRoleName.Text = roleName;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            UC_Dashbroad uC_Dashbroad = new UC_Dashbroad();
            AddControlsToPanel(uC_Dashbroad);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            UC_ManageProductCategory uC_ManageProductCategory = new UC_ManageProductCategory();
            AddControlsToPanel(uC_ManageProductCategory);
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            UC_ManageUser uC_ManageUser = new UC_ManageUser();
            AddControlsToPanel(uC_ManageUser);
        }

        private void btnTopping_Click_1(object sender, EventArgs e)
        {
            UC_ManageToppingProduct uC_ManageToppingProduct = new UC_ManageToppingProduct();
            AddControlsToPanel(uC_ManageToppingProduct);
        }
    }
}
