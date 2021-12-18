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

namespace SquiredCoffee.FormManage
{
    public partial class FormInformationDiscount : Form
    {
        public string id_discount;
        public FormInformationDiscount()
        {
            InitializeComponent();
        }

        public void Display()
        {
            dgvDiscount.Rows.Clear();
            List<Discount> discounts = DbDiscount.LoadDiscountListId(id_discount);
            foreach (Discount item in discounts)
            {
                List<Product> products = DbProduct.LoadProductList();
                foreach (Product item1 in products)
                {
                    string k = Convert.ToString(item.product);
                    string[] arrListStr = k.Split(',');
                    if (arrListStr.Contains(item1.id.ToString()) == true)
                    {
                        List<Product> products1 = DbProduct.LoadProduct(item1.id.ToString());
                        foreach (Product item2 in products1)
                        {
                            DateTime dt = Convert.ToDateTime(item.start_date);
                            string start_date = dt.ToString("dd-MM-yyyy");
                            DateTime dt1 = Convert.ToDateTime(item.expiry_date);
                            string expiry_date = dt.ToString("dd-MM-yyyy");
                            dgvDiscount.Rows.Add(new object[]
                            {
                                      imageList1.Images[0],
                                      item.id,
                                      item.discount,
                                      item2.title,
                                      start_date,
                                      expiry_date
                            });
                        }
                    }

                }
            }
        }

        private void FormInformationDiscount_Load(object sender, EventArgs e)
        {
            Display();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
