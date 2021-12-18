using MySql.Data.MySqlClient;
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
    public partial class FormInfomationStaff : Form
    {
        MySqlConnection con = new MySqlConnection();
        public static UC_ManageStaff _parent;
        FormSuccess Form1;
        FormError Form2;
        public FormInfomationStaff(UC_ManageStaff parent)
        {
            InitializeComponent();
            _parent = parent;
            ListRole();
            Form1 = new FormSuccess();
            Form2 = new FormError();
        }

        Bitmap ImageProduct;
        public string image_staff;
        public int id_staff;
        public string x = "Admin";
        public string roleName;
        public string gender;
        public int status;
        public string password;

        void ketnoi()
        {
            con.ConnectionString = "SERVER=45.252.251.29;PORT=3306;DATABASE=sodopxlg_koffeeholic;UID=sodopxlg;PASSWORD=05qT1yfRp9";
            if (con.State == ConnectionState.Closed)
                con.Open();
        }


        public DataSet LoadDB(string sql)
        {
            ketnoi();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
            da.Fill(ds);
            return ds;
        }

        void ListRole()
        {
            string sql = "SELECT * FROM roles";
            DataSet ListCategory = new DataSet();
            ListCategory = LoadDB(sql);
            cbRoleName.DataSource = ListCategory.Tables[0];
            cbRoleName.DisplayMember = "Title";
            cbRoleName.ValueMember = "id";
            cbRoleName.SelectedIndex = -1;
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

        public void Display()
        {
            List<Staff> staffList = DbStaff.LoadInfomationStaff(id_staff.ToString());
            foreach (Staff item in staffList)
            {
                txtFirstName.Text = item.first_name;
                txtlast_name.Text = item.last_name;
                if(item.gender == "male")
                {
                    chkMale.Checked = true;
                }
                else if (item.gender == "female")
                {
                    chkFemale.Checked = true;
                }
                dtpBirthday.Text = item.birthday;
                txtPhone.Text = item.phone;
                txtEmail.Text = item.email;
                txtUserName.Text = item.username;
                password = item.password;
                cbRoleName.Text = item.title;
                if (item.status == 1)
                {
                    rdStatus1.Checked = true;
                }
                else if (item.status == 0)
                {
                    rdStatus2.Checked = true;
                }
                image_staff = item.image;
                if (image_staff != "")
                {
                    ptImage.Image = ConvertBase64ToImage(item.image);
                }
                else
                {
                    ptImage.Image = new Bitmap(Application.StartupPath + "\\Resource\\no_img.jpg");
                }
                status = item.status;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormInfomationStaff_Load(object sender, EventArgs e)
        {
            Display();       
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG" +
             "|All files(*.*)|*.*";
            dialog.CheckFileExists = true;
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ImageProduct = new Bitmap(dialog.FileName);
                ptImage.Image = (Image)ImageProduct;

                byte[] imageArray = System.IO.File.ReadAllBytes(dialog.FileName);
                string base64Text = Convert.ToBase64String(imageArray); //base64Text must be global but I'll use  richtext
                image_staff = base64Text;
            }
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text.Trim() == "")
            {
                Form2.title = "Tên Của Nhân Viên (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtFirstName.Text.Trim().Length < 1)
            {
                Form2.title = "Họ Của Nhân Viên Không Được (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtlast_name.Text.Trim() == "")
            {
                Form2.title = "Tên Và Họ Nhân Viên Không Được (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtlast_name.Text.Trim().Length < 1)
            {
                Form2.title = "Tên Và Họ Nhân Viên (>1 Ký Tự) ";
                Form2.ShowDialog();
                return;
            }
            if (gender == "")
            {
                Form2.title = "Giới Tính Không Được (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (dtpBirthday.Value == DateTime.Now)
            {
                Form2.title = "Ngày Sinh Không Được Trùng Với Hiện Tại (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtPhone.Text.Trim() == "")
            {
                Form2.title = "Số Điện Thoại Nhân Viên Không Được Để ( Trống ) ";
                Form2.ShowDialog();
                return;
            }
            if (txtPhone.Text.Trim().Length < 1)
            {
                Form2.title = "Số Điện Thoại Nhân Viên (>1 Ký Tự) ";
                Form2.ShowDialog();
                return;
            }
            if (txtPhone.Text.Trim().Length > 11)
            {
                Form2.title = "Số Điện Thoại Chỉ Tối Đa (10 Ký Tự) ";
                Form2.ShowDialog();
                return;
            }
            if (txtEmail.Text.Trim() == "")
            {
                Form2.title = "Email Không Được (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtEmail.Text.Trim().Length < 1)
            {
                Form2.title = "Email Phải (>1 Ký Tự) ";
                Form2.ShowDialog();
                return;
            }
            if (!this.txtEmail.Text.Contains('@') || !this.txtEmail.Text.Contains('.'))
            {
                Form2.title = "Email Nhập Không Hợp Lệ (@) ";
                Form2.ShowDialog();
                return;
            }
            if (txtUserName.Text.Trim() == "")
            {
                Form2.title = "Tên Đăng Nhập Không Để (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtUserName.Text.Trim().Length < 1)
            {
                Form2.title = "Tên Đăng Nhập (>1 Ký Tự) ";
                Form2.ShowDialog();
                return;
            }
            if (txtPassword.Text.Trim() == "")
            {
                Form2.title = "Mật Khẩu Đang (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtPassword.Text.Trim().Length < 1)
            {
                Form2.title = "Mật Khẩu (>1 Ký Tự) ";
                Form2.ShowDialog();
                return;
            }
            if (cbRoleName.ValueMember == "")
            {
                Form2.title = "Bạn Chưa Phân Quyền Tài Khoản";
                Form2.ShowDialog();
                return;
            }
            if (image_staff == "")
            {
                Form2.title = "Hình Ảnh Của Nhân Viên Đang (Trống) ";
                Form2.ShowDialog();
                return;
            }
            
                if (btnEdit.Text == "Sửa")
                {
                    string birthday = dtpBirthday.Value.Date.ToString("yyyy-MM-dd");
                    Staff std = new Staff(txtlast_name.Text, txtFirstName.Text, txtUserName.Text,password, gender, birthday, image_staff, txtPhone.Text, txtEmail.Text, Convert.ToInt32(cbRoleName.SelectedValue), status);
                    if(DbStaff.CheckUpdateStaff(std,id_staff.ToString())== true)
                    {
                        Form1.title = "Sửa Thành Công ";
                        Form1.ShowDialog();
                        this.Close();
                        _parent.resetForm();
                        _parent.Display();
                    }
                    else
                    {
                        Form2.title = "Sửa Không Thành Công ";
                        Form2.ShowDialog();
                        this.Close();
                        _parent.resetForm();
                        _parent.Display();
                    }
                }
           
        }

        private void rdStatus1_CheckedChanged(object sender, EventArgs e)
        {
            status = 1;
        }

        private void rdStatus2_CheckedChanged(object sender, EventArgs e)
        {
            status = 0;
        }

        private void chkMale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "male";
            chkFemale.Checked = false;
        }

        private void chkFemale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "female";
            chkMale.Checked = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Text == "Xóa")
            {
                if (DbStaff.CheckDeleteStaff(id_staff.ToString())==false)
                {
                    Form1.title = "Xóa Thành Công ";
                    Form1.ShowDialog();
                    this.Close();
                    _parent.resetForm();
                    _parent.Display();
                }
                else
                {
                    Form1.title = "Xóa Không Thành Công ";
                    Form1.ShowDialog();
                    this.Close();
                    _parent.resetForm();
                    _parent.Display();
                }
            }
        }
    }
}
