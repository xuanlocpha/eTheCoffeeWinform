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

namespace SquiredCoffee.FormManage
{
    public partial class FormShowOrder : Form
    {
        FormSale _parent;
        public string username;
        public FormShowOrder(FormSale parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            _parent.checkBtn();
        }

        public void Display()
        {
            dgvOrder.Rows.Clear();
            List<OrderShow2> orderList = DbOrder.LoadShowOrder();
            foreach (OrderShow2 item in orderList)
            {
                if(item.user_name == "guest")
                {
                    username = "Khách vãng lai";
                }
                else
                {
                    username = item.user_name;
                }
                DateTime dt = Convert.ToDateTime(item.created_at);
                string date = dt.ToString("yyyy-MM-dd");
                if(DateTime.Now.ToString("yyyy-MM-dd") == date)
                {
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
                });
                }

            }
        }

        private void FormShowOrder_Load(object sender, EventArgs e)
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
    }
}
