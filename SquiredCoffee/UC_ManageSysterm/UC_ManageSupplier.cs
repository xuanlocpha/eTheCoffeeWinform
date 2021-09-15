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
    public partial class UC_ManageSupplier : UserControl
    {
        public int totalSupplier;
        public int totalSupplierSearch;
        FormAddSupplier Form;
        FormInformationSupplier Form1;
        public UC_ManageSupplier()
        {
            InitializeComponent();
            Form = new FormAddSupplier(this);
            Form1 = new FormInformationSupplier(this);
        }

        public void clear()
        {
            totalSupplier = 0;
            totalSupplierSearch = 0;
        }


        public void clear1()
        {
            txtSearch.Text = string.Empty;
        }

        public void Display()
        {
            clear();
            clear1();
            dgvSupplier.Rows.Clear();
            List<Supplier> supplierList = DbSupplier.LoadSupplierList();
            foreach (Supplier item in supplierList)
            {
                totalSupplier += 1;
                dgvSupplier.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.name_supplier,
                    item.address,
                    item.phone,
                    item.email,
                     Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalSupplier.Text = totalSupplier.ToString();
            lblTotalOptionGroupSearch.Text = totalSupplier.ToString();
        }


        public void LoadSupplierSearch(string status)
        {
            clear();
            clear1();
            dgvSupplier.Rows.Clear();
            List<Supplier> supplierList = DbSupplier.LoadSupplierListSearchClick(status);
            foreach (Supplier item in supplierList)
            {
                totalSupplierSearch += 1;
                dgvSupplier.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.name_supplier,
                    item.address,
                    item.phone,
                    item.email,
                     Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalOptionGroupSearch.Text = totalSupplierSearch.ToString();
        }

        private void UC_ManageSupplier_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            Display();
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            LoadSupplierSearch("1");
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            LoadSupplierSearch("0");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            clear();
            dgvSupplier.Rows.Clear();
            List<Supplier> supplierList = DbSupplier.LoadSupplierListSearch(txtSearch.Text);
            foreach (Supplier item in supplierList)
            {
                totalSupplierSearch += 1;
                dgvSupplier.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.name_supplier,
                    item.address,
                    item.phone,
                    item.email,
                     Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalOptionGroupSearch.Text = totalSupplierSearch.ToString();
        }

        private void dgvSupplier_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = dgvSupplier.RowCount - 1;
            }
            catch
            {

            }
        }

        private void dgvSupplier_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = dgvSupplier.RowCount - 1;
            }
            catch
            {

            }
        }

        private void bunifuVScrollBar1_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            try
            {
                dgvSupplier.FirstDisplayedScrollingRowIndex = dgvSupplier.Rows[e.Value].Index;
            }
            catch (Exception)
            {

            }
        }

        private void btnAddOptionGroup_Click(object sender, EventArgs e)
        {
            Form.ShowDialog();
        }

        private void dgvSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id_supplier = dgvSupplier.Rows[e.RowIndex].Cells[1].Value.ToString();
            Form1.id_supplier = Convert.ToInt32(id_supplier);
            Form1.ShowDialog();
        }
    }
}
