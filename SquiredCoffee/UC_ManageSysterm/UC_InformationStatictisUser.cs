using SquiredCoffee.Class;
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
    public partial class UC_InformationStatictisUser : UserControl
    {
        public int total;
        public int totalSearch;
        public string name_staff;
        public string id_order;
        public string tableName;
        public int quantity;
        public string option_name;
        public string option_price;
        public string topping_name;
        public string topping_price;
        public string provisional;
        public string voucher_discount;
        public string shipping;
        public string grand_total;
        public string date;
        public string username;
        public string key;
        public decimal totalOrder;
        public string title;
        public string id_user;
        public UC_InformationStatictisUser()
        {
            InitializeComponent();
        }

        public void Display()
        {
            List<User> userList = DbUser.ListUserInformation(id_user);
            foreach (User item in userList)
            {
                txtDisplayName.Text = item.display_name;
                if (item.gender == "male")
                {
                    rdGender1.Checked = true;
                }
                else
                {
                    rdGender2.Checked = true;
                }
                dtpBirthday.Text = item.birthday;
                txtEmail.Text = item.email;
                txtPhone.Text = item.phone;
                txtPoint.Text = item.point.ToString();
                if (item.point < 100)
                {
                    txtLevel.Text = "Bạc";
                }
                if (item.point < 100)
                {
                    txtLevel.Text = "Bạc";
                }
                else if (item.point > 101 && item.point < 1000)
                {
                    txtLevel.Text = "Vàng";
                }
                else
                {
                    txtLevel.Text = "Kim Cương";
                }
            }
        }


        public void Display1()
        {
            dgvOrder.Rows.Clear();
            List<OrderShow2> orderList = DbOrder.LoadShowOrderSearchId(id_user);
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
                totalOrder = totalOrder + item.grandtotal;
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
                lblTotalOrder1.Text = total.ToString();
                lblRevenue1.Text = string.Format("{0:#,##0} đ", totalOrder);
            }
        }

        private void UC_InformationStatictisUser_Load(object sender, EventArgs e)
        {
            id_user = "1";
            Display1();
            Display();
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
    }
}
