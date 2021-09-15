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
using System.Globalization;

namespace SquiredCoffee.FormManage
{
    public partial class FormAddProduct : Form
    {
        MySqlConnection con = new MySqlConnection();
        Bitmap ImageProduct;
        public string image_product;
        public int status = 1;
        public static UC_ManageProduct _parent;
        public FormAddProduct(UC_ManageProduct parent)
        {
            InitializeComponent();
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

        void ListCategory()
        {
            string sql = "SELECT * FROM categories";
            DataSet ListCategory = new DataSet();
            ListCategory = LoadDB(sql);
            cbCategoryName.DataSource = ListCategory.Tables[0];
            cbCategoryName.DisplayMember = "title";
            cbCategoryName.ValueMember = "id";
            cbCategoryName.SelectedIndex = -1;
            con.Close();
        }



        private void FormAddProduct_Load(object sender, EventArgs e)
        {
            ListCategory();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG" +
             "|All files(*.*)|*.*";
            dialog.CheckFileExists = true;
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ImageProduct = new Bitmap(dialog.FileName);
                ptImage.Image = (Image)ImageProduct;

                byte[] imageArray = System.IO.File.ReadAllBytes(dialog.FileName);
                string base64Text = Convert.ToBase64String(imageArray); //base64Text must be global but I'll use  richtext
                image_product = base64Text;
            }
        }

        private void rdStatus1_CheckedChanged(object sender, EventArgs e)
        {
            status = 1;
        }

        private void rdStatus2_CheckedChanged(object sender, EventArgs e)
        {
            status = 1;
        }

        public void clear()
        {
            txtPriceProduct.Text = txtContent.Text = txtProductName.Text = string.Empty;
            cbCategoryName.SelectedIndex = -1;
            ptImage.Image = new Bitmap(Application.StartupPath + "\\Resource\\no_img.jpg");
            rdStatus1.Checked = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbCategoryName.Text == "")
            {
                MessageBox.Show("Loại sản phẩm đang ( Trống )");
                return;
            }
            if (txtProductName.Text.Trim() == "")
            {
                MessageBox.Show("Tên sản phẩm không được để ( Trống )");
                return;
            }
            if (txtProductName.Text.Trim().Length < 1)
            {
                MessageBox.Show("Tên sản phẩm phải lớn hơn (  1 ký tự )");
                return;
            }
            if (txtPriceProduct.Text.Trim() == "")
            {
                MessageBox.Show("Giá sản phẩm không được để ( Trống )");
                return;
            }
            if (txtPriceProduct.Text.Trim().Length < 3)
            {
                MessageBox.Show("Giá sản phẩm phải lớn hơn (  3 ký tự )");
                return;
            }
            if (txtContent.Text.Trim() == "")
            {
                MessageBox.Show("Giới thiệu sản phẩm không được để ( Trống )");
                return;
            }
            if (txtContent.Text.Trim().Length < 1)
            {
                MessageBox.Show("Giới thiệu sản phẩm phải lớn hơn (  1 ký tự )");
                return;
            }
            if(image_product == "")
            {
                MessageBox.Show("Hình ảnh sản phẩm không được (  Trống )");
                return;
            }
            if (DbProduct.CheckProduct(txtProductName.Text) == true)
            {
                MessageBox.Show("Sản phẩm ( Đã tồn tại )");
                return;
            }
            if (btnSave.Text == "Lưu")
            {
                Product std = new Product(Convert.ToInt32(cbCategoryName.SelectedValue),txtProductName.Text,Convert.ToDecimal(txtPriceProduct.Text),image_product,txtContent.Text,status);
                DbProduct.AddProduct(std);
                this.Close();
                clear();
                _parent.Display();
            }
        }

        private void txtPriceProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

       

        private void txtPriceProduct_TextChanged_1(object sender, EventArgs e)
        {
            try
            {

                double flTienThuong = double.Parse(txtPriceProduct.Text);
                txtPriceProduct.Text = flTienThuong.ToString("0,00.##");
                txtPriceProduct.Select(txtPriceProduct.TextLength, 0);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
