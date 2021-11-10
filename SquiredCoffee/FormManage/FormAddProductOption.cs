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
    public partial class FormAddProductOption : Form
    {
        MySqlConnection con = new MySqlConnection();
        Bitmap ImageProduct;
        public int status = 1;
        public int defaults = 1;
        public int id_product_option;
        public static UC_ManageProductOption _parent;
        FormSuccess Form1;
        FormError Form2;
        public FormAddProductOption(UC_ManageProductOption parent)
        {
            InitializeComponent();
            _parent = parent;
            Form1 = new FormSuccess();
            Form2 = new FormError();
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

        void ListOption()
        {
            string sql = "SELECT * FROM options";
            DataSet ListCategory = new DataSet();
            ListCategory = LoadDB(sql);
            cbOptionName.DataSource = ListCategory.Tables[0];
            cbOptionName.DisplayMember = "title";
            cbOptionName.ValueMember = "id";
            cbOptionName.SelectedIndex = -1;
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


        private void rdStatus1_CheckedChanged(object sender, EventArgs e)
        {
            status = 1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbDefault1_CheckedChanged(object sender, EventArgs e)
        {
            defaults = 1;
        }

        private void FormAddProductOption_Load(object sender, EventArgs e)
        {
            ListProduct();
            ListOption();
        }

        private void rdStatus2_CheckedChanged(object sender, EventArgs e)
        {
            status = 0;
        }

        private void rbDefault2_CheckedChanged(object sender, EventArgs e)
        {
            defaults = 0;
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {

                double flTienThuong = double.Parse(txtPrice.Text);
                txtPrice.Text = flTienThuong.ToString("0,00.##");
                txtPrice.Select(txtPrice.TextLength, 0);
            }
            catch (Exception ex)
            {

            }
        }

        public void clear()
        {
            cbOptionName.SelectedIndex = -1;
            cbProductName.SelectedIndex = -1;
            txtPrice.Text = txtTitle.Text = string.Empty;
            chkDefault1.Checked = false;
            chkDefault2.Checked = false;
            rdStatus1.Checked = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbOptionName.Text == "")
            {
                Form2.title = "Tên Option Không Được (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (cbProductName.Text == "")
            {
                Form2.title = "Tên Sản Phẩm Không Được (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtTitle.Text.Trim() == "")
            {
                Form2.title = "Tiêu Đề Không Được (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtTitle.Text.Trim().Length < 1)
            {
                Form2.title = "Tiêu Đề Phải (> 1 Ký Tự) ";
                Form2.ShowDialog();
                return;
            }
            if (txtPrice.Text.Trim() == "")
            {
                Form2.title = "Giá Tiền Không  (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if(defaults == null)
            {
                Form2.title = "Chưa Xét Mặc Định ";
                Form2.ShowDialog();
                return;
            }
            if(DbProductOption.CheckProductOption((cbProductName.SelectedValue).ToString(),(cbOptionName.SelectedValue).ToString())== true)
            {
                Form2.title = "Option này đã tồn tại";
                Form2.ShowDialog();
                return;
            }
            if (btnSave.Text == "Lưu")
            {
                ProductOption std = new ProductOption(Convert.ToInt32(cbProductName.SelectedValue), Convert.ToInt32(cbOptionName.SelectedValue),txtTitle.Text,Convert.ToDecimal(txtPrice.Text),defaults,status);
                if(DbProductOption.CheckCreateProductOption(std)== true)
                {
                    Form1.title = "Tạo Thành Công";
                    Form1.ShowDialog();
                    this.Close();
                    clear();
                    _parent.Display();
                }
                else
                {
                    Form2.title = "Tạo Không Thành Công";
                    Form2.ShowDialog();
                    this.Close();
                    clear();
                    _parent.Display();
                }
               
            }
        }

        private void chkDefault1_CheckedChanged(object sender, EventArgs e)
        {
            defaults = 1;
        }

        private void chkDefault2_CheckedChanged(object sender, EventArgs e)
        {
            defaults = 0;
        }
    }
}
