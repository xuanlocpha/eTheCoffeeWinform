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
    public partial class UC_ManageUser : UserControl
    {
        public int totalUser;
        public int totalUserSearch;
        public UC_ManageUser()
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

        //public void Display()
        //{
        //    clear();
        //    clear1();
        //    dgvUser.Rows.Clear();
        //    List<User> userList = DbUser.UserList();
        //    foreach (Supplier item in supplierList)
        //    {
        //        totalSupplier += 1;
        //        dgvUser.Rows.Add(new object[] {
        //            imageList1.Images[0],
        //            item.id,
        //            item.name_supplier,
        //            item.address,
        //            item.phone,
        //            item.email,
        //             Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
        //        });
        //    }
        //    lblTotalSupplier.Text = totalSupplier.ToString();
        //    lblTotalOptionGroupSearch.Text = totalSupplier.ToString();
        //}
    }
}
