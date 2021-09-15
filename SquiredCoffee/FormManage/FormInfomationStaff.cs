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
        public FormInfomationStaff(UC_ManageStaff parent)
        {
            InitializeComponent();
            _parent = parent;
            ListRole();
        }

        Bitmap ImageProduct;
        public string image_staff;
        public int id_staff;
        public string x = "Admin";
        public string roleName;
        public string gender;
        public int status;

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
                if(item.gender == "Nam")
                {
                    chkMale.Checked = true;
                }
                else if (item.gender == "Nữ")
                {
                    chkFemale.Checked = true;
                }
                dtpBirthday.Text = item.birthday;
                txtPhone.Text = item.phone;
                txtEmail.Text = item.email;
                txtUserName.Text = item.username;
                txtPassword.Text = item.password;
                cbRoleName.Text = roleName;
                if (item.status == 1)
                {
                    rdStatus1.Checked = true;
                }
                else if (item.status == 0)
                {
                    rdStatus2.Checked = true;
                }
                image_staff = item.image;
                ptImage.Image = ConvertBase64ToImage(image_staff);
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

        private void btnEdit_Click(object sender, EventArgs e)
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
            if (MessageBox.Show("Bạn có muốn chỉnh sửa tài khoản này không !", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (btnEdit.Text == "Sửa")
                {
                    string birthday = dtpBirthday.Value.Date.ToString("yyyy-MM-dd");
                    Staff std = new Staff(txtlast_name.Text, txtFirstName.Text, txtUserName.Text, txtPassword.Text, gender, birthday, image_staff, txtPhone.Text, txtEmail.Text, Convert.ToInt32(cbRoleName.SelectedValue), status);
                    DbStaff.UpdateStaff(std, id_staff.ToString());
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
            gender = "Nam";
        }

        private void chkFemale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Nữ";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa tài khoản này không !", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (btnDelete.Text == "Xóa")
                {
                    DbStaff.DeleteStaff(id_staff.ToString());
                    this.Close();
                    _parent.resetForm();
                    _parent.Display();
                }
            }
        }
    }
}
