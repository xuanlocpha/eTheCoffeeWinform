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
        public FormAddCategory(UC_ManageCategory parent)
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
                MessageBox.Show("Tên loại sản phẩm không được để ( Trống )");
                return;
            }
            if (txtTitleCategory.Text.Trim().Length < 1)
            {
                MessageBox.Show("Tên loại sản phẩm phải lớn hơn  ( 1 ký tự )");
                return;
            }
            if(cbType.Text == "")
            {
                MessageBox.Show("Ô Thể Loại đang  ( Trống )");
                return;
            }
            if (DbCategory.CheckTitleCategory(txtTitleCategory.Text) == true)
            {
                MessageBox.Show("Tên loại sản phẩm đã  ( Tồn tại )");
                return;
            }
            if (btnSave.Text == "Lưu")
            {
                Category std = new Category(txtTitleCategory.Text,cbType.Text,status);
                DbCategory.AddCategory(std);
                this.Close();
                _parent.Display();
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
