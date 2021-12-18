using Newtonsoft.Json;
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
    public partial class UC_ManageOrder : UserControl
    {
        public int total;
        public int totalSearch;
        public string name_staff;
        public string id_order;
        public string tableName;
        public int quantity ;
        public string option_name;
        public string option_price;
        public string topping_name;
        public string topping_price;
        public string provisional;
        public string voucher_discount;
        public string shipping;
        public string grand_total;
        public string date;
        List<int> str1 = new List<int>();
        List<int> str2 = new List<int>();
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
            List<OrderShow2> orderList = DbOrder.LoadShowOrder();
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
                string date = dt.ToString("yyyy-MM-dd");
                if (DateTime.Now.ToString("yyyy-MM-dd") == date)
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
                    date
                    });
                }

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

        public void ReadFormDataFile(string fileLocation)
        {
            ItemDetail itemDetail = JsonConvert.DeserializeObject<ItemDetail>(fileLocation);
            str1 = itemDetail.options;
            str2 = itemDetail.toppings;
        }

        public void OptionName(int id, string product_id, int quantity)
        {
            if (DbOption.CheckOption(id.ToString()) == true)
            {

                List<OptionShow> option_Show_List = DbOption.OptionShow(id.ToString(), product_id);
                foreach (OptionShow item1 in option_Show_List)
                {
                    option_name = item1.title;
                    option_price = string.Format("{0:#,##0}", item1.price);
                    return;
                }
            }
        }


        public void ToppingName(int id, int quantity)
        {
            if (DbTopping.CheckTopping(id.ToString()) == true)
            {
                List<ToppingShow> toppingShows = DbTopping.LoadToppingClick(id.ToString());
                foreach (ToppingShow item1 in toppingShows)
                {
                    topping_name = item1.title;
                    topping_price = string.Format("{0:#,##0}", item1.price);
                    return;
                }
            }
        }

       

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font = new Font("Quicksand", 12);
            float fontHeight = font.GetHeight();
            int startx = 190;
            int starty = 40;
            int offset = 40;
            float leftmargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            graphics.DrawString("SQUIRED THE COFFEE", new Font("Quicksand", 25, FontStyle.Bold), new SolidBrush(color: Color.Black), new Point(245, 40));
            offset = offset + 10;
            graphics.DrawString("65 Huỳnh Thúc Kháng, Phường.Bến Nghé, Q.1", new Font("Quicksand", 17), new SolidBrush(color: Color.Black), 180, starty + offset);
            offset = offset + 30;
            graphics.DrawString("Delivery: 1800 3456", new Font("Quicksand", 20, FontStyle.Bold), new SolidBrush(color: Color.Black), 290, starty + offset);
            offset = offset + 30;
            graphics.DrawString("Hotline: 0774 740 192", new Font("Quicksand", 20, FontStyle.Bold), new SolidBrush(color: Color.Black), 280, starty + offset);
            offset = offset + 65;
            graphics.DrawString("Thời Gian :", new Font("Quicksand", 15, FontStyle.Bold), new SolidBrush(color: Color.Black), 70, starty + offset);
            graphics.DrawString(date, new Font("Quicksand", 15), new SolidBrush(color: Color.Black), 185, starty + offset);
            graphics.DrawString("Số HĐ :", new Font("Quicksand", 15, FontStyle.Bold), new SolidBrush(color: Color.Black), 560, starty + offset);
            graphics.DrawString("HD" + id_order.ToString(), new Font("Quicksand", 15), new SolidBrush(color: Color.Black), 635, starty + offset);
            offset = offset + 40;
            graphics.DrawString("Thu Ngân :", new Font("Quicksand", 15, FontStyle.Bold), new SolidBrush(color: Color.Black), 70, starty + offset);
            graphics.DrawString(name_staff, new Font("Quicksand", 15), new SolidBrush(color: Color.Black), 185, starty + offset);
            graphics.DrawString("Bàn Số :", new Font("Quicksand", 15, FontStyle.Bold), new SolidBrush(color: Color.Black), 560, starty + offset);
            graphics.DrawString(tableName, new Font("Quicksand", 15), new SolidBrush(color: Color.Black), 650, starty + offset);
            offset = offset + 40;
            graphics.DrawString("Khách Hàng :", new Font("Quicksand", 15, FontStyle.Bold), new SolidBrush(color: Color.Black), 70, starty + offset);
            graphics.DrawString(username, new Font("Quicksand", 15), new SolidBrush(color: Color.Black), 210, starty + offset);
            offset = offset + 35;
            graphics.DrawString("------------------------------------------------------------------------------------", new Font("Quicksand", 15), new SolidBrush(color: Color.Black), 50, starty + offset);
            offset = offset + 25;
            graphics.DrawString("TT\t   Tên Món\t      SL\t    Đ.Giá\t   \tG.Giá\t T.Tiền", new Font("Quicksand", 15, FontStyle.Bold), new SolidBrush(color: Color.Black), 60, starty + offset);
            offset = offset + 25;
            graphics.DrawString("------------------------------------------------------------------------------------", new Font("Quicksand", 15), new SolidBrush(color: Color.Black), 50, starty + offset);
            offset = offset + 25;
            int x = 0;
            List<Order_Items> order_Items_List = DbOrderItem.order_Items_List(Convert.ToString(id_order));
            foreach (Order_Items item in order_Items_List)
            {
                ReadFormDataFile(item.item_detail);
                x = x + 1;
                quantity = item.quantity;
                graphics.DrawString(x.ToString(), new Font("Quicksand", 15), new SolidBrush(color: Color.Black), 65, starty + offset);
                if (item.title.Length < 14)
                {
                    graphics.DrawString(item.title, new Font("Quicksand", 13), new SolidBrush(color: Color.Black), 150, starty + offset);
                }
                else
                {
                    graphics.DrawString(item.title, new Font("Quicksand", 13), new SolidBrush(color: Color.Black), 100, starty + offset);
                }
                graphics.DrawString(item.quantity.ToString(), new Font("Quicksand", 14), new SolidBrush(color: Color.Black), 348, starty + offset);
                graphics.DrawString(string.Format("{0:#,##0} đ", item.price), new Font("Quicksand", 14), new SolidBrush(color: Color.Black), 412, starty + offset);
               
                    if (item.price_discount != 0)
                    {
                        graphics.DrawString(string.Format("{0:#,##0} đ", (item.price - item.price_discount)/item.quantity), new Font("Quicksand", 14), new SolidBrush(color: Color.Black), 555, starty + offset);
                        graphics.DrawString(string.Format("{0:#,##0} đ", item.price_discount ), new Font("Quicksand", 14), new SolidBrush(color: Color.Black), 650, starty + offset);
                    }
                    else
                    {
                        graphics.DrawString(string.Format("{0:#,##0} đ", 0), new Font("Quicksand", 14), new SolidBrush(color: Color.Black), 555, starty + offset);
                        graphics.DrawString(string.Format("{0:#,##0} đ", item.price_discount), new Font("Quicksand", 14), new SolidBrush(color: Color.Black), 650, starty + offset);
                    }
                offset = offset + 27;
                int length = str1.Count;
                if (length > 0)
                {
                    for (int i = 0; i < length; i++)
                    {
                        OptionName(str1[i], item.product_id.ToString(), item.quantity);
                        graphics.DrawString(string.Format("{0:#,##0}", option_name), new Font("Quicksand", 14), new SolidBrush(color: Color.Black), 150, starty + offset);
                        graphics.DrawString(string.Format("{0:#,##0}", option_price), new Font("Quicksand", 14), new SolidBrush(color: Color.Black), 412, starty + offset);
                        graphics.DrawString(string.Format("{0:#,##0}", Convert.ToDecimal(option_price) * quantity), new Font("Quicksand", 14), new SolidBrush(color: Color.Black), 650, starty + offset);
                        offset = offset + 25;
                    }
                }
                int length1 = str2.Count;
                if (length1 > 0)
                {
                    for (int i = 0; i < length; i++)
                    {
                        ToppingName(str2[i], item.quantity);
                        graphics.DrawString(string.Format("{0:#,##0}", topping_name), new Font("Quicksand", 14), new SolidBrush(color: Color.Black), 150, starty + offset);
                        graphics.DrawString(string.Format("{0:#,##0}", topping_price), new Font("Quicksand", 14), new SolidBrush(color: Color.Black), 412, starty + offset);
                        graphics.DrawString(string.Format("{0:#,##0}", Convert.ToDecimal(topping_price) * quantity), new Font("Quicksand", 14), new SolidBrush(color: Color.Black), 650, starty + offset);
                        offset = offset + 25;
                    }
                }
            }

            graphics.DrawString("------------------------------------------------------------------------------------", new Font("Quicksand", 15), new SolidBrush(color: Color.Black), 60, starty + offset);
            offset = offset + 25;
            graphics.DrawString("Thành Tiền :", new Font("Quicksand", 16, FontStyle.Bold), new SolidBrush(color: Color.Black), 190, starty + offset);
            graphics.DrawString(provisional, new Font("Quicksand", 16), new SolidBrush(color: Color.Black), 630, starty + offset);
            offset = offset + 25;
            graphics.DrawString("+ Tiền phiếu giảm giá :", new Font("Quicksand", 15), new SolidBrush(color: Color.Black), 220, starty + offset);
            graphics.DrawString(voucher_discount, new Font("Quicksand", 15), new SolidBrush(color: Color.Black), 630, starty + offset);
            offset = offset + 25;
            graphics.DrawString("------------------------------------------------------------------------------------", new Font("Quicksand", 15), new SolidBrush(color: Color.Black), 60, starty + offset);
            offset = offset + 25;
            graphics.DrawString("Shipping :", new Font("Quicksand", 16, FontStyle.Bold), new SolidBrush(color: Color.Black), 190, starty + offset);
            graphics.DrawString(shipping, new Font("Quicksand", 16), new SolidBrush(color: Color.Black), 630, starty + offset);
            offset = offset + 27;
            graphics.DrawString("Thanh Toán :", new Font("Quicksand", 16, FontStyle.Bold), new SolidBrush(color: Color.Black), 190, starty + offset);
            graphics.DrawString(grand_total, new Font("Quicksand", 16), new SolidBrush(color: Color.Black), 630, starty + offset);
            offset = offset + 25;
            graphics.DrawString("------------------------------------------------------------------------------------", new Font("Quicksand", 15), new SolidBrush(color: Color.Black), 60, starty + offset);
            offset = offset + 25;
            graphics.DrawString("+ Tiền mặt VNĐ :", new Font("Quicksand", 15), new SolidBrush(color: Color.Black), 220, starty + offset);
            graphics.DrawString(grand_total, new Font("Quicksand", 15), new SolidBrush(color: Color.Black), 630, starty + offset);
            offset = offset + 25;
            graphics.DrawString("------------------------------------------------------------------------------------", new Font("Quicksand", 15), new SolidBrush(color: Color.Black), 60, starty + offset);
            offset = offset + 30;
            graphics.DrawString("Giá Sản Phẩm Đã Bao Gồm ( VAT ) ", new Font("Quicksand", 16, FontStyle.Bold), new SolidBrush(color: Color.Black), 250, starty + offset);
            offset = offset + 30;
            graphics.DrawString("Password wifi : squirethecoffee", new Font("Quicksand", 15), new SolidBrush(color: Color.Black), 265, starty + offset);
        }

        private void dgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_order = dgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString();
            List<OrderShow2> orderList = DbOrder.LoadShowOrder(id_order);
            foreach (OrderShow2 item in orderList)
            {
                total = total + 1;
                if (item.user_name == "guest")
                {
                    username = "Khách Ngoài";
                }
                else
                {
                    username = item.user_name;
                }
                tableName = item.table_number.ToString();
                List<Staff> staffList = DbStaff.LoadInfomationStaff(item.staff_id.ToString());
                foreach (Staff item1 in staffList)
                {
                    name_staff = item1.first_name+" "+ item1.last_name;
                }
                date = item.created_at;
                provisional = string.Format("{0:#,##0}", item.subtotal);
                voucher_discount = string.Format("{0:#,##0}", item.voucher_discount);
                shipping = string.Format("{0:#,##0}", item.shipping);
                grand_total = string.Format("{0:#,##0}", item.grandtotal);
            }
            (printPreviewDialog1 as Form).WindowState = FormWindowState.Maximized;
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }
}
