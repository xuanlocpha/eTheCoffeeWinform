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
    public partial class FormEditOrderItems : Form
    {
        private readonly FormStaff _parent;
        public string id,id_order,id_product ,price ,count ,provisional;

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public FormEditOrderItems(FormStaff parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void UpdateOrderItem()
        {
            txtCount.Text = count;
        }



        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    if (txtCount.Text.Trim() == "")
        //    {
        //        MessageBox.Show("Số Lượng Không Được Để Trống");
        //        return;
        //    }
        //    if (btnSave.Text == "Lưu")
        //    {
        //        decimal x = Convert.ToDecimal(txtCount.Text.Trim()) * Convert.ToDecimal(price);
        //        Order_Items std = new Order_Items(Convert.ToInt32(id_order), Convert.ToInt32(id_product), Convert.ToInt32(txtCount.Text.Trim()),decimal.Parse(price),x);
        //        DbOrderItem.UpdateOrderItem1(std, id);
        //        Clear();
        //    }
        //    this.Close();
        //    _parent.Display();
        //}

        public void Clear()
        {
            txtCount.Text = string.Empty;
        }
    }
}
