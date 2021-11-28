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
    public partial class FormInputTableNumber : Form
    {
        private readonly FormSale _parent;
        public string table_number;
        public int staff_id;
        FormError Form2;
        public FormInputTableNumber(FormSale parent)
        {
            _parent = parent;
            InitializeComponent();
            Form2 = new FormError(); 
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtTableNumber.Text = txtTableNumber.Text + "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtTableNumber.Text = txtTableNumber.Text + "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtTableNumber.Text = txtTableNumber.Text + "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtTableNumber.Text = txtTableNumber.Text + "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtTableNumber.Text = txtTableNumber.Text + "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtTableNumber.Text = txtTableNumber.Text + "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtTableNumber.Text = txtTableNumber.Text + "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtTableNumber.Text = txtTableNumber.Text + "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtTableNumber.Text = txtTableNumber.Text + "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtTableNumber.Text = txtTableNumber.Text + "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtTableNumber.Text = string.Empty;
        }

        public void clear()
        {
            txtTableNumber.Text = string.Empty;
        }

        

        private void btnSave_Click(object sender, EventArgs e)
        {

            table_number = txtTableNumber.Text;
           
            if (table_number == "")
            {
                Form2.title = "Số Bàn Đang Trống !";
                Form2.ShowDialog();
                txtTableNumber.Text = string.Empty;
                return;
            }
            else if ((DbOrder.CheckDb(table_number)) == true)
            {
                Form2.title = "Bàn Đã Có Order !";
                Form2.ShowDialog();
                txtTableNumber.Text = string.Empty;
                return;
            } 
            else
            {
                Order std = new Order(table_number,staff_id,18,2,0,0,0,0,"",0,"",0);
                DbOrder.AddOrder(std);
                _parent.tableNumber = table_number;
                _parent.clear();
                clear();
                List<Order> order_List = DbOrder.LoadOrder(table_number);
                foreach (Order item in order_List)
                {
                    _parent.id_order = item.id.ToString();
                    string x = "#000000" + item.id.ToString();
                    Trannsaction std1 = new Trannsaction(18,item.id, x,"cash", "offline", "pickup", "", "packing");
                    DbTransaction.AddTransaction(std1);
                }
                
                this.Close();
            }
        }

        private void FormInputTableNumber_Load(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clear();
        }


        private void pbClosse_click(object sender, EventArgs e)
        {
            clear();
            this.Close();
        }
    }
}
