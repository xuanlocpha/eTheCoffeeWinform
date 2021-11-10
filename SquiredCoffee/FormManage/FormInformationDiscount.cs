using MySql.Data.MySqlClient;
using SquiredCoffee.Class;
using SquiredCoffee.DB;
using SquiredCoffee.UC_ManageSysterm;
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
    public partial class FormInformationDiscount : Form
    {
        MySqlConnection con = new MySqlConnection();
        //public static UC_ManageDiscount _parent;
        public int status ;
        public int id_discount;
        public FormInformationDiscount(/*UC_ManageDiscount parent*/)
        {
            InitializeComponent();
            //_parent = parent;
            ListDiscount();
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

        void ListDiscount()
        {
            string sql = "SELECT * FROM products";
            DataSet ListCategory = new DataSet();
            ListCategory = LoadDB(sql);
            cbDiscount.DataSource = ListCategory.Tables[0];
            cbDiscount.DisplayMember = "title";
            cbDiscount.ValueMember = "id";
            cbDiscount.SelectedIndex = -1;
            con.Close();
        }

        private void rdStatus1_CheckedChanged(object sender, EventArgs e)
        {
            status = 1;
        }

        private void rdStatus2_CheckedChanged(object sender, EventArgs e)
        {
            status = 0;
        }

        public void Display()
        {
            //List<Discount> discountList = DbDiscount.LoadDiscountList(id_discount.ToString());
            //foreach (Discount item in discountList)
            //{
            //    cbDiscount.Text = item.title_product;
            //    txtDiscount.Text = item.discount.ToString();
            //    dtpStartDate.Text = String.Format("{0:dd/MM/yyyy}", item.start_date);
            //    dtpExpiryeDate.Text = String.Format("{0:dd/MM/yyyy}", item.expiry_date);
            //    if (item.status == 1)
            //    {
            //        rdStatus1.Checked = true;
            //    }
            //    else if (item.status == 0)
            //    {
            //        rdStatus2.Checked = true;
            //    }
            //    status = item.status;
            //}
        }

        private void FormInformationDiscount_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void bunifuGradientPanel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void clear()
        {
            cbDiscount.SelectedIndex = -1; ;
            txtDiscount.Text = string.Empty;
            dtpExpiryeDate.Value = DateTime.Now;
            dtpStartDate.Value = DateTime.Now;
            rdStatus1.Checked = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (cbDiscount.Text == "")
            {
                MessageBox.Show("Tên Sản phẩm Không Được Để ( Trống )");
                return;
            }
            if (txtDiscount.Text.Trim() == "")
            {
                MessageBox.Show("Giá trị giảm giá không được ( Trống )");
                return;
            }
            if (txtDiscount.Text.Trim().Length < 1)
            {
                MessageBox.Show("Giá trị giảm giá phải lớn hơn (  1 ký tự )");
                return;
            }
            if (Convert.ToDateTime(dtpExpiryeDate.Text) <= DateTime.Now)
            {
                MessageBox.Show("Ngày Kết Thúc Không Được Nhỏ Hơn Ngày Hiện Tại !!!");
                return;
            }
            if (MessageBox.Show("Bạn có muốn chỉnh sửa giảm giá sản phẩm này không !", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (btnEdit.Text == "Sửa")
                {
                    //string start_date = dtpStartDate.Value.Date.ToString("yyyy-MM-dd");
                    //string expiry_date = dtpExpiryeDate.Value.Date.ToString("yyyy-MM-dd");
                    //Discount std = new Discount(Convert.ToDouble(txtDiscount.Text), Convert.ToInt32(cbDiscount.SelectedValue), start_date, expiry_date, status);
                    //DbDiscount.UpdateDiscount(std, id_discount.ToString());
                    //this.Close();
                    //clear();
                    //_parent.Display();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa giảm giá sản phẩm này không !", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (btnDelete.Text == "Xóa")
                {
                    DbDiscount.DeleteDiscount(id_discount.ToString());
                    this.Close();
                    clear();
                    //_parent.Display();
                }
            }
        }
    }
}
