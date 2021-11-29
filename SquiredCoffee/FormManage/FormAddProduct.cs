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
        FormSuccess Form1;
        FormError Form2;
        public FormAddProduct(UC_ManageProduct parent)
        {
            InitializeComponent();
            _parent = parent;
            Form1 = new FormSuccess();
            Form2 = new FormError();
        }
        

        void ketnoi()
        {
            con.ConnectionString = "SERVER=45.252.251.21;PORT=3306;DATABASE=sodopxlg_koffeeholic;UID=sodopxlg;PASSWORD=05qT1yfRp9";
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

        public void clear()
        {
            txtPriceProduct.Text = txtContent.Text = txtProductName.Text = string.Empty;
            cbCategoryName.SelectedIndex = -1;
            ptImage.Image = new Bitmap(Application.StartupPath + "\\Resource\\no_img.jpg");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbCategoryName.Text == "")
            {
                Form2.title = "Loại Sản Phẩm Không Được (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtProductName.Text.Trim() == "")
            {
                Form2.title = "Tên Sản Phẩm Không Được (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtProductName.Text.Trim().Length < 1)
            {
                Form2.title = "Tên Sản Phẩm (> 1 Ký Tự) ";
                Form2.ShowDialog();
                return;
            }
            if (txtPriceProduct.Text.Trim() == "")
            {
                Form2.title = "Giá Sản Phẩm Không Được (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtPriceProduct.Text.Trim().Length < 3)
            {
                Form2.title = "Giá Sản Phẩm  (> 3 Ký Tự) ";
                Form2.ShowDialog();
                return;
            }
            if (txtContent.Text.Trim() == "")
            {
                Form2.title = "Giới Thiệu Sản Phẩm Không Được (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtContent.Text.Trim().Length < 1)
            {
                Form2.title = "Giới Thiệu San Phẩm (> 1 Ký Tự) ";
                Form2.ShowDialog();
                return;
            }
            if(image_product == "")
            {
                Form2.title = "Hình Ảnh Sản Phẩm Không Để (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (DbProduct.CheckProduct(txtProductName.Text) == true)
            {
                Form2.title = "Sản Phẩm Đã Tồn Tại ";
                Form2.ShowDialog();
                return;
            }
            if (btnSave.Text == "Lưu")
            {      
                Product std = new Product(Convert.ToInt32(cbCategoryName.SelectedValue),txtProductName.Text,Convert.ToDecimal(txtPriceProduct.Text),image_product,txtContent.Text,1);
                if (DbProduct.CheckCreateProduct(std) == true)
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
