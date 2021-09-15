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
    public partial class UC_ManageDiscount : UserControl
    {
        FormAddDiscount Form;
        FormInformationDiscount Form1;
        public UC_ManageDiscount()
        {
            InitializeComponent();
            Form = new FormAddDiscount(this);
            Form1 = new FormInformationDiscount(this);
        }
        public int totalDiscount;
        public int toalSearchDiscount;

        public void Display()
        {
            clear();
            dgvDiscount.Rows.Clear();
            List<Discount> discountList1 = DbDiscount.LoadDiscountList();
            foreach (Discount item in discountList1)
            {
                DateTime start_date1 = Convert.ToDateTime(item.start_date);
                DateTime expiry_date1 = Convert.ToDateTime(item.expiry_date);
                if (expiry_date1 < DateTime.Now)
                {
                    Discount std = new Discount(item.discount, item.product_id, String.Format("{0:yyyy/MM/dd}", start_date1), String.Format("{0:yyyy/MM/dd}", expiry_date1), 0);
                    DbDiscount.UpdateDiscountStatus(std, item.id.ToString());
                }
            }
                List<Discount> discountList = DbDiscount.LoadDiscountList();
                    foreach (Discount item in discountList)
                    {
                        totalDiscount += 1;
                        DateTime start_date = Convert.ToDateTime(item.start_date);
                        DateTime expiry_date = Convert.ToDateTime(item.expiry_date);
                        dgvDiscount.Rows.Add(new object[] {
                            imageList1.Images[0],
                            item.id,
                            item.title_product,
                            String.Format("{0:0}%",item.discount),
                            String.Format("{0:dd/MM/yyyy}",start_date),
                            String.Format("{0:dd/MM/yyyy}",expiry_date),
                            Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                            });
                    }
            lblTotalDiscount.Text = totalDiscount.ToString();
            lblTotalProductSearch.Text = totalDiscount.ToString();
        }



       

        public void LoadListDiscount(string key)
        {
            dgvDiscount.Rows.Clear();
            List<Discount> discountList = DbDiscount.LoadDiscountSearchList(key);
            foreach (Discount item in discountList)
            {
                DateTime start_date = Convert.ToDateTime(item.start_date);
                DateTime expiry_date = Convert.ToDateTime(item.expiry_date);
                toalSearchDiscount += 1;
                dgvDiscount.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.title_product,
                    String.Format("{0:0}%",item.discount),
                    String.Format("{0:dd/MM/yyyy}",start_date),
                    String.Format("{0:dd/MM/yyyy}",expiry_date),
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
           lblTotalProductSearch.Text = toalSearchDiscount.ToString();
        }

        public void clear()
        {
            totalDiscount = 0;
            toalSearchDiscount = 0;
        }

        private void UC_ManageDiscount_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            clear();
            Display();
            lblTotalProductSearch.Text = totalDiscount.ToString();
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            clear();
            LoadListDiscount("1");
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            clear();
            LoadListDiscount("0");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            clear();
            dgvDiscount.Rows.Clear();
            List<Discount> discountList = DbDiscount.LoadtSearchList(txtSearch.Text);
            foreach (Discount item in discountList)
            {
                
                DateTime start_date = Convert.ToDateTime(item.start_date);
                DateTime expiry_date = Convert.ToDateTime(item.expiry_date);
                toalSearchDiscount += 1;
                dgvDiscount.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.title_product,
                    String.Format("{0:0}%",item.discount),
                    String.Format("{0:dd/MM/yyyy}",start_date),
                    String.Format("{0:dd/MM/yyyy}",expiry_date),
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalProductSearch.Text = toalSearchDiscount.ToString();
        }

        private void btnAddDiscount_Click(object sender, EventArgs e)
        {
            Form.ShowDialog();
        }

        private void dgvDiscount_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = dgvDiscount.RowCount - 1;
            }
            catch
            {

            }
        }

        private void dgvDiscount_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = dgvDiscount.RowCount - 1;
            }
            catch
            {

            }
        }

        private void bunifuVScrollBar1_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            try
            {
                dgvDiscount.FirstDisplayedScrollingRowIndex = dgvDiscount.Rows[e.Value].Index;
            }
            catch (Exception)
            {

            }
        }

        private void dgvDiscount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id_category = dgvDiscount.Rows[e.RowIndex].Cells[1].Value.ToString();
            Form1.id_discount = Convert.ToInt32(id_category);
            Form1.ShowDialog();
        }
    }
}
