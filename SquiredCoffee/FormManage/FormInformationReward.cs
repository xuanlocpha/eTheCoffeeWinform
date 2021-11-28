using SquiredCoffee.Class;
using SquiredCoffee.DB;
using SquiredCoffee.UC_ManageSysterm;
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
    public partial class FormInformationReward : Form
    {
        UC_ManageReward _parent;
        public string id_reward;
        public string image_reward;
        public int status;
        FormSuccess Form1;
        FormError Form2;
        public FormInformationReward(UC_ManageReward parent)
        {
            InitializeComponent();
            Form1 = new FormSuccess();
            Form2 = new FormError();
            _parent = parent;
        }


        public void clear()
        {
            txtQuantity.Text = txtTitle.Text = txtContent.Text = txtPoint.Text = txtBrand.Text = "";
            ptImage.Image = new Bitmap(Application.StartupPath + "\\Resource\\no_img.jpg");
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

        public void Display()
        {
            List<RewardShow> rewardShowList = DbReward.LoadReward(id_reward);
            foreach (RewardShow item in rewardShowList)
            {
                txtTitle.Text = item.title;
                txtBrand.Text = item.brand_name;
                txtContent.Text = item.content;
                txtPoint.Text = item.point.ToString();
                txtQuantity.Text = item.quantity.ToString();
                image_reward = item.image;
                ptImage.Image = ConvertBase64ToImage(image_reward);
                if (item.status == 1)
                {
                    rdStatus1.Checked = true;
                }
                else if (item.status == 0)
                {
                    rdStatus2.Checked = true;
                }
                status = item.status;
                if (status == 1)
                {
                    rdStatus1.Checked = true;
                }
                else if (status == 0)
                {
                    rdStatus2.Checked = true;
                }
            }
        }

        private void rdStatus_CheckedChanged(object sender, EventArgs e)
        {
            status = 1;
        }

        private void rdStatus2_CheckedChanged(object sender, EventArgs e)
        {
            status = 0;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text == "")
            {
                Form2.title = "Tên Quà Tặng Không Để(Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtTitle.Text.Trim().Length < 1)
            {
                Form2.title = "Tên Quà Tặng (> 1 Ký Tự) ";
                Form2.ShowDialog();
                return;
            }
            if (txtBrand.Text == "")
            {
                Form2.title = "Tên Nhà Sản Xuất Không (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtBrand.Text.Trim().Length < 1)
            {
                Form2.title = "Tên Nhà Sản Xuất (> 1 Ký Tự) ";
                Form2.ShowDialog();
                return;
            }
            if (txtContent.Text == "")
            {
                Form2.title = "Giới Thiệu Không Để (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtContent.Text.Trim().Length < 1)
            {
                Form2.title = "Giới Thiệu Phải (> 1 Ký Tự) ";
                Form2.ShowDialog();
                return;
            }
            if (txtPoint.Text == "")
            {
                Form2.title = "Điểm Không Được Để (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtPoint.Text.Trim().Length < 1)
            {
                Form2.title = "Điểm Phải (> 1 Ký Tự) ";
                Form2.ShowDialog();
                return;
            }
            if (txtQuantity.Text == "")
            {
                Form2.title = "Số Lượng Không Được Để (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtQuantity.Text.Trim().Length < 1)
            {
                Form2.title = "Số Lượng Phải (> 1 Ký Tự) ";
                Form2.ShowDialog();
                return;
            }
            if (image_reward == "")
            {
                Form2.title = "Hình Ảnh Quà Tặng Đang Để Trống (> 1 Ký Tự) ";
                Form2.ShowDialog();
                return;
            }
            if (btnEdit.Text == "Sửa")
            {
                Rewards std = new Rewards(12, txtTitle.Text, txtBrand.Text, txtContent.Text, image_reward, Convert.ToInt32(txtPoint.Text), Convert.ToInt32(txtQuantity.Text), status);
                if (DbReward.CheckUpdateReward(std,id_reward) == true)
                {
                    Form1.title = "Cập Nhật Quà Tặng ( Thành Công )";
                    Form1.ShowDialog();
                    clear();
                    this.Close();
                    _parent.Display();
                }
                else
                {
                    Form2.title = "Cập Nhật Quà Tặng ( Không Thành Công )";
                    Form2.ShowDialog();
                }
            }
        }

        private void FormInformationReward_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "Sửa")
            {
               
                if (DbReward.CheckDeleteReward(id_reward) == false)
                {
                    Form1.title = "Xóa Quà Tặng ( Thành Công )";
                    Form1.ShowDialog();
                    clear();
                    this.Close();
                    _parent.Display();
                }
                else
                {
                    Form2.title = "Xóa Quà Tặng ( Không Thành Công )";
                    Form2.ShowDialog();
                    clear();
                    this.Close();
                    _parent.Display();
                }
            }
        }
    }
}
