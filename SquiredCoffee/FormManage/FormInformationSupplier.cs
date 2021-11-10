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
        FormSuccess Form1;
        FormError Form2;
        public int id_supplier;
        public int status;
        public readonly UC_ManageSupplier _parent;
        public FormInformationSupplier(UC_ManageSupplier parent)
        {
            InitializeComponent();
            _parent = parent;
            Form1 = new FormSuccess();
            Form2 = new FormError();
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
            if (btnEdit.Text == "Sửa")
            {
                Supplier std = new Supplier(txtSupplierName.Text, txtAddress.Text, txtPhone.Text, txtEmail.Text, status);
                if ((DbSupplier.CheckUpdateSupplier(std,id_supplier.ToString())) == true)
                {
                    Form1.title = "Chỉnh sửa Thành Công";
                    Form1.ShowDialog();
                    this.Close();
                    _parent.clear();
                    _parent.clear1();
                    _parent.Display();
                }
                else
                {
                    Form2.title = "Chỉnh Sửa Không Thành Công";
                    Form2.ShowDialog();
                    this.Close();
                    _parent.clear();
                    _parent.clear1();
                    _parent.Display();
                }
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
                if (btnDelete.Text == "Xóa")
                {
                    if ((DbSupplier.CheckDeleteSupplier(id_supplier.ToString())) == false)
                    {
                        Form1.title = "Xóa Thành Công";
                        Form1.ShowDialog();
                        this.Close();
                        _parent.clear();
                        _parent.clear1();
                        _parent.Display();
                    }
                    else
                    {
                        Form2.title = "Xóa Không Thành Công";
                        Form2.ShowDialog();
                        this.Close();
                        _parent.clear();
                        _parent.clear1();
                        _parent.Display();
                    }
                }
        }

        private void rdStatus1_CheckedChanged_1(object sender, EventArgs e)
        {
            status = 1;
        }

        private void rdStatus2_CheckedChanged_1(object sender, EventArgs e)
        {
            status = 0;
        }
    }
}
