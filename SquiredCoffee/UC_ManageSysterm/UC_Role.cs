using SquiredCoffee.DB;
using SquiredCoffee.FormManage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SquiredCoffee.UC_ManageSysterm
{
    public partial class UC_Role : UserControl
    {
        FormRole Form;
        public UC_Role()
        {
            InitializeComponent();
            Form = new FormRole(this);
        }

        public void Display()
        {
            DbRole.DisplayAndSearch("SELECT id,Title,status FROM roles", dgvRole);
        }

        private void UC_Role_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form.Clear();
            Form.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DbRole.DisplayAndSearch("SELECT id,title,status FROM roles WHERE title LIKE'%" + txtSearch.Text + "%'", dgvRole);
        }

        private void dgvRole_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                //Sửa
                Form.Clear();
                Form.id = dgvRole.Rows[e.RowIndex].Cells[2].Value.ToString();
                Form.title = dgvRole.Rows[e.RowIndex].Cells[3].Value.ToString();
                Form.UpdateRole();
                Form.ShowDialog();
                return;
            }
            if (e.ColumnIndex == 1)
            {
                // Xóa
                if (MessageBox.Show("Bạn có muốn xóa Loại Sản Phẩm Này", "Infomation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DbCategory.DeleteCategory(dgvRole.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Display();
                }

                return;
            }
        }
    }
}
