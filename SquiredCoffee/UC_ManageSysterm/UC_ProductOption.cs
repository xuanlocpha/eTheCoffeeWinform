using MySql.Data.MySqlClient;
using SquiredCoffee.Class;
using SquiredCoffee.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SquiredCoffee.UC_Controls
{
    public partial class UC_ProductOption : UserControl
    {
        MySqlConnection con = new MySqlConnection();

        int id,status;
        int defaults = 0;

        public UC_ProductOption()
        {
            InitializeComponent();
            ListProduct();
            ListOption();
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

        void ListProduct()
        {
            string sql = "SELECT * FROM products";
            DataSet ListProduct = new DataSet();
            ListProduct = LoadDB(sql);
            cbProductName.DataSource = ListProduct.Tables[0];
            cbProductName.DisplayMember = "title";
            cbProductName.ValueMember = "id";
            cbProductName.SelectedIndex = -1;
            con.Close();
        }



        void ListOption()
        {
            string sql = "SELECT * FROM options";
            DataSet ListOption = new DataSet();
            ListOption = LoadDB(sql);
            cbOptionName.DataSource = ListOption.Tables[0];
            cbOptionName.DisplayMember = "title";
            cbOptionName.ValueMember = "id";
            cbOptionName.SelectedIndex = -1;
            con.Close();
        }

        public void Display()
        {
            DbProductOption.DisplayAndSearch("SELECT po.id,po.product_id,po.option_id,po.title,po.price,po.defaults,po.status,p.title AS product_title,o.title AS option_title FROM products p,options o,product_options po WHERE po.product_id = p.id AND po.option_id = o.id ", dgvProductOption);
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UC_ProductOption_Load(object sender, EventArgs e)
        {
            Display();
        }

        public void Clear()
        {
            txtTitle.Text = txtPrice.Text = txtSearch.Text = string.Empty;
            cbOptionName.Text= null;
            cbProductName.Text = null;
            chkDefaults.Checked = false;
            rbStatus1.Checked = false;
            rbStatus2.Checked = false;

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DbProductOption.DisplayAndSearch("SELECT po.id,po.product_id,po.option_id,po.title,po.price,po.defaults,po.status,p.title AS product_title,o.title AS option_title FROM products p,options o,product_options po WHERE po.product_id = p.id AND po.option_id = o.id AND  po.title LIKE'%" + txtSearch.Text + "%'", dgvProductOption);
        }

        private void rbStatus2_CheckedChanged(object sender, EventArgs e)
        {
            status = 0;
        }

        private void dgvProductOption_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dgvProductOption.SelectedRows[0].Cells[0].Value.ToString());
            cbProductName.Text = dgvProductOption.SelectedRows[0].Cells[7].Value.ToString();
            cbOptionName.Text = dgvProductOption.SelectedRows[0].Cells[8].Value.ToString();
            txtTitle.Text = dgvProductOption.SelectedRows[0].Cells[3].Value.ToString();
            txtPrice.Text = string.Format("{0:#,##0}", double.Parse(dgvProductOption.SelectedRows[0].Cells[4].Value.ToString()));
            if (Convert.ToInt32(dgvProductOption.SelectedRows[0].Cells[5].Value.ToString()) == 1)
            {
                chkDefaults.Checked = true;
            }
            if (Convert.ToInt32(dgvProductOption.SelectedRows[0].Cells[6].Value.ToString()) == 1)
            {
                rbStatus1.Checked = true;
            }
            else if (Convert.ToInt32(dgvProductOption.SelectedRows[0].Cells[6].Value.ToString()) == 0)
            {
                rbStatus2.Checked = true;
            }
            status = Convert.ToInt32(dgvProductOption.SelectedRows[0].Cells[6].Value.ToString());
            defaults = Convert.ToInt32(dgvProductOption.SelectedRows[0].Cells[5].Value.ToString());

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbProductName.Text))
            {
                MessageBox.Show("Bạn Chưa Chọn Tên Sản Phẩm ");
                return;
            }
            if (string.IsNullOrEmpty(cbOptionName.Text))
            {
                MessageBox.Show("Bạn Chưa Chọn Option ");
                return;
            }
            if (txtTitle.Text.Trim().Length < 3)
            {
                MessageBox.Show("Tên Đề Option  phải ( > 3) ký tự");
                return;
            }
            if (txtPrice.Text.Trim().Length == null)
            {
                MessageBox.Show("Giá Option không được để chống  ");
                return;
            }
            if (txtTitle.Text.Trim().Length < 4)
            {
                MessageBox.Show("Giá Option phải ( > 4) số");
                return;
            }
            if (btnInsert.Text == "Thêm")
            {
                ProductOption std = new ProductOption(int.Parse(cbProductName.SelectedValue.ToString()), int.Parse(cbOptionName.SelectedValue.ToString()), txtTitle.Text.Trim(), decimal.Parse(txtPrice.Text),defaults, status);
                DbProductOption.AddProductOption(std);
                Clear();
                Display();
            }
        }

        private void chkDefaults_CheckedChanged(object sender, EventArgs e)
        {
            defaults = 0;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbProductName.Text))
            {
                MessageBox.Show("Bạn Chưa Chọn Tên Sản Phẩm ");
                return;
            }
            if (string.IsNullOrEmpty(cbOptionName.Text))
            {
                MessageBox.Show("Bạn Chưa Chọn Option ");
                return;
            }
            if (txtTitle.Text.Trim().Length < 3)
            {
                MessageBox.Show("Tên Đề Option  phải ( > 3) ký tự");
                return;
            }
            if (txtPrice.Text.Trim().Length == null)
            {
                MessageBox.Show("Giá Option không được để chống  ");
                return;
            }
            if (txtTitle.Text.Trim().Length < 4)
            {
                MessageBox.Show("Giá Option phải ( > 4) số");
                return;
            }
            if (btnInsert.Text == "Thêm")
            {
                ProductOption std = new ProductOption(int.Parse(cbProductName.SelectedValue.ToString()), int.Parse(cbOptionName.SelectedValue.ToString()), txtTitle.Text.Trim(), decimal.Parse(txtPrice.Text),defaults, status);
                DbProductOption.UpdateProductOption(std,id.ToString());
                Clear();
                Display();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Text == "Xóa")
            {
                DbProductOption.DeleteProductOption(id.ToString());
                Clear();
                Display();
            }
        }

        private void rbStatus1_CheckedChanged(object sender, EventArgs e)
        {
            status = 1;
        }
    }
}
