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
        FormSuccess Form1;
        FormError Form2;
        public FormAddTopping(UC_ManageTopping1 parent)
        {
            InitializeComponent();
            _parent = parent;
            Form1 = new FormSuccess();
            Form2 = new FormError();
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
                Form2.title = "Tên Topping Không Được (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtTitle.Text.Trim().Length < 1)
            {
                Form2.title = "Tên Topping (>1 Ký Tự) ";
                Form2.ShowDialog();
                return;
            }
            if (txtPrice.Text.Trim() == "")
            {
                Form2.title = "Giá Topping Không Được Để (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtPrice.Text.Trim().Length < 1)
            {
                Form2.title = "Giá Topping (>1 Ký Tự) ";
                Form2.ShowDialog();
                return;
            }
            if(DbTopping.CheckToppingForm(txtTitle.Text)== true)
            {
                Form2.title = "Topping Này Đã Tồn Tại ";
                Form2.ShowDialog();
                return;
            }
            if (btnSave.Text == "Lưu")
            {
                Topping std = new Topping(txtTitle.Text,txtDescription.Text,Convert.ToDecimal(txtPrice.Text),status);
                if(DbTopping.CheckCreateTopping(std)== true)
                {
                    Form1.title = "Tạo Thành Công";
                    Form1.ShowDialog();
                    this.Close();
                    _parent.clear();
                    _parent.clear1();
                    _parent.Display();
                }
                else
                {
                    Form2.title = "Tạo Không Thành Công";
                    Form2.ShowDialog();
                    this.Close();
                    _parent.clear();
                    _parent.clear1();
                    _parent.Display();
                }
               
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
