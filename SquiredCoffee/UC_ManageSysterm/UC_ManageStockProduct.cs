using SquiredCoffee.Class;
using SquiredCoffee.DB;
using SquiredCoffee.FormManage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SquiredCoffee.UC_ManageSysterm
{
    public partial class UC_ManageStockProduct : UserControl
    {
        public int totalStockProduct;
        public int totalStockProductSearch;
        FormAddStockProduct Form;
        FormInformationStockProduct Form1;
        public UC_ManageStockProduct()
        {
            InitializeComponent();
            Form = new FormAddStockProduct(this);
            Form1 = new FormInformationStockProduct(this);
        }

        public void clear()
        {
            totalStockProduct = 0;
            totalStockProductSearch = 0;
        }
        public void clear1()
        {
            txtSearch.Text = string.Empty;
        }

        public void Display()
        {
            clear();
            clear1();
            dgvStockProduct.Rows.Clear();
            List<StockProduct> stockProductList = DbStockProduct.LoadStockProductList();
            foreach (StockProduct item in stockProductList)
            {
                totalStockProduct += 1;
                dgvStockProduct.Rows.Add(new object[] {
                    imageList1.Images[0], 
                    item.id,
                    item.title,
                    item.quantity,
                    item.unit,
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalStockProduct.Text = totalStockProduct.ToString();
            lblTotalStockProductSearch.Text = totalStockProduct.ToString();
        }



        public void LoadStockProductSearchClick(string status)
        {
            clear();
            clear1();
            dgvStockProduct.Rows.Clear();
            List<StockProduct> stockProductList = DbStockProduct.LoadStockProductSearchClickList(status);
            foreach (StockProduct item in stockProductList)
            {
                totalStockProductSearch += 1;
                dgvStockProduct.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.title,
                    item.quantity,
                    item.unit,
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalStockProductSearch.Text = totalStockProductSearch.ToString();
        }

        private void UC_ManageStockProduct_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            Display();
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            LoadStockProductSearchClick("1");
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            LoadStockProductSearchClick("0");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            clear();
            dgvStockProduct.Rows.Clear();
            List<StockProduct> stockProductList = DbStockProduct.LoadStockProductSearchList(txtSearch.Text);
            foreach (StockProduct item in stockProductList)
            {
                totalStockProductSearch += 1;
                dgvStockProduct.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.title,
                    item.quantity,
                    item.unit,
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalStockProductSearch.Text = totalStockProductSearch.ToString();
        }

        private void btnAddOptionGroup_Click(object sender, EventArgs e)
        {
            Form.ShowDialog();
        }

        private void dgvStockProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id_stockProduct = dgvStockProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
            Form1.id_stockProduct = Convert.ToInt32(id_stockProduct);
            Form1.ShowDialog();
        }
    }
}
