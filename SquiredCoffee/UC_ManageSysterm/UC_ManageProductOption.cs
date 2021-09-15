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
    public partial class UC_ManageProductOption : UserControl
    {
        public int totalProductOption;
        public int totalProductOptionSearch;
        FormAddProductOption Form;
        FormInformationProductOption Form1;
        public UC_ManageProductOption()
        {
            InitializeComponent();
            Form = new FormAddProductOption(this);
            Form1 = new FormInformationProductOption(this);
        }

        public void clear()
        {
            totalProductOption = 0;
            totalProductOptionSearch = 0;
        }


        public void clear1()
        {
            txtSearch.Text = string.Empty;
        }

        public void Display()
        {
            clear();
            clear1();
            dgvProductOption.Rows.Clear();
            List<ProductOptionShow> productOptionShowList = DbProductOption.LoadProductOption();
            foreach (ProductOptionShow item in productOptionShowList)
            {
                totalProductOption += 1;
                dgvProductOption.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.name_product,
                    item.name_option,
                    item.title,
                    Convert.ToBoolean(item.defaults)?  imageList1.Images[1] : imageList1.Images[2],
                    string.Format("{0:#,##0} đ",item.price),
                    Convert.ToBoolean(item.status)?  imageList2.Images[1] : imageList2.Images[2],
                });
            }
            lblTotalProductOption.Text = totalProductOption.ToString();
            lblTotalProductOptionSearch.Text = totalProductOption.ToString();
        }


        public void LoadProductOptionSearch(string status)
        {
            clear();
            clear1();
            dgvProductOption.Rows.Clear();
            List<ProductOptionShow> productOptionShowList = DbProductOption.LoadProductOptionSearchClick(status);
            foreach (ProductOptionShow item in productOptionShowList)
            {
                totalProductOptionSearch += 1;
                dgvProductOption.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.name_product,
                    item.name_option,
                    item.title,
                    Convert.ToBoolean(item.defaults)?  imageList1.Images[1] : imageList1.Images[2],
                    string.Format("{0:#,##0} đ",item.price),
                    Convert.ToBoolean(item.status)?  imageList2.Images[1] : imageList2.Images[2],
                });
            }
            lblTotalProductOptionSearch.Text = totalProductOptionSearch.ToString();
        }

        private void UC_ManageProductOption_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void dgvProductOption_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum =dgvProductOption.RowCount - 1;
            }
            catch
            {

            }
        }

        private void dgvProductOption_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = dgvProductOption.RowCount - 1;
            }
            catch
            {

            }
        }

        private void bunifuVScrollBar1_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            try
            {
                dgvProductOption.FirstDisplayedScrollingRowIndex = dgvProductOption.Rows[e.Value].Index;
            }
            catch (Exception)
            {

            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            Display();
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            LoadProductOptionSearch("1");
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            LoadProductOptionSearch("0");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            clear();
            dgvProductOption.Rows.Clear();
            List<ProductOptionShow> productOptionShowList = DbProductOption.LoadProductOptionSearch(txtSearch.Text);
            foreach (ProductOptionShow item in productOptionShowList)
            {
                totalProductOptionSearch += 1;
                dgvProductOption.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.name_product,
                    item.name_option,
                    item.title,
                    Convert.ToBoolean(item.defaults)?  imageList1.Images[1] : imageList1.Images[2],
                    string.Format("{0:#,##0} đ",item.price),
                    Convert.ToBoolean(item.status)?  imageList2.Images[1] : imageList2.Images[2],
                });
            }
            lblTotalProductOptionSearch.Text = totalProductOptionSearch.ToString();
        }

        private void btnAddProductOption_Click(object sender, EventArgs e)
        {
            Form.ShowDialog();
        }

        private void dgvProductOption_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id_product_option = dgvProductOption.Rows[e.RowIndex].Cells[1].Value.ToString();
            Form1.id_product_option = Convert.ToInt32(id_product_option);
            Form1.ShowDialog();
        }
    }
}
