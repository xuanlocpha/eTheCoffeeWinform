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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SquiredCoffee.FormManage
{
    public partial class FormInformationProductOption : Form
    {
        MySqlConnection con = new MySqlConnection();
        public int id_product_option;
        public int status;
        public int defaults;
        public static UC_ManageProductOption _parent;
        FormSuccess Form1;
        FormError Form2;
        public FormInformationProductOption(UC_ManageProductOption parent)
        {
            InitializeComponent();
            ListOption();
            ListProduct();
            _parent = parent;
            Form1 = new FormSuccess();
            Form2 = new FormError();
        }

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

        void ListOption()
        {
            string sql = "SELECT * FROM options";
            DataSet ListCategory = new DataSet();
            ListCategory = LoadDB(sql);
            cbOptionName.DataSource = ListCategory.Tables[0];
            cbOptionName.DisplayMember = "title";
            cbOptionName.ValueMember = "id";
            cbOptionName.SelectedIndex = -1;
            con.Close();
        }

        void ListProduct()
        {
            string sql = "SELECT * FROM products";
            DataSet ListCategory = new DataSet();
            ListCategory = LoadDB(sql);
            cbProductName.DataSource = ListCategory.Tables[0];
            cbProductName.DisplayMember = "title";
            cbProductName.ValueMember = "id";
            cbProductName.SelectedIndex = -1;
            con.Close();
        }

        public void chk(bool a)
        {
            if(a == true)
            {
                chkDefault1.Checked = true;
                chkDefault2.Checked = false;
            }
            else if(a == false)
            {
                chkDefault1.Checked = false;
                chkDefault2.Checked = true;
            }
        }


        public void Display()
        {
            List<ProductOptionShow> productOptionShowList = DbProductOption.LoadProductOption(id_product_option.ToString());
            foreach (ProductOptionShow item in productOptionShowList)
            {
                cbOptionName.Text = item.name_option;
                cbProductName.Text = item.name_product;
                txtTitle.Text = item.title;
                txtPrice.Text = string.Format("{0:#,##0}", item.price);
                if (item.defaults == 1)
                {
                    chk(true);
                }
                else if (item.defaults == 0)
                {
                    chk(false);
                }
                if (item.status == 1)
                {
                    rdStatus1.Checked = true;
                }
                else if (item.status == 0)
                {
                    rdStatus2.Checked = true;
                }
                defaults = item.defaults;
                status = item.status;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormInformationProductOption_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void chkDefault2_Click(object sender, EventArgs e)
        {
            defaults = 0;
            chk(false);
        }

        private void chkDefault1_Click(object sender, EventArgs e)
        {
            defaults = 1;
            chk(true);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (cbOptionName.Text == "")
            {
                Form2.title = "Tên Option Không Được (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (cbProductName.Text == "")
            {
                Form2.title = "Tên Sản Phẩm Không Được (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtTitle.Text.Trim() == "")
            {
                Form2.title = "Tiêu Đề Không Được (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtTitle.Text.Trim().Length < 1)
            {
                Form2.title = "Tiêu Đề Phải (> 1 Ký Tự) ";
                Form2.ShowDialog();
                return;
            }
            if (txtPrice.Text.Trim() == "")
            {
                Form2.title = "Giá Tiền Không  (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (defaults == null)
            {
                Form2.title = "Chưa Xét Mặc Định ";
                Form2.ShowDialog();
                return;
            }
           
            if (btnEdit.Text == "Sửa")
            {
                ProductOption std = new ProductOption(Convert.ToInt32(cbProductName.SelectedValue), Convert.ToInt32(cbOptionName.SelectedValue), txtTitle.Text, Convert.ToDecimal(txtPrice.Text), defaults, status);
                if (DbProductOption.CheckUpdateProductOption(std,id_product_option.ToString()) == true)
                {
                    Form1.title = "Sửa Thành Công";
                    Form1.ShowDialog();
                    this.Close();
                    _parent.clear();
                    _parent.clear1();
                    _parent.Display();
                }
                else
                {
                    Form2.title = "Sửa Không Thành Công";
                    Form2.ShowDialog();
                    this.Close();
                    _parent.clear();
                    _parent.clear1();
                    _parent.Display();
                }
            }
            
        }

        private void rdStatus1_CheckedChanged(object sender, EventArgs e)
        {
            status = 1;
        }

        private void rdStatus2_CheckedChanged(object sender, EventArgs e)
        {
            status = 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (btnDelete.Text == "Xóa")
            {
                if (DbProductOption.CheckDeleteProductOption(id_product_option.ToString()) == false)
                {
                    Form1.title = "Xóa Thành Công";
                    Form1.ShowDialog();
                    this.Close();
                    _parent.clear();
                    _parent.clear1();
                    _parent.Display();
                }
                else
                {
                    Form2.title = "Xóa Không Thành Công";
                    Form2.ShowDialog();
                    this.Close();
                    _parent.clear();
                    _parent.clear1();
                    _parent.Display();
                }
            }
        }
    }
}
