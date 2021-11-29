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
        public string id_import_invoice_items;
        public static UC_ManageImportInvoice _parent;
        FormSuccess Form1;
        FormError Form2;
        public string id_import_invoice;
        public decimal total = 0;
        public FormAddImportInvoice(UC_ManageImportInvoice parent)
        {
            InitializeComponent();
            _parent = parent;
            Form1 = new FormSuccess();
            Form2 = new FormError();
        }


        void ketnoi()
        {
            con.ConnectionString = "SERVER=45.252.251.21;PORT=3306;DATABASE=sodopxlg_koffeeholic;UID=sodopxlg;PASSWORD=05qT1yfRp9";
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
            txtQuantity.Text = txtUnitPrice.Text = string.Empty;
            dtpExpiryDate.Value = DateTime.Now;
            dgvImportInvoiceItem.Rows.Clear();
        }


        public void LoadIdImportInvoice()
        {
            List<ImportInvoice> importInvoiceList = DbImportInvoice.LoadImportInvoice(staff_id.ToString(),"0");
            foreach (ImportInvoice item in importInvoiceList)
            {
                id_import_invoice = item.id.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSuccess.Enabled = true;
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
            if (dtpExpiryDate.Value >= DateTime.Now)
            {
                Form2.title = "Hạn Sử Dụng Không Được (Nhỏ hơn ngày hiện tại)";
                Form2.ShowDialog();
                return;
            }
            if (btnSave.Text == "Nhập")
            {
                string StartDate = DateTime.Now.ToString("yyyy-MM-dd");
                string ExpiryDate = dtpExpiryDate.Value.Date.ToString("yyyy-MM-dd");
                int quantity = Convert.ToInt32(txtQuantity.Text);
                ImportInvoiceItem std = new ImportInvoiceItem(Convert.ToInt32(id_import_invoice), Convert.ToInt32(cbStockProduct.SelectedValue), Convert.ToInt32(cbSupplier.SelectedValue),quantity, txtUnit.Text, Convert.ToDecimal(txtUnitPrice.Text), StartDate, ExpiryDate, 1);
                if ((DbImportInvoiceItem.CheckCreateImportInvoice(std)) == true)
                {
                    decimal kq = (Convert.ToDecimal(txtUnitPrice.Text) * Convert.ToDecimal(txtQuantity.Text));
                    total = total + kq;
                    Form1.title = "Thêm Hàng Thành Công ";
                    Form1.ShowDialog();
                    List<StockProduct> stockProductList = DbStockProduct.LoadStockProductCheck(Convert.ToString(cbStockProduct.SelectedValue));
                    foreach (StockProduct item in stockProductList)
                    {
                        int x = quantity + item.quantity;
                        StockProduct std1 = new StockProduct(item.title, x, item.unit, item.status);
                        DbStockProduct.UpdateStockProduct(std1, Convert.ToString(cbStockProduct.SelectedValue));
                    }
                    clear();
                    lblTotal.Text = string.Format("{0:#,##0} đ", total);
                    LoadImportInvoiceItem();
                   
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
            btnSuccess.Enabled = false;
            txtUnit.Enabled = false;
            LoadIdImportInvoice();
            ListSupplier();
            ListStockProduct();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            List<ImportInvoiceItem> importInvoiceItemList = DbImportInvoiceItem.LoadImportInvoiceItem(id_import_invoice);
            foreach (ImportInvoiceItem item in importInvoiceItemList)
            {
                DbImportInvoiceItem.DeleteImportInvoice(item.id.ToString());
            }
            DbImportInvoice.DeleteImportInvoice(id_import_invoice);
            Form1.title = "Hủy Nhập Hàng Thành Công";
            Form1.ShowDialog();
            total = 0;
            this.Close();
            clear();
            _parent.clear();
            _parent.clear1();
            _parent.Display();
        }

        private void btnSuccess_Click(object sender, EventArgs e)
        {
            Form1.title = "Hoàn Thành Nhập Hàng ";
            Form1.ShowDialog();
            ImportInvoice std = new ImportInvoice(staff_id,total, DateTime.Now.ToString("yyyy-MM-dd"), 1);
            DbImportInvoice.UpdateImportInvoice(std,id_import_invoice);
            total = 0;
            this.Close();
            clear();
            _parent.clear();
            _parent.clear1();
            _parent.Display();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            List<ImportInvoiceItem> importInvoiceItemList = DbImportInvoiceItem.LoadImportInvoiceItem(id_import_invoice);
            foreach (ImportInvoiceItem item in importInvoiceItemList)
            {
                DbImportInvoiceItem.DeleteImportInvoice(item.id.ToString());
            }
            DbImportInvoice.DeleteImportInvoice(id_import_invoice);
            Form1.title = "Hủy Nhập Hàng Thành Công";
            Form1.ShowDialog();
            total = 0;
            this.Close();
            clear();
            _parent.clear();
            _parent.clear1();
            _parent.Display();
        }



        public void LoadImportInvoiceItem()
        {
            dgvImportInvoiceItem.Rows.Clear();
            List<ImportInvoiceItem> importInvoiceItemList = DbImportInvoiceItem.LoadImportInvoiceItem(id_import_invoice);
            foreach (ImportInvoiceItem item in importInvoiceItemList)
            {
                dgvImportInvoiceItem.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.nameStockProduct,
                    item.nameSupplier,
                    item.quantity,
                    item.unit,
                    string.Format("{0:#,##0} đ",item.unit_price),
                    string.Format("{0:dd/MM/yyyy}",item.start_date),
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
        }

        private void bunifuVScrollBar1_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            try
            {
                dgvImportInvoiceItem.FirstDisplayedScrollingRowIndex = dgvImportInvoiceItem.Rows[e.Value].Index;
            }
            catch (Exception)
            {

            }
        }

        private void dgvImportInvoiceItem_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = dgvImportInvoiceItem.RowCount - 1;
            }
            catch
            {

            }
        }

        private void dgvImportInvoiceItem_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = dgvImportInvoiceItem.RowCount - 1;
            }
            catch
            {

            }
        }


        private void cbStockProduct_TextChanged(object sender, EventArgs e)
        {
            List<StockProduct> stockProductList = DbStockProduct.LoadStockProductSearchList(Convert.ToString(cbStockProduct.SelectedText));
            foreach (StockProduct item in stockProductList)
            {
                txtUnit.Text = item.unit;
            }
        }


        private void cbStockProduct_SelectedValueChanged_1(object sender, EventArgs e)
        {
            List<StockProduct> stockProductList = DbStockProduct.LoadStockProductSearchList1(Convert.ToString(cbStockProduct.SelectedValue));
            foreach (StockProduct item in stockProductList)
            {
                txtUnit.Text = item.unit;
            }
        }
    }
}
