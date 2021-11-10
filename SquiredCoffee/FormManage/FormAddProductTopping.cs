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
    public partial class FormAddProductTopping : Form
    {
        MySqlConnection con = new MySqlConnection();
        public int status = 1;
        public static UC_ManageProductTopping _parent;
        FormSuccess Form1;
        FormError Form2;
        public FormAddProductTopping(UC_ManageProductTopping parent)
        {
            InitializeComponent();
            _parent = parent;
            Form1 = new FormSuccess();
            Form2 = new FormError();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void ketnoi()
        {
            con.ConnectionString = "SERVER=45.252.251.29;PORT=3306;DATABASE=sodopxlg_koffeeholic;UID=sodopxlg;PASSWORD=05qT1yfRp9";
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

        void ListTopping()
        {
            string sql = "SELECT * FROM toppings";
            DataSet ListCategory = new DataSet();
            ListCategory = LoadDB(sql);
            cbToppingName.DataSource = ListCategory.Tables[0];
            cbToppingName.DisplayMember = "title";
            cbToppingName.ValueMember = "id";
            cbToppingName.SelectedIndex = -1;
            con.Close();
        }

        void ListProduct()
        {
            string sql = "SELECT * FROM products";
            DataSet ListCategory = new DataSet();
            ListCategory = LoadDB(sql);
            cbProductName.DataSource = ListCategory.Tables[0];
            cbProductName.DisplayMember = "title";
            cbProductName.ValueMember = "id";
            cbProductName.SelectedIndex = -1;
            con.Close();
        }

        private void FormAddProductTopping_Load(object sender, EventArgs e)
        {
            ListTopping();
            ListProduct();
        }

        private void rdStatus1_CheckedChanged(object sender, EventArgs e)
        {
            status = 1;
        }

        private void rdStatus2_CheckedChanged(object sender, EventArgs e)
        {
            status = 0;
        }

        public void clear()
        {
            cbProductName.SelectedIndex = -1;
            cbToppingName.SelectedIndex = -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbProductName.Text == null)
            {
                Form2.title = "Bạn Chưa Chọn Tên Sản Phẩm ";
                Form2.ShowDialog();
                return;
            }
            if (cbToppingName.Text == null)
            {
                Form2.title = "Bạn Chưa Chọn Tên Topping ";
                Form2.ShowDialog();
                return;
            }
            if(DbProductTopping.CheckProductTopping(cbProductName.SelectedValue.ToString(), cbToppingName.SelectedValue.ToString())== true)
            {
                Form2.title = "Topping Sản Phẩm Này Đã Tồn Tại ";
                Form2.ShowDialog();
                return;
            }
            if (btnSave.Text == "Lưu")
            {
                ProductTopping std = new ProductTopping(Convert.ToInt32(cbProductName.SelectedValue), Convert.ToInt32(cbToppingName.SelectedValue),status);
               if(DbProductTopping.CheckCreateProductTopping(std)== true)
                {
                    Form1.title = "Tạo Thành Công ";
                    Form1.ShowDialog();
                    this.Close();
                    clear();
                    _parent.clear();
                    _parent.clear1();
                    _parent.Display();
                }
                else
                {
                    Form2.title = "Tạo Không Thành Công ";
                    Form2.ShowDialog();
                    this.Close();
                    clear();
                    _parent.clear();
                    _parent.clear1();
                    _parent.Display();
                }
            }
        }
    }
}
