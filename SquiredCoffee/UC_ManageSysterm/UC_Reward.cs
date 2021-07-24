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
    public partial class UC_Reward : UserControl
    {
        Bitmap ImageReward;
        public string image_reward;
        public int status,id;
        public UC_Reward()
        {
            InitializeComponent();
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
                    ImageReward = new Bitmap(dialog.FileName);
                    ptImage.Image = (Image)ImageReward;

                    byte[] imageArray = System.IO.File.ReadAllBytes(dialog.FileName);
                    string base64Text = Convert.ToBase64String(imageArray); //base64Text must be global but I'll use  richtext
                    image_reward = base64Text;
                }
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
            DbReward.DisplayAndSearch("SELECT id,title,content,image,start_date,expiry_date,point,status FROM rewards ", dgvReward);
        }


        public void Clear()
        {
            txtContent.Text = txtPoint.Text = txtRewardName.Text = txtSearch.Text = string.Empty;
            rbStatus1.Checked = false;
            rbStatus2.Checked = false;
            dtpExpiry_Date.Value = DateTime.Now;
            dtpStart_Date.Value = DateTime.Now;
            ptImage.Image = new Bitmap(Application.StartupPath + "\\Resource\\no_img.jpg");
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtRewardName.Text.Trim().Length < 1)
            {
                MessageBox.Show("Tên Phần Thưởng phải ( > 1) ký tự");
                return;
            }
            if (txtPoint.Text.Trim().Length < 1)
            {
                MessageBox.Show("Mã Nhân Viên phải ( > 1) ký tự");
                return;
            }
            if (txtContent.Text.Trim().Length == null)
            {
                MessageBox.Show("Nội Dung Phần Thưởng Không Được Để Trống");
                return;
            }
            if (ptImage.Image == null)
            {
                MessageBox.Show("Hình Ảnh Phẩn Thưởng Đang Trống");
                return;
            }
            if (btnInsert.Text == "Thêm")
            {
                Rewards std = new Rewards(txtRewardName.Text.Trim(),txtContent.Text.Trim(),image_reward,dtpStart_Date.Text.Trim(), dtpExpiry_Date.Text.Trim(),int.Parse(txtPoint.Text.Trim()),status);
                DbReward.AddReward(std);
                Clear();
                Display();
            }
        }

        private void rbStatus1_CheckedChanged(object sender, EventArgs e)
        {
            status = 1;
        }

        private void rbStatus2_CheckedChanged(object sender, EventArgs e)
        {
            status = 0;
        }

        private void UC_Reward_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtRewardName.Text.Trim().Length < 1)
            {
                MessageBox.Show("Tên Phần Thưởng phải ( > 1) ký tự");
                return;
            }
            if (txtPoint.Text.Trim().Length < 1)
            {
                MessageBox.Show("Mã Nhân Viên phải ( > 1) ký tự");
                return;
            }
            if (txtContent.Text.Trim().Length == null)
            {
                MessageBox.Show("Nội Dung Phần Thưởng Không Được Để Trống");
                return;
            }
            if (ptImage.Image == null)
            {
                MessageBox.Show("Hình Ảnh Phẩn Thưởng Đang Trống");
                return;
            }
            if (btnEdit.Text == "Sửa")
            {
                Rewards std = new Rewards(txtRewardName.Text.Trim(), txtContent.Text.Trim(), image_reward, dtpStart_Date.Text.Trim(), dtpExpiry_Date.Text.Trim(), int.Parse(txtPoint.Text.Trim()), status);
                DbReward.UpdateReward(std,id.ToString());
                Clear();
                Display();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DbReward.DisplayAndSearch("SELECT id,title,content,image,start_date,expiry_date,point,status FROM rewards WHERE title LIKE'%" + txtSearch.Text + "%'", dgvReward);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "Xóa")
            {
                DbReward.DeleteReward(id.ToString());
                Clear();
                Display();
            }
        }

        private void dgvReward_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dgvReward.SelectedRows[0].Cells[0].Value.ToString());
            txtRewardName.Text = dgvReward.SelectedRows[0].Cells[1].Value.ToString();
            txtPoint.Text = dgvReward.SelectedRows[0].Cells[6].Value.ToString();
            dtpStart_Date.Text= dgvReward.SelectedRows[0].Cells[5].Value.ToString();
            dtpExpiry_Date.Text = dgvReward.SelectedRows[0].Cells[4].Value.ToString();
            txtContent.Text = dgvReward.SelectedRows[0].Cells[2].Value.ToString();
            if (Convert.ToInt32(dgvReward.SelectedRows[0].Cells[7].Value.ToString()) == 1)
            {
                rbStatus1.Checked = true;
            }
            if (Convert.ToInt32(dgvReward.SelectedRows[0].Cells[7].Value.ToString()) == 0)
            {
                rbStatus2.Checked = true;
            }
            status = Convert.ToInt32(dgvReward.SelectedRows[0].Cells[7].Value.ToString());
            image_reward = dgvReward.SelectedRows[0].Cells[3].Value.ToString();
            ptImage.Image = ConvertBase64ToImage(image_reward);
        }
    }
}
