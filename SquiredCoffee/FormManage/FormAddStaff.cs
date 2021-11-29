using MySql.Data.MySqlClient;
using SquiredCoffee.Class;
using SquiredCoffee.DB;
using SquiredCoffee.UC_ManageSysterm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SquiredCoffee.FormManage
{
    public partial class FormAddStaff : Form
    {
        MySqlConnection con = new MySqlConnection();
        Bitmap ImageProduct;
        public string image_staff;
        public string gender;
        public int status = 1;
        public static UC_ManageStaff _parent;
        FormSuccess Form1;
        FormError Form2;
        public FormAddStaff(UC_ManageStaff parent)
        {
            InitializeComponent();
            _parent = parent;
            Form1 = new FormSuccess();
            Form2 = new FormError();
        }

        void ketnoi()
        {
            con.ConnectionString = "SERVER=45.252.251.21;PORT=3306;DATABASE=sodopxlg_koffeeholic;UID=sodopxlg;PASSWORD=05qT1yfRp9";
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

        void ListCategory()
        {
            string sql = "SELECT * FROM roles";
            DataSet ListCategory = new DataSet();
            ListCategory = LoadDB(sql);
            cbRoleName.DataSource = ListCategory.Tables[0];
            cbRoleName.DisplayMember = "title";
            cbRoleName.ValueMember = "id";
            cbRoleName.SelectedIndex = -1;
        }

        private void FormAddStaff_Load(object sender, EventArgs e)
        {
            ListCategory();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void rdStatus1_CheckedChanged(object sender, EventArgs e)
        {
            status = 1;
        }

        private void rdStatus2_CheckedChanged(object sender, EventArgs e)
        {
            status = 2;
        }

        public void clear()
        {
            txtEmail.Text =txtFirstName.Text=txtlast_name.Text=txtPassword.Text=txtPhone.Text=txtUserName.Text= string.Empty;
            cbRoleName.SelectedIndex = -1;
            ptImage.Image = new Bitmap(Application.StartupPath + "\\Resource\\no_img.jpg");
            rdStatus1.Checked = true;
        }
    
        private void btnSave_Click(object sender, EventArgs e)
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
            if (DbStaff.CheckAdd(txtUserName.Text,txtPhone.Text) == true)
            {
                Form2.title = "Tài Khoản Đã (Tồn Tại)";
                Form2.ShowDialog();
                return;
            }
            if (btnSave.Text == "Lưu")
            {
                string birthday = dtpBirthday.Value.Date.ToString("yyyy-MM-dd");
                Staff std = new Staff(txtlast_name.Text,txtFirstName.Text,txtUserName.Text,txtPassword.Text,gender,birthday,image_staff,txtPhone.Text,txtEmail.Text, Convert.ToInt32(cbRoleName.SelectedValue), status);
                if(DbStaff.CheckCreateStaff(std) == true)
                {
                    Form1.title = "Tạo Thành Công";
                    Form1.ShowDialog();
                    this.Close();
                    clear();
                    _parent.resetForm();
                    _parent.Display();
                }
                else
                {
                    Form2.title = "Tạo Không Thành Công";
                    Form2.ShowDialog();
                    this.Close();
                    clear();
                    _parent.resetForm();
                    _parent.Display();
                }
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtFirstName.Text, "^[a-zA-Z ]"))
            {
                MessageBox.Show("Họ nhân viên chỉ được nhập chữ ");
                return;
            }
        }

        private void txtlast_name_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtFirstName.Text, "^[a-zA-Z ]"))
            {
                MessageBox.Show("Tên Lót Và Tên nhân viên chỉ được nhập chữ ");
                return;
            }
        }


        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
