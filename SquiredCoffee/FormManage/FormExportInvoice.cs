using MySql.Data.MySqlClient;
using SquiredCoffee.Class;
using SquiredCoffee.DB;
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
    public partial class FormExportInvoice : Form
    {
        MySqlConnection con = new MySqlConnection();
        FormSale _parent;
        FormSuccess Form1;
        FormError Form2;
        public string id_staff;
        public string id_export_invoice;
        public FormExportInvoice(FormSale parent)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            
            List<ExportInvoiceItems> exportInvoiceItemList = DbExportInvoiceItem.LoadExportInvoiceItem(id_export_invoice);
            foreach (ExportInvoiceItems item in exportInvoiceItemList)
            {
                DbExportInvoiceItem.DeleteExportInvoiceItems(item.id.ToString());
            }
            DbExportInvoice.DeleteExportInvoice(id_export_invoice);
            this.Close();
            _parent.checkBtn();
        }

        public void clear()
        {
            cbStockProduct.SelectedIndex = -1;
            txtQuantity.Text = string.Empty;
            dgvExportInvoice.Rows.Clear();
        }


        public void LoadExportInvoiceItem()
        {
            dgvExportInvoice.Rows.Clear();
            List<ExportInvoiceItems> exportInvoiceItemList = DbExportInvoiceItem.LoadExportInvoiceItem(id_export_invoice);
            foreach (ExportInvoiceItems item in exportInvoiceItemList)
            {
                dgvExportInvoice.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.nameStockProduct,
                    item.quantity,
                    item.unit,
                    string.Format("{0:dd/MM/yyyy}",item.create_date)
                });
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
            if (txtQuantity.Text == "")
            {
                Form2.title = "Số Lượng Không Được (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (btnSave.Text == "Lưu")
            {
                string CreateDate = DateTime.Now.ToString("yyyy-MM-dd");
                int quantity = Convert.ToInt32(txtQuantity.Text);
                ExportInvoiceItems std = new ExportInvoiceItems(Convert.ToInt32(id_export_invoice), Convert.ToInt32(cbStockProduct.SelectedValue),quantity,txtUnit.Text,CreateDate,1);
                DbExportInvoiceItem.AddExportInvoice(std);
                Form1.title = "Cập Nhật Kho Thành Công ";
                Form1.ShowDialog();
                List<StockProduct> stockProductList = DbStockProduct.LoadStockProductCheck(Convert.ToString(cbStockProduct.SelectedValue));
                foreach (StockProduct item in stockProductList)
                {
                   int x = item.quantity - quantity;
                   StockProduct std1 = new StockProduct(item.title, x, item.unit, item.status);
                   DbStockProduct.UpdateStockProduct(std1, Convert.ToString(cbStockProduct.SelectedValue));
                }
                clear();
                LoadExportInvoiceItem();
            }
            
        }

        public void LoadIdExportInvoice()
        {
            List<ExportInvoice> exportInvoiceList = DbExportInvoice.LoadExportInvoice(id_staff.ToString(), "0");
            foreach (ExportInvoice item in exportInvoiceList)
            {
                id_export_invoice = item.id.ToString();
            }
        }

        private void FormExportInvoice_Load(object sender, EventArgs e)
        {
            LoadIdExportInvoice();
            txtUnit.Enabled = false;
            btnSuccess.Enabled = false;
            txtUnit.Text = "";
            ListStockProduct();
        }

        private void cbStockProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<StockProduct> stockProductList = DbStockProduct.LoadStockProductSearchList1(Convert.ToString(cbStockProduct.SelectedValue));
            foreach (StockProduct item in stockProductList)
            {
                txtUnit.Text = item.unit;
            }
        }

        private void btnSuccess_Click(object sender, EventArgs e)
        {
            DbExportInvoice.UpdateExportInvoice(id_export_invoice,"1");
            Form1.title = "Kết ca hoàn thành";
            Form1.ShowDialog();
            this.Close();
            _parent.checkBtn();
        }
    }
}
