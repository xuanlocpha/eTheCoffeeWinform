using MySql.Data.MySqlClient;
using SquiredCoffee.Class;
using SquiredCoffee.DB;
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
    public partial class FormAddDiscount : Form
    {
        MySqlConnection con = new MySqlConnection();
        List<string> str1 = new List<string>();
        FormSuccess Form1;
        FormError Form2;
        public FormAddDiscount()
        {
            InitializeComponent();
            Form1 = new FormSuccess();
            Form2 = new FormError();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            str1.Clear();
            this.Close();
        }

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
            cbCategoryName.DataSource = ListCategory.Tables[0];
            cbCategoryName.DisplayMember = "title";
            cbCategoryName.ValueMember = "id";
            cbCategoryName.SelectedIndex = -1;
            con.Close();
        }

        private void cbCategoryName_TextChanged(object sender, EventArgs e)
        {
            flpProduct.Controls.Clear();
            List<ProductShow> productShowList = DbProduct.LoadProductSearchList1(cbCategoryName.Text);
            foreach (ProductShow item in productShowList)
            {
                CheckBox chk = new CheckBox();
                chk.Width = 150;
                chk.Height = 30;
                chk.Text = item.title;
                chk.ForeColor = Color.Black;
                chk.Font = new Font("Quicksand", 12);
                chk.Tag = item.id.ToString();

                flpProduct.Controls.Add(chk);               
                chk.Click += new EventHandler(Onclick);
            }
        }

        public void Onclick(object sender, EventArgs e)
        {
            string tag = ((CheckBox)sender).Tag.ToString();
            str1.Add(tag);
        }


        private void FormAddDiscount_Load(object sender, EventArgs e)
        {
            ListCategory();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (str1 == null)
            {
                Form2.title = "Sản phẩm giảm đang (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtDiscount.Text.Trim() == "")
            {
                Form2.title = "Giảm giá đang (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtDiscount.Text.Trim().Length < 1)
            {
                Form2.title = "Giảm giá phải ( > 1 ký tự ) ";
                Form2.ShowDialog();
                return;
            }
            if (dtpExpiry_Date.Value <= DateTime.Now)
            {
                Form2.title = "Ngày Kết Thúc Phải ( >= Ngày Hiện Tại) ";
                Form2.ShowDialog();
                return;
            }
            if (btnSave.Text == "Lưu")
            {
                string Expiry_Date = dtpExpiry_Date.Value.Date.ToString("yyyy-MM-dd");
                string product = string.Join(",", str1.ToArray());
                Discount std = new Discount(Convert.ToDouble(txtDiscount.Text),product, DateTime.Now.ToString("yyyy-MM-dd"), Expiry_Date);
                if (DbDiscount.CheckDiscount(std) == true)
                {
                    Form1.title = "Thêm Mới Discount ( Thành Công )";
                    Form1.ShowDialog();
                    this.Close();
                }
                else
                {
                    Form2.title = "Thêm Mới Discount ( Không Thành Công )";
                    Form2.ShowDialog();
                    this.Close();
                }
            }
        }
    }
}
