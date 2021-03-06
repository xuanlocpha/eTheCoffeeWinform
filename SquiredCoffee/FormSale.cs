using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Guna.UI.WinForms;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using Nancy.Json;
using Newtonsoft.Json;
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
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace SquiredCoffee
{
    public partial class FormSale : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "a9dcTERVqKjXumq650cZgtQelwv2uqFTmAejZjjj",
            BasePath = "https://koffeeholic-75e48-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;

        FormLoginSysterm _parent;
        public int id_staff;
        public string fullName;
        public string roleName;
        public string imageStaff;
        public string tableNumber;
        public string id_order;
        public string id_size;
        public string id_option;
        public string id_sugar;
        public string id_drink_type_name;
        public string id_topping;
        public string option_ice_name;
        public string option_drink_type_name;
        public string sugar_name;
        public string topping_name;
        public string topping_price;
        public string drink_type_name;
        public string option_name;
        public string option_price;
        public decimal grandTotal;   
        public string topping;
        public string options;
        public string mode;
        public decimal subTotal;
        public decimal shipping;
        public decimal grandTotalPayment;
        public string code;
        public int quantityOrder;
        public string token;
        public string id_transaction;
        public int min = 0;
        public string type;
        public string id_user;
        public string delivery_method;
        List<int> str1 = new List<int>();
        List<int> str2 = new List<int>();


        FormInputTableNumber Form;
        FormOrderProduct Form1;
        FormPaymentSale Form2;
        FormOrderOnline Form3;
        FormError Form4;
        FormReward Form5;
        FormVoucherDiscount Form6;
        FormShowOrder Form7;
        MySqlConnection con = new MySqlConnection();
        FormExportInvoice Form8;
        public FormSale(FormLoginSysterm parent)
        {
            InitializeComponent();
            _parent = parent;
            ListCategory();
            Form = new FormInputTableNumber(this);
            Form1 = new FormOrderProduct(this);
            Form2 = new FormPaymentSale(this);
            Form3 = new FormOrderOnline(this);
            Form4 = new FormError();
            Form5 = new FormReward(this);
            Form6 = new FormVoucherDiscount(this);
            Form7 = new FormShowOrder(this);
            Form8 = new FormExportInvoice(this);
        }
        private PictureBox pic = new PictureBox();
        public Label price;
        public Label title;



        void ketnoi()
        {
            con.ConnectionString = "SERVER=45.252.251.29;PORT=3306;DATABASE=sodopxlg_koffeeholic;UID=sodopxlg;PASSWORD=05qT1yfRp9";
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

        public void clear()
        {
            cbCategory.SelectedIndex = -1;
            txtSearch.Text = string.Empty; 
        }

        public void clearFlp()
        {
            flpOrder.Controls.Clear();
        }



        public void clearOrder()
        {
            id_order = "0";
            tableNumber = "0";
            grandTotal = 0;
            grandTotalPayment = 0;
            subTotal = 0;
            shipping = 0;
            lblGrandTotal.Text = lblShipping.Text = lblSubtotal.Text = "0 đ";
            quantityOrder = 0;
        }



        public void clearOrder1()
        {
            grandTotal = 0;
            grandTotalPayment = 0;
            subTotal = 0;
            shipping = 0;
            lblGrandTotal.Text = lblShipping.Text = lblSubtotal.Text = "0 đ";
            quantityOrder = 0;
        }

        public void clearProduct()
        {
            lblGrandTotal.Text = lblShipping.Text = lblSubtotal.Text = "0 đ";
            grandTotalPayment = 0;
        }

        public void LoadStaff()
        {
            lblFullName.Text = fullName;
            lblRoleName.Text = roleName;
            ptImageStaff.Image = ConvertBase64ToImage(imageStaff);
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


        public void LoadProductList()
        {
            List<ProductShow> productList = DbProduct.LoadProductList1();

            foreach (ProductShow item in productList)
            {
                Guna2Elipse elip = new Guna2Elipse();
                elip.TargetControl = pic;
                elip.BorderRadius = 7;

                Guna2Elipse elip1 = new Guna2Elipse();
                elip1.TargetControl = title;
                elip1.BorderRadius = 7;

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
                guna2GradientPanel.BorderRadius = 5;


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

                pic.Click += new EventHandler(Onclick);
            }
        }


        public void Onclick(object sender, EventArgs e)
        {
            FormBackGround formBackGround = new FormBackGround();
            try
            {
                using (FormOrderProduct Form = new FormOrderProduct(this))
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

                    grandTotal = 0;
                    string tag = ((PictureBox)sender).Tag.ToString();
                    Form.idProduct = tag;
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
            //grandTotal = 0;
            //string tag = ((PictureBox)sender).Tag.ToString();
            //Form1.idProduct = tag;
            //Form1.ShowDialog();
        }

        public void Onclick1(object sender, EventArgs e)
        {
            string tag = ((CartItem)sender).ItemId.ToString();
            DbOrderItem.DeleteOrderItem(tag);
            LoadOrderItem();
        }


        public void ReadFormDataFile(string fileLocation)
        {
            ItemDetail itemDetail = JsonConvert.DeserializeObject<ItemDetail>(fileLocation);
            str1 = itemDetail.options;
            str2 = itemDetail.toppings;
        }


        public void OptionName(int id, string product_id, int quantity)
        {
            if (DbOption.CheckOption(id.ToString()) == true)
            {

                List<OptionShow> option_Show_List = DbOption.OptionShow(id.ToString(), product_id);
                foreach (OptionShow item1 in option_Show_List)
                {
                    option_name = item1.title;
                    option_price = string.Format("{0:#,##0} đ", item1.price);
                    id_option = item1.id.ToString();
                    grandTotal = grandTotal + (item1.price * quantity);
                    return;
                }
            }
        }


        public void ToppingName(int id, int quantity)
        {
            if (DbTopping.CheckTopping(id.ToString()) == true)
            {
                List<ToppingShow> toppingShows = DbTopping.LoadToppingClick(id.ToString());
                foreach (ToppingShow item1 in toppingShows)
                {
                    topping_name = item1.title;
                    topping_price = string.Format("{0:#,##0} đ", item1.price);
                    id_topping = item1.id.ToString();
                    grandTotal = grandTotal + (item1.price * quantity);
                    return;
                }
            }
        }




        public void LoadOrderItem(string id, string shippingOrderOnline)
        {
            id_order = id;
            flpOrder.Controls.Clear();
            List<Order_Items> order_Items_List = DbOrderItem.order_Items_List(Convert.ToString(id));
            foreach (Order_Items item in order_Items_List)
            {
                quantityOrder = quantityOrder + 1;
                ReadFormDataFile(item.item_detail);
                string x = id_topping;
                CartItem cart = new CartItem(this);
                cart.ItemName = item.title;
                cart.ItemPrice = string.Format("{0:#,##0} đ", item.price);
                cart.ItemQuantity = item.quantity.ToString();
                List<Discount> discounts = DbDiscount.LoadDiscountList(DateTime.Now.ToString("yyyy-MM-dd"));
                foreach (Discount item1 in discounts)
                {
                    string k = Convert.ToString(item.product_id);
                    if (item1.product.Contains(k) == true)
                    {
                        decimal kq = (item.price * Convert.ToDecimal(item1.discount)) / 100;
                        decimal discount = item.price - kq;
                        cart.ItemDiscount = string.Format("{0:#,##0} đ", kq);
                        grandTotal = grandTotal + (item.quantity * discount);
                    }
                    else
                    {
                        grandTotal = grandTotal + (item.quantity * item.price);
                    }
                }
                flpOrder.Controls.Add(cart);

                int length = str1.Count;
                for (int i = 0; i < length; i++)
                {
                    OptionName(str1[i], item.product_id.ToString(), item.quantity);
                    if (Convert.ToInt32(str1[i]) != 0)
                    {
                        ItemDetailOption itemDetailOption = new ItemDetailOption();
                        itemDetailOption.ItemId = str1[i].ToString();
                        itemDetailOption.ItemNameOption = option_name;
                        itemDetailOption.ItemPrice = option_price;
                        flpOrder.Controls.Add(itemDetailOption);
                    }
                }
                int length1 = str2.Count;
                for (int i = 0; i < length1; i++)
                {
                    ToppingName(str2[i], item.quantity);
                    if (Convert.ToInt32(str2[i]) != 0)
                    {
                        ItemDetailTopping itemDetailTopping = new ItemDetailTopping();
                        itemDetailTopping.ItemId = str2[i].ToString();
                        itemDetailTopping.ItemNameTopping = topping_name;
                        itemDetailTopping.ItemPriceTopping = topping_price;
                        flpOrder.Controls.Add(itemDetailTopping);
                    }
                }
                lblGrandTotal.Text = string.Format("{0:#,##0} đ", double.Parse(grandTotal.ToString()));
                grandTotalPayment = grandTotal;
                subTotal = grandTotal + Convert.ToDecimal(shippingOrderOnline);
                lblShipping.Text = string.Format("{0:#,##0} đ", double.Parse(shippingOrderOnline.ToString()));
                lblSubtotal.Text = string.Format("{0:#,##0} đ", double.Parse(subTotal.ToString()));
                mode = "online";
                shipping = Convert.ToDecimal(shippingOrderOnline);
            }
        }


        public void LoadOrderItem()
        {
            flpOrder.Controls.Clear();
            List<Order_Items> order_Items_List = DbOrderItem.order_Items_List(Convert.ToString(id_order));
            foreach (Order_Items item in order_Items_List)
            {
                quantityOrder = quantityOrder + 1;
                ReadFormDataFile(item.item_detail);
                string x = id_topping;
                CartItem cart = new CartItem(this);
                cart.ItemName = item.title;
                cart.ItemPrice = string.Format("{0:#,##0} đ", item.price);
                cart.ItemQuantity = item.quantity.ToString();
                cart.ItemId = item.id.ToString();


                List<Discount> discounts = DbDiscount.LoadDiscountList(DateTime.Now.ToString("yyyy-MM-dd"));
                foreach (Discount item1 in discounts)
                {
                    string k = Convert.ToString(item.product_id);
                    if (item1.product.Contains(k) == true)
                    {
                        decimal kq = (item.price * Convert.ToDecimal(item1.discount)) / 100;
                        decimal discount = item.price - kq;
                        cart.ItemDiscount = string.Format("{0:#,##0} đ", kq);
                        grandTotal = grandTotal + (item.quantity * discount);
                    }
                    else
                    {
                        grandTotal = grandTotal + (item.quantity * item.price);
                    }
                }

                flpOrder.Controls.Add(cart);

                int length = str1.Count;
                for (int i = 0; i < length; i++)
                {
                    OptionName(str1[i], item.product_id.ToString(), item.quantity);
                    if (Convert.ToInt32(str1[i]) != 0)
                    {
                        ItemDetailOption itemDetailOption = new ItemDetailOption();
                        itemDetailOption.ItemId = str1[i].ToString();
                        itemDetailOption.ItemNameOption = option_name;
                        itemDetailOption.ItemPrice = option_price;
                        flpOrder.Controls.Add(itemDetailOption);
                    }
                }
                int length1 = str2.Count;
                for (int i = 0; i < length1; i++)
                {
                    ToppingName(str2[i], item.quantity);
                    if (Convert.ToInt32(str2[i]) != 0)
                    {
                        ItemDetailTopping itemDetailTopping = new ItemDetailTopping();
                        itemDetailTopping.ItemId = str2[i].ToString();
                        itemDetailTopping.ItemNameTopping = topping_name;
                        itemDetailTopping.ItemPriceTopping = topping_price;
                        flpOrder.Controls.Add(itemDetailTopping);
                    }
                }
                lblGrandTotal.Text = string.Format("{0:#,##0} đ", double.Parse(grandTotal.ToString()));
                grandTotalPayment = grandTotal;
                subTotal = grandTotal + shipping;
                lblShipping.Text = string.Format("{0:#,##0} đ", double.Parse(shipping.ToString()));
                lblSubtotal.Text = string.Format("{0:#,##0} đ", double.Parse(subTotal.ToString()));
                mode = "offline";

                cart.Click += new EventHandler(Onclick1);
            }
        }


        private void FormSale_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
            Timer timer = new Timer();
            timer.Interval = (1 * 450); // 1 secs
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();

            Timer timer2 = new Timer();
            timer2.Interval = (1 * 450); // 1 secs
            timer2.Tick += new EventHandler(timer2_Tick);
            timer2.Start();

            LoadProductList();
            LoadOrderItem();
            LoadStaff();

            Guna.UI.Lib.ScrollBar.PanelScrollHelper flowpan = new Guna.UI.Lib.ScrollBar.PanelScrollHelper(flpProduct, gunaVScrollBar1, true);
            Guna.UI.Lib.ScrollBar.PanelScrollHelper flowpan1 = new Guna.UI.Lib.ScrollBar.PanelScrollHelper(flpOrder, gunaVScrollBar2, true);
        }



        private void btnAllProduct_Click(object sender, EventArgs e)
        {
            clear();
            flpProduct.Controls.Clear();
            LoadProductList();
        }


        private void btnResetOrder_Click(object sender, EventArgs e)
        {
            List<Order_Items> order_Items_List = DbOrderItem.order_Items_List(Convert.ToString(id_order));
            foreach (Order_Items item in order_Items_List)
            {
                DbOrderItem.DeleteOrderItem(item.id.ToString());
            }
            flpOrder.Controls.Clear();
            lblGrandTotal.Text = lblShipping.Text = lblSubtotal.Text = "0 đ";
            grandTotalPayment = 0;
        }


        public void showTableNumber()
        {
            lblTableNumber.Text = tableNumber;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            min = min + 1;
            showTableNumber();
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            FormBackGround formBackGround = new FormBackGround();
            try
            {
                using (FormInputTableNumber Form = new FormInputTableNumber(this))
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
                    grandTotal = 0;
                    Form.staff_id = id_staff;
                    Form.ShowDialog();
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

        private void cbCategory_TextChanged(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            flpProduct.Controls.Clear();
            List<ProductShow> productShowList = DbProduct.LoadProductSearchList1(cbCategory.Text);
            foreach (ProductShow item in productShowList)
            {
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

                pic.Click += new EventHandler(Onclick);
            }
        }

        public void checkBtn()
        {
            btnAllProduct.Checked = true;
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            cbCategory.SelectedIndex = -1;
            flpProduct.Controls.Clear();
            List<ProductShow> productShowList = DbProduct.LoadProductSearchList(txtSearch.Text.Trim());
            foreach (ProductShow item in productShowList)
            {
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

                pic.Click += new EventHandler(Onclick);
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (grandTotalPayment == 0)
            {
                Form4.title = "Hóa Đơn Chưa Có Sản Phẩm!";
                Form4.ShowDialog();
                return;
            }
            //FormBackGround formBackGround = new FormBackGround();
            //try
            //{
            //    using (FormPaymentSale Form = new FormPaymentSale(this))
            //    {
            //        formBackGround.StartPosition = FormStartPosition.Manual;
            //        formBackGround.FormBorderStyle = FormBorderStyle.None;
            //        formBackGround.Opacity = .70d;
            //        formBackGround.BackColor = Color.Black;
            //        formBackGround.WindowState = FormWindowState.Maximized;
            //        formBackGround.TopMost = true;
            //        formBackGround.Location = this.Location;
            //        formBackGround.ShowInTaskbar = false;
            //        formBackGround.Show();


            //        if (mode == "online")
            //        {
            //            List<Trannsaction> trannsactionList = DbTransaction.LoadTransaction(id_order.ToString());
            //            foreach (Trannsaction item in trannsactionList)
            //            {
            //                token = item.token;
            //                id_transaction = item.id.ToString();
            //            }
            //            code = "#00000" + Convert.ToString(Convert.ToInt32(id_order) - 1);
            //            Trannsaction std1 = new Trannsaction(18, token, Convert.ToInt32(id_order), code, "cash", mode, "pickup", "", "packing");
            //            DbTransaction.UpdateTransaction(std1, id_transaction.ToString());
            //            SendPushNotification(id_transaction);
            //            Form2 = new FormPaymentSale(this);
            //            Form2.tableName = lblTableNumber.Text;
            //            Form2.provisional = grandTotalPayment.ToString();
            //            Form2.id_order = Convert.ToInt32(id_order);
            //            Form2.id_staff = id_staff;
            //            Form2.mode = mode;
            //            Form2.shipping = shipping;
            //            Form2.name_staff = lblFullName.Text;
            //            Form2.quantity = quantityOrder;
            //            Form2.ShowDialog();
            //        }
            //        else
            //        {
            //            Form2 = new FormPaymentSale(this);
            //            Form2.tableName = lblTableNumber.Text;
            //            Form2.provisional = grandTotalPayment.ToString();
            //            Form2.id_order = Convert.ToInt32(id_order);
            //            Form2.id_staff = id_staff;
            //            Form2.mode = mode;
            //            Form2.shipping = shipping;
            //            Form2.name_staff = lblFullName.Text;
            //            Form2.quantity = quantityOrder;
            //            Form2.ShowDialog();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}
            //finally
            //{
            //    formBackGround.Dispose();
            //}

            if (mode == "online")
            {
                List<Trannsaction> trannsactionList = DbTransaction.LoadTransaction(id_order.ToString());
                foreach (Trannsaction item in trannsactionList)
                {
                    token = item.token;
                    id_transaction = item.id.ToString();
                    id_user = item.user_id.ToString();
                    type = item.type;
                    delivery_method = item.delivery_method;
                }
                code = "#00000" + Convert.ToString(Convert.ToInt32(id_order) - 1);
                Trannsaction std1 = new Trannsaction(Convert.ToInt32(id_user), token, Convert.ToInt32(id_order), code,type, mode,delivery_method, "", "packing");
                DbTransaction.UpdateTransaction(std1, id_transaction.ToString());
                SendPushNotification(token,id_transaction);
                Form2 = new FormPaymentSale(this);
                Form2.tableName = lblTableNumber.Text;
                Form2.provisional = grandTotalPayment.ToString();
                Form2.id_order = Convert.ToInt32(id_order);
                Form2.id_staff = id_staff;
                Form2.mode = mode;
                Form2.shipping = shipping;
                Form2.id_user = id_user;
                Form2.name_staff = lblFullName.Text;
                Form2.quantity = quantityOrder;
                Form2.ShowDialog();
            }
            else
            {
                Form2 = new FormPaymentSale(this);
                Form2.tableName = lblTableNumber.Text;
                Form2.provisional = grandTotalPayment.ToString();
                Form2.id_order = Convert.ToInt32(id_order);
                Form2.id_staff = id_staff;
                Form2.mode = mode;
                Form2.shipping = shipping;
                Form2.id_user = "18";
                Form2.name_staff = lblFullName.Text;
                Form2.quantity = quantityOrder;
                Form2.ShowDialog();
            }

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string time = DateTime.Now.ToString("HH");
            List<Assignment> assignmentList = DbAssignment.LoadAssginmentListSearch(id_staff.ToString(), date);
            foreach (Assignment item1 in assignmentList)
            {
               int total_min = min + item1.total_min;
               DbAssignment.UpdateAssignmentTotalMin(total_min.ToString(), item1.id.ToString());
            }
            this.Close();
        }


        private void btnOrderOnline_Click(object sender, EventArgs e)
        {
            FormBackGround formBackGround = new FormBackGround();
            try
            {
                using (FormOrderOnline Form = new FormOrderOnline (this))
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

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {
            FormBackGround formBackGround = new FormBackGround();
            try
            {
                using (FormReward Form = new FormReward(this))
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

        private void timer2_Tick(object sender, EventArgs e)
        {
            int kq = 0;
            List<OrderShow> orderList = DbOrder.LoadOrderShow("online");
            foreach (OrderShow item in orderList)
            {
                kq = kq + 1;
            }
            lblCountOrderOnline.Text = Convert.ToString(kq);
        }

        private void btnHistoryOrder_Click(object sender, EventArgs e)
        {
            FormBackGround formBackGround = new FormBackGround();
            try
            {
                using (FormShowOrder Form = new FormShowOrder(this))
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

        private void btnVoucherDiscount_Click(object sender, EventArgs e)
        {
            FormBackGround formBackGround = new FormBackGround();
            try
            {
                using (FormVoucherDiscount Form = new FormVoucherDiscount(this))
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

        public async void notification()
        {
            var token = "fTmPozwiQeiDUIeLK-ofgE:APA91bFjFsINh6kbm_PuPWHRFY0M9XiR5S2Dt3lg-jeCdRgn24B0qRGj23tMkw44UAWHYfQC0MEKoKSpHv2ot5kyS1s_iCel09Ff80keHZskqT_vSgKMnHRYt-liJatnDrtNJyhIhSgg";
            var data = new NotificationTransaction
            {
                id = id_order,
                mode = mode,
                delivery_method = "pickup",
                status = "packing"
            };
            var result = client.DeleteAsync("notification");
            SetResponse response = await client.SetAsync("notification_transaction", data);
            SetResponse response1 = await client.SetAsync("token", token);
        }

        private static string SendPushNotification(string token,string id_transaction)
        {
            string response;

            try
            {
                // From: https://console.firebase.google.com/project/x.y.z/settings/general/android:x.y.z

                // Projekt-ID: x.y.z
                // Web-API-Key: A...Y (39 chars)
                // App-ID: 1:...:android:...

                // From https://console.firebase.google.com/project/x.y.z/settings/
                // cloudmessaging/android:x,y,z
                // Server-Key: AAAA0...    ...._4

                string serverKey = "AAAAxsx2lx8:APA91bHFQHpVrA3Mchy07X8oesMssw0mLx0mUFahdhumYy7s5kqM7PvLXLgfZruzKx8H8ps_j6QSX0jDn50UXfkfzFTykgQJO4Hw_j0Y7HzZoOjvBg3IspJm-DTS7PajmFWogib0kMJH"; // Something very long
                string senderId = "853833848607";
                string deviceId = token; // Also something very long, 
                // got from android
                //string deviceId = "/topics/all";               // Use this to notify all devices, 
                                                               // but App must be subscribed to 
                                                               // topic notification
                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");

                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                var dataBase = new
                {
                    to = token,
                    notification = new
                    {
                        title ="Trạng thái đơn hàng của bạn : Đã được tiếp nhận và đang xử lý !!!",
                        body = "Đơn hàng của bạn đã được tiếp nhận và đang xử lý , các trạng thái tiếp theo của đơn hàng sẽ được cập nhật đến bạn . ",
                        sound = "default"
                    },
                    data = new
                    {
                        transaction_id = id_transaction,
                        type = "transaction" 
                    }
                };

                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(dataBase);
                Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                tRequest.Headers.Add(string.Format("Authorization: key={0}", serverKey));
                tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                tRequest.ContentLength = byteArray.Length;

                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                response = sResponseFromServer;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }

            return response;
        }

        private void btnExportInvoice_Click(object sender, EventArgs e)
        {
            ExportInvoice std = new ExportInvoice(id_staff, DateTime.Now.ToString("yyyy-MM-dd"), 0);
            DbExportInvoice.AddExportInvoice(std);
            FormBackGround formBackGround = new FormBackGround();
            try
            {
                using (FormExportInvoice Form = new FormExportInvoice(this))
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
                    Form.id_staff = id_staff.ToString();
                    Form.ShowDialog();
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
