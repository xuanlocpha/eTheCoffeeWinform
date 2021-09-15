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
    public partial class FormInformationStockProduct : Form
    {
        public int status;
        public int id_stockProduct;
        public static UC_ManageStockProduct _parent;
        public FormInformationStockProduct(UC_ManageStockProduct parent)
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

        public void Display()
        {
            List<StockProduct> stockProductList = DbStockProduct.LoadStockProductList(id_stockProduct.ToString());
            foreach (StockProduct item in stockProductList)
            {
                txtTitle.Text = item.title;
                txtQuantity.Text = item.quantity.ToString();
                txtUnit.Text = item.unit;
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

        private void FormInformationStockProduct_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnEdit_Click(object sender, EventArgs e)
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
            if (MessageBox.Show("Bạn có muốn chỉnh sửa thông tin của ( Sản phẩm kho  ) này không !", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (btnEdit.Text == "Sửa")
                {
                    StockProduct std = new StockProduct(txtTitle.Text, Convert.ToInt32(txtQuantity.Text), txtUnit.Text, status);
                    DbStockProduct.UpdateStockProduct(std, id_stockProduct.ToString());
                    this.Close();
                    _parent.clear();
                    _parent.clear1();
                    _parent.Display();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa thông tin của ( Sản phẩm kho  ) này không !", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (btnDelete.Text == "Xóa")
                {
                    DbStockProduct.DeleteStockProduct(id_stockProduct.ToString());
                    this.Close();
                    _parent.clear();
                    _parent.clear1();
                    _parent.Display();
                }
            }
        }
    }
}
