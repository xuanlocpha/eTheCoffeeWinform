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
    public partial class FormPayment : Form
    {
        private readonly FormStaff _parent;
        public string provisional;
        public int id_order;
        public int id_staff;
        public string tableName;
        
        public FormPayment(FormStaff parent)
        {
            _parent = parent;
            InitializeComponent();
        }

      

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMethod1_Click(object sender, EventArgs e)
        {

        }

        private void btnMethod2_Click(object sender, EventArgs e)
        {

        }

        private void btnMethod3_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnMethod1_Click_1(object sender, EventArgs e)
        {
            btnMethod1.BackColor = Color.FromArgb(255, 153, 0);
            btnMethod2.BackColor = Color.FromArgb(128, 128, 255);
            btnMethod3.BackColor = Color.FromArgb(128, 128, 255);
            Enabled(true);
            txtTotal.Text = lblMoneyReduced.Text;
        }

        private void btnMethod2_Click_1(object sender, EventArgs e)
        {
            btnMethod2.BackColor = Color.FromArgb(255, 153, 0);
            btnMethod1.BackColor = Color.FromArgb(128, 128, 255);
            btnMethod3.BackColor = Color.FromArgb(128, 128, 255);
            Enabled(false);
            
        }

        private void btnMethod3_Click_1(object sender, EventArgs e)
        {
            btnMethod3.BackColor = Color.FromArgb(255, 153, 0);
            btnMethod2.BackColor = Color.FromArgb(128, 128, 255);
            btnMethod1.BackColor = Color.FromArgb(128, 128, 255);
            Enabled(false);
        }
        public void excessCash()
        {
            if(txtMoneyCustomer.Text == "")
            {
                txtExcessCash.Text = "";
            }
            else
            {
                double x = Convert.ToDouble(txtMoneyCustomer.Text) - Convert.ToDouble(txtTotal.Text);
                txtExcessCash.Text = string.Format("{0:#,##0}", x);
            }     
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if(txtMoneyCustomer.Enabled == true)
            {
                txtMoneyCustomer.Text = txtMoneyCustomer.Text + "7";
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (txtMoneyCustomer.Enabled == true)
            {
                txtMoneyCustomer.Text = txtMoneyCustomer.Text + "8";
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (txtMoneyCustomer.Enabled == true)
            {
                txtMoneyCustomer.Text = txtMoneyCustomer.Text + "9";
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (txtMoneyCustomer.Enabled == true)
            {
                txtMoneyCustomer.Text = txtMoneyCustomer.Text + "4";
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (txtMoneyCustomer.Enabled == true)
            {
                txtMoneyCustomer.Text = txtMoneyCustomer.Text + "5";
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (txtMoneyCustomer.Enabled == true)
            {
                txtMoneyCustomer.Text = txtMoneyCustomer.Text + "6";
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (txtMoneyCustomer.Enabled == true)
            {
                txtMoneyCustomer.Text = txtMoneyCustomer.Text + "3";
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (txtMoneyCustomer.Enabled == true)
            {
                txtMoneyCustomer.Text = txtMoneyCustomer.Text + "2";
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (txtMoneyCustomer.Enabled == true)
            {
                txtMoneyCustomer.Text = txtMoneyCustomer.Text + "1";
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (txtMoneyCustomer.Enabled == true)
            {
                txtMoneyCustomer.Text = txtMoneyCustomer.Text + "0";
            }
        }

        private void btn00_Click(object sender, EventArgs e)
        {
            if (txtMoneyCustomer.Enabled == true)
            {
                txtMoneyCustomer.Text = txtMoneyCustomer.Text + "00";
            }
        }

        private void btn000_Click(object sender, EventArgs e)
        {
            if (txtMoneyCustomer.Enabled == true)
            {
                txtMoneyCustomer.Text = txtMoneyCustomer.Text + "000";
            }
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            txtMoneyCustomer.Text = string.Empty;
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

        private void txtMoneyCustomer_TextChanged(object sender, EventArgs e)
        {
            if(txtMoneyCustomer.Text.Length == 0)
            {
                txtMoneyCustomer.Text = "";
            }
            else
            {
                txtMoneyCustomer.Text = string.Format("{0:#,##0}", double.Parse(txtMoneyCustomer.Text));
            }
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

        private void FormPayment_Load(object sender, EventArgs e)
        {
            lblTableName.Text = tableName;
            Enabled(false);
            double x = Convert.ToDouble(provisional);
            lblProvisional.Text = string.Format("{0:#,##0}",x);
            Timer timer = new Timer();
            timer.Interval = (1 * 450); // 1 secs
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (txtExcessCash.Enabled == true)
            {
                excessCash();
            }   
        }

        private void btn5K_Click(object sender, EventArgs e)
        {
            if (txtMoneyCustomer.Enabled == true)
            {
                txtMoneyCustomer.Text = txtMoneyCustomer.Text + "5000";
            }
        }

        private void btn20K_Click(object sender, EventArgs e)
        {
            if (txtMoneyCustomer.Enabled == true)
            {
                txtMoneyCustomer.Text = txtMoneyCustomer.Text + "20000";
            }
        }

        private void btn30K_Click(object sender, EventArgs e)
        {
            if (txtMoneyCustomer.Enabled == true)
            {
                txtMoneyCustomer.Text = txtMoneyCustomer.Text + "30000";
            }
        }

        private void btn50K_Click(object sender, EventArgs e)
        {
            if (txtMoneyCustomer.Enabled == true)
            {
                txtMoneyCustomer.Text = txtMoneyCustomer.Text + "50000";
            }
        }

        private void btn100K_Click(object sender, EventArgs e)
        {
            if (txtMoneyCustomer.Enabled == true)
            {
                txtMoneyCustomer.Text = txtMoneyCustomer.Text + "100000";
            }
        }

        private void btn200K_Click(object sender, EventArgs e)
        {
            if (txtMoneyCustomer.Enabled == true)
            {
                txtMoneyCustomer.Text = txtMoneyCustomer.Text + "200000";
            }
        }

        private void btn500K_Click(object sender, EventArgs e)
        {
            if (txtMoneyCustomer.Enabled == true)
            {
                txtMoneyCustomer.Text = txtMoneyCustomer.Text + "500000";
            }
        }

        
        public void Voucher()
        {
            double x = (Convert.ToDouble(lblProvisional.Text) * Convert.ToDouble(lblDiscount.Text)) / 100;
            lblMoneyReduced.Text = string.Format("{0:#,##0}", x);
        }

        public void Total()
        {
            double y = Convert.ToDouble(lblProvisional.Text) - Convert.ToDouble(lblMoneyReduced.Text);
            lblIntoMoney.Text = string.Format("{0:#,##0}", y);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Voucher();
            Total();
        }
    }
}
