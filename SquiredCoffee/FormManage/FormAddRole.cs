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
    public partial class FormAddRole : Form
    {
        public static UC_ManageRole _parent;
        public FormAddRole(UC_ManageRole parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public int status =1;
        private void rdStatus1_CheckedChanged(object sender, EventArgs e)
        {
            status = 1;
        }

        private void rdStatus2_CheckedChanged(object sender, EventArgs e)
        {
            status = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
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
            if (DbRole.CheckRole(txtTitleRole.Text)==true)
            {
                MessageBox.Show("Tên của quyền ( Đã Tồn Tại )");
                return;
            }
            if (btnSave.Text == "Lưu")
            {
                Role std = new Role(txtTitleRole.Text, status);
                DbRole.AddRole(std);
                this.Close();
                _parent.Display();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
