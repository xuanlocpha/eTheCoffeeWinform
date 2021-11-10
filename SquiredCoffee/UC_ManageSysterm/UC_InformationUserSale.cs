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
    public partial class UC_InformationUserSale : UserControl
    {
        public int totalUser;
        public int totalUserSearch;
        public UC_InformationUserSale()
        {
            InitializeComponent();
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
                totalUser = totalUser + 1;
                dgvUser.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.display_name,
                    item.gender,
                    item.birthday,
                    item.phone,
                    item.email,
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalUser.Text = totalUser.ToString();
            lblTotalUsersSearch.Text = totalUser.ToString();
        }

        public void LoadUserSearchClick(string status)
        {
            clear();
            clear1();
            dgvUser.Rows.Clear();
            List<User> userList = DbUser.ListUserSearchClick(status);
            foreach (User item in userList)
            {
                totalUserSearch = totalUser + 1;
                dgvUser.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.display_name,
                    item.gender,
                    item.birthday,
                    item.phone,
                    item.email,
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalUsersSearch.Text = totalUserSearch.ToString();
        }

        private void UC_InformationUserSale_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            Display();
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            string x = "1";
            LoadUserSearchClick(x);
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            string x = "0";
            LoadUserSearchClick(x);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            clear();
            dgvUser.Rows.Clear();
            List<User> userList = DbUser.ListUserSearch(txtSearch.Text);
            foreach (User item in userList)
            {
                totalUserSearch = totalUser + 1;
                dgvUser.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.display_name,
                    item.gender,
                    item.birthday,
                    item.phone,
                    item.email,
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalUsersSearch.Text = totalUserSearch.ToString();
        }
    }
}
