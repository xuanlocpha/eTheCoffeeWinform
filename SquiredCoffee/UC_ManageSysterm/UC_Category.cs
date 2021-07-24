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
using SquiredCoffee.Class;
using System.Windows.Forms;

namespace SquiredCoffee.UC_ManageSysterm
{
    public partial class UC_Category : UserControl
    {

        FormCategory Form;
        public UC_Category()
        {
            InitializeComponent();
            Form = new FormCategory(this);
        }

        public void Display()
        {
            DbCategory.DisplayAndSearch("SELECT id,title,status FROM categories", dgvCategory);
        }

        private void UC_Category_Load(object sender, EventArgs e)
        {
            Display();
        }


        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            Form.Clear();
            Form.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DbCategory.DisplayAndSearch("SELECT id,title,status FROM categories WHERE title LIKE'%"+ txtSearch.Text +"%'" , dgvCategory);
        }

        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                //Sửa
                Form.Clear();
                Form.id = dgvCategory.Rows[e.RowIndex].Cells[2].Value.ToString();
                Form.title = dgvCategory.Rows[e.RowIndex].Cells[3].Value.ToString();
                Form.UpdateCategory();
                Form.ShowDialog();
                return;
            }
            if(e.ColumnIndex == 1)
            {
                // Xóa
                if(MessageBox.Show("Bạn có muốn xóa Loại Sản Phẩm Này", "Infomation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DbCategory.DeleteCategory(dgvCategory.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Display();
                }

                return;
            }    
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
