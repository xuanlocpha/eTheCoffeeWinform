using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SquiredCoffee.UC_ManageSysterm
{
    public partial class UC_Voucher : UserControl
    {
        Bitmap ImageVoucher;
        Bitmap ImageQrCode;
        public string image,image_QrCode;
        public int id, status;

        public UC_Voucher()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
                    ImageVoucher = new Bitmap(dialog.FileName);
                    ptImage.Image = (Image)ImageVoucher;

                    byte[] imageArray = System.IO.File.ReadAllBytes(dialog.FileName);
                    string base64Text = Convert.ToBase64String(imageArray); //base64Text must be global but I'll use  richtext
                    image = base64Text;
                }
        }


      


        private void btnGenerate_Click(object sender, EventArgs e)
        {
            QRCoder.QRCodeGenerator QG = new QRCoder.QRCodeGenerator();
            var MyData = QG.CreateQrCode(txtCoupon.Text, QRCoder.QRCodeGenerator.ECCLevel.H);
            var code = new QRCoder.QRCode(MyData);
            ptQr_Code.Image = code.GetGraphic(50);

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG" +
                 "|All files(*.*)|*.*";
            dialog.CheckFileExists = true;
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ImageVoucher = new Bitmap(dialog.FileName);
                ptImage.Image = (Image)ImageVoucher;

                byte[] imageArray = System.IO.File.ReadAllBytes(dialog.FileName);
                string base64Text = Convert.ToBase64String(imageArray); //base64Text must be global but I'll use  richtext
                image_QrCode = base64Text;
            }

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtVoucherName.Text.Trim().Length < 3)
            {
                MessageBox.Show("Tên Voucher ( > 3) ký tự");
                return;
            }
            if (txtContent.Text.Trim().Length < 3)
            {
                MessageBox.Show("Nội Dung Của Voucher ( > 3) ký tự ");
                return;
            }
            if (txtCoupon.Text.Trim().Length == null)
            {
                MessageBox.Show("Coupen code Đang Trống ");
                return;
            }
            if (txtMinimum_Order.Text.Trim().Length == null)
            {
                MessageBox.Show("Điều Kiện Của Voucher Đang Trống ");
                return;
            }

            if (txtDisscount_Unit.Text.Trim().Length == null)
            {
                MessageBox.Show(" Đơn Vị Giảm Đang Trống ");
                return;
            }
            if (txtDisscount.Text.Trim().Length == null)
            {
                MessageBox.Show("Giá Trị Giảm Đang Trống ");
                return;
            }

        }
    }
}
