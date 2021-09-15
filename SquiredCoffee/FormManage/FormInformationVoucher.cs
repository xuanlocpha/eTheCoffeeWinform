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
    public partial class FormInformationVoucher : Form
    {
        Bitmap ImageVoucher;
        public static UC_ManageVoucher _parent;
        public int status = 1;
        public int id_voucher;
        public string image, image_QrCode;
        public FormInformationVoucher(UC_ManageVoucher parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void Display()
        {
            List<Voucher> voucherList = DbVoucher.LoadVoucherList(id_voucher.ToString());
            foreach (Voucher item in voucherList)
            {
                txtTitle.Text = item.title;
                txtContent.Text = item.content;
                txtCoupenCode.Text = item.coupen_code;
                dtpStartDate.Text = String.Format("{0:dd/MM/yyyy}", item.start_date);
                dtpExpiryDate.Text = String.Format("{0:dd/MM/yyyy}", item.expiry_date);
                cbDiscountUnit.Text = item.discount_unit;
                txtDiscount.Text = item.discount.ToString();
                cbApply.Text = item.apply_for;
                txtQuantityRule.Text = item.quantity_rule.ToString();
                txtPriceRule.Text = item.price_rule.ToString();
                if (item.status == 1)
                {
                    rdStatus1.Checked = true;
                }
                else if (item.status == 0)
                {
                    rdStatus2.Checked = true;
                }
                status = item.status;
                image = item.image;
                image_QrCode = item.qr_code;
                ptImage.Image = ConvertBase64ToImage(image);
            }
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

        public Image ConvertBase64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                ms.Write(imageBytes, 0, imageBytes.Length);
                return Image.FromStream(ms, true);
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            Generate();
        }

        private void FormInformationVoucher_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = (1 * 450); // 1 secs
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
            Display();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa voucher  này không . Vì nó có thể ảnh hưởng tới dữ liệu của bạn !", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (btnDelete.Text == "Xóa")
                {
                    DbVoucher.DeleteVoucher(id_voucher.ToString());
                    this.Close();
                    _parent.clear();
                    _parent.Display();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
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
            if (cbDiscountUnit.Text == "")
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
            if (cbApply.Text == "")
            {
                MessageBox.Show(" Áp dụng không được để ( Trống )");
                return;
            }
            if (txtQuantityRule.Text.Trim() == "")
            {
                MessageBox.Show("Số lượng giới hạn không được để ( Trống )");
                return;
            }
            if (MessageBox.Show("Bạn có muốn chỉnh sửa voucher  này không !", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (btnEdit.Text == "Sửa")
                {
                    string start_date = dtpStartDate.Value.Date.ToString("yyyy-MM-dd");
                    string expiry_date = dtpExpiryDate.Value.Date.ToString("yyyy-MM-dd");
                    Voucher std = new Voucher(txtTitle.Text, txtContent.Text, txtCoupenCode.Text, image, image_QrCode,start_date,expiry_date, cbDiscountUnit.Text, Convert.ToInt32(txtDiscount.Text), cbApply.Text, Convert.ToInt32(txtQuantityRule.Text), Convert.ToInt32(txtPriceRule.Text), status);
                    DbVoucher.UpdateVoucher(std, id_voucher.ToString());
                    this.Close();
                    _parent.clear();
                    _parent.Display();
                }
            }
        }
    }
}
