using Bunifu.UI.WinForms.BunifuButton;
using Guna.UI.WinForms;
using Guna.UI2.WinForms;
using SquiredCoffee.Class;
using SquiredCoffee.DB;
using SquiredCoffee.UC_Controls;
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
    public partial class FormLogin : Form
    {
        FormStaff Form;
        FormMain Form1;
        public FormLogin()
        {
            InitializeComponent();
            //Form = new FormStaff(this);
           // Form1 = new FormMain(this);
        }

        public string userName;
        public int role_id;
        public int id_staff;
        public string fullName;
        public string roleName;


        public void Log(bool x)
        {
            if(x == true)
            {
                btnNumber0.Enabled = x;
                btnNumber1.Enabled = x;
                btnNumber2.Enabled = x;
                btnNumber3.Enabled = x;
                btnNumber4.Enabled = x;
                btnNumber5.Enabled = x;
                btnNumber6.Enabled = x;
                btnNumber7.Enabled = x;
                btnNumber8.Enabled = x;
                btnNumber9.Enabled = x;
                btnReset.Enabled = x;
            }
            if (x == false)
            {
                btnNumber0.Enabled = x;
                btnNumber1.Enabled = x;
                btnNumber2.Enabled = x;
                btnNumber3.Enabled = x;
                btnNumber4.Enabled = x;
                btnNumber5.Enabled = x;
                btnNumber6.Enabled = x;
                btnNumber7.Enabled = x;
                btnNumber8.Enabled = x;
                btnNumber9.Enabled = x;
                btnReset.Enabled = x;
            }
        }
       

        private void btnNumber2_Click(object sender, EventArgs e)
        {
            txtPassword.Text = txtPassword.Text + "2";
        }

        private void btnNumber3_Click(object sender, EventArgs e)
        {
            txtPassword.Text = txtPassword.Text + "3";
        }

        private void btnNumber4_Click(object sender, EventArgs e)
        {
            txtPassword.Text = txtPassword.Text + "4";
        }

        private void btnNumber5_Click(object sender, EventArgs e)
        {
            txtPassword.Text = txtPassword.Text + "5";
        }

        private void btnNumber6_Click(object sender, EventArgs e)
        {
            txtPassword.Text = txtPassword.Text + "6";
        }

        private void btnNumber7_Click(object sender, EventArgs e)
        {
            txtPassword.Text = txtPassword.Text + "7";
        }

        private void btnNumber8_Click(object sender, EventArgs e)
        {
            txtPassword.Text = txtPassword.Text + "8";
        }

        private void btnNumber9_Click(object sender, EventArgs e)
        {
            txtPassword.Text = txtPassword.Text + "9";
        }

        private void btnNumber0_Click(object sender, EventArgs e)
        {
            txtPassword.Text = txtPassword.Text + "0";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtPassword.Text = string.Empty;
        }

        private void chkHidden_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHidden.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        public void clear()
        {
            txtPassword.Text = string.Empty;
            flpStaff.Controls.Clear();
            loadStaff();
            Log(false);
        }

        public void clear1()
        {
            txtPassword.Text = string.Empty;
            flpStaff.Controls.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            clear();
            this.Close();

        }

        public void loadStaff()
        {
            List<Staff> staffList = DbStaff.LoadStaffList();

            foreach (Staff item in staffList)
            {
              
                RadioButton btn = new RadioButton()
                {
                    Width = 145,
                    Height = 50,
                };
                btn.Text = item.username;
                btn.Appearance = Appearance.Button;
                btn.BackColor = Color.FromArgb(21, 171, 108);
                btn.FlatStyle= FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseDownBackColor = Color.Tomato;
                btn.TextAlign = ContentAlignment.MiddleCenter;
                btn.Tag = item;
                Guna2Elipse e = new Guna2Elipse();
                e.BorderRadius = 15;
                e.TargetControl = btn;
                flpStaff.Controls.Add(btn);
                btn.Click += new EventHandler(Onclick);
            }
        }

        public void Onclick(object sender, EventArgs e)
        {
            int tag = ((sender as RadioButton).Tag as Staff).id;
            string tag1 = ((sender as RadioButton).Tag as Staff).username;
            int tag2 = ((sender as RadioButton).Tag as Staff).role_id;
            string tag3 = ((sender as RadioButton).Tag as Staff).first_name;
            string tag4 = ((sender as RadioButton).Tag as Staff).last_name;
            string tag5 = ((sender as RadioButton).Tag as Staff).title;
            userName = tag1;
            role_id = tag2;
            fullName = tag3 +" "+tag4;
            roleName = tag5;
            id_staff = tag;
            Log(true);
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = (1 * 450); // 1 secs
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
            Log(false);
            loadStaff();
        }

        

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (userName == "")
            {
                MessageBox.Show("UserName hiện đang (Trống)");
                return;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Mật Khẩu hiện đang (Trống)");
                return;
            }
            if ((DbStaff.CheckLoginStaff(userName, txtPassword.Text)) == true)
            {
                List<Staff> staffList = DbStaff.CheckRole(role_id.ToString());
                foreach (Staff item in staffList)
                {
                    if (item.role_id == 1)
                    {
                        Form1.fullName = fullName;
                        Form1.roleName = roleName;
                        Form1.id_staff = id_staff;
                        Form1.ShowDialog();
                        this.Close();
                        return;
                    }
                    else if (item.role_id == 2)
                    {
                        //Form.fullName = fullName;
                        //Form.roleName = roleName;
                        //Form.id_staff = id_staff;
                        //this.Hide();
                        //Form.ShowDialog();
                        //this.Show();
                        //return;
                    }
                    else
                    {

                    }
                }
            }
            else if ((DbStaff.CheckLoginStaff(userName, txtPassword.Text)) == false)
            {
                MessageBox.Show("Bạn hãy kiểm tra lại UserName hoặc Password ");
                return;
            }
        }

       
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

     
        private void btnNumber1_Click(object sender, EventArgs e)
        {
            txtPassword.Text = txtPassword.Text + "1";
        }
    }
}
