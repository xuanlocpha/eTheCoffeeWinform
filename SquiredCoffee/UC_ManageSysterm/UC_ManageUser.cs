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
    public partial class UC_ManageUser : UserControl
    {
        public int totalUser;
        public int totalUserSearch;
        public string gender;
        public string level;
        FormInformationUser Form;
        public UC_ManageUser()
        {
            InitializeComponent();
            Form = new FormInformationUser(this);
        }

        public void clear()
        {
            totalUser = 0;
            totalUserSearch = 0;
        }


        public void clear1()
        {
            txtSearch.Text = string.Empty;
        }

        public void Display()
        {
            clear();
            clear1();
            dgvUser.Rows.Clear();
            List<User> userList = DbUser.ListUser();
            foreach (User item in userList)
            {
                if(item.gender == "male")
                {
                    gender = "Nam";
                }
                else
                {
                    gender = "Nữ";
                }
                if(item.point <= 100)
                {
                    level = "Bạc";
                }
                if (item.point > 101 && item.point < 1000)
                {
                    level = "Vàng";
                }
                if (item.point > 1001)
                {
                    level = "Kim Cương";
                }
                totalUser += 1;
                dgvUser.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.display_name,
                    gender,
                    item.phone,
                    item.email,
                    item.point,
                    level,
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalUser.Text = totalUser.ToString();
            lblTotalUserSearch.Text = totalUser.ToString();
        }

        private void UC_ManageUser_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //string id_user = dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString();
            //Form.id_user = id_user;
            //Form.ShowDialog();
            FormBackGround formBackGround = new FormBackGround();
            try
            {
                using (FormInformationUser Form = new FormInformationUser(this))
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
                    string id_user = dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                    Form.id_user = id_user;
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
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            Display();
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            clear();
            clear1();
            dgvUser.Rows.Clear();
            List<User> userList = DbUser.ListUserSearchStatus("1");
            foreach (User item in userList)
            {
                if (item.gender == "male")
                {
                    gender = "Nam";
                }
                else
                {
                    gender = "Nữ";
                }
                if (item.point <= 100)
                {
                    level = "Bạc";
                }
                if (item.point > 101 && item.point < 1000)
                {
                    level = "Vàng";
                }
                if (item.point > 1001)
                {
                    level = "Kim Cương";
                }
                totalUserSearch += 1;
                dgvUser.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.display_name,
                    gender,
                    item.phone,
                    item.email,
                    item.point,
                    level,
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalUserSearch.Text = totalUserSearch.ToString();
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            clear();
            clear1();
            dgvUser.Rows.Clear();
            List<User> userList = DbUser.ListUserSearchStatus("0");
            foreach (User item in userList)
            {
                if (item.gender == "male")
                {
                    gender = "Nam";
                }
                else
                {
                    gender = "Nữ";
                }
                if (item.point <= 100)
                {
                    level = "Bạc";
                }
                if (item.point > 101 && item.point < 1000)
                {
                    level = "Vàng";
                }
                if (item.point > 1001)
                {
                    level = "Kim Cương";
                }
                totalUserSearch += 1;
                dgvUser.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.display_name,
                    gender,
                    item.phone,
                    item.email,
                    item.point,
                    level,
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalUserSearch.Text = totalUserSearch.ToString();
        }

        private void bunifuVScrollBar1_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            try
            {
                dgvUser.FirstDisplayedScrollingRowIndex = dgvUser.Rows[e.Value].Index;
            }
            catch (Exception)
            {

            }
        }

        private void dgvUser_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = dgvUser.RowCount - 1;
            }
            catch
            {

            }
        }

        private void dgvUser_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = dgvUser.RowCount - 1;
            }
            catch
            {

            }
        }

    }
}
