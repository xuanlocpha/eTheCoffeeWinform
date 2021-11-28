using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SquiredCoffee.Class;
using SquiredCoffee.DB;
using System.Windows.Forms;

namespace SquiredCoffee.UC_ManageSysterm
{
    public partial class UC_ShowVoucher : UserControl
    {
        public string discount_unit;
        public string apply_for;
        public UC_ShowVoucher()
        {
            InitializeComponent();
        }


        public void Display()
        {
            dgvVoucher.Rows.Clear();
            string type = "public";
            List<Voucher> voucherList = DbVoucher.LoadVoucherListToday(DateTime.Now.ToString("yyyy-MM-dd"), type);
            foreach (Voucher item in voucherList)
            {
                if (item.discount_unit == "percent")
                {
                    discount_unit = "Thẻ";
                }
                if (item.discount_unit == "cash")
                {
                    discount_unit = "Tiền mặt";
                }
                if (item.apply_for == "order")
                {
                    apply_for = "order";
                }
                if (item.discount_unit == "product")
                {
                    apply_for = "Sản Phẩm";
                }
                if (item.discount_unit == "shipping")
                {
                    apply_for = "Giao hàng";
                }
                if (item.discount_unit == "category")
                {
                    apply_for = "Loại sản phẩm";
                }
                dgvVoucher.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.title,
                    discount_unit,
                    item.discount,
                    apply_for,
                    item.quantity_rule,
                    item.price_rule,
                    string.Format("{0:dd/MM/yyyy}",item.start_date),
                    string.Format("{0:dd/MM/yyyy}",item.expiry_date)
                });
            }
        }


        private void UC_ShowVoucher_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void bunifuVScrollBar1_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            try
            {
                dgvVoucher.FirstDisplayedScrollingRowIndex = dgvVoucher.Rows[e.Value].Index;
            }
            catch (Exception)
            {

            }
        }

        private void dgvVoucher_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = dgvVoucher.RowCount - 1;
            }
            catch
            {

            }
        }

        private void dgvVoucher_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = dgvVoucher.RowCount - 1;
            }
            catch
            {

            }
        }
    }
}
