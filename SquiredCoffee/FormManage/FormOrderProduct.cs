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
       


        private readonly UC_ProductList _parent;
        private readonly FormStaff _parent1;
        public FormOrderProduct(UC_ProductList parent, FormStaff parent1)
        {
            InitializeComponent();
            _parent = parent;
            _parent1 = parent1;
        }

        public CheckBox chk = new CheckBox();
        public RadioButton rd = new RadioButton();
        public ComboBox cb = new ComboBox();
        
        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                lblProductName.Text = item.title;
                lblPrice.Text = string.Format("{0:#,##0}", double.Parse((item.price).ToString()));
                ptImage.Image = ConvertBase64ToImage(item.image);
                price_product = item.price;     
            }
        }



        public void LoadTopping()
        {
            List<ProductTopping> productToppings = DbProductTopping.LoadProductTopping(idProduct);
            foreach (ProductTopping item in productToppings)
            {
                List<Topping> toppings = DbTopping.LoadTopping((item.topping_id).ToString());
                foreach (Topping item1 in toppings)
                {
                    rd = new RadioButton();
                    rd.Width = 170;
                    rd.Height = 50;
                    rd.Text = item1.title;
                    rd.ForeColor = Color.White;
                    rd.Tag = item1;
                    flpToppings.Controls.Add(rd);
                    rd.Click += new EventHandler(OnclickTopping);
                }
            }
        }
        public void OnclickTopping(object sender, EventArgs e)
        {
            int tag_id = ((sender as RadioButton).Tag as Topping).id;
            decimal tag = ((sender as RadioButton).Tag as Topping).price;
            price_topping = tag;
            topping_id = tag_id;
        }

        

        public void LoadOptionSize()
        {
            List<OptionGroup> optionGroups = DbOptionGroup.LoadOptionGroup("size");
            foreach (OptionGroup item in optionGroups)
            {
                List<Option> options = DbOption.LoadOption(idProduct.ToString(),item.id.ToString());
                foreach (Option item1 in options)
                {
                    if(item1.default_product_option == 1)
                    {
                        rd = new RadioButton();
                        rd.Width = 150;
                        rd.Height = 50;
                        rd.Text = item1.title + item1.name_product_option;
                        rd.Checked = true;
                        rd.ForeColor = Color.White;
                        rd.Tag = item1;
                        id_product_option_size = item1.id;
                    }
                    else
                    {
                        rd = new RadioButton();
                        rd.Width = 150;
                        rd.Height = 50;
                        rd.Text = item1.title + item1.name_product_option;
                        rd.ForeColor = Color.White;
                        rd.Tag = item1;
                    }
                   
                    flpSize.Controls.Add(rd);
                    rd.Click += new EventHandler(OnclickSize);
                }
            }
        }

        public void OnclickSize(object sender, EventArgs e)
        {
            int tag1 = ((sender as RadioButton).Tag as Option).id;
            decimal tag = ((sender as RadioButton).Tag as Option).price;
            price_option_size = tag;
            id_product_option_size = tag1;
        }

        public void LoadOptionIce()
        {
            List<OptionGroup> optionGroups = DbOptionGroup.LoadOptionGroup("ice");
            foreach (OptionGroup item in optionGroups)
            {
                List<Option> options = DbOption.LoadOption(idProduct.ToString(), item.id.ToString());
                foreach (Option item1 in options)
                {

                    if (item1.default_product_option == 1)
                    {
                        rd = new RadioButton();
                        rd.Width = 150;
                        rd.Height = 50;
                        rd.Text = item1.title + item1.name_product_option;
                        rd.Checked = true;
                        rd.ForeColor = Color.White;
                        rd.Tag = item1;
                    }
                    else
                    {
                        rd = new RadioButton();
                        rd.Width = 150;
                        rd.Height = 50;
                        rd.Text = item1.title + item1.name_product_option;
                        rd.ForeColor = Color.White;
                        rd.Tag = item1;
                    }

                    flpIce.Controls.Add(rd);
                    rd.Click += new EventHandler(OnclickIce);
                }
            }
        }
        public void OnclickIce(object sender, EventArgs e)
        {   int tag_id = ((sender as RadioButton).Tag as Option).id;
            decimal tag = ((sender as RadioButton).Tag as Option).price;
            price_option_ice = tag;
            id_product_option_ice = tag_id;
        }

        public void LoadOptionSugar()
        {
            List<OptionGroup> optionGroups = DbOptionGroup.LoadOptionGroup("sugar");
            foreach (OptionGroup item in optionGroups)
            {
                List<Option> options = DbOption.LoadOption(idProduct.ToString(), item.id.ToString());
                foreach (Option item1 in options)
                {
                    if (item1.default_product_option == 1)
                    {
                        rd = new RadioButton();
                        rd.Width = 150;
                        rd.Height = 50;
                        rd.Text = item1.title + item1.name_product_option;
                        rd.Checked = true;
                        rd.ForeColor = Color.White;
                    }
                    else
                    {
                        rd = new RadioButton();
                        rd.Width = 150;
                        rd.Height = 50;
                        rd.Text = item1.title + item1.name_product_option;
                        rd.ForeColor = Color.White;
                    }
                    flpSugar.Controls.Add(rd);
                    rd.Click += new EventHandler(OnclickSugar);
                }
            }
        }

        public void OnclickSugar(object sender, EventArgs e)
        {
            int tag_id = ((sender as RadioButton).Tag as Option).id;
            decimal tag = ((sender as RadioButton).Tag as Option).price;
            id_product_option_sugar = tag_id;
        }


        public void clear()
        {
            txtAmount.Text = "1";
        }


        private void FormOrderProduct_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = (1 * 450); // 1 secs
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
            txtAmount.Enabled = false;
            price_topping = 0;
            flpIce.Controls.Clear();
            flpSize.Controls.Clear();
            flpSugar.Controls.Clear();
            flpToppings.Controls.Clear();
            LoadProductList();
            LoadOptionSize();
            LoadOptionIce();
            LoadOptionSugar();
          
            LoadTopping();
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
            decimal cost = (price_topping + price_product + price_option_size);
            total_product = cost*Convert.ToInt32(txtAmount.Text);
            lblTotal.Text = string.Format("{0:#,##0} vnđ",total_product);
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if(_parent.id_order == 0)
            {
                MessageBox.Show("Hãy Nhập Số Bàn Trước Khi Order");
                return;
            }
            List<ItemDetail> itemDetails = new List<ItemDetail>
            {         
                 new ItemDetail
                 {
                     size = id_product_option_size,
                     ice = id_product_option_ice,
                     sugar = id_product_option_sugar,
                     drink_type =id_product_option_drink_type,
                     topping = topping_id
                 }
            };
            // Kiểm tra trước khi chọn 
            string jsonString = JsonConvert.SerializeObject(itemDetails.ToArray());
            Order_Items std = new Order_Items(_parent.id_order, Convert.ToInt32(idProduct), jsonString, Convert.ToInt32(txtAmount.Text),total_product, txtContent.Text);
            DbOrderItem.AddOrderItem(std);
            clear();
            this.Close();
            _parent1.clear();
            _parent1.Display();
        }
    }
}
