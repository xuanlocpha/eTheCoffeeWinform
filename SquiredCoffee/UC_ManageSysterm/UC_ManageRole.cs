using SquiredCoffee.Class;
using SquiredCoffee.CustomControls;
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
            FormBackGround formBackGround = new FormBackGround();
            try
            {
                using (FormAddRole Form = new FormAddRole(this))
                {
                    formBackGround.StartPosition = FormStartPosition.Manual;
                    formBackGround.FormBorderStyle = FormBorderStyle.None;
                    formBackGround.Opacity = .70d;
                    formBackGround.BackColor = Color.Black;
                    formBackGround.WindowState = FormWindowState.Maximized;
                    formBackGround.TopMost = true;
                    formBackGround.Location = this.Location;
                    formBackGround.ShowInTaskbar = false;
                    formBackGround.Show();

                    Form.Owner = formBackGround;
                    Form.ShowDialog();

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                formBackGround.Dispose();
            }
            //Form.ShowDialog();
        }

        private void dgvRole_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FormBackGround formBackGround = new FormBackGround();
            try
            {
                using (FormInformationRole Form = new FormInformationRole(this))
                {
                    formBackGround.StartPosition = FormStartPosition.Manual;
                    formBackGround.FormBorderStyle = FormBorderStyle.None;
                    formBackGround.Opacity = .70d;
                    formBackGround.BackColor = Color.Black;
                    formBackGround.WindowState = FormWindowState.Maximized;
                    formBackGround.TopMost = true;
                    formBackGround.Location = this.Location;
                    formBackGround.ShowInTaskbar = false;
                    formBackGround.Show();

                    Form.Owner = formBackGround;
                    string id_role = dgvRole.Rows[e.RowIndex].Cells[1].Value.ToString();
                    Form.id_role = Convert.ToInt32(id_role);
                    Form.ShowDialog();

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                formBackGround.Dispose();
            }
            //string id_role = dgvRole.Rows[e.RowIndex].Cells[1].Value.ToString();
            //Form1.id_role = Convert.ToInt32(id_role);
            //Form1.ShowDialog();
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
