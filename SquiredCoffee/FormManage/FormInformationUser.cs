using SquiredCoffee.Class;
using SquiredCoffee.DB;
using SquiredCoffee.UC_ManageSysterm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SquiredCoffee.FormManage
{
    public partial class FormInformationUser : Form
    {
        UC_ManageUser _parent;
        public string id_user;
        public string image_user;
        public int status;
        FormSuccess Form1;
        public FormInformationUser(UC_ManageUser parent)
        {
            InitializeComponent();
            _parent = parent;
            Form1 = new FormSuccess();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            clear();
            this.Close();
        }

        public Image ConvertBase64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                ms.Write(imageBytes, 0, imageBytes.Length);
                return Image.FromStream(ms, true);
            }
        }

        public void clear()
        {
            image_user = "";
            ptImage.Image = new Bitmap(Application.StartupPath + "\\Resource\\no_img.jpg");
        }
        
        public void Display()
        {
            List<User> userList = DbUser.ListUserInformation(id_user);
            foreach (User item in userList)
            {
                txtDisplayName.Text = item.display_name;
                if(item.gender == "male")
                {
                    rdGender1.Checked = true;
                }
                else
                {
                    rdGender2.Checked = true;
                }
                dtpBirthday.Text = item.birthday;
                txtEmail.Text = item.email;
                txtPhone.Text = item.phone;
                txtPoint.Text = item.point.ToString();
                if(item.point < 100)
                {
                    txtLevel.Text = "Bạc";
                }
                if (item.point < 100)
                {
                    txtLevel.Text = "Bạc";
                }
                else if (item.point > 101 && item.point < 1000)
                {
                    txtLevel.Text = "Vàng";
                }
                else
                {
                    txtLevel.Text = "Kim Cương";
                }
                if(item.status == 1)
                {
                    cbStatus.Text = "Kích Hoạt";
                }
                else
                {
                    cbStatus.Text = "Tạm Khóa";
                }
                image_user = item.image;
                if (image_user != "")
                {
                    ptImage.Image = ConvertBase64ToImage(item.image);
                }
                else
                {
                    ptImage.Image = new Bitmap(Application.StartupPath + "\\Resource\\no_img.jpg");
                }
               
            }
        }


        private void FormInformationUser_Load(object sender, EventArgs e)
        {
            txtDisplayName.Enabled = txtEmail.Enabled = txtLevel.Enabled = txtPhone.Enabled = txtPoint.Enabled = false;
            dtpBirthday.Enabled = false;
            rdGender1.Enabled = true;
            rdGender2.Enabled = true;
            Display();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(DbUser.CheckUpdateUser(status.ToString(), id_user) == true)
            {
                Form1.title = "Cập Nhật Trạng Thái Thành Công";
                Form1.ShowDialog();
                clear();
                this.Close();
                _parent.Display();
            }   
        }

        private void cbStatus_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbStatus.Text == "Kích Hoạt")
            {
                status = 1;
            }
            else if (cbStatus.Text == "Tạm Khóa")
            {
                status = 0;
            }
        }
    }
}
