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
    public partial class FormInformationImportInvoice : Form
    {
        UC_ManageImportInvoice _parent;
        public FormInformationImportInvoice(UC_ManageImportInvoice parent)
        {
            InitializeComponent();
            _parent = parent;
        }
        public string id_import_invoice;
        public decimal total;

        private void btnClose_Click(object sender, EventArgs e)
        {
            total = 0;
            this.Close();
        }

        public void Display()
        {
            dgvImportInvoiceItem.Rows.Clear();
            List<ImportInvoiceItem> importInvoiceItemList = DbImportInvoiceItem.LoadImportInvoiceItem(id_import_invoice);
            foreach (ImportInvoiceItem item in importInvoiceItemList)
            {
                total = total + (Convert.ToDecimal(item.quantity) * Convert.ToDecimal(item.unit_price));
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
                lblTotal.Text = string.Format("{0:#,##0} đ", total);
            }
        }

        private void FormInformationImportInvoice_Load(object sender, EventArgs e)
        {
            Display();
        }
    }
}
