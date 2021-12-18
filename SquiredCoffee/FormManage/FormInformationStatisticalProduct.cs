using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using SquiredCoffee.Class;
using SquiredCoffee.DB;
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
    public partial class FormInformationStatisticalProduct : Form
    {
        MySqlConnection con = new MySqlConnection();
        FormAddProduct Form;

        public int totalProductSearch;
        private PictureBox pic = new PictureBox();
        public Label price;
        public Label title;
        public string titleForm;
        public decimal totalProduct;

        public FormInformationStatisticalProduct()
        {
            InitializeComponent();
        }

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

        public void Display()
        {
            //List<Order_Items> order_Items_List = DbOrderItem.order_Items_List_Date(key);
            //foreach (Order_Items item1 in order_Items_List)
            //{
            //    List<ProductShow> productList = DbProduct.LoadProductList1(item1.product_id.ToString());
            //    foreach (ProductShow item in productList)
            //    {
            //        totalProduct += 1;
            //        Guna2Elipse elip = new Guna2Elipse();
            //        elip.TargetControl = pic;
            //        elip.BorderRadius = 10;

            //        Guna2Elipse elip1 = new Guna2Elipse();
            //        elip1.TargetControl = title;
            //        elip1.BorderRadius = 10;

            //        pic = new PictureBox();
            //        pic.Width = 196;
            //        pic.Height = 202;
            //        pic.BackColor = Color.SaddleBrown;
            //        pic.BackgroundImageLayout = ImageLayout.Stretch;
            //        pic.BackgroundImage = LoadBase64(item.image.ToString());
            //        pic.Tag = item.id.ToString();

            //        price = new Label();
            //        price.Text = string.Format("{0:#,##0} Đ", double.Parse((item.price).ToString()));
            //        price.BackColor = Color.Transparent;
            //        price.TextAlign = ContentAlignment.MiddleCenter;
            //        price.ForeColor = Color.White;
            //        price.Font = new Font("Quicksand", 12, FontStyle.Bold);
            //        price.TextAlign = ContentAlignment.MiddleRight;
            //        price.Dock = DockStyle.Bottom;

            //        title = new Label();
            //        title.Text = (item.title).ToString();
            //        title.BackColor = Color.FromArgb(130, 255, 255, 255);
            //        title.TextAlign = ContentAlignment.MiddleCenter;
            //        title.ForeColor = Color.Black;
            //        title.Font = new Font("Quicksand", 12, FontStyle.Bold);
            //        title.Dock = DockStyle.Bottom;

            //        Guna2GradientPanel guna2GradientPanel = new Guna2GradientPanel();
            //        guna2GradientPanel.Width = 115;
            //        guna2GradientPanel.Height = 25;
            //        guna2GradientPanel.FillColor = Color.FromArgb(249, 130, 68);
            //        guna2GradientPanel.FillColor2 = Color.FromArgb(247, 72, 115);
            //        guna2GradientPanel.BackColor = Color.Transparent;
            //        guna2GradientPanel.BorderRadius = 7;


            //        Label lbl = new Label();
            //        lbl.Text = item.title_category;
            //        lbl.ForeColor = Color.White;
            //        lbl.Font = new Font("Quicksand", 10, FontStyle.Bold);
            //        lbl.TextAlign = ContentAlignment.MiddleCenter;


            //        pic.Controls.Add(title);
            //        pic.Controls.Add(price);
            //        pic.Controls.Add(guna2GradientPanel);
            //        guna2GradientPanel.Controls.Add(lbl);
            //        flpProduct.Controls.Add(pic);

            //        lblTotalProduct.Text = totalProduct.ToString();
            //        // pic.Click += new EventHandler(Onclick);
            //    }
            //}
        }

        private void FormInformationStatisticalProduct_Load(object sender, EventArgs e)
        {
            Guna.UI.Lib.ScrollBar.PanelScrollHelper flowpan = new Guna.UI.Lib.ScrollBar.PanelScrollHelper(flpProduct, gunaVScrollBar1, true);
            lblTitle.Text = titleForm;
            Display();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
