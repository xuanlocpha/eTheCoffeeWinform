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
    public partial class UC_ManageDiscount : UserControl
    {
        List<int> str1 = new List<int>();
        public UC_ManageDiscount()
        {
            InitializeComponent();
        }


        public void Display()
        {
            dgvDiscount.Rows.Clear();
            List<Discount> discounts = DbDiscount.LoadDiscountList(DateTime.Now.ToString("yyyy-MM-dd"));
            foreach (Discount item in discounts)
            {
                dgvDiscount.Rows.Add(new object[]
                {
                    imageList1.Images[0],
                    item.id,
                    item.discount,
                    string.Format("{0:dd/MM/yyyy}",item.start_date),
                    string.Format("{0:dd/MM/yyyy}",item.expiry_date),
                });
            }
        }

        private void UC_ManageDiscount_Load(object sender, EventArgs e)
        {
            Display();
        }
    }
}
