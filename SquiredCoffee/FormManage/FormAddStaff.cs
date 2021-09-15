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
        public FormAddStaff(UC_ManageStaff parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        void ketnoi()
        {
            con.ConnectionString = "datasource=localhost;port=3306;username=root;password=;database=coffeeshop";
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
            gender = "Nam";
        }

        private void chkFemale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Nữ";
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
                MessageBox.Show("Họ nhân viên không được để ( Trống )");
                return;
            }
            if (txtFirstName.Text.Trim().Length < 1)
            {
                MessageBox.Show("Họ nhân viên lớn hơn (  1 ký tự )");
                return;
            }
            if (txtlast_name.Text.Trim() == "")
            {
                MessageBox.Show("Tên lót & Tên nhân viên không được để ( Trống )");
                return;
            }
            if (txtlast_name.Text.Trim().Length < 1)
            {
                MessageBox.Show("Tên lót & Tên nhân viên lớn hơn (  1 ký tự )");
                return;
            }
            if (gender == "")
            {
                MessageBox.Show("Giới tính không được để ( Trống )");
                return;
            }
            if (dtpBirthday.Value == DateTime.Now)
            {
                MessageBox.Show("Ngày Sinh Không được trùng với ngày hiện tại ");
                return;
            }
            if (txtPhone.Text.Trim() == "")
            {
                MessageBox.Show("Số điện thoại nhân viên không được để ( Trống )");
                return;
            }
            if (txtPhone.Text.Trim().Length < 1)
            {
                MessageBox.Show("Số điện thoại  nhân viên lớn hơn  (  1 ký tự )");
                return;
            }
            if (txtPhone.Text.Trim().Length > 11)
            {
                MessageBox.Show("Số điện thoại  nhân viên chỉ được  bằng (  10 ký tự )");
                return;
            }
            if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Email nhân viên không được để ( Trống )");
                return;
            }
            if (txtEmail.Text.Trim().Length < 1)
            {
                MessageBox.Show("Email nhân viên lớn hơn (  1 ký tự )");
                return;
            }
            if (!this.txtEmail.Text.Contains('@') || !this.txtEmail.Text.Contains('.'))
            {
                MessageBox.Show("Email nhập vào không hợp lệ");
                return;
            }
            if (txtUserName.Text.Trim() == "")
            {
                MessageBox.Show("Tên đăng nhập không được để ( Trống )");
                return;
            }
            if (txtUserName.Text.Trim().Length < 1)
            {
                MessageBox.Show("Tên đăng nhập lớn hơn (  1 ký tự )");
                return;
            }
            if (txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Mật Khẩu không được để ( Trống )");
                return;
            }
            if (txtPassword.Text.Trim().Length < 1)
            {
                MessageBox.Show("Mật Khẩu lớn hơn (  1 ký tự )");
                return;
            }
            if (cbRoleName.ValueMember == "")
            {
                MessageBox.Show("Bạn chưa phân quyền cho tài khoản");
                return;
            }
            if (image_staff == "")
            {
                MessageBox.Show("Hình ảnh của nhân viên đang ( Trống )");
                return;
            }
            if (DbStaff.CheckAdd(txtUserName.Text,txtPhone.Text) == true)
            {
                MessageBox.Show("Tài khoản đã tồn tại");
                return;
            }
            if (btnSave.Text == "Lưu")
            {
                string birthday = dtpBirthday.Value.Date.ToString("yyyy-MM-dd");
                Staff std = new Staff(txtlast_name.Text,txtFirstName.Text,txtUserName.Text,txtPassword.Text,gender,birthday,image_staff,txtPhone.Text,txtEmail.Text, Convert.ToInt32(cbRoleName.SelectedValue), status);
                DbStaff.AddStaff(std);
                this.Close();
                clear();
                _parent.resetForm();
                _parent.Display();
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
    }
}
