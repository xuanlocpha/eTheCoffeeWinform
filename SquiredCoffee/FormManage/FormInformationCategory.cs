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
    public partial class FormInformationCategory : Form
    {
        public static UC_ManageCategory _parent;
        public int id_category;
        public int status;
        public FormInformationCategory(UC_ManageCategory parent)
        {
            _parent = parent;
            InitializeComponent();
            
        }

        public void Display()
        {
            List<Category> categoryList = DbCategory.LoadCategoryList(id_category.ToString());
            foreach (Category item in categoryList)
            {
                txtTitleCategory.Text = item.title;
                cbType.Text = item.type;
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
            status = 2;
        }

        private void FormInformationCategory_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
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
            if (cbType.Text == "")
            {
                MessageBox.Show("Ô Thể Loại đang  ( Trống )");
                return;
            }
            if (MessageBox.Show("Bạn có muốn chỉnh sửa loại sản phẩm  này không !", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (btnEdit.Text == "Sửa")
                {
                    Category std = new Category(txtTitleCategory.Text, cbType.Text, status);
                    DbCategory.UpdateCategory(std, id_category.ToString());
                    this.Close();
                    _parent.Display();
                }
            }
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn Khóa loại sản phẩm  này không !", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (btnLock.Text == "Khóa")
                {
                    Category std = new Category(txtTitleCategory.Text, cbType.Text, status);
                    DbCategory.LockCategory(id_category.ToString());
                    this.Close();
                    _parent.Display();
                }
            }
        }
    }
}
