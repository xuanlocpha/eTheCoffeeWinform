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
        public FormAddGroupOption(UC_ManageOptionGroup parent)
        {
            InitializeComponent();
            _parent = parent;
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
                MessageBox.Show("Tên tùy chọn món không được ( Trống )");
                return;
            }
            if (txtOptionGroupName.Text.Trim().Length < 1)
            {
                MessageBox.Show("Tên tùy chọn món phải lớn hơn ( 1 ký tự )");
                return;
            }
            if (DbOptionGroup.CheckOptionGroup(txtOptionGroupName.Text)== true)
            {
                MessageBox.Show("Tên tùy chọn món  ( Đã tồn tại )");
                return;
            }
            if (btnSave.Text == "Lưu")
            {
                OptionGroup std = new OptionGroup(txtOptionGroupName.Text, status);
                DbOptionGroup.AddOptionGoup(std);
                this.Close();
                clear();
                _parent.clear1();
                _parent.clear();
                _parent.Display();
            }
        }
    }
}
