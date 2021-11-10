using MySql.Data.MySqlClient;
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
    public partial class FormAddDiscount : Form
    {
        MySqlConnection con = new MySqlConnection();
        //public static UC_ManageDiscount _parent;
        public int status = 1;
        public FormAddDiscount(/*UC_ManageDiscount parent*/)
        {
            InitializeComponent();
            //_parent = parent;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        void ketnoi()
        {
            con.ConnectionString = "datasource=localhost;port=3306;username=root;password=;database=coffeeshop";
            if (con.State == ConnectionState.Closed)
                con.Open();
        }

        public DataSet LoadDB(string sql)
        {
            ketnoi();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
            da.Fill(ds);
            return ds;
        }

        void ListDiscount()
        {
            string sql = "SELECT * FROM products";
            DataSet ListCategory = new DataSet();
            ListCategory = LoadDB(sql);
            cbDiscount.DataSource = ListCategory.Tables[0];
            cbDiscount.DisplayMember = "title";
            cbDiscount.ValueMember = "id";
            cbDiscount.SelectedIndex = -1;
            con.Close();
        }


        private void rdStatus1_CheckedChanged(object sender, EventArgs e)
        {
            status = 1;
        }

        private void rdStatus2_CheckedChanged(object sender, EventArgs e)
        {
            status = 0;
        }

        private void FormAddDiscount_Load(object sender, EventArgs e)
        {
            ListDiscount();
        }

        public void clear()
        {
            txtDiscount.Text = string.Empty;
            cbDiscount.SelectedIndex = -1;
            dtpStartDate.Value = DateTime.Now;
            dtpExpiryeDate.Value = DateTime.Now;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbDiscount.Text == "")
            {
                MessageBox.Show("Tên Sản phẩm Không Được Để ( Trống )");
                return;
            }
            if (txtDiscount.Text.Trim() == "")
            {
                MessageBox.Show("Giá trị giảm giá không được ( Trống )");
                return;
            }
            if (txtDiscount.Text.Trim().Length < 1)
            {
                MessageBox.Show("Giá trị giảm giá phải lớn hơn (  1 ký tự )");
                return;
            }
            if(Convert.ToDateTime(dtpExpiryeDate.Text) <= DateTime.Now)
            {
                MessageBox.Show("Ngày Kết Thúc Không Được Nhỏ Hơn Ngày Hiện Tại !!!");
                return;
            }
            if (DbDiscount.CheckDiscount((cbDiscount.SelectedValue).ToString(), txtDiscount.Text)==true)
            {
                MessageBox.Show("Giảm giá này đã (  Tồn tại )");
                return;
            }
            if (btnSave.Text == "Lưu")
            {
                string start_date = dtpStartDate.Value.Date.ToString("yyyy-MM-dd");
                string expiry_date = dtpExpiryeDate.Value.Date.ToString("yyyy-MM-dd");
                //Discount std = new Discount(Convert.ToDouble(txtDiscount.Text), Convert.ToInt32(cbDiscount.SelectedValue),start_date,expiry_date,status);
                //DbDiscount.AddDiscount(std);
                this.Close();
                clear();
                //_parent.Display();
            }
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
