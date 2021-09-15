using MySql.Data.MySqlClient;
using SquiredCoffee.Class;
using SquiredCoffee.DB;
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

namespace SquiredCoffee.UC_ManageSysterm
{ 
    public partial class UC_Staff : UserControl
    {
        MySqlConnection con = new MySqlConnection();
        Bitmap ImageProduct;
        public string gender;
        public int id;
        public int status;
        public string image_staff;
      

        public UC_Staff()
        {
            InitializeComponent();
            ListCategory();
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
            guna2ComboBox1.DataSource = ListCategory.Tables[0];
            guna2ComboBox1.DisplayMember = "title";
            guna2ComboBox1.ValueMember = "id";
            guna2ComboBox1.SelectedIndex = -1;
        }

        public void Clear()
        {
            txtAddress.Text=txtEmail.Text=txtEmployeeCode.Text=txtFullName.Text=txtPassword.Text=txtPhoneNumber.Text=txtSearch.Text=txtUserName.Text= string.Empty;
            guna2ComboBox1.Text = null;
            ptImage.Image = new Bitmap(Application.StartupPath + "\\Resource\\no_img.jpg");
            chkStatus1.Checked = chkStatus2.Checked = false;
            rbFemale.Checked = rbMale.Checked = false;
            dtpBirthDay.Value = DateTime.Today;
        }

        public void Display()
        {
            DbStaff.DisplayAndSearch("SELECT s.id,s.employee_code,s.full_name,s.username,s.password,s.gender,s.birthday,s.image,s.phone,s.email,s.address,s.role_id,s.status,r.Title FROM staffs s, roles r WHERE s.role_id = r.id", dgvStaff);
        }

        private void UC_Staff_Load(object sender, EventArgs e)
        {
            Display();
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


        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dgvStaff.SelectedRows[0].Cells[0].Value.ToString());
            txtEmployeeCode.Text = dgvStaff.SelectedRows[0].Cells[1].Value.ToString();
            txtFullName.Text = dgvStaff.SelectedRows[0].Cells[2].Value.ToString();
            txtUserName.Text = dgvStaff.SelectedRows[0].Cells[3].Value.ToString();
            txtPassword.Text = dgvStaff.SelectedRows[0].Cells[4].Value.ToString();
           
            if (dgvStaff.SelectedRows[0].Cells[5].Value.ToString() == "male")
            {
                rbMale.Checked = true;
            }
            if (dgvStaff.SelectedRows[0].Cells[5].Value.ToString() == "female")
            {
                rbFemale.Checked = true;
            }
            dtpBirthDay.Text = dgvStaff.SelectedRows[0].Cells[6].Value.ToString();
            image_staff = dgvStaff.SelectedRows[0].Cells[7].Value.ToString();
            guna2ComboBox1.Text = dgvStaff.SelectedRows[0].Cells[13].Value.ToString();
            txtPhoneNumber.Text = dgvStaff.SelectedRows[0].Cells[8].Value.ToString();
            txtEmail.Text = dgvStaff.SelectedRows[0].Cells[9].Value.ToString();
            ptImage.Image = ConvertBase64ToImage(image_staff);

            if (Convert.ToInt32(dgvStaff.SelectedRows[0].Cells[12].Value.ToString())== 1)
            {
                chkStatus1.Checked = true;
            }
            if (Convert.ToInt32(dgvStaff.SelectedRows[0].Cells[12].Value.ToString()) == 0)
            {
                chkStatus2.Checked = true;
            }
            txtAddress.Text = dgvStaff.SelectedRows[0].Cells[10].Value.ToString();
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "male";
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "female";
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

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtEmployeeCode.Text.Trim().Length < 3)
            {
                MessageBox.Show("Mã Nhân Viên phải ( > 3) ký tự");
                return;
            }
            if (txtFullName.Text.Trim().Length < 3)
            {
                MessageBox.Show("Tên Nhân Viên ( > 3) ký tự");
                return;
            }

            if (txtUserName.Text.Trim().Length < 3)
            {
                MessageBox.Show("UserName ( > 3) ký tự");
                return;
            }

            if (txtPassword.Text.Trim().Length < 3)
            {
                MessageBox.Show("Password ( > 3) ký tự");
                return;
            }

            if (txtEmail.Text.Trim().Length < 3)
            {
                MessageBox.Show("UserName ( > 3) ký tự");
                return;
            }

            if (txtPhoneNumber.Text.Trim().Length < 3)
            {
                MessageBox.Show("UserName ( > 3) ký tự");
                return;
            }

            if (txtAddress.Text.Trim().Length < 3)
            {
                MessageBox.Show("UserName ( > 3) ký tự");
                return;
            }

            if (btnInsert.Text == "Thêm")
            {
                Staff std = new Staff(txtEmployeeCode.Text.Trim(),txtFullName.Text.Trim(),txtUserName.Text.Trim(),txtPassword.Text.Trim(),gender,dtpBirthDay.Text.Trim(), image_staff,txtPhoneNumber.Text.Trim(), txtEmail.Text.Trim(), Convert.ToInt32(guna2ComboBox1.SelectedValue),status);
                DbStaff.AddStaff(std);
                Clear();
                Display();
            }
        }

        private void chkStatus1_CheckedChanged(object sender, EventArgs e)
        {
            status = 1;
        }

        private void chkStatus2_CheckedChanged(object sender, EventArgs e)
        {
            status = 0;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtEmployeeCode.Text.Trim().Length < 3)
            {
                MessageBox.Show("Mã Nhân Viên phải ( > 3) ký tự");
                return;
            }
            if (txtFullName.Text.Trim().Length < 3)
            {
                MessageBox.Show("Tên Nhân Viên ( > 3) ký tự");
                return;
            }

            if (txtUserName.Text.Trim().Length < 3)
            {
                MessageBox.Show("UserName ( > 3) ký tự");
                return;
            }

            if (txtPassword.Text.Trim().Length < 3)
            {
                MessageBox.Show("Password ( > 3) ký tự");
                return;
            }

            if (txtEmail.Text.Trim().Length < 3)
            {
                MessageBox.Show("UserName ( > 3) ký tự");
                return;
            }

            if (txtPhoneNumber.Text.Trim().Length < 3)
            {
                MessageBox.Show("UserName ( > 3) ký tự");
                return;
            }

            if (txtAddress.Text.Trim().Length < 3)
            {
                MessageBox.Show("UserName ( > 3) ký tự");
                return;
            }

            if (btnInsert.Text == "Thêm")
            {
                Staff std = new Staff(txtEmployeeCode.Text.Trim(), txtFullName.Text.Trim(), txtUserName.Text.Trim(), txtPassword.Text.Trim(), gender, dtpBirthDay.Text.Trim(), image_staff, txtPhoneNumber.Text.Trim(), txtEmail.Text.Trim(), Convert.ToInt32(guna2ComboBox1.SelectedValue), status);
                DbStaff.UpdateStaff(std,id.ToString());
                Clear();
                Display();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DbStaff.DisplayAndSearch("SELECT id,employee_code,full_name,username,password,gender,birthday,image,phone,email,address,role_id,status FROM staffs  WHERE (employee_code LIKE'%" + txtSearch.Text + "%') OR (full_name LIKE'%" + txtSearch.Text + "%')", dgvStaff);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Text == "Xóa")
            {
                DbStaff.DeleteStaff(id.ToString());
                Clear();
                Display();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
