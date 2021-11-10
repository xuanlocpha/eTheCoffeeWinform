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
    public partial class FormInformationOptionGroup : Form
    {
        public int id_option_group;
        public int status;
        public static UC_ManageOptionGroup _parent;
        FormSuccess Form1;
        FormError Form2;
        public FormInformationOptionGroup(UC_ManageOptionGroup parent)
        {
            _parent = parent;
            InitializeComponent();
            Form1 = new FormSuccess();
            Form2 = new FormError();
        }

        public void clear()
        {
            txtOptionGroupName.Text = string.Empty;
        }

        public void Display()
        {
            List<OptionGroup> optionGroupList = DbOptionGroup.LoadOptionGroup1(id_option_group.ToString());
            foreach (OptionGroup item in optionGroupList)
            {
                txtOptionGroupName.Text = item.title;
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

       

        private void FormInformationOptionGroup_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtOptionGroupName.Text == "")
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
            if (btnEdit.Text == "Sửa")
            {
                OptionGroup std = new OptionGroup(txtOptionGroupName.Text, status);
                if ((DbOptionGroup.CheckUpdateOptionGroup(std,id_option_group.ToString())) == true)
                {
                    Form1.title = "Sửa Thành Công";
                    Form1.ShowDialog();
                    this.Close();
                    clear();
                    _parent.clear1();
                    _parent.clear();
                    _parent.Display();
                }
                else
                {
                    Form2.title = "Sửa Không Thành Công";
                    Form2.ShowDialog();
                    this.Close();
                    clear();
                    _parent.clear1();
                    _parent.clear();
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

            if (btnDelete.Text == "Xóa")
            {
                status = 0;
                OptionGroup std = new OptionGroup(txtOptionGroupName.Text, status);
                if ((DbOptionGroup.CheckLockOptionGroup(std, id_option_group.ToString())) == true)
                {
                    Form1.title = "Xóa Thành Công";
                    Form1.ShowDialog();
                    this.Close();
                    clear();
                    _parent.clear1();
                    _parent.clear();
                    _parent.Display();
                }
                else
                {
                    Form1.title = "Xóa Không Thành Công";
                    Form1.ShowDialog();
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
