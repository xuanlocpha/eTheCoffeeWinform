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
    public partial class FormRole : Form
    {

        private readonly UC_Role _parent;
        public string id, title;

        public FormRole(UC_Role parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void UpdateRole()
        {
            lblTitle.Text = "Sửa Tên Quyền Hệ Thống";
            btnSave.Text = "Sửa";
            txtRoleName.Text = title;
        }

        public void Clear()
        {
            txtRoleName.Text = string.Empty;
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtRoleName.Text.Trim().Length < 3)
            {
                MessageBox.Show("Tên quyền phải ( > 3) ký tự");
                return;
            }
            if (txtRoleName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Tên Quyền đang trống");
                return;
            }
            //if (btnSave.Text == "Lưu")
            //{
            //    Role std = new Role(txtRoleName.Text.Trim());
            //    DbRole.AddRole(std);
            //    Clear();
            //}

            //if (btnSave.Text == "Sửa")
            //{
            //    Role std = new Role(txtRoleName.Text.Trim());
            //    DbRole.UpdateRole(std, id);
            //    Clear();
            //}
            _parent.Display();
        }
    }
}
