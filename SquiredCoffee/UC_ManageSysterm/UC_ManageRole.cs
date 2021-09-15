using SquiredCoffee.Class;
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
    public partial class UC_ManageRole : UserControl
    {
        public int totalRole;
        public int totalRoleSearch;
        FormAddRole Form;
        FormInformationRole Form1;
        public UC_ManageRole()
        {
            InitializeComponent();
            Form = new FormAddRole(this);
            Form1 = new FormInformationRole(this);
        }
      

        public void clear()
        {
            totalRole = 0;
            totalRoleSearch = 0;
        }

        public void Display()
        {
            dgvRole.Rows.Clear();
            List<Role> roleList = DbRole.LoadRoleList();
            foreach (Role item in roleList)
            {
                totalRole += 1;
                dgvRole.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.title,
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalRole.Text = totalRole.ToString();
        }



        public void LoadStatusRoleList(string key)
        {
            dgvRole.Rows.Clear();
            List<Role> roleList = DbRole.LoadStatusRoleList(key);
            foreach (Role item in roleList)
            {
                totalRoleSearch += 1;
                dgvRole.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.title,
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalRoleSearch.Text = totalRoleSearch.ToString();
        }

        private void UC_ManageRole_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            clear();
            Display();
            lblTotalRoleSearch.Text = totalRole.ToString();
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            clear();
            LoadStatusRoleList("1");
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            clear();
            LoadStatusRoleList("0");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            clear();
            dgvRole.Rows.Clear();
            List<Role> roleList = DbRole.LoadSearchRoleList(txtSearch.Text);
            foreach (Role item in roleList)
            {
                totalRoleSearch += 1;
                dgvRole.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.title,
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalRoleSearch.Text = totalRoleSearch.ToString();
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            Form.ShowDialog();
        }

        private void dgvRole_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id_role = dgvRole.Rows[e.RowIndex].Cells[1].Value.ToString();
            Form1.id_role = Convert.ToInt32(id_role);
            Form1.ShowDialog();
        }

        private void dgvRole_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = dgvRole.RowCount - 1;
            }
            catch
            {

            }
        }

        private void dgvRole_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = dgvRole.RowCount - 1;
            }
            catch
            {

            }
        }

        private void bunifuVScrollBar1_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            try
            {
                dgvRole.FirstDisplayedScrollingRowIndex = dgvRole.Rows[e.Value].Index;
            }
            catch (Exception)
            {

            }
        }
    }
}
