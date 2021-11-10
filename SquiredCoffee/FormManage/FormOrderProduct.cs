using SquiredCoffee.Class;
using SquiredCoffee.DB;
using SquiredCoffee.UC_ManageSysterm;
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
using Newtonsoft.Json;
using MySql.Data.MySqlClient;
using SquiredCoffee.ViewModels;

namespace SquiredCoffee.FormManage
{
    public partial class FormOrderProduct : Form
    {
        public string idProduct;
        public decimal price_product;
        public decimal price_topping;
        public decimal price_option_size;
        public decimal price_option_ice;
        public int id_product_option_size;
        public int id_product_option_ice;
        public int id_product_option_sugar;
        public int id_product_option_drink_type;
        public int topping_id;
        public decimal total_product;
        List<int> str1 = new List<int>();
        List<int> str2 = new List<int>();
        public string option ="";
        public string topping ="";
        public decimal price;
        public string voucher;
        FormSuccess Form1;
        FormError Form2;

        private readonly FormSale _parent;
        public FormOrderProduct(FormSale parent)
        {
            InitializeComponent();
            _parent = parent;
            Form1 = new FormSuccess();
            Form2 = new FormError();
        }

      

        public CheckBox chk = new CheckBox();
        public RadioButton rd = new RadioButton();
        public ComboBox cb = new ComboBox();
        MySqlConnection con = new MySqlConnection();

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

        void ListSize()
        {
            List<OptionGroup> optionGroups = DbOptionGroup.LoadOptionGroup("Size");
            foreach (OptionGroup item in optionGroups)
            {
                string sql = "SELECT o.id,o.title,o.option_group_id,o.status,CONCAT(o.title,' ',po.title) as name_product_option,po.price,po.default as default_product_option FROM options o,product_options po WHERE po.product_id ='" + idProduct + "' AND po.option_id = o.id AND o.option_group_id='" + item.id + "' ";
                DataSet ListCategory = new DataSet();
                ListCategory = LoadDB(sql);
                cbSize.DataSource = ListCategory.Tables[0];
                cbSize.DisplayMember = "name_product_option";
                cbSize.SelectedIndex = -1;
                cbSize.ValueMember = "id";
            }
            con.Close();
        }

        public DataSet LoadDB1(string sql1)
        {
            ketnoi();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(sql1, con);
            da.Fill(ds);
            return ds;
        }

        void ListIce()
        {
            List<OptionGroup> optionGroups = DbOptionGroup.LoadOptionGroup("Ice");
            foreach (OptionGroup item in optionGroups)
            {
                string sql1 = "SELECT o.id,o.title,o.option_group_id,o.status,CONCAT(o.title,' ',po.title) as name_product_option,po.price,po.default as default_product_option FROM options o,product_options po WHERE po.product_id ='" + idProduct + "' AND po.option_id = o.id AND o.option_group_id='" + item.id + "' ";
                DataSet ListIce = new DataSet();
                ListIce= LoadDB1(sql1);
                cbIce.DataSource = ListIce.Tables[0];
                cbIce.DisplayMember = "name_product_option";
                cbIce.SelectedIndex = -1;
                cbIce.ValueMember = "id";
            }
            con.Close();
        }

        public DataSet LoadDB2(string sql2)
        {
            ketnoi();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(sql2, con);
            da.Fill(ds);
            return ds;
        }

        void ListSugar()
        {
            List<OptionGroup> optionGroups = DbOptionGroup.LoadOptionGroup("Sugar");
            foreach (OptionGroup item in optionGroups)
            {
                string sql2 = "SELECT o.id,o.title,o.option_group_id,o.status,CONCAT(o.title,' ',po.title) as name_product_option,po.price,po.default as default_product_option FROM options o,product_options po WHERE po.product_id ='" + idProduct + "' AND po.option_id = o.id AND o.option_group_id='" + item.id + "' ";
                DataSet ListSugar = new DataSet();
                ListSugar = LoadDB2(sql2);
                cbSugar.DataSource = ListSugar.Tables[0];
                cbSugar.DisplayMember = "name_product_option";
                cbSugar.SelectedIndex = -1;
                cbSugar.ValueMember = "id";
                
                con.Close();
            }
        }


        public DataSet LoadDB3(string sql3)
        {
            ketnoi();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(sql3, con);
            da.Fill(ds);
            return ds;
        }

        void ListTopping()
        {
            string sql3 = "SELECT t.id,t.title,t.description,t.price FROM product_toppings pt  INNER JOIN products p ON p.id = pt.product_id   INNER JOIN toppings t ON t.id = pt.topping_id WHERE p.id = '" + idProduct + "'";
            DataSet ListTopping = LoadDB3(sql3);
            cbTopping.DataSource = ListTopping.Tables[0];
            cbTopping.DisplayMember = "title";
            cbTopping.ValueMember = "id";
            cbTopping.SelectedIndex = -1;
            con.Close();
        }


   

        public void clear()
        {
            txtAmount.Text = "1";
            price_topping = 0;
            price_option_size = 0;
            option = "";
            topping = "";
            str1.Clear();
            str2.Clear();
            id_product_option_size = 0;
            id_product_option_ice = 0;
            id_product_option_sugar = 0;
            topping_id = 0;
        }


        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
            clear(); 
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

        public void LoadProductList()
        {
            List<Product> productList = DbProduct.LoadProduct(idProduct);

            foreach (Product item in productList)
            {
                lblProductName1.Text = item.title;
                lblPrice.Text = string.Format("{0:#,##0} đ", double.Parse((item.price).ToString()));
                ptImage.Image = ConvertBase64ToImage(item.image);
                price_product = item.price;
                price = item.price;
            }
        }


        //public void LoadTopping()
        //{
        //    List<ProductTopping> productToppings = DbProductTopping.LoadProductTopping(idProduct);
        //    foreach (ProductTopping item in productToppings)
        //    {
        //        List<Topping> toppings = DbTopping.LoadTopping((item.topping_id).ToString());
        //        foreach (Topping item1 in toppings)
        //        {
        //            rd = new RadioButton();
        //            rd.Width = 120;
        //            rd.Height = 50;
        //            rd.Text = item1.title;
        //            rd.ForeColor = Color.White;
        //            rd.Tag = item1;
        //            panelTopping.Controls.Add(rd);
        //            //rd.Click += new EventHandler(OnclickTopping);
        //        }
        //    }
        //}


        private void FormOrderProduct_Load(object sender, EventArgs e)
        {
            LoadProductList();
            ListTopping();
            ListSize();
            ListIce();
            ListSugar();

            str1.Clear();
            str2.Clear();

            Timer timer = new Timer();
            timer.Interval = (1 * 450); // 1 secs
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
            txtAmount.Enabled = false;
            price_topping = 0;
            price_option_size = 0;
 
          
        }

        private void pbClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            txtAmount.Text = (Convert.ToInt32(txtAmount.Text) + 1).ToString();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            txtAmount.Text = (Convert.ToInt32(txtAmount.Text) - 1).ToString();
            if(txtAmount.Text == "-1")
            {
                txtAmount.Text = "0";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            decimal cost = ( price_product + price_option_size + price_topping );
            total_product = cost*Convert.ToInt32(txtAmount.Text);
            lblTotal.Text = string.Format("{0:#,##0} vnđ",total_product);
        }
    

        private void btnOrder_Click(object sender, EventArgs e)
        {
           
            if (Convert.ToInt32(_parent.id_order) == 0)
            {
                Form2.title = "Bạn Chưa Nhập Số Bàn !";
                Form2.ShowDialog();
                this.Close();
                return;
            }

            if(DbOrder.CheckTypeOrderProduct(idProduct,"drink") == true && str1.Count == 0)
            {
                    Form2.title = "Bạn Chưa Nhập Chọn Size Cho Sản Phẩm !";
                    Form2.ShowDialog();
                    return;
            }
          
            else
            {
                ItemDetail itemDetails = new ItemDetail();
                itemDetails.options = str1;
                itemDetails.toppings = str2;
 
                // Kiểm tra trước khi chọn 
                string jsonString = JsonConvert.SerializeObject(itemDetails);
                Order_Items std = new Order_Items(Convert.ToInt32(idProduct), jsonString, Convert.ToInt32(_parent.id_order), Convert.ToInt32(txtAmount.Text), price, "");
                DbOrderItem.AddOrderItem(std);
                clear();
                this.Close();              
                _parent.LoadOrderItem();
             }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbSize_SelectedValueChanged(object sender, EventArgs e)
        {
            string x = Convert.ToString(cbSize.SelectedValue);
            List<ProductOptionShow> productOptionShows = DbProductOption.SearchProductOption(Convert.ToString(cbSize.SelectedValue));
            foreach (ProductOptionShow item in productOptionShows)
            {
                price_option_size = item.price;
                id_product_option_size = item.id;
                str1.Add(id_product_option_size);
            }
        }

        private void cbIce_SelectedValueChanged(object sender, EventArgs e)
        {
            List<ProductOptionShow> productOptionShows = DbProductOption.SearchProductOption(Convert.ToString(cbIce.SelectedValue));
            foreach (ProductOptionShow item in productOptionShows)
            {
                price_option_ice = item.price;
                id_product_option_ice = item.id;
                str1.Add(id_product_option_ice);
            }
        }

        private void cbSugar_SelectedValueChanged(object sender, EventArgs e)
        {
            List<ProductOptionShow> productOptionShows = DbProductOption.SearchProductOption(Convert.ToString(cbSugar.SelectedValue));
            foreach (ProductOptionShow item in productOptionShows)
            {
                id_product_option_sugar = item.id;
                str1.Add(id_product_option_sugar);
            }
        }

        private void cbTopping_SelectedValueChanged(object sender, EventArgs e)
        {
            string x = Convert.ToString(cbTopping.SelectedValue);
            if( x == "")
            {
                price_topping = 0;
                topping_id = 0;
            }
            else
            {
                List<ToppingShow> toppingShows = DbTopping.LoadToppingClick(Convert.ToString(cbTopping.SelectedValue));
                foreach (ToppingShow item in toppingShows)
                {
                    price_topping = item.price;
                    topping_id = item.id;
                    str2.Add(topping_id);
                }
            }
        }

    }
}
