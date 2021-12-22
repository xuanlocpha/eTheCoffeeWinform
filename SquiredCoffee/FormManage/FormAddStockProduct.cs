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
    public partial class FormAddStockProduct : Form
    {
        FormSuccess Form1;
        FormError Form2;
        public int status = 1;
        public static UC_ManageStockProduct _parent;
        public FormAddStockProduct(UC_ManageStockProduct parent)
        {
            InitializeComponent();
            _parent = parent;
            Form1 = new FormSuccess();
            Form2 = new FormError();
        }

        private void FormAddStockProduct_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            clear();
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
            txtTitle.Text = txtUnit.Text = string.Empty;
            rdStatus1.Checked = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text.Trim() == "")
            {
                Form2.title = "Tên Sản Phẩm Không Được (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtTitle.Text.Trim().Length < 1)
            {
                Form2.title = "Tên Sản Phẩm (> 1 Ký Tự) ";
                Form2.ShowDialog();
                return;
            }
            if (txtUnit.Text.Trim() == "")
            {
                Form2.title = "Đơn Vị Không Được Để (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (DbStockProduct.CheckAdd(txtTitle.Text)==true)
            {
                Form2.title = "Sản Phẩm Đã Tồn Tại Trong Kho ";
                Form2.ShowDialog();
                return;
            }
            if (btnSave.Text == "Lưu")
            {
                StockProduct std = new StockProduct(txtTitle.Text,0,txtUnit.Text,status);
                DbStockProduct.AddStockProduct(std);
                if (DbStockProduct.CheckCreateStockProduct(std) == true)
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

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
