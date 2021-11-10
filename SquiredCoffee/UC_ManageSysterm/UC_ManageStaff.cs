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
    public partial class UC_ManageStaff : UserControl
    {
        FormAddStaff Form;
        FormInfomationStaff Form1;
        public int totalStaff;
        public int totalSearch;
        public string id_staff;
        public string role_name;
        public UC_ManageStaff()
        {
            InitializeComponent();
            Form = new FormAddStaff(this);
            Form1 = new FormInfomationStaff(this);
        }

        private void UC_ManageStaff_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

        }

        public void Display()
        {
            clear();
            List<Staff> staffList = DbStaff.LoadStaffList();
            foreach (Staff item in staffList)
            {
                DateTime birthday = Convert.ToDateTime(item.birthday);
                totalStaff += 1;
                dgvStaff.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.first_name,
                    item.last_name,
                    item.gender,
                    String.Format("{0:dd/MM/yyyy}",birthday),
                    item.title,
                    item.phone,
                    item.email,
                    item.username,
                    item.password,
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalStaff.Text = totalStaff.ToString();
        }

        private void bunifuVScrollBar1_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            try
            {
                dgvStaff.FirstDisplayedScrollingRowIndex = dgvStaff.Rows[e.Value].Index;
            }
            catch(Exception)
            {
               
            }     
        }

        private void dgvStaff_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = dgvStaff.RowCount - 1;
            }
            catch
            {

            }
           
        }

        private void dgvStaff_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = dgvStaff.RowCount - 1;
            }
            catch
            {

            }
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            FormBackGround formBackGround = new FormBackGround();
            try
            {
                using (FormAddStaff Form = new FormAddStaff(this))
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
           // Form.ShowDialog();
        }
        public void clear()
        {
            totalSearch = 0;
            totalStaff = 0;
        }


      

        public void resetForm()
        {
            dgvStaff.Rows.Clear();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            clear();
            dgvStaff.Rows.Clear();
            Display();
            lblTotalStaffSearch.Text = totalStaff.ToString();
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            clear();
            dgvStaff.Rows.Clear();
            int x = 1;

            List<Staff> staffList = DbStaff.LoadStaffStatusList(x.ToString());
            foreach (Staff item in staffList)
            {
                DateTime birthday = Convert.ToDateTime(item.birthday);
                totalSearch += 1;
                dgvStaff.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.first_name,
                    item.last_name,
                    item.gender,
                    String.Format("{0:dd/MM/yyyy}",birthday),
                    item.title,
                    item.phone,
                    item.email,
                    item.username,
                    item.password,
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalStaffSearch.Text = totalSearch.ToString();
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            dgvStaff.Rows.Clear();
            int x = 0;
            totalSearch = 0;
            List<Staff> staffList = DbStaff.LoadStaffStatusList(x.ToString());
            foreach (Staff item in staffList)
            {
                DateTime birthday = Convert.ToDateTime(item.birthday);
                totalSearch += 1;
                dgvStaff.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.first_name,
                    item.last_name,
                    item.gender,
                    String.Format("{0:dd/MM/yyyy}",birthday),
                    item.title,
                    item.phone,
                    item.email,
                    item.username,
                    item.password,
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],

                }); 
            }
            lblTotalStaffSearch.Text = totalSearch.ToString();
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FormBackGround formBackGround = new FormBackGround();
            try
            {
                using (FormInfomationStaff Form = new FormInfomationStaff(this))
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
                    id_staff = dgvStaff.Rows[e.RowIndex].Cells[1].Value.ToString();
                    role_name = dgvStaff.Rows[e.RowIndex].Cells[6].Value.ToString();
                    Form.id_staff = Convert.ToInt32(id_staff);
                    Form.roleName = role_name;
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
            //Form1.id_staff = Convert.ToInt32(dgvStaff.Rows[e.RowIndex].Cells[1].Value);
            //Form1.roleName = role_name;
            //Form1.ShowDialog();
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            clear();
            dgvStaff.Rows.Clear();
            List<Staff> staffList = DbStaff.Search(txtSearch.Text);
            foreach (Staff item in staffList)
            {
                DateTime birthday = Convert.ToDateTime(item.birthday);
                totalSearch += 1;
                dgvStaff.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.first_name,
                    item.last_name,
                    item.gender,
                    String.Format("{0:dd/MM/yyyy}",birthday),
                    item.title,
                    item.phone,
                    item.email,
                    item.username,
                    item.password,
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalStaffSearch.Text = totalSearch.ToString();
        }
    }
}
