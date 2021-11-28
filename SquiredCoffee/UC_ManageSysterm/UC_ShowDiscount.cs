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

namespace SquiredCoffee.UC_ManageSysterm
{
    public partial class UC_ShowDiscount : UserControl
    {

        public UC_ShowDiscount()
        {
            InitializeComponent();
        }


        public void Display()
        {
            dgvDiscount.Rows.Clear();
            List<Discount> discounts = DbDiscount.LoadDiscountList(DateTime.Now.ToString("yyyy-MM-dd"));
            foreach (Discount item in discounts)
            {
                List<Product> products = DbProduct.LoadProductList();
                foreach (Product item1 in products)
                {
                    string k = Convert.ToString(item.product);
                    if (k.Contains(item1.id.ToString()) == true)
                    {
                        List<Product> products1 = DbProduct.LoadProduct(item1.id.ToString());
                        foreach (Product item2 in products1)
                        {
                            dgvDiscount.Rows.Add(new object[]
                            {
                                      imageList1.Images[0],
                                      item.id,
                                      item.discount,
                                      item2.title,
                                      string.Format("{0:dd/MM/yyyy}",item.start_date),
                                      string.Format("{0:dd/MM/yyyy}",item.expiry_date)
                            });
                        }
                    }

                }
            }
        }

        private void UC_ShowDiscount_Load(object sender, EventArgs e)
        {
            Display();
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
    }
}
