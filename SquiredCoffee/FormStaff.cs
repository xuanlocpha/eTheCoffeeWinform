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
using SquiredCoffee.UC_ManageSysterm;
using Nancy.Json;
using SquiredCoffee.ViewModels;
using Guna.UI2.WinForms;

namespace SquiredCoffee
{
    public partial class FormStaff : Form
    {
        UC_TableList Form4;
        FormInputTableNumber Form5;
        FormPayment Form1;
        UC_ProductList Form6;

        public string title_table;
        public int id_order;
        public int id_staff;
        public string table_name;
        public string image;
        public Label price;
        public Label title;
        public int amount = 1;
        public string fullName;
        public string roleName;
        public int size_id;
        public int topping_id;
        public int ice_id;
        public int sugar_id;
        public int drink_type_id;
        public decimal grandTotal;
        public string option_size_name;
        public string option_sugar_name;
        public string option_ice_name;
        public string option_drink_type_name;
        public string topping_name;

        private readonly FormLogin _parent;
        
        public FormStaff(FormLogin parent)
        {
            InitializeComponent();
            _parent = parent;
            Form1 = new FormPayment(this);
            Form4 = new UC_TableList(this);
            Form5 = new FormInputTableNumber(this);
            Form6 = new UC_ProductList(this);
        }

        private PictureBox pic = new PictureBox();
        private Button btn = new Button();
        
       

        public void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelList.Controls.Clear();
            panelList.Controls.Add(c);
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
        
       


        public void LoadJson(string file)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            ItemDetail[] itemDetails = js.Deserialize<ItemDetail[]>(file);
            foreach (ItemDetail item in itemDetails)
            {
                size_id = item.size;
                ice_id = item.ice;
                topping_id = item.topping;
                sugar_id = item.sugar;
                drink_type_id = item.drink_type;
            }
        }

        public void optionIceName()
        {

            if (DbOption.CheckOption(ice_id.ToString()) == true)
            {
                List<OptionShow> option_Show_List = DbOption.OptionShow(ice_id.ToString());
                foreach (OptionShow item1 in option_Show_List)
                {
                    option_ice_name = item1.title;
                }
            }
            else
            {
                option_ice_name = "Mặc định";
            }

        }


        public void optionSugarName()
        {

            if (DbOption.CheckOption(sugar_id.ToString()) == true)
            {
                List<OptionShow> option_Show_List = DbOption.OptionShow(sugar_id.ToString());
                foreach (OptionShow item1 in option_Show_List)
                {
                    option_sugar_name = item1.title;
                }
            }
            else
            {
                option_sugar_name = "Mặc định";
            }

        }


        public void optionDrinkTypeName()
        {

            if (DbOption.CheckOption(drink_type_id.ToString()) == true)
            {
                List<OptionShow> option_Show_List = DbOption.OptionShow(drink_type_id.ToString());
                foreach (OptionShow item1 in option_Show_List)
                {
                    option_drink_type_name = item1.title;
                }
            }
            else
            {
                option_drink_type_name = "Mặc định";
            }

        }

        public void toppingName()
        {

            if (DbTopping.CheckTopping(topping_id.ToString()) == true)
            {
                List<Topping> toppping_Show_List = DbTopping.LoadTopping(topping_id.ToString());
                foreach (Topping item1 in toppping_Show_List)
                {
                    topping_name = item1.title;
                }
            }
            else
            {
                topping_name = "Mặc định";
            }

        }


        public void Display()
        {
            List<Order_Items> order_Items_List = DbOrderItem.order_Items_List(id_order.ToString());
            foreach (Order_Items item in order_Items_List)
            {
                grandTotal += item.total_product;
                LoadJson(item.item_detail);
                optionIceName();
                optionSugarName();
                optionDrinkTypeName();
                toppingName();
                List<OptionShow> option_Show_List = DbOption.OptionShow(size_id.ToString());
                foreach (OptionShow item1 in option_Show_List)
                {
                    dgvOrder.Rows.Add(new object[]
                    {
                            item.title,
                            item.quantity,
                            item1.title,
                            string.Format("{0:#,##0} đ",item.price),
                            string.Format("{0:#,##0} đ",item.total_product),
                            "Topping :"+topping_name+" , "+"Đá :"+option_ice_name+" , "+"Đường :"+option_sugar_name+" , "+"Kiểu nước:"+option_drink_type_name
                    });
                }
            }


            lblGrandTotal.Text = string.Format("{0:#,##0} đ", double.Parse(grandTotal.ToString()));
        }
          


        public void Onclick(object sender, EventArgs e)
        {
            string tag = ((PictureBox)sender).Tag.ToString();
        }



        public void OnclickCategory(object sender, EventArgs e)
        {
            string tag = ((Button)sender).Tag.ToString();
            clear();
        }




        private void FormStaff_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = (1 * 450); // 1 secs
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            UC_ProductList uC_ProductList = new UC_ProductList(this);
            AddControlsToPanel(uC_ProductList);
            lblFullName.Text = fullName;
            lblRole.Text = roleName;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnListTable_Click(object sender, EventArgs e)
        {
           
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

     

      
        private void timer_Tick(object sender, EventArgs e)
        {
            showTableName();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {

        }

    

        public void clear()
        {
            txtSearch.Text = string.Empty;
            grandTotal = 0;
            lblGrandTotal.Text = string.Empty;
            dgvOrder.Rows.Clear();
        }

        private void btnAllProduct_Click(object sender, EventArgs e)
        {
           // flpProducts.Controls.Clear();
         
            clear();
        }
        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            Form5.ShowDialog();
        }

        private void btnAccumulatePoints_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void btnChangeTable_Click(object sender, EventArgs e)
        {
          
        }

        private void btnListTable_Click_2(object sender, EventArgs e)
        {
            UC_TableList uC_TableList = new UC_TableList(this);
            AddControlsToPanel(uC_TableList);
        }

        public void showTableName()
        {
            lblTableName.Show();
            lblTableNumber.Text = table_name;
        }

        private void lblTableNumber_Click_1(object sender, EventArgs e)
        {

        }

        private void btnListProduct_Click(object sender, EventArgs e)
        {
            UC_ProductList uC_ProductList = new UC_ProductList(this);
            AddControlsToPanel(uC_ProductList);
        }

        private void dgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvOrder_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string price = dgvOrder.Rows[e.RowIndex].Cells[6].Value.ToString();
            MessageBox.Show("Xin Chào Bạn !!!" + price);
            return;
        }

        private void dgvOrder_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn Logout hay không !!!", "Infomation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
            _parent.clear();
            return;
           
        }

        private void dgvOrder_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            Form1.provisional = grandTotal.ToString();
            Form1.id_order = id_order;
            Form1.id_staff = id_staff;
            Form1.tableName = table_name;
            Form1.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Form6.Search = (txtSearch.Text).ToString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if(id_order == 0)
            {
                if (MessageBox.Show("Bạn chưa chọn bàn để làm mới !!!", "Infomation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                }
            }
            else
            {
                List<Order_Items> order_Items_List = DbOrderItem.order_Items_List(id_order.ToString());
                foreach (Order_Items item in order_Items_List)
                {
                    DbOrderItem.DeleteOrderItem(item.id.ToString());
                }
                DbOrder.DeleteOrder(id_order.ToString());
                table_name = "";
                Display();
                clear();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (DbTransaction.CheckDb(id_order.ToString()) == true)
            {

            }
            else
            {
                string code = "code" + id_order.ToString();
                Trannsaction std = new Trannsaction(id_order, code, "", "offline", "", "received");
                DbTransaction.AddTransaction(std);
            }
        }
    }
}
