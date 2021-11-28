using SquiredCoffee.DB;
using SquiredCoffee.ViewModels;
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
    public partial class UC_ManageOrder : UserControl
    {
        public int total;
        public int totalSearch;
        public UC_ManageOrder()
        {
            InitializeComponent();
        }
        public string username;

        public void Display()
        {
            clear();
            dgvOrder.Rows.Clear();
            List<OrderShow2> orderList = DbOrder.LoadShowOrder();
            foreach (OrderShow2 item in orderList)
            {
                total = total + 1;
                if (item.user_name == "guest")
                {
                    username = "Khách vãng lai";
                }
                else
                {
                    username = item.user_name;
                }
                DateTime dt = Convert.ToDateTime(item.created_at);
                string date = dt.ToString("dd-MM-yyyy");
                    dgvOrder.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.first_name+""+item.last_name,
                    username,
                    item.address,
                    item.mode,
                    string.Format("{0:#,##0} đ",item.subtotal),
                    string.Format("{0:#,##0} đ",item.shipping),
                    string.Format("{0:#,##0} đ",item.voucher_discount),
                    string.Format("{0:#,##0} đ",item.shipping_discount),
                    string.Format("{0:#,##0} đ",item.grandtotal),
                    date
                });
                lblTotalOrder.Text = total.ToString();
                lblTotalOrderSearch.Text = total.ToString();
            }
        }

        public void clear()
        {
            total = 0;
            totalSearch = 0;
        }

        public void clear1()
        {
            totalSearch = 0;
        }

        private void UC_ManageOrder_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void bunifuVScrollBar1_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            try
            {
                dgvOrder.FirstDisplayedScrollingRowIndex = dgvOrder.Rows[e.Value].Index;
            }
            catch (Exception)
            {

            }
        }

        private void dgvOrder_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = dgvOrder.RowCount - 1;
            }
            catch
            {

            }
        }

        private void dgvOrder_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = dgvOrder.RowCount - 1;
            }
            catch
            {

            }
        }

        private void btnSearchDate_Click(object sender, EventArgs e)
        {
            clear1();
            dgvOrder.Rows.Clear();
            string x = dtpStart_date.Value.Date.ToString("yyyy-MM-dd");
            string y = dtpEnd_Date.Value.Date.ToString("yyyy-MM-dd");
            List<OrderShow2> orderList = DbOrder.LoadShowOrderShowDate(x, y);
            foreach (OrderShow2 item in orderList)
            {
                totalSearch +=1;
                if (item.user_name == "guest")
                {
                    username = "Khách vãng lai";
                }
                else
                {
                    username = item.user_name;
                }
                DateTime dt = Convert.ToDateTime(item.created_at);
                string date = dt.ToString("dd-MM-yyyy");
                dgvOrder.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.first_name+""+item.last_name,
                    username,
                    item.address,
                    item.mode,
                    string.Format("{0:#,##0} đ",item.subtotal),
                    string.Format("{0:#,##0} đ",item.shipping),
                    string.Format("{0:#,##0} đ",item.voucher_discount),
                    string.Format("{0:#,##0} đ",item.shipping_discount),
                    string.Format("{0:#,##0} đ",item.grandtotal),
                    date
                });
            }
            lblTotalOrderSearch.Text = totalSearch.ToString();
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {

        }

        private void btnActive_Click(object sender, EventArgs e)
        {

        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            clear1();
            dgvOrder.Rows.Clear();
            string x = DateTime.Now.Date.ToString("yyyy-MM-dd");
            List<OrderShow2> orderList = DbOrder.LoadShowOrderShowDateNow(x);
            foreach (OrderShow2 item in orderList)
            {
                totalSearch += 1;
                if (item.user_name == "guest")
                {
                    username = "Khách vãng lai";
                }
                else
                {
                    username = item.user_name;
                }
                DateTime dt = Convert.ToDateTime(item.created_at);
                string date = dt.ToString("dd-MM-yyyy");
                dgvOrder.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.first_name+""+item.last_name,
                    username,
                    item.address,
                    item.mode,
                    string.Format("{0:#,##0} đ",item.subtotal),
                    string.Format("{0:#,##0} đ",item.shipping),
                    string.Format("{0:#,##0} đ",item.voucher_discount),
                    string.Format("{0:#,##0} đ",item.shipping_discount),
                    string.Format("{0:#,##0} đ",item.grandtotal),
                    date
                }); 
            }
            lblTotalOrderSearch.Text = totalSearch.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear1();
            dgvOrder.Rows.Clear();
            List<OrderShow2> orderList = DbOrder.LoadShowOrderShowCancel();
            foreach (OrderShow2 item in orderList)
            {
                totalSearch +=1;
                if (item.user_name == "guest")
                {
                    username = "Khách vãng lai";
                }
                else
                {
                    username = item.user_name;
                }
                DateTime dt = Convert.ToDateTime(item.created_at);
                string date = dt.ToString("dd-MM-yyyy");
                dgvOrder.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.first_name+""+item.last_name,
                    username,
                    item.address,
                    item.mode,
                    string.Format("{0:#,##0} đ",item.subtotal),
                    string.Format("{0:#,##0} đ",item.shipping),
                    string.Format("{0:#,##0} đ",item.voucher_discount),
                    string.Format("{0:#,##0} đ",item.shipping_discount),
                    string.Format("{0:#,##0} đ",item.grandtotal),
                    date
                });
            }
            lblTotalOrderSearch.Text = totalSearch.ToString();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            Display();
        }

    }
}
