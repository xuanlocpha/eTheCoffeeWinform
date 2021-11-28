using Guna.UI2.WinForms;
using SquiredCoffee.CustomControls;
using SquiredCoffee.DB;
using SquiredCoffee.FormManage;
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

namespace SquiredCoffee.UC_ManageSysterm
{
    public partial class UC_ManageReward : UserControl
    {
        FormAddReward Form;
        FormInformationReward Form1;
        private PictureBox pic = new PictureBox();
        public Label price;
        public Label title;
        public Label title1;
        public int total;
        public int totalSearch;

        public UC_ManageReward()
        {
            InitializeComponent();
            Form = new FormAddReward(this);
            Form1 = new FormInformationReward(this);
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
        public void clear()
        {
            total = 0;
            totalSearch = 0;
        }
        public void clear1()
        {
            totalSearch = 0;
        }

        public void Display()
        {
            clear();
            flpReward.Controls.Clear();
            List<RewardShow> rewardShowList = DbReward.LoadReward();
            foreach (RewardShow item in rewardShowList)
            {
                total += 1;
                if(item.quantity == 0)
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


                    title1 = new Label();
                    title1.Text = "( Hết Sản Phẩm !!!)";
                    title1.TextAlign = ContentAlignment.MiddleCenter;
                    title1.BackColor = Color.FromArgb(130, 255, 255, 255);
                    title1.ForeColor = Color.Red;
                    title1.Font = new Font("Quicksand", 12, FontStyle.Bold);
                    title1.Dock = DockStyle.Bottom;

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

                    pic.Controls.Add(title1);
                    pic.Controls.Add(title);
                    pic.Controls.Add(guna2GradientPanel);
                    guna2GradientPanel.Controls.Add(lbl);
                    flpReward.Controls.Add(pic);
                }
                else
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
                }
                pic.Click += new EventHandler(Onclick);
            }
            lblTotalReward.Text = total.ToString();
            lblTotalRewardSearch.Text = total.ToString();
        }



        public void Onclick(object sender, EventArgs e)
        {

            FormBackGround formBackGround = new FormBackGround();
            try
            {
                using (FormInformationReward Form = new FormInformationReward(this))
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
                    Form.id_reward = tag;
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

        private void UC_ManageReward_Load(object sender, EventArgs e)
        {
            Display();
            Guna.UI.Lib.ScrollBar.PanelScrollHelper flowpan = new Guna.UI.Lib.ScrollBar.PanelScrollHelper(flpReward, gunaVScrollBar1, true);
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            //Form.ShowDialog();
            FormBackGround formBackGround = new FormBackGround();
            try
            {
                using (FormAddReward Form = new FormAddReward(this))
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

        private void btnAll_Click(object sender, EventArgs e)
        {
            Display();
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            SearchStatus("1");
        }

        public void SearchStatus(string status)
        {
            clear1();
            flpReward.Controls.Clear();
            List<RewardShow> rewardShowList = DbReward.LoadRewardStatus(status);
            foreach (RewardShow item in rewardShowList)
            {
                totalSearch += 1;
                if (item.quantity == 0)
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


                    title1 = new Label();
                    title1.Text = "( Hết Sản Phẩm !!!)";
                    title1.TextAlign = ContentAlignment.MiddleCenter;
                    title1.BackColor = Color.FromArgb(130, 255, 255, 255);
                    title1.ForeColor = Color.Red;
                    title1.Font = new Font("Quicksand", 12, FontStyle.Bold);
                    title1.Dock = DockStyle.Bottom;

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

                    pic.Controls.Add(title1);
                    pic.Controls.Add(title);
                    pic.Controls.Add(guna2GradientPanel);
                    guna2GradientPanel.Controls.Add(lbl);
                    flpReward.Controls.Add(pic);
                }
                else
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
                }     
                pic.Click += new EventHandler(Onclick);
            }
            lblTotalRewardSearch.Text = totalSearch.ToString();
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            SearchStatus("0");
        }
    }
}
