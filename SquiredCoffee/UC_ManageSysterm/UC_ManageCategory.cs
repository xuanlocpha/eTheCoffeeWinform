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
    public partial class UC_ManageCategory : UserControl
    {
        public int totalCategory;
        public int totalCategorySearch;
        FormAddCategory Form;
        FormInformationCategory Form1;
        public UC_ManageCategory()
        {
            InitializeComponent();
            Form = new FormAddCategory(this);
            Form1 = new FormInformationCategory(this);
            
        }


        private void dgvStaff_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = dgvCategory.RowCount - 1;
            }
            catch
            {

            }
        }

        private void dgvCategory_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = dgvCategory.RowCount - 1;
            }
            catch
            {

            }
        }


        public void Display()
        {
            dgvCategory.Rows.Clear();
            List<Category> categoryList = DbCategory.LoadCategoryList();
            foreach (Category item in categoryList)
            {
                totalCategory += 1;
                dgvCategory.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.title,
                    item.type,
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalCategory.Text = totalCategory.ToString();
        }

        public void loadCategoryStatusList(string status)
        {
            List<Category> categoryList = DbCategory.LoadCategoryStatusList(status);
            foreach (Category item in categoryList)
            {
                totalCategorySearch += 1;
                dgvCategory.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.title,
                    item.type,
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
        }

        public void clear()
        {
            totalCategory = 0;
            totalCategorySearch = 0;
        }


        private void UC_ManageCategory_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            clear();
            dgvCategory.Rows.Clear();
            Display();
            lblTotalCategorySearch.Text = totalCategory.ToString();
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            clear();
            dgvCategory.Rows.Clear();
            loadCategoryStatusList("1");
            lblTotalCategorySearch.Text = totalCategorySearch.ToString();
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            clear();
            dgvCategory.Rows.Clear();
            loadCategoryStatusList("0");
            lblTotalCategorySearch.Text = totalCategorySearch.ToString();
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            clear();
            dgvCategory.Rows.Clear();
            List<Category> categoryList = DbCategory.LoadCategorySearchList(txtSearch.Text);
            foreach (Category item in categoryList)
            {
                totalCategorySearch += 1;
                dgvCategory.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.title,
                    item.type,
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalCategorySearch.Text = totalCategorySearch.ToString();
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            Form.ShowDialog();
        }

        private void bunifuVScrollBar1_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            try
            {
                dgvCategory.FirstDisplayedScrollingRowIndex = dgvCategory.Rows[e.Value].Index;
            }
            catch (Exception)
            {

            }
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id_category = dgvCategory.Rows[e.RowIndex].Cells[1].Value.ToString();
            Form1.id_category = Convert.ToInt32(id_category);
            Form1.ShowDialog();
        }
    }
}
