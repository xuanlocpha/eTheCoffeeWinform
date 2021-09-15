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
        public FormInformationTopping(UC_ManageTopping1 parent)
        {
            InitializeComponent();
            _parent = parent;
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
            if (MessageBox.Show("Bạn có muốn chỉnh sửa topping  này không !", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Topping std = new Topping(txtTitle.Text, txtDescription.Text, Convert.ToDecimal(txtPrice.Text), status);
                DbTopping.UpdateTopping(std,id_topping.ToString());
                this.Close();
                _parent.clear();
                _parent.clear1();
                _parent.Display();
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
            if (MessageBox.Show("Bạn có muốn xóa topping  này không . Vì nó có thể ảnh hưởng tới dữ liệu của bạn !", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                DbTopping.DeleteTopping(id_topping.ToString());
                this.Close();
                _parent.clear();
                _parent.clear1();
                _parent.Display();
            }
        }
    }
}
