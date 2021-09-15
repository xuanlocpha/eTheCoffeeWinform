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
        public FormAddProductTopping(UC_ManageProductTopping parent)
        {
            InitializeComponent();
            _parent = parent;
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
                MessageBox.Show("Bạn Chưa Chọn Tên Sản Phẩm !");
                return;
            }
            if (cbToppingName.Text == null)
            {
                MessageBox.Show("Bạn Chưa Chọn Tên Topping !");
                return;
            }
            if(DbProductTopping.CheckProductTopping(cbProductName.SelectedValue.ToString(), cbToppingName.SelectedValue.ToString())== true)
            {
                MessageBox.Show(" Topping này đã tồn tại !");
                return;
            }
            if (btnSave.Text == "Lưu")
            {
                ProductTopping std = new ProductTopping(Convert.ToInt32(cbProductName.SelectedValue), Convert.ToInt32(cbToppingName.SelectedValue),status);
                DbProductTopping.AddProductTopping(std);
                this.Close();
                clear();
                _parent.clear();
                _parent.clear1();
                _parent.Display();
            }
        }
    }
}
