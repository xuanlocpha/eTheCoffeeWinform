using MySql.Data.MySqlClient;
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
    public partial class FormAddImportInvoice : Form
    {
        MySqlConnection con = new MySqlConnection();
        public int status = 1;
        public int staff_id;
        public static UC_ManageImportInvoice _parent;
        FormSuccess Form1;
        FormError Form2;
        public FormAddImportInvoice(UC_ManageImportInvoice parent)
        {
            InitializeComponent();
            _parent = parent;
            Form1 = new FormSuccess();
            Form2 = new FormError();
        }


        void ketnoi()
        {
            con.ConnectionString = "SERVER=45.252.251.29;PORT=3306;DATABASE=sodopxlg_koffeeholic;UID=sodopxlg;PASSWORD=05qT1yfRp9";
            if (con.State == ConnectionState.Closed)
                con.Open();
        }

        public DataSet LoadDB(string sql)
        {
            ketnoi();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
            da.Fill(ds);
            return ds;
        }

        void ListStockProduct()
        {
            string sql = "SELECT * FROM stock_products";
            DataSet ListCategory = new DataSet();
            ListCategory = LoadDB(sql);
            cbStockProduct.DataSource = ListCategory.Tables[0];
            cbStockProduct.DisplayMember = "title";
            cbStockProduct.ValueMember = "id";
            cbStockProduct.SelectedIndex = -1;
            con.Close();
        }


        void ListSupplier()
        {
            string sql = "SELECT * FROM suppliers";
            DataSet ListCategory = new DataSet();
            ListCategory = LoadDB(sql);
            cbSupplier.DataSource = ListCategory.Tables[0];
            cbSupplier.DisplayMember = "name_supplier";
            cbSupplier.ValueMember = "id";
            cbSupplier.SelectedIndex = -1;
            con.Close();
        }

        public void clear()
        {
            cbStockProduct.SelectedIndex = -1;
            cbSupplier.SelectedIndex = -1;
            txtQuantity.Text = txtUnit.Text = txtUnitPrice.Text = string.Empty;
            dtpExpiryDate.Value = DateTime.Now;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbStockProduct.Text == "")
            {
                Form2.title = "Tên Sản Phẩm Không Được (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (cbSupplier.Text == "")
            {
                Form2.title = "Tên Nhà Cung Cấp Không Được (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtQuantity.Text == "")
            {
                Form2.title = "Số Lượng Không Được (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtUnit.Text == "")
            {
                Form2.title = "Đơn Vị Không Được (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtUnitPrice.Text == "")
            {
                Form2.title = "Giá Nhập Không Được (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (dtpExpiryDate.Value == DateTime.Now)
            {
                Form2.title = "Hạn Sử Dụng Không Được (Trùng với ngày hiện tại)";
                Form2.ShowDialog();
                return;
            }
            if (btnSave.Text == "Lưu")
            {
                string StartDate = DateTime.Now.ToString("yyyy-MM-dd");
                string ExpiryDate = dtpExpiryDate.Value.Date.ToString("yyyy-MM-dd");
                ImportInvoice std = new ImportInvoice(staff_id,Convert.ToInt32(cbStockProduct.SelectedValue), Convert.ToInt32(cbSupplier.SelectedValue), Convert.ToInt32(txtQuantity.Text),txtUnit.Text, Convert.ToDecimal(txtUnitPrice.Text),StartDate,ExpiryDate,status);
                if ((DbImportInvoice.CheckCreateImportInvoice(std)) == true)
                {
                    Form1.title = "Nhập Hàng Thành Công ";
                    Form1.ShowDialog();
                    List<StockProduct> stockProductList = DbStockProduct.LoadStockProductCheck(Convert.ToString(cbStockProduct.SelectedValue));
                    foreach (StockProduct item in stockProductList)
                    {
                        int x = Convert.ToInt32(txtQuantity.Text) + item.quantity;
                        StockProduct std1 = new StockProduct(item.title, x, item.unit, item.status);
                        DbStockProduct.UpdateStockProduct(std1, Convert.ToString(cbStockProduct.SelectedValue));
                    }
                    this.Close();
                    clear();
                    _parent.clear();
                    _parent.clear1();
                    _parent.Display();
                }
                else
                {
                    Form2.title = "Nhập Hàng Không Thành Công ";
                    Form2.ShowDialog();
                }
                
            }
        }

        private void txtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void rdStatus1_CheckedChanged(object sender, EventArgs e)
        {
            status = 1;
        }

        private void rdStatus2_CheckedChanged(object sender, EventArgs e)
        {
            status = 0;
        }

        private void FormAddImportInvoice_Load(object sender, EventArgs e)
        {
            ListSupplier();
            ListStockProduct();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
