using SquiredCoffee.Class;
using SquiredCoffee.DB;
using SquiredCoffee.FormManage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SquiredCoffee.UC_ManageSysterm
{
    public partial class UC_ManageImportInvoice : UserControl
    {
        FormAddImportInvoice Form;
        public int total;
        public int totalSearch;
        public UC_ManageImportInvoice()
        {
            InitializeComponent();
            Form = new FormAddImportInvoice(this);
        }

        public void clear()
        {
            total = 0;
            totalSearch = 0;
        }

        public void clear1()
        {
            txtSearch.Text = string.Empty;
        }

        public void Display()
        {
            clear();
            clear1();
            dgvImportInvoice.Rows.Clear();
            List<ImportInvoice> importInvoiceList = DbImportInvoice.LoadImportInvoice();
            foreach (ImportInvoice item in importInvoiceList)
            {
                DateTime start_date = Convert.ToDateTime(item.start_date);
                DateTime expiry_date = Convert.ToDateTime(item.expiry_date);
                total += 1;
                dgvImportInvoice.Rows.Add(new object[] {
                    imageList1.Images[0], 
                    item.id,
                    item.nameStockProduct,
                    item.nameSupplier,
                    item.quantity,
                    item.unit,
                    string.Format("{0:#,##0} đ", item.unit_price),
                    string.Format("{0:dd/MM/yyyy}",expiry_date),
                    string.Format("{0:dd/MM/yyyy}",start_date),
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotal.Text = total.ToString();
            lblTotalSearch.Text = total.ToString();
        }

        public void LoadImportInvoiceSearchClick(string status)
        {
            clear();
            clear1();
            dgvImportInvoice.Rows.Clear();
            List<ImportInvoice> importInvoiceList = DbImportInvoice.LoadImportInvoiceSearchClick(status);
            foreach (ImportInvoice item in importInvoiceList)
            {
                DateTime start_date = Convert.ToDateTime(item.start_date);
                DateTime expiry_date = Convert.ToDateTime(item.expiry_date);
                totalSearch += 1;
                dgvImportInvoice.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.nameStockProduct,
                    item.nameSupplier,
                    item.quantity,
                    item.unit,
                    string.Format("{0:#,##0} đ", item.unit_price),
                    string.Format("{0:dd/MM/yyyy}",expiry_date),
                    string.Format("{0:dd/MM/yyyy}",start_date),
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalSearch.Text = totalSearch.ToString();
        }


        private void UC_ManageImportInvoice_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            Display();
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            LoadImportInvoiceSearchClick("1");
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            LoadImportInvoiceSearchClick("0");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            clear();

            dgvImportInvoice.Rows.Clear();
            List<ImportInvoice> importInvoiceList = DbImportInvoice.LoadImportInvoiceSearch(txtSearch.Text);
            foreach (ImportInvoice item in importInvoiceList)
            {
                DateTime start_date = Convert.ToDateTime(item.start_date);
                DateTime expiry_date = Convert.ToDateTime(item.expiry_date);
                totalSearch += 1;
                dgvImportInvoice.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.nameStockProduct,
                    item.nameSupplier,
                    item.quantity,
                    item.unit,
                    string.Format("{0:#,##0} đ", item.unit_price),
                    string.Format("{0:dd/MM/yyyy}",expiry_date),
                    string.Format("{0:dd/MM/yyyy}",start_date),
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalSearch.Text = totalSearch.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            clear();
            clear1();
            dgvImportInvoice.Rows.Clear();
            string x = dtpSearch.Value.Date.ToString("yyyy-MM-dd");
            List<ImportInvoice> importInvoiceList = DbImportInvoice.LoadImportInvoiceButtonSearch(x);
            foreach (ImportInvoice item in importInvoiceList)
            {
                DateTime start_date = Convert.ToDateTime(item.start_date);
                DateTime expiry_date = Convert.ToDateTime(item.expiry_date);
                totalSearch += 1;
                dgvImportInvoice.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.nameStockProduct,
                    item.nameSupplier,
                    item.quantity,
                    item.unit,
                    string.Format("{0:#,##0} đ", item.unit_price),
                    string.Format("{0:dd/MM/yyyy}",expiry_date),
                    string.Format("{0:dd/MM/yyyy}",start_date),
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalSearch.Text = totalSearch.ToString();
        }

        private void btnAddImportInvoice_Click(object sender, EventArgs e)
        {
            Form.ShowDialog();
        }
    }
}
