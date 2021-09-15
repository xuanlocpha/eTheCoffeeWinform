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
    public partial class UC_ManageTopping1 : UserControl
    {
        public int totalTopping;
        public int totalToppingSearch;
        FormAddTopping Form;
        FormInformationTopping Form1;
        public UC_ManageTopping1()
        {
            InitializeComponent();
            Form = new FormAddTopping(this);
            Form1 = new FormInformationTopping(this);
        }

        public void clear()
        {
            totalTopping = 0;
            totalToppingSearch = 0;
        }

        public void clear1()
        {
            txtSearch.Text = string.Empty;
        }

        public void Display()
        {
            clear();
            clear1();
            dgvTopping.Rows.Clear();
            List<Topping> toppingList = DbTopping.LoadTopping();
            foreach (Topping item in toppingList)
            {
                totalTopping += 1;
                dgvTopping.Rows.Add(new object[] {
                    imageList1.Images[0], 
                    item.id,
                    item.title,
                    item.description,
                     string.Format("{0:#,##0} đ", item.price),
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalTopping.Text = totalTopping.ToString();
            lblTotalToppingSearch.Text = totalTopping.ToString();
        }



        public void LoadToppingSearch(string status)
        {
            clear();
            clear1();
            dgvTopping.Rows.Clear();
            List<Topping> toppingList = DbTopping.LoadToppingSearchList(status);
            foreach (Topping item in toppingList)
            {
                totalToppingSearch += 1;
                dgvTopping.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.title,
                    item.description,
                     string.Format("{0:#,##0} đ", item.price),
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalToppingSearch.Text = totalToppingSearch.ToString();
        }

        private void UC_ManageTopping1_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            Display();
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            LoadToppingSearch("1");
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            LoadToppingSearch("0");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            clear();
            dgvTopping.Rows.Clear();
            List<Topping> toppingList = DbTopping.LoadToppingSearch(txtSearch.Text);
            foreach (Topping item in toppingList)
            {
                totalToppingSearch += 1;
                dgvTopping.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.title,
                    item.description,
                     string.Format("{0:#,##0} đ", item.price),
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalToppingSearch.Text = totalToppingSearch.ToString();
        }

        private void dgvStaff_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = dgvTopping.RowCount - 1;
            }
            catch
            {

            }
        }

        private void dgvStaff_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = dgvTopping.RowCount - 1;
            }
            catch
            {

            }
        }

        private void bunifuVScrollBar1_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            try
            {
                dgvTopping.FirstDisplayedScrollingRowIndex = dgvTopping.Rows[e.Value].Index;
            }
            catch (Exception)
            {

            }
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            Form.ShowDialog();
        }

        private void dgvTopping_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id_topping = dgvTopping.Rows[e.RowIndex].Cells[1].Value.ToString();
            Form1.id_topping = Convert.ToInt32(id_topping);
            Form1.ShowDialog();
        }
    }
}
