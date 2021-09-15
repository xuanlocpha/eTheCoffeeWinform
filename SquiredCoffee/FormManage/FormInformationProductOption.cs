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
        public FormInformationProductOption(UC_ManageProductOption parent)
        {
            InitializeComponent();
            ListOption();
            ListProduct();
            _parent = parent;
        }

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
                MessageBox.Show("Tên tùy chọn không được để ( Trống )");
                return;
            }
            if (cbProductName.Text == "")
            {
                MessageBox.Show("Tên sản phẩm không được để ( Trống )");
                return;
            }
            if (txtTitle.Text.Trim() == "")
            {
                MessageBox.Show("Tiêu đề không được ( Trống )");
                return;
            }
            if (txtTitle.Text.Trim().Length < 1)
            {
                MessageBox.Show("Tiêu đề phải lớn hơn (  1 ký tự )");
                return;
            }
            if (txtPrice.Text.Trim() == "")
            {
                MessageBox.Show("Giá tiền không được ( Trống )");
                return;
            }
            if (defaults == null)
            {
                MessageBox.Show("Chưa xét mặc định cho tùy chọn ");
                return;
            }
            if (MessageBox.Show("Bạn có muốn chỉnh sửa tùy chọn sản phẩm  này không !", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (btnEdit.Text == "Sửa")
                {
                    ProductOption std = new ProductOption(Convert.ToInt32(cbProductName.SelectedValue), Convert.ToInt32(cbOptionName.SelectedValue), txtTitle.Text, Convert.ToDecimal(txtPrice.Text), defaults, status);
                    DbProductOption.UpdateProductOption(std, id_product_option.ToString());
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
            if (MessageBox.Show("Bạn có muốn xóa tùy chọn sản phẩm  này không . Vì nó sẽ ảnh hưởng tới dữ liệu !", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (btnDelete.Text == "Xóa")
                {
                    DbProductOption.DeleteProductOption(id_product_option.ToString());
                    this.Close();
                    _parent.clear();
                    _parent.clear1();
                    _parent.Display();
                }
            }
        }
    }
}
