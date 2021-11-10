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
        FormSuccess Form1;
        FormError Form2;
        public FormInformationStockProduct(UC_ManageStockProduct parent)
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
            if (txtQuantity.Text.Trim() == "")
            {
                Form2.title = "Số Lượng Không Được (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtQuantity.Text.Trim().Length < 1)
            {
                Form2.title = "Số Lượng Phải (> 1 Ký Tự) ";
                Form2.ShowDialog();
                return;
            }
            if (txtUnit.Text.Trim() == "")
            {
                Form2.title = "Đơn Vị Không Được Để (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtQuantity.Text.Trim().Length < 1)
            {
                Form2.title = "Đơn Vị Phải Lớn Hơn (>1 Ký Tự) ";
                Form2.ShowDialog();
                return;
            }
                if (btnEdit.Text == "Sửa")
                {
                    StockProduct std = new StockProduct(txtTitle.Text, Convert.ToInt32(txtQuantity.Text), txtUnit.Text, status);
                    if ((DbStockProduct.CheckUpdateStockProduct(std,id_stockProduct.ToString())) == true)
                    {
                        Form1.title = "Chỉnh Sửa Thành Công";
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
                if ((DbStockProduct.CheckDeleteStockProduct(id_stockProduct.ToString())) == false)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
