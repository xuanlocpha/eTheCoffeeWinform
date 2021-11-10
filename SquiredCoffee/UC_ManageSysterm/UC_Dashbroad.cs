using SquiredCoffee.DB;
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
    public partial class UC_Dashbroad : UserControl
    {
        public UC_Dashbroad()
        {
            InitializeComponent();
        }


        public void Display()
        {
            dgvProduct.Rows.Clear();
            List<ProductShow> productShowList = DbProduct.LoadProductListTop();
            foreach (ProductShow item in productShowList)
            {
                dgvProduct.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.title_category,
                    item.title,
                    string.Format("{0:#,##0} đ", item.price),
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
        }

        private void UC_Dashbroad_Load(object sender, EventArgs e)
        {
            Display();
        }

    }
}
