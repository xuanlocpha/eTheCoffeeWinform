using MySql.Data.MySqlClient;
using SquiredCoffee.Class;
using SquiredCoffee.DB;
using SquiredCoffee.FormManage;
using SquiredCoffee.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
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

        public void Display()
        {
            dgvProduct.Rows.Clear();
            List<ProductShow> productShowList = DbProduct.LoadProductList1();
            foreach (ProductShow item in productShowList)
            {
                totalProduct += 1;
                dgvProduct.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.title_category,
                    item.title,
                    string.Format("{0:#,##0} đ", item.price),
                    item.content,
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                }) ; 
            }
            lblTotalProduct.Text = totalProduct.ToString();
        }


        public void productStatusList(string status)
        {
            dgvProduct.Rows.Clear();
            List<ProductShow> productShowList = DbProduct.LoadProductStatusList(status);
            foreach (ProductShow item in productShowList)
            {
                totalProductSearch += 1;
                dgvProduct.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.title_category,
                    item.title,
                    string.Format("{0:#,##0} đ", item.price),
                    item.content,
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
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
        }

        private void dgvProduct_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = dgvProduct.RowCount - 1;
            }
            catch
            {

            }
        }

        private void dgvProduct_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = dgvProduct.RowCount - 1;
            }
            catch
            {

            }
        }

        private void bunifuVScrollBar1_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            try
            {
                dgvProduct.FirstDisplayedScrollingRowIndex = dgvProduct.Rows[e.Value].Index;
            }
            catch (Exception)
            {

            }
        }



        private void btnAll_Click(object sender, EventArgs e)
        {
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
            dgvProduct.Rows.Clear();
            productStatusList("1");
            lblTotalProductSearch.Text = totalProductSearch.ToString();
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            clear1();
            clear();
            dgvProduct.Rows.Clear();
            productStatusList("0");
            lblTotalProductSearch.Text = totalProductSearch.ToString();
        }

        private void cbListProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            clear();
            dgvProduct.Rows.Clear();
            List<ProductShow> productShowList = DbProduct.LoadProductSearchList(txtSearch.Text);
            foreach (ProductShow item in productShowList)
            {
                totalProductSearch += 1;
                dgvProduct.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.title_category,
                    item.title,
                    string.Format("{0:#,##0} đ", item.price),
                    item.content,
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
           lblTotalProductSearch.Text = totalProductSearch.ToString();
        }

        private void cbListCategory_TextChanged(object sender, EventArgs e)
        {
            clear();
            dgvProduct.Rows.Clear();
            List<ProductShow> productShowList = DbProduct.LoadProductSearchList1(cbListCategory.Text);
            foreach (ProductShow item in productShowList)
            {
                totalProductSearch += 1;
                dgvProduct.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.title_category,
                    item.title,
                    string.Format("{0:#,##0} đ", item.price),
                    item.content,
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalProductSearch.Text = totalProductSearch.ToString();
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            Form.ShowDialog();
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id_product = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
            Form1.id_product = Convert.ToInt32(id_product);
            Form1.ShowDialog();
        }
    }
}
