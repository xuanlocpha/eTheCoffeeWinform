
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

namespace SquiredCoffee.UC_ManageSysterm
{
    public partial class UC_Table : UserControl
    {
        int id, status;
        public UC_Table()
        {
            InitializeComponent();
        }

        public void Display()
        {
            DbTable.DisplayAndSearch("SELECT id,title,status FROM tables", dgvTable);
        }

        public void Clear()
        {
            txtTableName.Text =txtSearch.Text= string.Empty;
            rbStatus1.Checked = false;
            rbStatus2.Checked = false;
        }

        private void UC_Table_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DbTable.DisplayAndSearch("SELECT id,title,status FROM tables WHERE title LIKE'%" + txtSearch.Text + "%'", dgvTable);
        }

        private void rbStatus1_CheckedChanged(object sender, EventArgs e)
        {
            status = 1;
        }

        private void rbStatus2_CheckedChanged(object sender, EventArgs e)
        {
            status = 0;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtTableName.Text.Trim().Length < 3)
            {
                MessageBox.Show("Tên Bàn ( > 3) ký tự");
                return;
            }

            if (rbStatus1.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn trạng thái kích hoạt ");
                return;
            }

            if ((DbTable.CheckDb(txtTableName.Text)) == true)
            {
                MessageBox.Show("Tên Bàn Đã Tồn Tại ");
                return;
            }

            if (btnInsert.Text == "Thêm")
            {
                Table std = new Table(txtTableName.Text.Trim(), status);
                DbTable.AddTable(std);
                Clear();
                Display();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtTableName.Text.Trim().Length < 3)
            {
                MessageBox.Show("Tên Bàn ( > 3) ký tự");
                return;
            }

            if (btnEdit.Text == "Sửa")
            {
                Table std = new Table(txtTableName.Text.Trim(), status);
                DbTable.UpdateTable(std,id.ToString());
                Clear();
                Display();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Text == "Xóa")
            {
                DbTable.DeleteTable(id.ToString());
                Clear();
                Display();
            }
        }

        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dgvTable.SelectedRows[0].Cells[0].Value.ToString());
            txtTableName.Text = dgvTable.SelectedRows[0].Cells[1].Value.ToString();
            if (Convert.ToInt32(dgvTable.SelectedRows[0].Cells[2].Value.ToString()) == 1)
            {
                rbStatus1.Checked = true;
            }
            if (Convert.ToInt32(dgvTable.SelectedRows[0].Cells[2].Value.ToString()) == 0)
            {
                rbStatus2.Checked = true;
            }
        }
    }
}
