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
        FormSuccess Form1;
        FormError Form2;
        public FormInformationCategory(UC_ManageCategory parent)
        {
            _parent = parent;
            InitializeComponent();
            Form1 = new FormSuccess();
            Form2 = new FormError();
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
            if (cbType.Text == "")
            {
                Form2.title = "Thể Loại Không Được (Trống) ";
                Form2.ShowDialog();
                return;
            }
           
                if (btnEdit.Text == "Sửa")
                {
                    Category std = new Category(txtTitleCategory.Text, cbType.Text, status);
                    if(DbCategory.CheckUpdateCategory(std,id_category.ToString())== true)
                    {
                        Form1.title = "Sửa Thành Công ";
                        Form1.ShowDialog();
                        this.Close();
                        _parent.Display();
                    }
                    else
                    {
                        Form2.title = "Sửa Không Thành Công ";
                        Form2.ShowDialog();
                        this.Close();
                        _parent.Display();
                    }
                }
            
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
          
                if (btnLock.Text == "Khóa")
                {
                    status = 0;
                    Category std = new Category(txtTitleCategory.Text, cbType.Text, status);
                    if (DbCategory.CheckLockCategory(std, id_category.ToString()) == true)
                    {
                        Form1.title = "Sửa Thành Công ";
                        Form1.ShowDialog();
                        this.Close();
                        _parent.Display();
                    }
                    else
                    {
                        Form2.title = "Sửa Không Thành Công ";
                        Form2.ShowDialog();
                        this.Close();
                        _parent.Display();
                    }
                }
         
        }
    }
}
