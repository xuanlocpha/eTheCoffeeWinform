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

namespace SquiredCoffee
{
    public partial class FormLoginSysterm : Form
    {
        FormSuccess Form1;
        FormError Form2;
        FormStaff Form3;
        FormMain Form4;
        FormSale Form5;

        public FormLoginSysterm()
        {
            InitializeComponent();
            Form1 = new FormSuccess();
            Form2 = new FormError();
            Form3 = new FormStaff(this);
            Form4 = new FormMain(this);
            Form5 = new FormSale(this);
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void clearForm1()
        {
            txtUserNameForm1.Text = txtPasswordForm1.Text = string.Empty;
            switchForm1.Checked = false;
        }


        public void clearForm2()
        {
            txtUserNameForm2.Text = txtPasswordOldForm2.Text = txtChangePasswordNewForm2.Text = txtChangePasswordNewCoverForm2.Text = string.Empty;
            switchForm2.Checked = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            pnlChangePassword.Visible = true;
            guna2Transition1.ShowSync(pnlChangePassword);
            clearForm2();
        }

        private void btnPageChangePassword_Click(object sender, EventArgs e)
        {
            pnlChangePassword.Visible = false;
            guna2Transition1.HideSync(pnlChangePassword);
            clearForm1();
        }

        private string GetMD5(string txt)
        {
            string str = "";
            Byte[] buffer = System.Text.Encoding.UTF8.GetBytes(txt);
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            buffer = md5.ComputeHash(buffer);
            foreach (Byte b in buffer)
            {
                str += b.ToString("X2");
            }
            return str;
        }

        private void btnLoginForm1_Click(object sender, EventArgs e)
        {
            if (txtUserNameForm1.Text == "")
            {
                Form2.title = "Tên Đăng Nhập Hiện Đang (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtPasswordForm1.Text == "")
            {
                Form2.title = "Mật Khẩu Hiện Đang (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtUserNameForm1.Text.Trim().Length < 2)
            {
                Form2.title = "Tên Đăng Nhập Phải Lớn Hơn ( 2 ký tự ) ";
                Form2.ShowDialog();
                return;
            }
            if (txtPasswordForm1.Text.Trim().Length < 3)
            {
                Form2.title = "Mật Khẩu Phải Lớn Hơn ( 3 ký tự ) ";
                Form2.ShowDialog();
                return;
            }
            string password = GetMD5(txtPasswordForm1.Text);
            if ((DbStaff.CheckLoginStaff(txtUserNameForm1.Text, password)) == true)
            {
                List<Staff> staffList = DbStaff.CheckRole(txtUserNameForm1.Text);
                foreach (Staff item in staffList)
                {
                    if (item.role_id == 2)
                    {
                        Form5.fullName = item.first_name + " " + item.last_name;
                        Form5.roleName = item.title;
                        Form5.imageStaff = item.image;
                        Form5.id_staff = item.id;
                        Form5.ShowDialog();
                        this.Close();
                        return;
                    }
                    else if (item.role_id == 1)
                    {
                        Form4.fullName = item.first_name + " " + item.last_name;
                        Form4.roleName = item.title;
                        Form4.id_staff = item.id;
                        Form4.ShowDialog();
                        this.Close();
                        return;
                    }
                }
            }
            else if ((DbStaff.CheckLoginStaff(txtUserNameForm1.Text, txtPasswordForm1.Text)) == false)
            {
                Form2.title = "Đăng Nhập Không Thành Công ";
                Form2.ShowDialog();
                return;
            }

        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            if (txtUserNameForm2.Text == "")
            {
                Form2.title = "Tên Đăng Nhập Hiện Đang (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtPasswordOldForm2.Text == "")
            {
                Form2.title = "Mật Khẩu Cũ Đang (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtChangePasswordNewForm2.Text == "")
            {
                Form2.title = "Mật Khẩu Mới Đang (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtChangePasswordNewCoverForm2.Text == "")
            {
                Form2.title = "Mật Khẩu Mới Nhập Lại Đang (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtUserNameForm2.Text.Trim().Length < 2)
            {
                Form2.title = "Tên Đăng Nhập Phải Lớn Hơn ( 2 ký tự ) ";
                Form2.ShowDialog();
                return;
            }
            if (txtPasswordOldForm2.Text.Trim().Length < 2)
            {
                Form2.title = "Mật Khẩu Cũ Phải Lớn Hơn ( 2 ký tự ) ";
                Form2.ShowDialog();
                return;
            }
            if (txtChangePasswordNewForm2.Text.Trim().Length < 2)
            {
                Form2.title = "Mật Khẩu Mới Phải Lớn Hơn ( 2 ký tự ) ";
                Form2.ShowDialog();
                return;
            }
            string PasswordOld = GetMD5(txtPasswordOldForm2.Text);
            string PasswordNewForm = GetMD5(txtChangePasswordNewForm2.Text);
            string ChangePasswordNewCoverForm = GetMD5(txtChangePasswordNewCoverForm2.Text);
            if (PasswordNewForm != ChangePasswordNewCoverForm)
            {
                Form2.title = "MK Mới Và MK Nhập Lại (Không Khớp) ";
                Form2.ShowDialog();
                return;
            }
            if ((DbStaff.CheckLoginStaff(txtUserNameForm2.Text, PasswordOld)) == false)
            {
                Form2.title = "Kiểm tra lại (Tên đăng nhập và MK Cũ)";
                Form2.ShowDialog();
                return;
            }
            if ((DbStaff.CheckUpdatePasswordStaff(txtUserNameForm2.Text, ChangePasswordNewCoverForm)) == true)
            {
                Form1.title = "Cập Nhật Thành Công";
                Form1.ShowDialog();

            }
            clearForm2();
        }

        private void switchForm1_CheckedChanged(object sender, EventArgs e)
        {
            if (switchForm1.Checked)
            {
                txtPasswordForm1.UseSystemPasswordChar = false;
            }
            else
            {
                txtPasswordForm1.UseSystemPasswordChar = true;
            }
        }

        private void switchForm2_CheckedChanged(object sender, EventArgs e)
        {
            if (switchForm2.Checked)
            {
                txtPasswordOldForm2.UseSystemPasswordChar = txtChangePasswordNewForm2.UseSystemPasswordChar = txtChangePasswordNewCoverForm2.UseSystemPasswordChar = false;
            }
            else
            {
                txtPasswordOldForm2.UseSystemPasswordChar = txtChangePasswordNewForm2.UseSystemPasswordChar = txtChangePasswordNewCoverForm2.UseSystemPasswordChar = true;
            }
        }
    }
}
