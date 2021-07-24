using MySql.Data.MySqlClient;
using SquiredCoffee.DB;
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
using SquiredCoffee.Class;
using SquiredCoffee.FormManage;
using System.Drawing.Imaging;

namespace SquiredCoffee
{
    public partial class FormStaff : Form
    {
        FormEditOrderItems Form1;
        FormScannerBarCode Form2;
        FormListTableChange Form3;
        double total;
        FormListTable Form;
        public string title_table;
        public int id_table;
        public int id_order;
        public int id_tableChange;
        public string image;
        public Label price;
        public Label title;
        public int amount = 1;

        public FormStaff()
        {
            InitializeComponent();
            Form = new FormListTable(this);
            Form1 = new FormEditOrderItems(this);
            Form2 = new FormScannerBarCode(this);
            Form3 = new FormListTableChange(this);
            lblTableName.Hide();
        }

        private PictureBox pic = new PictureBox();
        private Button btn = new Button();


        public static Image LoadBase64(string base64)
        {
            byte[] bytes = Convert.FromBase64String(base64);
            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }
            return image;
        }


        //public Image ConvertBase64ToImage(string base64String)
        //{
        //    //byte[] imageBytes = Convert.FromBase64String(base64String);
        //    //using (MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
        //    //{
        //    //    ms.Write(imageBytes, 0, imageBytes.Length);
        //    //    return Image.FromStream(ms, true);
        //    //}
        //    // Convert base 64 string to byte[]
          
        //}



        public void LoadProductList()
        {
            List<Product> productList = DbProduct.LoadProductList();

            foreach (Product item in productList)
            {
                pic = new PictureBox();
                pic.Width = 207;
                pic.Height = 207;
                pic.BackColor = Color.SaddleBrown;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.BackgroundImage = LoadBase64(item.image.ToString());
                pic.Tag = item.id.ToString();

                price = new Label();
                price.Text = string.Format("{0:#,##0} Đ", double.Parse((item.price).ToString()));
                price.BackColor = Color.FromArgb(255, 121, 121);
                price.TextAlign = ContentAlignment.MiddleCenter;
                price.ForeColor = Color.White;
                price.Dock = DockStyle.Bottom;

                title = new Label();
                title.Text = (item.title).ToString();
                title.BackColor = Color.FromArgb(46, 134, 222);
                title.TextAlign = ContentAlignment.MiddleCenter;
                title.ForeColor = Color.White;
                title.Dock = DockStyle.Bottom;
                pic.Controls.Add(title);
                pic.Controls.Add(price);
                flpProducts.Controls.Add(pic);

                pic.Click += new EventHandler(Onclick);
            }
        }


        public void LoadProductListOnCategory(string id)
        {
            List<Product> productList = DbProduct.LoadProductListOnCategory(id);

            foreach (Product item in productList)
            {
                pic = new PictureBox();
                pic.Width = 207;
                pic.Height = 207;
                pic.BackColor = Color.SaddleBrown;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.BackgroundImage = LoadBase64(item.image);
                pic.Tag = item.id.ToString();

                price = new Label();
                price.Text = string.Format("{0:#,##0} Đ", double.Parse((item.price).ToString()));
                price.BackColor = Color.FromArgb(255, 121, 121);
                price.TextAlign = ContentAlignment.MiddleCenter;
                price.ForeColor = Color.White;
                price.Dock = DockStyle.Bottom;

                title = new Label();
                title.Text = (item.title).ToString();
                title.BackColor = Color.FromArgb(46, 134, 222);
                title.TextAlign = ContentAlignment.MiddleCenter;
                title.ForeColor = Color.White;
                title.Dock = DockStyle.Bottom;
                pic.Controls.Add(title);
                pic.Controls.Add(price);
                flpProducts.Controls.Add(pic);

                pic.Click += new EventHandler(Onclick);
            }
        }


        public void LoadProduct(string id)
        {
            List<Product> product = DbProduct.LoadProduct(id);
            foreach (Product item in product)
            {
                if (id_table == 0)
                {
                    MessageBox.Show("Bạn Chưa Chọn ( BÀN ) !!!");
                    return;
                }
                else
                {
                    if (DbOrderItem.CheckDb(id_order.ToString(), (item.id).ToString()) == true)
                    {
                        List<Order_Items> order_Items = DbOrderItem.OrderItemsList(id_order.ToString(), id_table.ToString(), item.id.ToString());
                        foreach (Order_Items item1 in order_Items)
                        {
                            Order_Items std = new Order_Items(id_order, item.id, item1.count + 1, item.price, (item1.count + 1) * item.price);
                            DbOrderItem.UpdateOrderItem(std, item1.id.ToString(), item1.created_at);
                            total += double.Parse((item.price.ToString()));

                        }
                    }
                    else
                    {
                        Order_Items std = new Order_Items(id_order, item.id, amount, item.price, amount * item.price);
                        DbOrderItem.AddOrderItem(std);
                        total += double.Parse((item.price.ToString()));

                    }

                }
            }
        }

        public void Display()
        {
            id_table = Form.tag_id;
            id_order = Form.order_id;
            DbOrderItem.DisplayAndSearch("SELECT oi.id,p.title,oi.count,oi.price,oi.provisional,oi.id_order,oi.id_product FROM order_items oi, orders o ,products p  WHERE  oi.id_order = o.id  AND oi.id_order = '" + id_order + "' AND o.status='" + 0 + "' AND o.id_table ='" + id_table + "' AND p.id = oi.id_product ", dgvOrder);
        }


        public void Onclick(object sender, EventArgs e)
        {
            string tag = ((PictureBox)sender).Tag.ToString();
            id_table = Form.tag_id;
            id_order = Form.order_id;
            LoadProduct(tag);
        }



        public void OnclickCategory(object sender, EventArgs e)
        {
            string tag = ((Button)sender).Tag.ToString();
            flpProducts.Controls.Clear();
            LoadProductListOnCategory(tag);
            clear();
        }

        private void FormStaff_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = (1 * 450); // 1 secs
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            LoadProductList();
            LoadCategory();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnListTable_Click(object sender, EventArgs e)
        {
            Form.ShowDialog();
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadCategory()
        {
            List<Category> categoryList = DbCategory.LoadCategoryList();
            foreach (Category item in categoryList)
            {
                btn = new Button();
                btn.Text = item.title;
                btn.Width = 112;
                btn.Height = 41;
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = Color.FromArgb(242, 169, 136);
                btn.FlatAppearance.BorderSize = 1;
                btn.ForeColor = Color.DarkRed;
                btn.TextAlign = ContentAlignment.MiddleCenter;
                flpCategory.Controls.Add(btn);

                btn.Tag = item.id.ToString();

                btn.Click += new EventHandler(OnclickCategory);
            }
        }

        public void LoadProductList(string query)
        {
            List<Product> productList = DbProduct.LoadProductList(query);

            foreach (Product item in productList)
            {
                pic = new PictureBox();
                pic.Width = 207;
                pic.Height = 207;
                pic.BackColor = Color.SaddleBrown;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.BackgroundImage = LoadBase64(item.image);
                pic.Tag = item.id.ToString();

                price = new Label();
                price.Text = string.Format("{0:#,##0} Đ", double.Parse((item.price).ToString()));
                price.BackColor = Color.FromArgb(255, 121, 121);
                price.TextAlign = ContentAlignment.MiddleCenter;
                price.ForeColor = Color.White;
                price.Dock = DockStyle.Bottom;

                title = new Label();
                title.Text = (item.title).ToString();
                title.BackColor = Color.FromArgb(46, 134, 222);
                title.TextAlign = ContentAlignment.MiddleCenter;
                title.ForeColor = Color.White;
                title.Dock = DockStyle.Bottom;
                pic.Controls.Add(title);
                pic.Controls.Add(price);
                flpProducts.Controls.Add(pic);

                pic.Click += new EventHandler(Onclick);
            }
        }

        public void LoadTable()
        {
            if (Form.status_form == 1)
            {
                lblTableName.Show();
                lblTableName.Text = Form.tag_title;
                Display();
            }
            else
            {
                lblTableName.Hide();
            }

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            flpProducts.Controls.Clear();
            LoadProductList(txtSearch.Text);

        }

        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                //Sửa
                Form1.Clear();
                Form1.id = dgvOrder.Rows[e.RowIndex].Cells[2].Value.ToString();
                Form1.id_order = dgvOrder.Rows[e.RowIndex].Cells[7].Value.ToString();
                Form1.id_product = dgvOrder.Rows[e.RowIndex].Cells[8].Value.ToString();
                Form1.count = dgvOrder.Rows[e.RowIndex].Cells[4].Value.ToString();
                Form1.price = dgvOrder.Rows[e.RowIndex].Cells[5].Value.ToString();
                Form1.provisional = dgvOrder.Rows[e.RowIndex].Cells[6].Value.ToString();
                Form1.UpdateOrderItem();
                Form1.ShowDialog();
                return;
            }

            if (e.ColumnIndex == 1)
            {
                // Xóa
                if (MessageBox.Show("Bạn có muốn xóa Loại Sản Phẩm Này", "Infomation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DbOrderItem.DeleteIngredient(dgvOrder.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Display();
                }
                return;
            }
        }

        public void clear()
        {
            txtSearch.Text = string.Empty;
        }

        private void btnAllProduct_Click(object sender, EventArgs e)
        {
            flpProducts.Controls.Clear();
            LoadProductList();
            clear();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            Form.ShowDialog();
        }

        private void btnAccumulatePoints_Click(object sender, EventArgs e)
        {
            Form2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form.ShowDialog();
        }

        private void btnChangeTable_Click(object sender, EventArgs e)
        {
            Form3.ShowDialog();
            id_tableChange = Form3.tagTable_id;
            List<Product> productList = DbProduct.LoadProductList();

            foreach (Product item in productList)
            {
                if (id_table == 0)
                {
                    MessageBox.Show("Bạn Chưa Chọn ( BÀN ) !!!");
                    return;
                }
            }
        }

    }
}
