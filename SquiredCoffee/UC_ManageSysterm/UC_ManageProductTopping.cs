using SquiredCoffee.Class;
using SquiredCoffee.DB;
using SquiredCoffee.FormManage;
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

namespace SquiredCoffee.UC_ManageSysterm
{
    public partial class UC_ManageProductTopping : UserControl
    {
        public int totalProductTopping;
        public int totalProductToppingSearch;
        FormAddProductTopping Form;
        FormInformationProductTopping Form1;
        public UC_ManageProductTopping()
        {
            InitializeComponent();
            Form = new FormAddProductTopping(this);
            Form1 = new FormInformationProductTopping(this);
        }

        public void clear()
        {
            totalProductTopping = 0;
            totalProductToppingSearch = 0;
        }

        public void clear1()
        {
            txtSearch.Text = string.Empty;
        }

        public void Display()
        {
            clear();
            clear1();
            dgvProductTopping.Rows.Clear();
            List<ProductToppingShow> productToppingList = DbProductTopping.LoadProductTopping();
            foreach (ProductToppingShow item in productToppingList)
            {
                totalProductTopping += 1;
                dgvProductTopping.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id, 
                    item.name_product,
                    item.name_topping,
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalProductTopping.Text = totalProductTopping.ToString();
            lblTotalProductToppingSearch.Text = totalProductTopping.ToString();
        }


        public void ProductToppingSearch(string status)
        {
            clear();
            clear1();
            dgvProductTopping.Rows.Clear();
            List<ProductToppingShow> productToppingList = DbProductTopping.LoadProductToppingSearch(status);
            foreach (ProductToppingShow item in productToppingList)
            {
               totalProductToppingSearch += 1;
                dgvProductTopping.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.name_product,
                    item.name_topping,
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalProductToppingSearch.Text = totalProductToppingSearch.ToString();
        }


        private void UC_ProductTopping_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            Display();
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            ProductToppingSearch("1");
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            ProductToppingSearch("0");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            clear();
            dgvProductTopping.Rows.Clear();
            List<ProductToppingShow> productToppingList = DbProductTopping.LoadProductToppingSearch1(txtSearch.Text);
            foreach (ProductToppingShow item in productToppingList)
            {
                totalProductToppingSearch += 1;
                dgvProductTopping.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.name_product,
                    item.name_topping,
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalProductToppingSearch.Text = totalProductToppingSearch.ToString();
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            Form.ShowDialog();
        }

        private void dgvProductTopping_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = dgvProductTopping.RowCount - 1;
            }
            catch
            {

            }
        }

        private void dgvProductTopping_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = dgvProductTopping.RowCount - 1;
            }
            catch
            {

            }
        }

        private void bunifuVScrollBar1_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            try
            {
                dgvProductTopping.FirstDisplayedScrollingRowIndex = dgvProductTopping.Rows[e.Value].Index;
            }
            catch (Exception)
            {

            }
        }

        private void dgvProductTopping_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id_product_topping = dgvProductTopping.Rows[e.RowIndex].Cells[1].Value.ToString();
            Form1.id_product_topping = Convert.ToInt32(id_product_topping);
            Form1.ShowDialog();
        }
    }
}
