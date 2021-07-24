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
    public partial class FormCategory : Form
    {
        private readonly UC_Category _parent;
        public string id, title;

        public FormCategory(UC_Category parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void UpdateCategory()
        {
            lblTitle.Text = "Sửa Loại Sản Phẩm";
            btnSave.Text = "Sửa";
            txtCategoryName.Text = title;
        }

        public void Clear()
        {
            txtCategoryName.Text = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCategoryName.Text.Trim().Length < 3)
            {
                MessageBox.Show("Tên Loại Sản Phẩm phải ( > 3) ký tự");
                return;
            }
            if (txtCategoryName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Tên Loại Sản Phẩm đang trống");
                return;
            }
            if (btnSave.Text == "Lưu")
            {
                Category std = new Category(txtCategoryName.Text.Trim());
                DbCategory.AddCategory(std);
                Clear();
            }

            if (btnSave.Text == "Sửa")
            {
                Category std = new Category(txtCategoryName.Text.Trim());
                DbCategory.UpdateCategory(std,id);
                Clear();
            }
            _parent.Display();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
