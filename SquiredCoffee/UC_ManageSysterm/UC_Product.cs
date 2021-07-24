using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SquiredCoffee.Class;
using SquiredCoffee.DB;
using System.Globalization;
using System.IO;

namespace SquiredCoffee.UC_ManageSysterm
{
    public partial class UC_Product : UserControl
    {
        MySqlConnection con = new MySqlConnection();

        public UC_Product()
        {
            InitializeComponent();
            ListCategory();
        }
        Bitmap ImageProduct;
        public int id,status,category_id;
        public string image;

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
            cbCategory.DataSource = ListCategory.Tables[0];
            cbCategory.DisplayMember = "title";
            cbCategory.ValueMember = "id";
            cbCategory.SelectedIndex = -1;
        }

        public void Clear()
        {
            txtContent.Text =txtPrice.Text=txtProductName.Text=txtSearch.Text= string.Empty;
            cbCategory.Text = null; 
            ptImage.Image = new Bitmap(Application.StartupPath + "\\Resource\\no_img.jpg");
            rbStatus1.Checked = true;
        }

       

        private void UC_Product_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtProductName.Text.Trim().Length < 3)
            {
                MessageBox.Show("Tên Sản Phẩm phải ( > 3) ký tự");
                return;
            }
            if (txtPrice.Text.Trim().Length < 3)
            {
                MessageBox.Show("Giá của Sản Phẩm ( > 3) ký tự");
                return;
            }
           
            if (txtContent.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ô Điểm Nổi Bật Đang ( Trống )");
                return;
            }

            if (btnInsert.Text == "Thêm")
            {
                Product std = new Product(int.Parse(cbCategory.SelectedValue.ToString()), txtProductName.Text.Trim(),decimal.Parse(txtPrice.Text),image, txtContent.Text.Trim(),status);
                DbProduct.AddProduct(std);
                Clear();
                Display();
            }
        }

        public void Display()
        {
            DbProduct.DisplayAndSearch("SELECT p.id,p.category_id,p.title,p.price,p.image,p.content,p.status,c.title AS category_name FROM products p,categories c WHERE p.category_id = c.id ", dgvProduct);
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


        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dgvProduct.SelectedRows[0].Cells[0].Value.ToString());
            txtProductName.Text = dgvProduct.SelectedRows[0].Cells[2].Value.ToString();
            cbCategory.Text = dgvProduct.SelectedRows[0].Cells[7].Value.ToString();
            txtPrice.Text = string.Format("{0:#,##0}", double.Parse(dgvProduct.SelectedRows[0].Cells[3].Value.ToString()));
            image = dgvProduct.SelectedRows[0].Cells[4].Value.ToString();
            ptImage.Image = ConvertBase64ToImage(image);
            category_id = Convert.ToInt32(dgvProduct.SelectedRows[0].Cells[1].Value.ToString());
            txtContent.Text = dgvProduct.SelectedRows[0].Cells[5].Value.ToString();
            if (Convert.ToInt32(dgvProduct.SelectedRows[0].Cells[6].Value.ToString()) == 1)
            {
                rbStatus1.Checked = true;
            }
            else if (Convert.ToInt32(dgvProduct.SelectedRows[0].Cells[6].Value.ToString()) == 0)
            {
                rbStatus2.Checked = true;
            }
            status = Convert.ToInt32(dgvProduct.SelectedRows[0].Cells[6].Value.ToString());

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
        
            Clear();
            Display();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Text == "Xóa")
            {
                DbProduct.DeleteProduct(id.ToString());
                Clear();
                Display();
            }
            
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
                image = base64Text;
            } 
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DbRole.DisplayAndSearch("SELECT id,category_id,title,price,image,content,status FROM products WHERE title LIKE'%" + txtSearch.Text + "%'", dgvProduct);
        }

        private void rbStatus2_CheckedChanged(object sender, EventArgs e)
        {
            status = 0;
        }

        private void rbStatus1_CheckedChanged(object sender, EventArgs e)
        {
            status = 1;
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtProductName.Text.Trim().Length < 3)
            {
                MessageBox.Show("Tên Sản Phẩm phải ( > 3) ký tự");
                return;
            }
            if (txtPrice.Text.Trim().Length < 3)
            {
                MessageBox.Show("Giá của Sản Phẩm ( > 3) ký tự");
                return;
            }
            if (txtContent.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ô Điểm Nổi Bật Đang ( Trống )");
                return;
            }

            if (btnEdit.Text == "Sửa")
            {
                Product std = new Product(int.Parse(cbCategory.SelectedValue.ToString()), txtProductName.Text.Trim(), decimal.Parse(txtPrice.Text), image, txtContent.Text.Trim(), status);
                DbProduct.UpdateProduct(std, id.ToString());
                Clear();
                Display();
            }
        }
    }
}
