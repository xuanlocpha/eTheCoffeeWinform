using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using SquiredCoffee.Class;
using SquiredCoffee.CustomControls;
using SquiredCoffee.DB;
using SquiredCoffee.FormManage;
using SquiredCoffee.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SquiredCoffee.UC_ManageSysterm
{
    public partial class UC_ManageProduct : UserControl
    {

        MySqlConnection con = new MySqlConnection();
        FormAddProduct Form;
        FormInformationProduct Form1;
        public UC_ManageProduct()
        {
            InitializeComponent();
            Form = new FormAddProduct(this);
            Form1 = new FormInformationProduct(this);
        }
        public int totalProduct;
        public int totalProductSearch;
        private PictureBox pic = new PictureBox();
        public Label price;
        public Label title;

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
            cbListCategory.DataSource = ListCategory.Tables[0];
            cbListCategory.DisplayMember = "title";
            cbListCategory.ValueMember = "id";
            cbListCategory.SelectedIndex = -1;
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
            List<ProductShow> productList = DbProduct.LoadProductList1();

            foreach (ProductShow item in productList)
            {
                totalProduct += 1;
                Guna2Elipse elip = new Guna2Elipse();
                elip.TargetControl = pic;
                elip.BorderRadius = 10;

                Guna2Elipse elip1 = new Guna2Elipse();
                elip1.TargetControl = title;
                elip1.BorderRadius = 10;

                pic = new PictureBox();
                pic.Width = 196;
                pic.Height = 202;
                pic.BackColor = Color.SaddleBrown;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.BackgroundImage = LoadBase64(item.image.ToString());
                pic.Tag = item.id.ToString();

                price = new Label();
                price.Text = string.Format("{0:#,##0} Đ", double.Parse((item.price).ToString()));
                price.BackColor = Color.Transparent;
                price.TextAlign = ContentAlignment.MiddleCenter;
                price.ForeColor = Color.White;
                price.Font = new Font("Quicksand", 12, FontStyle.Bold);
                price.TextAlign = ContentAlignment.MiddleRight;
                price.Dock = DockStyle.Bottom;

                title = new Label();
                title.Text = (item.title).ToString();
                title.BackColor = Color.FromArgb(130, 255, 255, 255);
                title.TextAlign = ContentAlignment.MiddleCenter;
                title.ForeColor = Color.Black;
                title.Font = new Font("Quicksand", 12, FontStyle.Bold);
                title.Dock = DockStyle.Bottom;

                Guna2GradientPanel guna2GradientPanel = new Guna2GradientPanel();
                guna2GradientPanel.Width = 115;
                guna2GradientPanel.Height = 25;
                guna2GradientPanel.FillColor = Color.FromArgb(249, 130, 68);
                guna2GradientPanel.FillColor2 = Color.FromArgb(247, 72, 115);
                guna2GradientPanel.BackColor = Color.Transparent;
                guna2GradientPanel.BorderRadius = 7;


                Label lbl = new Label();
                lbl.Text = item.title_category;
                lbl.ForeColor = Color.White;
                lbl.Font = new Font("Quicksand", 10, FontStyle.Bold);
                lbl.TextAlign = ContentAlignment.MiddleCenter;


                pic.Controls.Add(title);
                pic.Controls.Add(price);
                pic.Controls.Add(guna2GradientPanel);
                guna2GradientPanel.Controls.Add(lbl);
                flpProduct.Controls.Add(pic);

                lblTotalProduct.Text = totalProduct.ToString();
                pic.Click += new EventHandler(Onclick);
            }
        }

        public void Onclick(object sender, EventArgs e)
        {
            FormBackGround formBackGround = new FormBackGround();
            try
            {
                using (FormInformationProduct Form = new FormInformationProduct(this))
                {
                    formBackGround.StartPosition = FormStartPosition.Manual;
                    formBackGround.FormBorderStyle = FormBorderStyle.None;
                    formBackGround.Opacity = .70d;
                    formBackGround.BackColor = Color.Black;
                    formBackGround.WindowState = FormWindowState.Maximized;
                    formBackGround.TopMost = true;
                    formBackGround.Location = this.Location;
                    formBackGround.ShowInTaskbar = false;
                    formBackGround.Show();

                    string tag = ((PictureBox)sender).Tag.ToString();
                    Form.id_product = Convert.ToInt32(tag);
                    Form.Owner = formBackGround;
                    Form.ShowDialog();
                    return;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                formBackGround.Dispose();
            }
        }


        public void productStatusList(string status)
        {
            flpProduct.Controls.Clear();
            List<ProductShow> productShowList = DbProduct.LoadProductStatusList(status);
            foreach (ProductShow item in productShowList)
            {
                totalProductSearch += 1;
                Guna2Elipse elip = new Guna2Elipse();
                elip.TargetControl = pic;
                elip.BorderRadius = 10;

                Guna2Elipse elip1 = new Guna2Elipse();
                elip1.TargetControl = title;
                elip1.BorderRadius = 10;

                pic = new PictureBox();
                pic.Width = 196;
                pic.Height = 202;
                pic.BackColor = Color.SaddleBrown;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.BackgroundImage = LoadBase64(item.image.ToString());
                pic.Tag = item.id.ToString();

                price = new Label();
                price.Text = string.Format("{0:#,##0} Đ", double.Parse((item.price).ToString()));
                price.BackColor = Color.Transparent;
                price.TextAlign = ContentAlignment.MiddleCenter;
                price.ForeColor = Color.White;
                price.Font = new Font("Quicksand", 12, FontStyle.Bold);
                price.TextAlign = ContentAlignment.MiddleRight;
                price.Dock = DockStyle.Bottom;

                title = new Label();
                title.Text = (item.title).ToString();
                title.BackColor = Color.FromArgb(130, 255, 255, 255);
                title.TextAlign = ContentAlignment.MiddleCenter;
                title.ForeColor = Color.Black;
                title.Font = new Font("Quicksand", 12, FontStyle.Bold);
                title.Dock = DockStyle.Bottom;

                Guna2GradientPanel guna2GradientPanel = new Guna2GradientPanel();
                guna2GradientPanel.Width = 115;
                guna2GradientPanel.Height = 25;
                guna2GradientPanel.FillColor = Color.FromArgb(249, 130, 68);
                guna2GradientPanel.FillColor2 = Color.FromArgb(247, 72, 115);
                guna2GradientPanel.BackColor = Color.Transparent;
                guna2GradientPanel.BorderRadius = 7;


                Label lbl = new Label();
                lbl.Text = item.title_category;
                lbl.ForeColor = Color.White;
                lbl.Font = new Font("Quicksand", 10, FontStyle.Bold);
                lbl.TextAlign = ContentAlignment.MiddleCenter;


                pic.Controls.Add(title);
                pic.Controls.Add(price);
                pic.Controls.Add(guna2GradientPanel);
                guna2GradientPanel.Controls.Add(lbl);
                flpProduct.Controls.Add(pic);

                lblTotalProductSearch.Text = totalProductSearch.ToString();
                pic.Click += new EventHandler(Onclick);
            }
        }

        public void clear()
        {
            totalProduct = 0;
            totalProductSearch = 0;
        }

        public void clear1()
        {
            cbListCategory.SelectedIndex = -1;
        }

        private void UC_ManageProduct_Load(object sender, EventArgs e)
        {
            ListCategory();
            Display();
            Guna.UI.Lib.ScrollBar.PanelScrollHelper flowpan = new Guna.UI.Lib.ScrollBar.PanelScrollHelper(flpProduct, gunaVScrollBar1, true);
           
        }

      

        private void btnAll_Click(object sender, EventArgs e)
        {
            flpProduct.Controls.Clear();
            txtSearch.Text = string.Empty;
            clear1();
            clear();
            Display();
            lblTotalProductSearch.Text = totalProduct.ToString();
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            clear1();
            clear();
            flpProduct.Controls.Clear();
            productStatusList("1");
            lblTotalProductSearch.Text = totalProductSearch.ToString();
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            clear1();
            clear();
            flpProduct.Controls.Clear();
            productStatusList("0");
            lblTotalProductSearch.Text = totalProductSearch.ToString();
        }

        private void cbListProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            clear();
            flpProduct.Controls.Clear();
            List<ProductShow> productShowList = DbProduct.LoadProductSearchList(txtSearch.Text);
            foreach (ProductShow item in productShowList)
            {
                totalProductSearch += 1;
                Guna2Elipse elip = new Guna2Elipse();
                elip.TargetControl = pic;
                elip.BorderRadius = 10;

                Guna2Elipse elip1 = new Guna2Elipse();
                elip1.TargetControl = title;
                elip1.BorderRadius = 10;

                pic = new PictureBox();
                pic.Width = 196;
                pic.Height = 202;
                pic.BackColor = Color.SaddleBrown;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.BackgroundImage = LoadBase64(item.image.ToString());
                pic.Tag = item.id.ToString();

                price = new Label();
                price.Text = string.Format("{0:#,##0} Đ", double.Parse((item.price).ToString()));
                price.BackColor = Color.Transparent;
                price.TextAlign = ContentAlignment.MiddleCenter;
                price.ForeColor = Color.White;
                price.Font = new Font("Quicksand", 12, FontStyle.Bold);
                price.TextAlign = ContentAlignment.MiddleRight;
                price.Dock = DockStyle.Bottom;

                title = new Label();
                title.Text = (item.title).ToString();
                title.BackColor = Color.FromArgb(130, 255, 255, 255);
                title.TextAlign = ContentAlignment.MiddleCenter;
                title.ForeColor = Color.Black;
                title.Font = new Font("Quicksand", 12, FontStyle.Bold);
                title.Dock = DockStyle.Bottom;

                Guna2GradientPanel guna2GradientPanel = new Guna2GradientPanel();
                guna2GradientPanel.Width = 115;
                guna2GradientPanel.Height = 25;
                guna2GradientPanel.FillColor = Color.FromArgb(249, 130, 68);
                guna2GradientPanel.FillColor2 = Color.FromArgb(247, 72, 115);
                guna2GradientPanel.BackColor = Color.Transparent;
                guna2GradientPanel.BorderRadius = 7;


                Label lbl = new Label();
                lbl.Text = item.title_category;
                lbl.ForeColor = Color.White;
                lbl.Font = new Font("Quicksand", 10, FontStyle.Bold);
                lbl.TextAlign = ContentAlignment.MiddleCenter;


                pic.Controls.Add(title);
                pic.Controls.Add(price);
                pic.Controls.Add(guna2GradientPanel);
                guna2GradientPanel.Controls.Add(lbl);
                flpProduct.Controls.Add(pic);

                lblTotalProductSearch.Text = totalProductSearch.ToString();
                pic.Click += new EventHandler(Onclick);
            }

        }

        private void cbListCategory_TextChanged(object sender, EventArgs e)
        {
            clear();
            flpProduct.Controls.Clear();
            List<ProductShow> productShowList = DbProduct.LoadProductSearchList1(cbListCategory.Text);
            foreach (ProductShow item in productShowList)
            {
                totalProductSearch += 1;
                Guna2Elipse elip = new Guna2Elipse();
                elip.TargetControl = pic;
                elip.BorderRadius = 10;

                Guna2Elipse elip1 = new Guna2Elipse();
                elip1.TargetControl = title;
                elip1.BorderRadius = 10;

                pic = new PictureBox();
                pic.Width = 196;
                pic.Height = 202;
                pic.BackColor = Color.SaddleBrown;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.BackgroundImage = LoadBase64(item.image.ToString());
                pic.Tag = item.id.ToString();

                price = new Label();
                price.Text = string.Format("{0:#,##0} Đ", double.Parse((item.price).ToString()));
                price.BackColor = Color.Transparent;
                price.TextAlign = ContentAlignment.MiddleCenter;
                price.ForeColor = Color.White;
                price.Font = new Font("Quicksand", 12, FontStyle.Bold);
                price.TextAlign = ContentAlignment.MiddleRight;
                price.Dock = DockStyle.Bottom;

                title = new Label();
                title.Text = (item.title).ToString();
                title.BackColor = Color.FromArgb(130, 255, 255, 255);
                title.TextAlign = ContentAlignment.MiddleCenter;
                title.ForeColor = Color.Black;
                title.Font = new Font("Quicksand", 12, FontStyle.Bold);
                title.Dock = DockStyle.Bottom;

                Guna2GradientPanel guna2GradientPanel = new Guna2GradientPanel();
                guna2GradientPanel.Width = 115;
                guna2GradientPanel.Height = 25;
                guna2GradientPanel.FillColor = Color.FromArgb(249, 130, 68);
                guna2GradientPanel.FillColor2 = Color.FromArgb(247, 72, 115);
                guna2GradientPanel.BackColor = Color.Transparent;
                guna2GradientPanel.BorderRadius = 7;


                Label lbl = new Label();
                lbl.Text = item.title_category;
                lbl.ForeColor = Color.White;
                lbl.Font = new Font("Quicksand", 10, FontStyle.Bold);
                lbl.TextAlign = ContentAlignment.MiddleCenter;


                pic.Controls.Add(title);
                pic.Controls.Add(price);
                pic.Controls.Add(guna2GradientPanel);
                guna2GradientPanel.Controls.Add(lbl);
                flpProduct.Controls.Add(pic);

                lblTotalProductSearch.Text = totalProductSearch.ToString();
                pic.Click += new EventHandler(Onclick);
            }

         
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            FormBackGround formBackGround = new FormBackGround();
            try
            {
                using (FormAddProduct Form = new FormAddProduct(this))
                {
                    formBackGround.StartPosition = FormStartPosition.Manual;
                    formBackGround.FormBorderStyle = FormBorderStyle.None;
                    formBackGround.Opacity = .70d;
                    formBackGround.BackColor = Color.Black;
                    formBackGround.WindowState = FormWindowState.Maximized;
                    formBackGround.TopMost = true;
                    formBackGround.Location = this.Location;
                    formBackGround.ShowInTaskbar = false;
                    formBackGround.Show();
  
                    Form.Owner = formBackGround;
                    Form.ShowDialog();
                    return;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                formBackGround.Dispose();
            }
           
        }

    }
}
