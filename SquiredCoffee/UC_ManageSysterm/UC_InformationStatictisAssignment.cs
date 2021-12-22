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
    public partial class UC_InformationStatictisAssignment : UserControl
    {
        public string id_user;
        public string image_user;
        public int status;
        public UC_InformationStatictisAssignment()
        {
            InitializeComponent();
        }
        //public void Display()
        //{
        //    List<User> userList = DbUser.ListUserInformation(id_user);
        //    foreach (User item in userList)
        //    {
        //        txtDisplayName.Text = item.display_name;
        //        if (item.gender == "male")
        //        {
        //            rdGender1.Checked = true;
        //        }
        //        else
        //        {
        //            rdGender2.Checked = true;
        //        }
        //        dtpBirthday.Text = item.birthday;
        //        txtEmail.Text = item.email;
        //        txtPhone.Text = item.phone;
        //        txtPoint.Text = item.point.ToString();
        //        if (item.point < 100)
        //        {
        //            txtLevel.Text = "Bạc";
        //        }
        //        if (item.point < 100)
        //        {
        //            txtLevel.Text = "Bạc";
        //        }
        //        else if (item.point > 101 && item.point < 1000)
        //        {
        //            txtLevel.Text = "Vàng";
        //        }
        //        else
        //        {
        //            txtLevel.Text = "Kim Cương";
        //        }
        //        if (item.status == 1)
        //        {
        //            cbStatus.Text = "Kích Hoạt";
        //        }
        //        else
        //        {
        //            cbStatus.Text = "Tạm Khóa";
        //        }
        //        image_user = item.image;
        //        if (image_user != "")
        //        {
        //            ptImage.Image = ConvertBase64ToImage(item.image);
        //        }
        //        else
        //        {
        //            ptImage.Image = new Bitmap(Application.StartupPath + "\\Resource\\no_img.jpg");
        //        }

        //    }
        //}

    }
}
