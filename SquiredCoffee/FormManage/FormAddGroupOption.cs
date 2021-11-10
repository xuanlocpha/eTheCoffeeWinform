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
    public partial class FormAddGroupOption : Form
    {

        public static UC_ManageOptionGroup _parent;
        public int status = 1;
        FormSuccess Form1;
        FormError Form2;
        public FormAddGroupOption(UC_ManageOptionGroup parent)
        {
            InitializeComponent();
            _parent = parent;
            Form1 = new FormSuccess();
            Form2 = new FormError();
        }

        private void rdStatus1_CheckedChanged(object sender, EventArgs e)
        {
            status = 1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdStatus2_CheckedChanged(object sender, EventArgs e)
        {
            status = 0;
        }
        
        public void clear()
        {
            txtOptionGroupName.Text = string.Empty;
            rdStatus1.Checked = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtOptionGroupName.Text == "")
            {
                Form2.title = "Tên Nhóm Option Không Được (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtOptionGroupName.Text.Trim().Length < 1)
            {
                Form2.title = "Tên Nhóm Option Phải (>1 Ký Tự) ";
                Form2.ShowDialog();
                return;
            }
            if (DbOptionGroup.CheckOptionGroup(txtOptionGroupName.Text)== true)
            {
                Form2.title = "Tên Nhóm Option (Đã Tồn Tại)";
                Form2.ShowDialog();
                return;
            }
            if (btnSave.Text == "Lưu")
            {
                OptionGroup std = new OptionGroup(txtOptionGroupName.Text, status);
                if ((DbOptionGroup.CheckCreateOptionGroup(std)) == true)
                {
                    Form1.title = "Tạo Thành Công";
                    Form1.ShowDialog();
                    this.Close();
                    clear();
                    _parent.clear1();
                    _parent.clear();
                    _parent.Display();
                }
                else
                {
                    Form2.title = "Tạo Không Thành Công";
                    Form2.ShowDialog();
                    this.Close();
                    clear();
                    _parent.clear1();
                    _parent.clear();
                    _parent.Display();
                }
            }
        }
    }
}
