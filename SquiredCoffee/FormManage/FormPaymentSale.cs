using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Nancy.Json;
using Newtonsoft.Json;
using SquiredCoffee.Class;
using SquiredCoffee.CustomControls;
using SquiredCoffee.DB;
using SquiredCoffee.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SquiredCoffee.FormManage
{
    public partial class FormPaymentSale : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "a9dcTERVqKjXumq650cZgtQelwv2uqFTmAejZjjj",
            BasePath = "https://koffeeholic-75e48-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;

        private readonly FormSale _parent;
        public string provisional;
        public int id_order;
        public int id_staff;
        public string name_staff;
        public string tableName;
        FormScannerBarCode Form;
        FormCheckUser Form1;
        FormInvoice Form2;
        public string type;
        public string mode;
        public decimal shipping;
        public decimal kq;
        public int quantity;
        public string option_name;
        public string option_price;
        public string topping_name;
        public string topping_price;
        public string id_transaction;
        public int x = 0;
        List<int> str1 = new List<int>();
        List<int> str2 = new List<int>();
        public FormPaymentSale(FormSale parent)
        {
            _parent = parent;
            InitializeComponent();
            Form = new FormScannerBarCode(this);
            Form1 = new FormCheckUser(this);
            Form2 = new FormInvoice(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            id_transaction = "";
            this.Close();
            _parent.clearOrder1();
            _parent.LoadOrderItem();
        }

        public void Enabled(bool x)
        {
            txtMoneyCustomer.Enabled = x;
            txtExcessCash.Enabled = x;
            txtTotal.Enabled = x;
            txtExcessCash.Text = "";
            txtMoneyCustomer.Text = "";
            txtTotal.Text = "";
        }

        private void btnMethod1_Click(object sender, EventArgs e)
        {
            btnMethod1.BackColor = Color.FromArgb(255, 153, 0);
            btnMethod2.BackColor = Color.FromArgb(128, 128, 255);
            btnMethod3.BackColor = Color.FromArgb(128, 128, 255);
            Enabled(true);
            txtTotal.Text = lblIntoMoney.Text;
            type = "cash";
        }

        private void btnMethod2_Click(object sender, EventArgs e)
        {
            btnMethod2.BackColor = Color.FromArgb(255, 153, 0);
            btnMethod1.BackColor = Color.FromArgb(128, 128, 255);
            btnMethod3.BackColor = Color.FromArgb(128, 128, 255);
            txtTotal.Text = lblIntoMoney.Text;
            txtTotal.Enabled = true;
            type = "payment transfer";
        }

        private void btnMethod3_Click(object sender, EventArgs e)
        {
            btnMethod3.BackColor = Color.FromArgb(255, 153, 0);
            btnMethod2.BackColor = Color.FromArgb(128, 128, 255);
            btnMethod1.BackColor = Color.FromArgb(128, 128, 255);
            txtTotal.Text = lblIntoMoney.Text;
            txtTotal.Enabled = true;
            type = "payment transfer";
        }


        public void Total()
        {
            double y = (Convert.ToDouble(shipping) + Convert.ToDouble(lblProvisional.Text)) - Convert.ToDouble(lblMoneyReduced.Text);
            lblIntoMoney.Text = string.Format("{0:#,##0}", Convert.ToDecimal(y));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Total();
        }

        private void FormPaymentSale_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
            Enabled(false);
            lblShipping.Text = string.Format("{0:#,##0} ", shipping);
            //lblDiscount.Text = Form.discount.ToString();
            double x = Convert.ToDouble(provisional);
            lblProvisional.Text = string.Format("{0:#,##0} ", x);
            Timer timer = new Timer();
            timer.Interval = (1 * 450); // 1 secs
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
            btnPrintBill.Enabled = false;
            btnPlusPoint.Enabled = false;
        }

        public void excessCash()
        {
            if (txtMoneyCustomer.Text == "")
            {
                txtExcessCash.Text = "";
            }
            else
            {
                double x = Convert.ToDouble(txtMoneyCustomer.Text) - Convert.ToDouble(txtTotal.Text);
                txtExcessCash.Text = string.Format("{0:#,##0}", x);
            }
        }


        public void Voucher(int discount)
        {
            double x = (Convert.ToDouble(lblProvisional.Text) * discount) / 100;
            lblDiscount.Text = discount.ToString();
            lblMoneyReduced.Text = string.Format("{0:#,##0}", x);
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            btnCancelOrder.Enabled = false;
            btnPrintBill.Enabled = true;
            btnPlusPoint.Enabled = true;
            if (txtExcessCash.Enabled == true)
            {
                excessCash();
            }
            if (mode == "offline")
            {
                List<Order> orders = DbOrder.LoadOrderUpdate(id_order.ToString());
                foreach (Order item in orders)
                {
                    kq = (Convert.ToDecimal(provisional) + item.shipping + item.shipping_discount) - Convert.ToDecimal(lblMoneyReduced.Text);
                    Order std = new Order(tableName, item.staff_id, item.user_id, item.address_id, Convert.ToDecimal(provisional), Convert.ToDecimal(lblMoneyReduced.Text), item.shipping_discount, item.shipping, item.promo, kq, item.content, 1);
                    DbOrder.UpdateOrder(std, id_order.ToString());
                    List<Trannsaction> transactions = DbTransaction.LoadTransaction(id_order.ToString());
                    foreach (Trannsaction item1 in transactions)
                    {
                        Trannsaction std1 = new Trannsaction(item1.user_id,item1.token, item1.order_id, item1.code, type, item1.mode, item1.delivery_method, item1.content, "success");
                        DbTransaction.UpdateTransaction(std1, item1.id.ToString());
                    }
                }
            }
            else
            {
                List<Order> orders = DbOrder.LoadOrderUpdate(id_order.ToString());
                foreach (Order item in orders)
                {
                    kq = (Convert.ToDecimal(provisional) + item.shipping + item.shipping_discount) - Convert.ToDecimal(lblMoneyReduced.Text);
                    Order std = new Order(tableName, item.staff_id, item.user_id, item.address_id, Convert.ToDecimal(provisional), Convert.ToDecimal(lblMoneyReduced.Text), item.shipping_discount, item.shipping, item.promo, kq, item.content, 1);
                    DbOrder.UpdateOrder(std, id_order.ToString());
                    List<Trannsaction> transactions = DbTransaction.LoadTransaction(id_order.ToString());
                    foreach (Trannsaction item1 in transactions)
                    {
                        id_transaction = item1.id.ToString();
                        Trannsaction std1 = new Trannsaction(item1.user_id, item1.token, item1.order_id, item1.code, item1.type, item1.mode, "delivery", item1.content, "shipping");
                        DbTransaction.UpdateTransaction(std1, item1.id.ToString());
                    }
                }
               SendPushNotification(id_transaction);
            }
            _parent.clearOrder();
            _parent.LoadOrderItem();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (txtMoneyCustomer.Enabled == true)
            {
                string x = txtMoneyCustomer.Text + "7";
                txtMoneyCustomer.Text = string.Format("{0:#,##0}", Convert.ToDouble(x));
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (txtMoneyCustomer.Enabled == true)
            {
                string x = txtMoneyCustomer.Text + "8";
                txtMoneyCustomer.Text = string.Format("{0:#,##0}", Convert.ToDouble(x));
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (txtMoneyCustomer.Enabled == true)
            {
                string x = txtMoneyCustomer.Text + "9";
                txtMoneyCustomer.Text = string.Format("{0:#,##0}", Convert.ToDouble(x));
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (txtMoneyCustomer.Enabled == true)
            {
                string x = txtMoneyCustomer.Text + "4";
                txtMoneyCustomer.Text = string.Format("{0:#,##0}", Convert.ToDouble(x));
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (txtMoneyCustomer.Enabled == true)
            {
                string x = txtMoneyCustomer.Text + "5";
                txtMoneyCustomer.Text = string.Format("{0:#,##0}", Convert.ToDouble(x));
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (txtMoneyCustomer.Enabled == true)
            {
                string x = txtMoneyCustomer.Text + "6";
                txtMoneyCustomer.Text = string.Format("{0:#,##0}", Convert.ToDouble(x));
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (txtMoneyCustomer.Enabled == true)
            {
                string x = txtMoneyCustomer.Text + "1";
                txtMoneyCustomer.Text = string.Format("{0:#,##0}", Convert.ToDouble(x));
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (txtMoneyCustomer.Enabled == true)
            {
                string x = txtMoneyCustomer.Text + "2";
                txtMoneyCustomer.Text = string.Format("{0:#,##0}", Convert.ToDouble(x));
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (txtMoneyCustomer.Enabled == true)
            {
                string x = txtMoneyCustomer.Text + "3";
                txtMoneyCustomer.Text = string.Format("{0:#,##0}", Convert.ToDouble(x));
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (txtMoneyCustomer.Text.Length == 0)
            {
                txtMoneyCustomer.Text = "";
            }
            else
            {
                txtMoneyCustomer.Text = txtMoneyCustomer.Text.Remove(txtMoneyCustomer.Text.Length - 1, 1);
            }
        }

        public void ReadFormDataFile(string fileLocation)
        {
            ItemDetail itemDetail = JsonConvert.DeserializeObject<ItemDetail>(fileLocation);
            str1 = itemDetail.options;
            str2 = itemDetail.toppings;
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            txtMoneyCustomer.Text = string.Empty;
        }

        private void btnPrintBill_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            (printPreviewDialog1 as Form).WindowState = FormWindowState.Maximized;
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
            id_transaction = "";
            this.Close();
            //Form2.tableName = tableName;
            //Form2.name_staff = name_staff;
            //Form2.id_order = id_order;
            //Form2.total = lblProvisional.Text;
            //Form2.total_voucher = lblMoneyReduced.Text;
            //Form2.payment = txtTotal.Text;
            //Form2.take = txtMoneyCustomer.Text;
            //Form2.excess_cash = txtExcessCash.Text;
            //Form2.ShowDialog();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (txtMoneyCustomer.Enabled == true)
            {
                string x = txtMoneyCustomer.Text + "0";
                txtMoneyCustomer.Text = string.Format("{0:#,##0}", Convert.ToDouble(x));
            }
        }

        private void btn00_Click(object sender, EventArgs e)
        {
            if (txtMoneyCustomer.Enabled == true)
            {
                string x = txtMoneyCustomer.Text + "00";
                txtMoneyCustomer.Text = string.Format("{0:#,##0}", Convert.ToDouble(x));
            }
        }

        private void btn000_Click(object sender, EventArgs e)
        {
            if (txtMoneyCustomer.Enabled == true)
            {
                string x = txtMoneyCustomer.Text + "000";
                txtMoneyCustomer.Text = string.Format("{0:#,##0}", Convert.ToDouble(x));
            }
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (mode == "offline")
            {
                List<Order> orders = DbOrder.LoadOrderUpdate(id_order.ToString());
                foreach (Order item in orders)
                {
                    decimal kq = (Convert.ToDecimal(provisional) + item.shipping + item.shipping_discount) - Convert.ToDecimal(lblMoneyReduced.Text);
                    Order std = new Order(tableName, item.staff_id, item.user_id, item.address_id, Convert.ToDecimal(provisional), Convert.ToDecimal(lblMoneyReduced.Text), item.shipping_discount, item.shipping, item.promo, kq, item.content, 1);
                    DbOrder.UpdateOrder(std, id_order.ToString());
                    List<Trannsaction> transactions = DbTransaction.LoadTransaction(id_order.ToString());
                    foreach (Trannsaction item1 in transactions)
                    {
                        Trannsaction std1 = new Trannsaction(item1.user_id, item1.token, item1.order_id, item1.code, type, item1.mode, item1.delivery_method, item1.content, "cancelled");
                        DbTransaction.UpdateTransaction(std1, item1.id.ToString());
                    }
                }
                this.Close();
            }
            else
            {
                List<Order> orders = DbOrder.LoadOrderUpdate(id_order.ToString());
                foreach (Order item in orders)
                {
                    decimal kq = (Convert.ToDecimal(provisional) + item.shipping + item.shipping_discount) - Convert.ToDecimal(lblMoneyReduced.Text);
                    Order std = new Order(tableName, item.staff_id, item.user_id, item.address_id, Convert.ToDecimal(provisional), Convert.ToDecimal(lblMoneyReduced.Text), item.shipping_discount, item.shipping, item.promo, kq, item.content, 1);
                    DbOrder.UpdateOrder(std, id_order.ToString());
                    List<Trannsaction> transactions = DbTransaction.LoadTransaction(id_order.ToString());
                    foreach (Trannsaction item1 in transactions)
                    {
                        Trannsaction std1 = new Trannsaction(item1.user_id, item1.token, item1.order_id, item1.code, item1.type, item1.mode, "delivery", item1.content, "cancelled");
                        DbTransaction.UpdateTransaction(std1, item1.id.ToString());
                    }
                }
                this.Close();
            }
            _parent.clearOrder();
            _parent.LoadOrderItem();
        }

        private void btnPlusPoint_Click(object sender, EventArgs e)
        {
            FormBackGround formBackGround = new FormBackGround();
            try
            {
                using (FormCheckUser Form = new FormCheckUser(this))
                {
                    formBackGround.StartPosition = FormStartPosition.Manual;
                    formBackGround.FormBorderStyle = FormBorderStyle.None;
                    formBackGround.Opacity = .70d;
                    formBackGround.BackColor = Color.Black;
                    formBackGround.WindowState = FormWindowState.Maximized;
                    formBackGround.TopMost = true;
                    formBackGround.Location = this.Location;
                    formBackGround.ShowInTaskbar = false;
                    formBackGround.Show();

                    Form.Owner = formBackGround;
                    Form.total = kq;
                    this.Hide();
                    Form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                formBackGround.Dispose();
            }
            Form1.total = kq;
            this.Hide();
            Form1.ShowDialog();
        }

        private void btnVoucher_Click(object sender, EventArgs e)
        {
            FormBackGround formBackGround = new FormBackGround();
            try
            {
                using (FormScannerBarCode Form = new FormScannerBarCode(this))
                {
                    formBackGround.StartPosition = FormStartPosition.Manual;
                    formBackGround.FormBorderStyle = FormBorderStyle.None;
                    formBackGround.Opacity = .70d;
                    formBackGround.BackColor = Color.Black;
                    formBackGround.WindowState = FormWindowState.Maximized;
                    formBackGround.TopMost = true;
                    formBackGround.Location = this.Location;
                    formBackGround.ShowInTaskbar = false;
                    formBackGround.Show();

                    Form.Owner = formBackGround;
                    Form.quantity = quantity;
                    Form.total = Convert.ToDecimal(provisional);
                    this.Hide();
                    Form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                formBackGround.Dispose();
            }
           
        }


        public async void notification()
        {
            var token = "fTmPozwiQeiDUIeLK-ofgE:APA91bFjFsINh6kbm_PuPWHRFY0M9XiR5S2Dt3lg-jeCdRgn24B0qRGj23tMkw44UAWHYfQC0MEKoKSpHv2ot5kyS1s_iCel09Ff80keHZskqT_vSgKMnHRYt-liJatnDrtNJyhIhSgg";
            var data = new NotificationTransaction
            {
               
                id = id_order.ToString(),
                mode = mode,
                delivery_method = "delivery",
                status = "shipping"
            };
            SetResponse response = await client.SetAsync("notification_transaction", data);
            SetResponse response1 = await client.SetAsync("token", token);
        }


        private static string SendPushNotification(string id_transaction)
        {
            string response;

            try
            {
                // From: https://console.firebase.google.com/project/x.y.z/settings/general/android:x.y.z

                // Projekt-ID: x.y.z
                // Web-API-Key: A...Y (39 chars)
                // App-ID: 1:...:android:...

                // From https://console.firebase.google.com/project/x.y.z/settings/
                // cloudmessaging/android:x,y,z
                // Server-Key: AAAA0...    ...._4

                string serverKey = "AAAAxsx2lx8:APA91bHFQHpVrA3Mchy07X8oesMssw0mLx0mUFahdhumYy7s5kqM7PvLXLgfZruzKx8H8ps_j6QSX0jDn50UXfkfzFTykgQJO4Hw_j0Y7HzZoOjvBg3IspJm-DTS7PajmFWogib0kMJH"; // Something very long
                string senderId = "853833848607";
                string deviceId = "fTmPozwiQeiDUIeLK-ofgE:APA91bFjFsINh6kbm_PuPWHRFY0M9XiR5S2Dt3lg-jeCdRgn24B0qRGj23tMkw44UAWHYfQC0MEKoKSpHv2ot5kyS1s_iCel09Ff80keHZskqT_vSgKMnHRYt-liJatnDrtNJyhIhSgg"; // Also something very long, 
                                                                                                                                                                                                         // got from android
                                                                                                                                                                                                         //string deviceId = "/topics/all";               // Use this to notify all devices, 
                                                                                                                                                                                                         // but App must be subscribed to 
                                                                                                                                                                                                         // topic notification
                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");

                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                var dataBase = new
                {
                    to = deviceId,
                    notification = new
                    {
                        title = "Trạng thái đơn hàng của bạn : Đã được tiếp nhận và đang xử lý !!!",
                        body = "Đơn hàng của bạn đã được tiếp nhận và đang xử lý , các trạng thái tiếp theo của đơn hàng sẽ được cập nhật đến bạn . ",
                        sound = "default"
                    },
                    data = new
                    {
                        mode = "online",
                        delivery_method = "delivery",
                        status = "shipping",
                        transaction_id = id_transaction
                    }
                };

                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(dataBase);
                Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                tRequest.Headers.Add(string.Format("Authorization: key={0}", serverKey));
                tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                tRequest.ContentLength = byteArray.Length;

                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                response = sResponseFromServer;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }

            return response;
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
            graphics.DrawString(DateTime.Now.ToString("HH:mm:ss / dd.MM.yyyy"), new Font("Quicksand", 15), new SolidBrush(color: Color.Black), 185, starty + offset);
            graphics.DrawString("Số HĐ :", new Font("Quicksand", 15, FontStyle.Bold), new SolidBrush(color: Color.Black), 560, starty + offset);
            graphics.DrawString("HD" + id_order.ToString(), new Font("Quicksand", 15), new SolidBrush(color: Color.Black), 635, starty + offset);
            offset = offset + 40;
            graphics.DrawString("Thu Ngân :", new Font("Quicksand", 15, FontStyle.Bold), new SolidBrush(color: Color.Black), 70, starty + offset);
            graphics.DrawString(name_staff, new Font("Quicksand", 15), new SolidBrush(color: Color.Black), 185, starty + offset);
            graphics.DrawString("Bàn Số :", new Font("Quicksand", 15, FontStyle.Bold), new SolidBrush(color: Color.Black), 560, starty + offset);
            graphics.DrawString(tableName, new Font("Quicksand", 15), new SolidBrush(color: Color.Black), 650, starty + offset);
            offset = offset + 40;
            graphics.DrawString("Khách Hàng :", new Font("Quicksand", 15, FontStyle.Bold), new SolidBrush(color: Color.Black), 70, starty + offset);
            graphics.DrawString("Lộc Phúc", new Font("Quicksand", 15), new SolidBrush(color: Color.Black), 210, starty + offset);
            offset = offset + 35;
            graphics.DrawString("------------------------------------------------------------------------------------", new Font("Quicksand", 15), new SolidBrush(color: Color.Black), 50, starty + offset);
            offset = offset + 25;
            graphics.DrawString("TT\t   Tên Món\t      SL\t    Đ.Giá\t   \tG.Giá\t T.Tiền", new Font("Quicksand", 15, FontStyle.Bold), new SolidBrush(color: Color.Black), 60, starty + offset);
            offset = offset + 25;
            graphics.DrawString("------------------------------------------------------------------------------------", new Font("Quicksand", 15), new SolidBrush(color: Color.Black), 50, starty + offset);
            offset = offset + 25;
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
                graphics.DrawString(string.Format("{0:#,##0}", item.price), new Font("Quicksand", 14), new SolidBrush(color: Color.Black), 412, starty + offset);
                List<Discount> discounts = DbDiscount.LoadDiscountList(DateTime.Now.ToString("yyyy-MM-dd"));
                foreach (Discount item1 in discounts)
                {
                    string k = Convert.ToString(item.product_id);
                    if (item1.product.Contains(k) == true)
                    {
                        decimal discount = (item.quantity * item.price * Convert.ToDecimal(item1.discount)) / 100;
                        graphics.DrawString(string.Format("{0:#,##0}", discount), new Font("Quicksand", 14), new SolidBrush(color: Color.Black), 555, starty + offset);
                        graphics.DrawString(string.Format("{0:#,##0}", (item.price * item.quantity) - discount), new Font("Quicksand", 14), new SolidBrush(color: Color.Black), 650, starty + offset);
                    }
                    else
                    {
                        graphics.DrawString(string.Format("{0:#,##0}", 0), new Font("Quicksand", 14), new SolidBrush(color: Color.Black), 555, starty + offset);
                        graphics.DrawString(string.Format("{0:#,##0}", (item.price * item.quantity) - 0), new Font("Quicksand", 14), new SolidBrush(color: Color.Black), 650, starty + offset);
                    }
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
            graphics.DrawString(lblProvisional.Text, new Font("Quicksand", 16), new SolidBrush(color: Color.Black), 630, starty + offset);
            offset = offset + 25;
            graphics.DrawString("+ Tiền phiếu giảm giá :", new Font("Quicksand", 15), new SolidBrush(color: Color.Black), 220, starty + offset);
            graphics.DrawString(lblMoneyReduced.Text, new Font("Quicksand", 15), new SolidBrush(color: Color.Black), 630, starty + offset);
            offset = offset + 25;
            graphics.DrawString("------------------------------------------------------------------------------------", new Font("Quicksand", 15), new SolidBrush(color: Color.Black), 60, starty + offset);
            offset = offset + 25;
            graphics.DrawString("Shipping :", new Font("Quicksand", 16, FontStyle.Bold), new SolidBrush(color: Color.Black), 190, starty + offset);
            graphics.DrawString(lblShipping.Text, new Font("Quicksand", 16), new SolidBrush(color: Color.Black), 630, starty + offset);
            offset = offset + 27;
            graphics.DrawString("Thanh Toán :", new Font("Quicksand", 16, FontStyle.Bold), new SolidBrush(color: Color.Black), 190, starty + offset);
            graphics.DrawString(lblIntoMoney.Text, new Font("Quicksand", 16), new SolidBrush(color: Color.Black), 630, starty + offset);
            offset = offset + 27;
            graphics.DrawString("Tiền Khách Đưa :", new Font("Quicksand", 16, FontStyle.Bold), new SolidBrush(color: Color.Black), 190, starty + offset);
            graphics.DrawString(txtMoneyCustomer.Text, new Font("Quicksand", 16), new SolidBrush(color: Color.Black), 630, starty + offset);
            offset = offset + 27;
            graphics.DrawString("Tiền Thừa :", new Font("Quicksand", 16, FontStyle.Bold), new SolidBrush(color: Color.Black), 190, starty + offset);
            graphics.DrawString(txtExcessCash.Text, new Font("Quicksand", 16), new SolidBrush(color: Color.Black), 630, starty + offset);
            offset = offset + 25;
            graphics.DrawString("------------------------------------------------------------------------------------", new Font("Quicksand", 15), new SolidBrush(color: Color.Black), 60, starty + offset);
            offset = offset + 25;
            graphics.DrawString("+ Tiền mặt VNĐ :", new Font("Quicksand", 15), new SolidBrush(color: Color.Black), 220, starty + offset);
            graphics.DrawString(lblIntoMoney.Text, new Font("Quicksand", 15), new SolidBrush(color: Color.Black), 630, starty + offset);
            offset = offset + 25;
            graphics.DrawString("------------------------------------------------------------------------------------", new Font("Quicksand", 15), new SolidBrush(color: Color.Black), 60, starty + offset);
            offset = offset + 30;
            graphics.DrawString("Giá Sản Phẩm Đã Bao Gồm ( VAT ) ", new Font("Quicksand", 16, FontStyle.Bold), new SolidBrush(color: Color.Black), 250, starty + offset);
            offset = offset + 30;
            graphics.DrawString("Password wifi : squirethecoffee", new Font("Quicksand", 15), new SolidBrush(color: Color.Black), 265, starty + offset);
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
}
