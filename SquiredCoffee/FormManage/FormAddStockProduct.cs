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
        public int status = 1;
        public static UC_ManageStockProduct _parent;
        public FormAddStockProduct(UC_ManageStockProduct parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void FormAddStockProduct_Load(object sender, EventArgs e)
        {

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
            txtQuantity.Text = txtTitle.Text = txtUnit.Text = string.Empty;
            rdStatus1.Checked = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text.Trim() == "")
            {
                MessageBox.Show("Tên sản phẩm kho không được để ( Trống )");
                return;
            }
            if (txtTitle.Text.Trim().Length < 1)
            {
                MessageBox.Show("Tên sản phẩm kho phải lớn hơn (  1 ký tự )");
                return;
            }
            if (txtQuantity.Text.Trim() == "")
            {
                MessageBox.Show("Số lượng không được để ( Trống )");
                return;
            }
            if (txtQuantity.Text.Trim().Length < 1)
            {
                MessageBox.Show(" Số lượng phải lớn hơn (  1 ký tự )");
                return;
            }
            if (txtUnit.Text.Trim() == "")
            {
                MessageBox.Show("Đơn vị không được để ( Trống )");
                return;
            }
            if (txtQuantity.Text.Trim().Length < 1)
            {
                MessageBox.Show("Đơn vị phải lớn hơn (  1 ký tự )");
                return;
            }
            if (DbStockProduct.CheckAdd(txtTitle.Text)==true)
            {
                MessageBox.Show("Sản phẩm này đã tồn tại trong kho !!!");
                return;
            }
            if (btnSave.Text == "Lưu")
            {
                StockProduct std = new StockProduct(txtTitle.Text,Convert.ToInt32(txtQuantity.Text),txtUnit.Text,status);
                DbStockProduct.AddStockProduct(std);
                this.Close();
                clear();
                _parent.clear();
                _parent.clear1();
                _parent.Display();
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
