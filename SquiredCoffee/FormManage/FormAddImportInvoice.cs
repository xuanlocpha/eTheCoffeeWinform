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
        public static UC_ManageImportInvoice _parent;
        public FormAddImportInvoice(UC_ManageImportInvoice parent)
        {
            InitializeComponent();
            _parent = parent;
        }


        void ketnoi()
        {
            con.ConnectionString = "datasource=localhost;port=3306;username=root;password=;database=coffeeshop";
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
                MessageBox.Show("Tên Sản Phẩm Đang Để ( Trống )");
                return;
            }
            if (cbSupplier.Text == "")
            {
                MessageBox.Show("Nhà Cung Cấp Đang Để ( Trống )");
                return;
            }
            if (txtQuantity.Text == "")
            {
                MessageBox.Show("Số Lượng Sản Phẩm ( Trống )");
                return;
            }
            if (txtUnit.Text == "")
            {
                MessageBox.Show("Đơn Vị Đang Để ( Trống )");
                return;
            }
            if (txtUnitPrice.Text == "")
            {
                MessageBox.Show("Giá Nhập Đang Để ( Trống )");
                return;
            }
            if (dtpExpiryDate.Value == DateTime.Now)
            {
                MessageBox.Show("Hạn Sử Dụng Không Được Trùng Với Ngày Hiện Tại ");
                return;
            }
            if (btnSave.Text == "Lưu")
            {
                string StartDate = DateTime.Now.ToString("yyyy-MM-dd");
                string ExpiryDate = dtpExpiryDate.Value.Date.ToString("yyyy-MM-dd");
                ImportInvoice std = new ImportInvoice(Convert.ToInt32(cbStockProduct.SelectedValue), Convert.ToInt32(cbSupplier.SelectedValue), Convert.ToInt32(txtQuantity.Text),txtUnit.Text, Convert.ToDecimal(txtUnitPrice),StartDate,ExpiryDate,status);
                DbImportInvoice.AddImportInvoice(std);
                this.Close();
                clear();
                _parent.clear();
                _parent.clear1();
                _parent.Display();
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
