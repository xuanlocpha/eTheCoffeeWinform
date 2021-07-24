
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
    public partial class UC_Option : UserControl
    {
        public int id, status;
        public UC_Option()
        {
            InitializeComponent();
        }

        public void Display()
        {
            DbOption.DisplayAndSearch("SELECT id,title,status FROM options ", dgvOption);
        }

        public void Clear()
        {
            txtOptionName.Text = string.Empty;
            rbStatus1.Checked = false;
            rbStatus2.Checked = false;
        }

        private void UC_Option_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void rbStatus1_CheckedChanged(object sender, EventArgs e)
        {
            status = 1;
        }

        private void rbStatus2_CheckedChanged(object sender, EventArgs e)
        {
            status = 0;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dgvOption_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dgvOption.SelectedRows[0].Cells[0].Value.ToString());
            txtOptionName.Text = dgvOption.SelectedRows[0].Cells[1].Value.ToString();
            if (Convert.ToInt32(dgvOption.SelectedRows[0].Cells[2].Value.ToString()) == 1)
            {
                rbStatus1.Checked = true;
            }
            if (Convert.ToInt32(dgvOption.SelectedRows[0].Cells[2].Value.ToString()) == 0)
            {
                rbStatus2.Checked = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtOptionName.Text.Trim().Length < 3)
            {
                MessageBox.Show("Tên Option phải ( > 3) ký tự");
                return;
            }

            if (rbStatus1.Checked == false)
            {
                MessageBox.Show("Bạn Chưa Tích Trạng Thái Cho ( Option )");
                return;
            }
            if (btnInsert.Text == "Thêm")
            {
                Option std = new Option(txtOptionName.Text.Trim(), status);
                DbOption.UpdateOption(std,id.ToString());
                Clear();
                Display();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Text == "Xóa")
            {
                DbOption.DeleteOption(id.ToString());
                Clear();
                Display();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DbOption.DisplayAndSearch("SELECT id,title,status FROM options WHERE title LIKE'%" + txtSearch.Text + "%'", dgvOption);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtOptionName.Text.Trim().Length < 3)
            {
                MessageBox.Show("Tên Option phải ( > 3) ký tự");
                return;
            }

            if(rbStatus1.Checked == false)
            {
                MessageBox.Show("Bạn Chưa Tích Trạng Thái Cho ( Option )");
                return;
            }
            if(DbOption.CheckDb(txtOptionName.Text.Trim()) == true)
            {
                MessageBox.Show("Tên Option Đã Tồn Tại");
                return;
            }
            if (btnInsert.Text == "Thêm")
            {
                Option std = new Option(txtOptionName.Text.Trim(),status);
                DbOption.AddOption(std);
                Clear();
                Display();
            }
        }
    }
}
