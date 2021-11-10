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
        FormSuccess Form1;
        FormError Form2;
        public static UC_ManageSupplier _parent;
        public int status = 1;
        public FormAddSupplier(UC_ManageSupplier parent)
        {
            InitializeComponent();
            _parent = parent;
            Form1 = new FormSuccess();
            Form2 = new FormError();
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
                Form2.title = "Tên Nhà Cung Cấp Không Được (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtSupplierName.Text.Trim().Length < 1)
            {
                Form2.title = "Tên Nhà Cung Cấp (> 1 Ký Tự) ";
                Form2.ShowDialog();
                return;
            }
            if (txtAddress.Text.Trim() == "")
            {
                Form2.title = "Địa Chỉ Nhà Cung Cấp (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtAddress.Text.Trim().Length < 1)
            {
                Form2.title = "Địa Chỉ Nhà Cung Cấp (>1 Ký Tự) ";
                Form2.ShowDialog();
                return;
            }
            if (txtPhone.Text.Trim() == "")
            {
                Form2.title = "Số Điện Thoại Nhà Cung Cấp Không Để (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtPhone.Text.Trim().Length < 1)
            {
                Form2.title = "Số Điện Thoại NCung Cấp (>1 Ký Tự) ";
                Form2.ShowDialog();
                return;
            }
            if (txtEmail.Text.Trim() == "")
            {
                Form2.title = "Email Nhà Cung Cấp Không Để (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtEmail.Text.Trim().Length < 1)
            {
                Form2.title = "Email Nhà Cung Cấp (>1 Ký Tự) ";
                Form2.ShowDialog();
                return;
            }
            if (!this.txtEmail.Text.Contains('@') || !this.txtEmail.Text.Contains('.'))
            {
                Form2.title = "Không Hợp Lệ ";
                Form2.ShowDialog();
                return;
            }
            if (DbSupplier.CheckAdd(txtSupplierName.Text)== true)
            {
                Form2.title = "Nhà Cung Cấp Đã Tồn Tại ";
                Form2.ShowDialog();
                return;
            }
            if (btnSave.Text == "Lưu")
            {
                Supplier std = new Supplier(txtSupplierName.Text, txtAddress.Text, txtPhone.Text, txtEmail.Text, status);
                if ((DbSupplier.CheckCreateSupplier(std)) == true)
                {
                    Form1.title = "Tạo Thành Công";
                    Form1.ShowDialog();
                    this.Close();
                    clear();
                    _parent.clear();
                    _parent.clear1();
                    _parent.Display();
                }
                else
                {
                    Form2.title = "Tạo Không Thành Công";
                    Form2.ShowDialog();
                    this.Close();
                    clear();
                    _parent.clear();
                    _parent.clear1();
                    _parent.Display();
                }
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
