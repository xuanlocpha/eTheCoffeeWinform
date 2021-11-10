using SquiredCoffee.Class;
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
    public partial class FormCheckVoucherReward : Form
    {

        public int id_reward;
        public int id_user;
        public int point_user;
        public int point_reward;
        public int quantity;
        public int id_voucher;
        public string qr_code;
        public string coupon_code;
        FormQRReward _parent;
        FormSuccess Form1;
        FormError Form2;
        public FormCheckVoucherReward(FormQRReward parent)
        {
            InitializeComponent();
            _parent = parent;
            Form1 = new FormSuccess();
            Form2 = new FormError();
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
            _parent.LoadReward();
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
            List<RewardShow> rewardShowList = DbReward.LoadReward(id_reward.ToString());
            foreach (RewardShow item in rewardShowList)
            {
                lblNameReward.Text = item.title;
                lblBrandName.Text = item.brand_name;
                lblPoint.Text = string.Format("{0:#,##0} Point", item.point);
                point_reward = item.point;
                quantity = item.quantity;
                txtContent.Text = item.content;
                ptImage.Image = ConvertBase64ToImage(item.image);
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (point_user >= point_reward)
            {
                int y = quantity - 1;
                int x = point_user - point_reward;
                if (DbReward.CheckPointUser(x.ToString(), id_user.ToString()) == true)
                {
                    DbReward.UpdateQuantityRewards(y.ToString(), id_reward.ToString());
                    Form1.title = "Đổi quà thành công !";
                    Form1.ShowDialog();
                    List<Voucher> voucherList = DbVoucher.LoadVoucherList();
                    foreach (Voucher item in voucherList)
                    {
                        if (item.coupon_code.Contains(qr_code) == true)
                        {
                            id_voucher = item.id;
                            if(item.coupon_code.Length == 6)
                            {
                                coupon_code = item.coupon_code.Remove(0,6);
                            }
                            else
                            {
                                coupon_code = item.coupon_code.Remove(0,7);
                            }
                            DbVoucher.UpdateVoucherReward(coupon_code, id_voucher.ToString());
                        }
                    }
                    this.Close();
                    _parent.LoadReward();
                }
                else
                {
                    Form2.title = "Đổi quà không thành công !";
                    Form2.ShowDialog();
                    this.Close();
                    this.Close();
                    _parent.LoadReward();
                }
            }
        }

        private void FormCheckVoucherReward_Load(object sender, EventArgs e)
        {
            Display();
        }
    }
}
