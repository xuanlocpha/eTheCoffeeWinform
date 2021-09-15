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
        public FormInformationOptionGroup(UC_ManageOptionGroup parent)
        {
            _parent = parent;
            InitializeComponent();
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
                MessageBox.Show("Tên tùy chọn món không được ( Trống )");
                return;
            }
            if (txtOptionGroupName.Text.Trim().Length < 1)
            {
                MessageBox.Show("Tên tùy chọn món phải lớn hơn ( 1 ký tự )");
                return;
            }
            if (MessageBox.Show("Bạn có muốn chỉnh sửa tùy chọn sản phẩm này không !", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (btnEdit.Text == "Sửa")
                {
                    OptionGroup std = new OptionGroup(txtOptionGroupName.Text, status);
                    DbOptionGroup.UpdateOptionGroup(std, id_option_group.ToString());
                    this.Close();
                    clear();
                    _parent.clear1();
                    _parent.clear();
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
            if (MessageBox.Show("Bạn có muốn xóa tùy chọn sản phẩm này không . Vì nó có thể ảnh hưởng tới dữ liệu của bạn!", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (btnDelete.Text == "Xóa")
                {
                   
                    DbOptionGroup.DeleteOptionGroup(id_option_group.ToString());
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
