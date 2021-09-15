using MySql.Data.MySqlClient;
using SquiredCoffee.Class;
using SquiredCoffee.DB;
using SquiredCoffee.UC_ManageSysterm;
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
    public partial class FormInformationProductTopping : Form
    {

        MySqlConnection con = new MySqlConnection();
        public int status = 1;
        public int id_product_topping;
        public static UC_ManageProductTopping _parent;
        public FormInformationProductTopping(UC_ManageProductTopping parent)
        {
            InitializeComponent();
            ListTopping();
            ListProduct();
            _parent = parent;
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

        public void Display()
        {
            List<ProductToppingShow> productToppingList = DbProductTopping.LoadProductTopping1(id_product_topping.ToString());
            foreach (ProductToppingShow item in productToppingList)
            {
                cbProductName.Text = item.name_product;
                cbToppingName.Text = item.name_topping;
                if (item.status == 1)
                {
                    rdStatus1.Checked = true;
                }
                else if (item.status == 0)
                {
                    rdStatus2.Checked = true;
                }
                status = item.status;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
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
            if (MessageBox.Show("Bạn có muốn chỉnh sửa topping sản phẩm  này không !", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (btnEdit.Text == "Sửa")
                {
                    ProductTopping std = new ProductTopping(Convert.ToInt32(cbProductName.SelectedValue), Convert.ToInt32(cbToppingName.SelectedValue), status);
                    DbProductTopping.UpdateProductTopping(std, id_product_topping.ToString());
                    this.Close();
                    _parent.clear();
                    _parent.clear1();
                    _parent.Display();
                }
            }
        }

        private void rdStatus1_CheckedChanged(object sender, EventArgs e)
        {
            status = 1;
        }

        private void rdStatus2_CheckedChanged(object sender, EventArgs e)
        {
            status = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormInformationProductTopping_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa topping sản phẩm  này không . Vì nó có thể anh hưởng tới dữ liệu của bạn!", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (btnDelete.Text == "Xóa")
                {
                    DbProductTopping.DeleteProductTopping(id_product_topping.ToString());
                    this.Close();
                    _parent.clear();
                    _parent.clear1();
                    _parent.Display();
                }
            }
        }
    }
}
