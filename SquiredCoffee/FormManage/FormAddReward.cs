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
    public partial class FormAddReward : Form
    {
        UC_ManageReward _parent;
        Bitmap ImageReward;
        public string image_reward;
        public int voucher_id;
        FormSuccess Form1;
        FormError Form2;
        public FormAddReward(UC_ManageReward parent)
        {
            InitializeComponent();
            Form1 = new FormSuccess();
            Form2 = new FormError();
            _parent = parent;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            clear();
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
                ImageReward = new Bitmap(dialog.FileName);
                ptImage.Image = (Image)ImageReward;

                byte[] imageArray = System.IO.File.ReadAllBytes(dialog.FileName);
                string base64Text = Convert.ToBase64String(imageArray); //base64Text must be global but I'll use  richtext
                image_reward = base64Text;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtQuantity.Text = txtTitle.Text = txtContent.Text = txtPoint.Text = txtBrand.Text = "";
            ptImage.Image = new Bitmap(Application.StartupPath + "\\Resource\\no_img.jpg");
        }

        public void clear()
        {
            txtQuantity.Text = txtTitle.Text = txtContent.Text = txtPoint.Text = txtBrand.Text = "";
            ptImage.Image = new Bitmap(Application.StartupPath + "\\Resource\\no_img.jpg");
        }


        private string RandomString()
        {
            int size = 120;
            bool lowerCase = false;
            StringBuilder sb = new StringBuilder();
            char c;
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                c = Convert.ToChar(Convert.ToInt32(rand.Next(65, 87)));
                sb.Append(c);
            }
            if (lowerCase)
                return sb.ToString().ToLower();
            return sb.ToString();

        }

        private string stringCouponCode()
        {
            var s = RandomString();
            var list = Enumerable
                .Range(0, s.Length / 6)
                .Select(i => s.Substring(i * 6, 6))
                .ToList();
            var res = string.Join(",", list);
            return res;
        }

        private void btnSave_Click(object sender, EventArgs e)
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
            if (btnSave.Text == "Lưu")
            {
                string start_date = DateTime.Now.Date.ToString("yyyy-MM-dd");
                string expiry_date = "2021-12-30";
                string coupen_code = stringCouponCode();
                Voucher std1 = new Voucher(txtTitle.Text, txtContent.Text,"private", coupen_code, "", "", start_date, expiry_date,"percent",0,"", 1,0,1);
                DbVoucher.AddVoucher(std1);
                List<Voucher> voucherList = DbVoucher.SearchVoucherListWithReward(coupen_code);
                foreach (Voucher item in voucherList)
                {
                    voucher_id = item.id;
                }
                    Rewards std = new Rewards(voucher_id, txtTitle.Text, txtBrand.Text, txtContent.Text, image_reward, Convert.ToInt32(txtPoint.Text), Convert.ToInt32(txtQuantity.Text), 1);
                if (DbReward.CheckAddReward(std) == true)
                {
                    Form1.title = "Thêm Quà Tặng ( Thành Công )";
                    Form1.ShowDialog();
                    clear();
                    this.Close();
                    _parent.Display();
                }
                else
                {
                    Form2.title = "Thêm Quà Tặng ( Không Thành Công )";
                    Form2.ShowDialog();
                }
            }
        }
    }
}
