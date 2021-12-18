using Guna.UI2.WinForms;
using SquiredCoffee.Class;
using SquiredCoffee.CustomControls;
using SquiredCoffee.DB;
using SquiredCoffee.ViewModels;
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
    public partial class FormReward : Form
    {
        private PictureBox pic = new PictureBox();
        public Label point;
        public Label title;
        public int id_user;
        public int point_user;
        FormSale _parent;
        FormInformationRewardUser Form;
        FormError Form1;
        FormQRReward Form3;
        public FormReward(FormSale parent)
        {
            _parent = parent;
            InitializeComponent();
            Form = new FormInformationRewardUser(this);
            Form1 = new FormError();
            Form3 = new FormQRReward(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _parent.checkBtn();
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

        public void clear1()
        {
            txtSearch.Text = string.Empty;
        }

        public static Image LoadBase64(string base64)
        {
            byte[] bytes = Convert.FromBase64String(base64);
            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }
            return image;
        }

        public void LoadRewardList()
        {
            flpReward.Controls.Clear();
            List<RewardShow> rewardShowList = DbReward.LoadReward();
            foreach (RewardShow item in rewardShowList)
            {
                Guna2Elipse elip = new Guna2Elipse();
                elip.TargetControl = pic;
                elip.BorderRadius = 10;

                Guna2Elipse elip1 = new Guna2Elipse();
                elip1.TargetControl = title;
                elip1.BorderRadius = 10;

                pic = new PictureBox();
                pic.Width = 196;
                pic.Height = 202;
                pic.BackColor = Color.SaddleBrown;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.BackgroundImage = LoadBase64(item.image.ToString());
                pic.Tag = item.id.ToString();

                title = new Label();
                title.Text = (item.title).ToString();
                title.BackColor = Color.Gainsboro;
                title.TextAlign = ContentAlignment.MiddleCenter;
                title.ForeColor = Color.Black;
                title.Font = new Font("Quicksand", 13, FontStyle.Bold);
                title.Dock = DockStyle.Bottom;

                Guna2GradientPanel guna2GradientPanel = new Guna2GradientPanel();
                guna2GradientPanel.Width = 115;
                guna2GradientPanel.Height = 25;
                guna2GradientPanel.FillColor = Color.FromArgb(249, 130, 68);
                guna2GradientPanel.FillColor2 = Color.FromArgb(247, 72, 115);
                guna2GradientPanel.BackColor = Color.Transparent;
                guna2GradientPanel.BorderRadius = 7;


                Label lbl = new Label();
                lbl.Text = string.Format("{0:#,##0} Point", double.Parse((item.point).ToString()));
                lbl.ForeColor = Color.White;
                lbl.Font = new Font("Quicksand", 10, FontStyle.Bold);
                lbl.TextAlign = ContentAlignment.MiddleCenter;


                pic.Controls.Add(title);
                pic.Controls.Add(guna2GradientPanel);
                guna2GradientPanel.Controls.Add(lbl);
                flpReward.Controls.Add(pic);

               pic.Click += new EventHandler(Onclick);
            }
        }

        public void Onclick(object sender, EventArgs e)
        {
            
            if(lblNameUser.Text == "name")
            {
                Form1.title = "Thông Tin Khách Hàng Đang ( Trống )!";
                Form1.ShowDialog();
                return;
            }
            else
            {
                FormBackGround formBackGround = new FormBackGround();
                try
                {
                    using (FormInformationRewardUser Form = new FormInformationRewardUser(this))
                    {
                        formBackGround.StartPosition = FormStartPosition.Manual;
                        formBackGround.FormBorderStyle = FormBorderStyle.None;
                        formBackGround.Opacity = .70d;
                        formBackGround.BackColor = Color.Black;
                        formBackGround.WindowState = FormWindowState.Maximized;
                        formBackGround.TopMost = true;
                        formBackGround.Location = this.Location;
                        formBackGround.ShowInTaskbar = false;
                        formBackGround.Show();

                        string tag = ((PictureBox)sender).Tag.ToString();
                        Form.id_user = id_user;
                        Form.id_reward = Convert.ToInt32(tag);
                        Form.point_user = point_user;
                        this.Hide();
                        Form.Owner = formBackGround;
                        Form.ShowDialog();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    formBackGround.Dispose();
                }
                
            }
          
        }

        private void FormReward_Load(object sender, EventArgs e)
        {
            LoadRewardList();
            Guna.UI.Lib.ScrollBar.PanelScrollHelper flowpan = new Guna.UI.Lib.ScrollBar.PanelScrollHelper(flpReward, gunaVScrollBar1, true);
        }

        public void clear()
        {
            txtSearch.PlaceholderText = "Hãy Nhập Số Điện Thoại Cần Tìm";
            txtSearch.Text = string.Empty;
            lblLevel.Text = "Bạc";
            lblNameUser.Text = "Name";
            lblPoint.Text = "0 Point";
        }


        public void LoadInformationUser()
        {
            List<User> userList = DbUser.UserSearch(txtSearch.Text);
            foreach (User item in userList)
            {
                if(item != null)
                {
                    lblNameUser.Text = item.display_name;
                    lblPoint.Text = string.Format("{0:#,##0} Point", item.point);
                    point_user = item.point;
                    id_user = item.id;
                    if (item.point >= 0 && item.point <= 300)
                    {
                        lblLevel.Text = "Bạc";
                    }
                    if (item.point >= 301 && item.point <= 1000)
                    {
                        lblLevel.Text = "Vàng";
                    }
                    if (item.point > 1000)
                    {
                        lblLevel.Text = "Kim Cương";
                    }
                }
                else
                {
                    Form1.title = "Tài khoản không tồn tại";
                    Form1.ShowDialog();
                }
               
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadInformationUser();
           
        }

        private void btnQrCode_Click(object sender, EventArgs e)
        {
            if(id_user == 0)
            {
                Form1.title = "Thông Tin Khách Hàng Đang ( Trống )!";
                Form1.ShowDialog();
                return;
            }
            FormBackGround formBackGround = new FormBackGround();
            try
            {
                using (FormQRReward Form = new FormQRReward(this))
                {
                    formBackGround.StartPosition = FormStartPosition.Manual;
                    formBackGround.FormBorderStyle = FormBorderStyle.None;
                    formBackGround.Opacity = .70d;
                    formBackGround.BackColor = Color.Black;
                    formBackGround.WindowState = FormWindowState.Maximized;
                    formBackGround.TopMost = true;
                    formBackGround.Location = this.Location;
                    formBackGround.ShowInTaskbar = false;
                    formBackGround.Show();

                    Form.Owner = formBackGround;
                    Form.id_user = id_user;
                    Form.point_user = point_user;
                    this.Hide();
                    Form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                formBackGround.Dispose();
            }
            //Form3.id_user = id_user;
            //Form3.point_user = point_user;
            //this.Hide();
            //Form3.ShowDialog();
        }
    }
}
