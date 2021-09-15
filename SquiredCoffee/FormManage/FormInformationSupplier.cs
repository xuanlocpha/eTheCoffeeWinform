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
    public partial class FormInformationSupplier : Form
    {
        public int id_supplier;
        public int status;
        public readonly UC_ManageSupplier _parent;
        public FormInformationSupplier(UC_ManageSupplier parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void rdStatus1_CheckedChanged(object sender, EventArgs e)
        {
            status = 1;
        }

        private void rdStatus2_CheckedChanged(object sender, EventArgs e)
        {
            status = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void Display()
        {
            List<Supplier> supplierList = DbSupplier.LoadSupplierList(id_supplier.ToString());
            foreach (Supplier item in supplierList)
            {
                txtSupplierName.Text = item.name_supplier;
                txtAddress.Text = item.address;
                txtEmail.Text = item.email;
                txtPhone.Text = item.phone;
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

        private void FormInformationSupplier_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnEdit_Click(object sender, EventArgs e)
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
            if (MessageBox.Show("Bạn có muốn chỉnh sửa thông tin của ( Nhà cung cấp ) này không !", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (btnEdit.Text == "Sửa")
                {
                    Supplier std = new Supplier(txtSupplierName.Text, txtAddress.Text, txtPhone.Text, txtEmail.Text, status);
                    DbSupplier.UpdateSupplier(std, id_supplier.ToString());
                    this.Close();
                    _parent.clear();
                    _parent.clear1();
                    _parent.Display();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa thông tin của ( Nhà cung cấp  ) này không . Vì nó có thể ảnh hưởng tới dữ liệu của bạn!", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (btnDelete.Text == "Xóa")
                {
                    DbSupplier.DeleteSupplier(id_supplier.ToString());
                    this.Close();
                    _parent.clear();
                    _parent.clear1();
                    _parent.Display();
                }
            }
        }
    }
}
