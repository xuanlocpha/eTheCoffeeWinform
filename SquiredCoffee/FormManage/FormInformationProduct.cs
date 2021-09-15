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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SquiredCoffee.FormManage
{
    public partial class FormInformationProduct : Form
    {
        MySqlConnection con = new MySqlConnection();
        Bitmap ImageProduct;
        public static UC_ManageProduct _parent;
        public int id_product;
        public int status;
        public string image_product;
        public FormInformationProduct(UC_ManageProduct parent)
        {
            InitializeComponent();
            _parent = parent;
            ListCategory();
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

        public Image ConvertBase64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                ms.Write(imageBytes, 0, imageBytes.Length);
                return Image.FromStream(ms, true);
            }
        }

        public void Display()
        {
            List<ProductShow> productShowList = DbProduct.LoadProductList2(id_product.ToString());
            foreach (ProductShow item in productShowList)
            {
                cbCategoryName.Text = item.title_category;
                txtProductName.Text = item.title;
                txtPriceProduct.Text = string.Format("{0:#,##0}",item.price);
                txtContent.Text = item.content;
                image_product = item.image;
                ptImage.Image = ConvertBase64ToImage(image_product);
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

        private void FormInformationProduct_Load(object sender, EventArgs e)
        {
            Display();
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

        private void btnEdit_Click(object sender, EventArgs e)
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
            if (image_product == "")
            {
                MessageBox.Show("Hình ảnh sản phẩm không được (  Trống )");
                return;
            }
            if (MessageBox.Show("Bạn có muốn chỉnh sửa sản phẩm  này không !", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (btnEdit.Text == "Sửa")
                {
                    Product std = new Product(Convert.ToInt32(cbCategoryName.SelectedValue), txtProductName.Text, Convert.ToDecimal(txtPriceProduct.Text), image_product, txtContent.Text, status);
                    DbProduct.UpdateProduct(std, id_product.ToString());
                    this.Close();
                    _parent.Display();
                    _parent.clear1();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa sản phẩm  này không ,vì nó có thể ảnh hưởng tới dữ liệu của bạn !", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (btnDelete.Text == "Xóa")
                {
                    DbProduct.DeleteProduct(id_product.ToString());
                    this.Close();
                    _parent.Display();
                    _parent.clear1();
                }
            }
        }
    }
}
