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

namespace SquiredCoffee.FormManage
{
    public partial class FormOrderOnline : Form
    {
        FormSale _parent;
        FormSale Form1;
        public FormOrderOnline(FormSale parent)
        {
            InitializeComponent();
            _parent = parent;
           
        }
       
        public void Display()
        {
            dgvOrder.Rows.Clear();
            List<OrderShow> orderList = DbOrder.LoadOrderShow("online");
            foreach (OrderShow item in orderList)
            {
                dgvOrder.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.display_name,
                    item.address,
                    string.Format("{0:#,##0} đ",item.grand_total),
                    item.status,           
                    item.shipping
                });
            }
        }

        private void FormOrderOline_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void dgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id_order = dgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString();
            string shipping = dgvOrder.Rows[e.RowIndex].Cells[6].Value.ToString();
            _parent.LoadOrderItem(id_order,shipping);
            _parent.tableNumber = "0";
            _parent.grandTotal = 0;
            this.Close();
        }
    }
}
