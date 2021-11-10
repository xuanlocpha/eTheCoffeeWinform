using SquiredCoffee.Class;
using SquiredCoffee.DB;
using SquiredCoffee.FormManage;
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

namespace SquiredCoffee.UC_ManageSysterm
{
    public partial class UC_ProductList : UserControl
    {
        FormOrderProduct Form;
        private readonly FormStaff _parent;
        public string Search;
        public UC_ProductList(FormStaff parent)
        {
            InitializeComponent();
            _parent = parent;
            //Form = new FormOrderProduct(this, _parent);
        }

        private PictureBox pic = new PictureBox();
        private Button btn = new Button();
        public Label price;
        public Label title;
        public int id_table;
        public int id_order;


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

        public void LoadProductList()
        {
            List<Product> productList = DbProduct.LoadProductList();

            foreach (Product item in productList)
            {
                pic = new PictureBox();
                pic.Width = 202;
                pic.Height = 202;
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

        

        public void LoadProductListSearch(string Search)
        {
            flpProducts.Controls.Clear();
            List<Product> productList = DbProduct.LoadProductList(Search);
            foreach (Product item in productList)
            {
                pic = new PictureBox();
                pic.Width = 202;
                pic.Height = 202;
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


        public void Onclick(object sender, EventArgs e)
        {
            string tag = ((PictureBox)sender).Tag.ToString();
            //Form.idProduct = tag;
            id_order = _parent.id_order;
            //Form.ShowDialog();
            return;
        }

        private void UC_ProductList_Load(object sender, EventArgs e)
        {
            LoadProductList();
        }

       
    }
}
