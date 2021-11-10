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
    public partial class FormInformationTopping : Form
    {
        public int id_topping;
        public int status;
        public static UC_ManageTopping1 _parent;
        FormSuccess Form1;
        FormError Form2;
        public FormInformationTopping(UC_ManageTopping1 parent)
        {
            InitializeComponent();
            _parent = parent;
            Form1 = new FormSuccess();
            Form2 = new FormError();
        }

        public void Display()
        {
            List<Topping> toppingList = DbTopping.LoadTopping(id_topping.ToString());
            foreach (Topping item in toppingList)
            {
                txtTitle.Text = item.title;
                txtDescription.Text = item.description;
                txtPrice.Text = string.Format("{0:#,##0}", item.price);
                if (item.status == 1)
                {
                    rdStatus1.Checked = true;
                }
                else if (item.status == 0)
                {
                    rdStatus2.Checked = true;
                }
                status = item.status;
            }
        }

        private void FormInformationTopping_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnEdit_Click(object sender, EventArgs e)
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
            if(btnEdit.Text == "Sửa")
            {
                Topping std = new Topping(txtTitle.Text, txtDescription.Text, Convert.ToDecimal(txtPrice.Text), status);
                if(DbTopping.CheckUpdateTopping(std,id_topping.ToString())== true)
                {
                    Form1.title = "Sửa Thành Công";
                    Form1.ShowDialog();
                    this.Close();
                    _parent.clear();
                    _parent.clear1();
                    _parent.Display();
                }
                else
                {
                    Form2.title = "Sửa Không Thành Công";
                    Form2.ShowDialog();
                    this.Close();
                    _parent.clear();
                    _parent.clear1();
                    _parent.Display();
                }
            }
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DbTopping.CheckDeleteTopping(id_topping.ToString()) == false)
            {
                Form1.title = "Xóa Thành Công";
                Form1.ShowDialog();
                this.Close();
                _parent.clear();
                _parent.clear1();
                _parent.Display();
            }
            else
            {
                Form2.title = "Xóa Không Thành Công";
                Form2.ShowDialog();
                this.Close();
                _parent.clear();
                _parent.clear1();
                _parent.Display();
            }
        }
    }
}
