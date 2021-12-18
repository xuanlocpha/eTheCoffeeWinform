using SquiredCoffee.Class;
using SquiredCoffee.DB;
using SquiredCoffee.UC_ManageSysterm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SquiredCoffee.FormManage
{
    public partial class FormAddVoucher : Form
    {
        public static UC_ManageVoucher _parent;
        Bitmap ImageVoucher;
        public string image, image_QrCode;
        public int status = 1;
        public FormAddVoucher(UC_ManageVoucher parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormAddVoucher_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = (1 * 450); // 1 secs
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
        }
        public string ConvertImageToBase64(Image file)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                file.Save(memoryStream, ImageFormat.Png);
                byte[] imageBytes = memoryStream.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }

        public void Generate()
        {
            QRCoder.QRCodeGenerator QG = new QRCoder.QRCodeGenerator();
            var MyData = QG.CreateQrCode(txtCoupenCode.Text, QRCoder.QRCodeGenerator.ECCLevel.H);
            var code = new QRCoder.QRCode(MyData);
            ptQr_Code.Image = code.GetGraphic(50);
            image_QrCode = ConvertImageToBase64(ptQr_Code.Image);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Generate();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdStatus1_CheckedChanged(object sender, EventArgs e)
        {
            status = 1;
        }

        private void rdStatus2_CheckedChanged(object sender, EventArgs e)
        {
            status = 0;
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
            if (txtTitle.Text.Trim() == "")
            {
                MessageBox.Show("Tên voucher không được để ( Trống )");
                return;
            }
            if (txtTitle.Text.Trim().Length < 1)
            {
                MessageBox.Show("Tên voucher  phải lớn hơn  ( 1 ký tự )");
                return;
            }
            if (txtContent.Text.Trim() == "")
            {
                MessageBox.Show("Nội dung không được để ( Trống )");
                return;
            }
            if (txtContent.Text.Trim().Length < 1)
            {
                MessageBox.Show("Nội dung  phải lớn hơn  ( 1 ký tự )");
                return;
            }
            if (txtCoupenCode.Text.Trim() == "")
            {
                MessageBox.Show("Coupen Code không được để ( Trống )");
                return;
            }
            if (txtCoupenCode.Text.Trim().Length < 1)
            {
                MessageBox.Show("Coupen Code  phải lớn hơn  ( 1 ký tự )");
                return;
            }
            if (dtpStartDate.Value <= DateTime.Now)
            {
                MessageBox.Show("Ngày bắt đầu không được trùng với ngày hiện tại ");
                return;
            }
            if(cbDiscountUnit.Text == "")
            {
                MessageBox.Show(" Phương thức không được để ( Trống )");
                return;
            }
            if (txtDiscount.Text.Trim() == "")
            {
                MessageBox.Show("Chiết Khấu không được để ( Trống )");
                return;
            }
            if (txtDiscount.Text.Trim().Length < 1)
            {
                MessageBox.Show("Chiết khấu phải lớn hơn  ( 1 ký tự )");
                return;
            }
            if(cbApply.Text == "")
            {
                MessageBox.Show(" Áp dụng không được để ( Trống )");
                return;
            }
            if (txtQuantityRule.Text.Trim() == "")
            {
                MessageBox.Show("Số lượng giới hạn không được để ( Trống )");
                return;
            }
            if (DbVoucher.CheckAdd(txtDiscount.Text, txtCoupenCode.Text) == true)
            {
                MessageBox.Show("Voucher này đã tồn tại ( Trống )");
                return;
            }
            if (btnSave.Text == "Lưu")
            {
                string start_date = dtpStartDate.Value.Date.ToString("yyyy-MM-dd");
                string expiry_date = dtpExpiryDate.Value.Date.ToString("yyyy-MM-dd");
                string coupen_code = stringCouponCode();
                Voucher std = new Voucher(txtTitle.Text,txtContent.Text,"public",coupen_code,image,image_QrCode,start_date,expiry_date,cbDiscountUnit.Text,Convert.ToInt32(txtDiscount.Text),cbApply.Text,Convert.ToInt32(txtQuantityRule.Text),Convert.ToInt32(txtPriceRule.Text),status) ;
                DbVoucher.AddVoucher(std);
                this.Close();
                _parent.Display();
            }

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
    }
}
