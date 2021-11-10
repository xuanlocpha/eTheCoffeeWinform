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
    public partial class FormPaymentSale : Form
    {
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
            Enabled(false);
        }

        private void btnMethod3_Click(object sender, EventArgs e)
        {
            btnMethod3.BackColor = Color.FromArgb(255, 153, 0);
            btnMethod2.BackColor = Color.FromArgb(128, 128, 255);
            btnMethod1.BackColor = Color.FromArgb(128, 128, 255);
            Enabled(false);
        }


        public void Total()
        {
            double y = (Convert.ToDouble(shipping) + Convert.ToDouble(lblProvisional.Text)) - Convert.ToDouble(lblMoneyReduced.Text);
            lblIntoMoney.Text = string.Format("{0:#,##0}",Convert.ToDecimal(y));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Total();
        }

        private void FormPaymentSale_Load(object sender, EventArgs e)
        {
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
                        Trannsaction std1 = new Trannsaction(item1.user_id, item1.order_id, item1.code, type, item1.mode, item1.delivery_method, item1.content, "success");
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
                        Trannsaction std1 = new Trannsaction(item1.user_id, item1.order_id, item1.code, item1.type, item1.mode, "delivery", item1.content, "shipping");
                        DbTransaction.UpdateTransaction(std1, item1.id.ToString());
                    }
                }
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
                txtMoneyCustomer.Text = string.Format("{0:#,##0}",Convert.ToDouble(x));
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

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            txtMoneyCustomer.Text = string.Empty;
        }

        private void btnPrintBill_Click(object sender, EventArgs e)
        {
            Form2.tableName = tableName;
            Form2.name_staff = name_staff;
            Form2.id_order = id_order;
            Form2.total = lblProvisional.Text;
            Form2.total_voucher = lblMoneyReduced.Text;
            Form2.payment = txtTotal.Text;
            Form2.take = txtMoneyCustomer.Text;
            Form2.excess_cash = txtExcessCash.Text;
            Form2.ShowDialog();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (txtMoneyCustomer.Enabled == true)
            {
                string x = txtMoneyCustomer.Text + "0";
                txtMoneyCustomer.Text = string.Format("{0:#,##0}",Convert.ToDouble(x));
            }
        }

        private void btn00_Click(object sender, EventArgs e)
        {
            if (txtMoneyCustomer.Enabled == true)
            {
                string x = txtMoneyCustomer.Text + "00";
                txtMoneyCustomer.Text = string.Format("{0:#,##0}",Convert.ToDouble(x));
            }
        }

        private void btn000_Click(object sender, EventArgs e)
        {
            if (txtMoneyCustomer.Enabled == true)
            {
                string x = txtMoneyCustomer.Text + "000";
                txtMoneyCustomer.Text = string.Format("{0:#,##0}",Convert.ToDouble(x));
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
                        Trannsaction std1 = new Trannsaction(item1.user_id, item1.order_id, item1.code, type, item1.mode, item1.delivery_method, item1.content, "cancelled");
                        DbTransaction.UpdateTransaction(std1, item1.id.ToString());
                    }
                }
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
                        Trannsaction std1 = new Trannsaction(item1.user_id, item1.order_id, item1.code, item1.type, item1.mode, "delivery", item1.content, "cancelled");
                        DbTransaction.UpdateTransaction(std1, item1.id.ToString());
                    }
                }
            }
            _parent.clearOrder();
            _parent.LoadOrderItem();
        }

        private void btnPlusPoint_Click(object sender, EventArgs e)
        {
            Form1.total = kq;
            this.Hide();
            Form1.ShowDialog();
        }

        private void btnVoucher_Click(object sender, EventArgs e)
        {
            Form.quantity = quantity;
            Form.total = Convert.ToDecimal(provisional);
            this.Hide();
            Form.ShowDialog();
        }
    }
}
