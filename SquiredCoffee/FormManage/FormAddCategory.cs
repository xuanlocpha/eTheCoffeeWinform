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
    public partial class FormAddCategory : Form
    {
        public int status = 1;
        public static UC_ManageCategory _parent;
        FormSuccess Form1;
        FormError Form2;
        public FormAddCategory(UC_ManageCategory parent)
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

        public void clear()
        {
            txtTitleCategory.Text =  string.Empty;
            cbType.SelectedIndex = -1;
            rdStatus1.Checked = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTitleCategory.Text.Trim() == "")
            {
                Form1.title = "Tên Loại Sản Phẩm Không Được (Trống) ";
                Form1.ShowDialog();
                return;
            }
            if (txtTitleCategory.Text.Trim().Length < 1)
            {
                Form2.title = "Tên Loại Sản Phẩm  (> 1 Ký Tự) ";
                Form2.ShowDialog();
                return;
            }
            if(cbType.Text == "")
            {
                Form2.title = "Thể Loại Không Được (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (DbCategory.CheckTitleCategory(txtTitleCategory.Text) == true)
            {
                Form2.title = "Tên Loại Sản Phẩm Đã Tồn Tại";
                Form2.ShowDialog();
                return;
            }
            if (btnSave.Text == "Lưu")
            {
                Category std = new Category(txtTitleCategory.Text,cbType.Text,status);
                if(DbCategory.CheckCreateCategory(std) == true)
                {
                    Form1.title = "Tạo Thành Công";
                    Form1.ShowDialog();
                    this.Close();
                    _parent.Display();
                }
                else
                {
                    Form2.title = "Tạo Không Thành Công";
                    Form2.ShowDialog();
                    this.Close();
                    _parent.Display();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtTitleCategory_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
