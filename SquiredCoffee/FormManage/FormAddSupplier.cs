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
    public partial class FormAddSupplier : Form
    {
        public static UC_ManageSupplier _parent;
        public int status = 1;
        public FormAddSupplier(UC_ManageSupplier parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdStatus1_CheckedChanged(object sender, EventArgs e)
        {
            status = 1;
        }

        private void rdStatus2_CheckedChanged(object sender, EventArgs e)
        {
            status = 0;
        }

        public void clear()
        {
            txtAddress.Text = txtEmail.Text = txtPhone.Text = txtSupplierName.Text = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtSupplierName.Text.Trim() == "")
            {
                MessageBox.Show("Tên nhà cung cấp không được để ( Trống )");
                return;
            }
            if (txtSupplierName.Text.Trim().Length < 1)
            {
                MessageBox.Show("Tên nhà cung cấp  lớn hơn (  1 ký tự )");
                return;
            }
            if (txtAddress.Text.Trim() == "")
            {
                MessageBox.Show("Địa chỉ nhà cung cấp không được để ( Trống )");
                return;
            }
            if (txtAddress.Text.Trim().Length < 1)
            {
                MessageBox.Show("Địa chỉ nhà cung cấp  lớn hơn (  1 ký tự )");
                return;
            }
            if (txtPhone.Text.Trim() == "")
            {
                MessageBox.Show("Số điện thoại nhà cung cấp không được để ( Trống )");
                return;
            }
            if (txtPhone.Text.Trim().Length < 1)
            {
                MessageBox.Show("Số điện thoại nhà cung cấp  lớn hơn (  1 ký tự )");
                return;
            }
            if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Email nhà cung cấp không được để ( Trống )");
                return;
            }
            if (txtEmail.Text.Trim().Length < 1)
            {
                MessageBox.Show("Email nhà cung cấp  lớn hơn (  1 ký tự )");
                return;
            }
            if (!this.txtEmail.Text.Contains('@') || !this.txtEmail.Text.Contains('.'))
            {
                MessageBox.Show("Email nhập vào không hợp lệ");
                return;
            }
            if (DbSupplier.CheckAdd(txtSupplierName.Text)== true)
            {
                MessageBox.Show("Nhà cung cấp đã tồn tại !!!");
                return;
            }
            if (btnSave.Text == "Lưu")
            {
                Supplier std = new Supplier(txtSupplierName.Text,txtAddress.Text,txtPhone.Text,txtEmail.Text,status);
                DbSupplier.AddSupplier(std);
                this.Close();
                clear();
                _parent.clear();
                _parent.clear1();
                _parent.Display();
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
