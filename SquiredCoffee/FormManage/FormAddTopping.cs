using SquiredCoffee.Class;
using SquiredCoffee.DB;
using SquiredCoffee.UC_ManageSysterm;
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
    public partial class FormAddTopping : Form
    {
        public int status = 1;
        public static UC_ManageTopping1 _parent;
        public FormAddTopping(UC_ManageTopping1 parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void FormAddTopping_Load(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdStatus1_CheckedChanged(object sender, EventArgs e)
        {
            status = 1;
        }

        private void rdStatus2_CheckedChanged(object sender, EventArgs e)
        {
            status = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text.Trim() == "")
            {
                MessageBox.Show("Tên topping không được để ( Trống )");
                return;
            }
            if (txtTitle.Text.Trim().Length < 1)
            {
                MessageBox.Show("Tên topping  phải lớn hơn  ( 1 ký tự )");
                return;
            }
            if (txtPrice.Text.Trim() == "")
            {
                MessageBox.Show("Giá topping không được để ( Trống )");
                return;
            }
            if (txtPrice.Text.Trim().Length < 1)
            {
                MessageBox.Show("Giá topping  phải lớn hơn  ( 1 ký tự )");
                return;
            }
            if(DbTopping.CheckToppingForm(txtTitle.Text)== true)
            {
                MessageBox.Show("Topping này đã tồn tại  phải lớn hơn  ( 1 ký tự )");
                return;
            }
            if (btnSave.Text == "Lưu")
            {
                Topping std = new Topping(txtTitle.Text,txtDescription.Text,Convert.ToDecimal(txtPrice.Text),status);
                DbTopping.AddTopping(std);
                this.Close();
                _parent.clear();
                _parent.clear1();
                _parent.Display();
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
