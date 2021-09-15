using SquiredCoffee.Class;
using SquiredCoffee.DB;
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
    public partial class FormInformationRole : Form
    {
        public int id_role;
        public int status;
        public readonly UC_ManageRole _parent;
        public FormInformationRole(UC_ManageRole parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void Display()
        {
            List<Role> roleList = DbRole.LoadRoleList(id_role.ToString());
            foreach (Role item in roleList)
            {
                txtTitleRole.Text = item.title;
                if (item.status == 1)
                {
                    rdStatus1.Checked = true;
                }
                else if (item.status == 0)
                {
                    rdStatus2.Checked = true;
                }
                status = item.status;
            }
        }

        private void rdStatus1_CheckedChanged(object sender, EventArgs e)
        {
            status = 1;
        }

        private void rdStatus2_CheckedChanged(object sender, EventArgs e)
        {
            status = 0;
        }

        private void FormInformationRole_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtTitleRole.Text.Trim() == "")
            {
                MessageBox.Show("Tên của quyền không được ( Trống )");
                return;
            }
            if (txtTitleRole.Text.Trim().Length < 1)
            {
                MessageBox.Show("Tên của quyền phải lớn hơn  ( 1 ký tự )");
                return;
            }
            if (MessageBox.Show("Bạn có muốn chỉnh sửa thông tin của ( Quyền ) này không !", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (btnEdit.Text == "Sửa")
                {
                    Role std = new Role(txtTitleRole.Text, status);
                    DbRole.UpdateRole(std,id_role.ToString());
                    this.Close();
                    _parent.Display();
                }
            }
        }
    }
}
