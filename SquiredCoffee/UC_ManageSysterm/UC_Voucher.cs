using SquiredCoffee.Class;
using SquiredCoffee.DB;
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

namespace SquiredCoffee.UC_ManageSysterm
{
    public partial class UC_Voucher : UserControl
    {
        Bitmap ImageVoucher;
        Bitmap ImageQrCode;
        public string image,image_QrCode;
        public int id, status = 1;

        public UC_Voucher()
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
                    ImageVoucher = new Bitmap(dialog.FileName);
                    ptImage.Image = (Image)ImageVoucher;

                    byte[] imageArray = System.IO.File.ReadAllBytes(dialog.FileName);
                    string base64Text = Convert.ToBase64String(imageArray); //base64Text must be global but I'll use  richtext
                    image = base64Text;
                }
        }

        private void label6_Click(object sender, EventArgs e)
        {

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

        private void rbStatus1_CheckedChanged(object sender, EventArgs e)
        {
            status = 1;
        }

        private void rbStatus2_CheckedChanged(object sender, EventArgs e)
        {
            status = 2;
        }

        public void clear()
        {
            txtContent.Text = txtCoupon.Text = txtDiscount.Text = txtPriceRule.Text = txtQuantityRule.Text = txtSearch.Text = txtVoucherName.Text = string.Empty;
            cbApplyFor.Text = "product";
            cbDiscountUnit.Text = "cash";
            rbStatus1.Checked = true;
            dtpStart_Date.Value = DateTime.Now;
            dtpExpiry_Date.Value = DateTime.Now;
            ptImage.Image = new Bitmap(Application.StartupPath + "\\Resource\\no_img.jpg");
            ptQr_Code.Image = new Bitmap(Application.StartupPath + "\\Resource\\qr_code.jpg");
        }



        public void Generate()
        {
            QRCoder.QRCodeGenerator QG = new QRCoder.QRCodeGenerator();
            var MyData = QG.CreateQrCode(txtCoupon.Text, QRCoder.QRCodeGenerator.ECCLevel.H);
            var code = new QRCoder.QRCode(MyData);
            ptQr_Code.Image = code.GetGraphic(50);
            image_QrCode = ConvertImageToBase64(ptQr_Code.Image);
        }

        private void UC_Voucher_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = (1 * 450); // 1 secs
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
            Display();
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

        private void dgvVoucher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dgvVoucher.SelectedRows[0].Cells[0].Value.ToString());
            txtVoucherName.Text = dgvVoucher.SelectedRows[0].Cells[1].Value.ToString();
            txtContent.Text = dgvVoucher.SelectedRows[0].Cells[2].Value.ToString();
            txtCoupon.Text = dgvVoucher.SelectedRows[0].Cells[3].Value.ToString();
            dtpStart_Date.Text = dgvVoucher.SelectedRows[0].Cells[6].Value.ToString();
            dtpExpiry_Date.Text = dgvVoucher.SelectedRows[0].Cells[7].Value.ToString();
            cbDiscountUnit.Text = dgvVoucher.SelectedRows[0].Cells[8].Value.ToString();
            txtDiscount.Text = dgvVoucher.SelectedRows[0].Cells[9].Value.ToString();
            cbApplyFor.Text = dgvVoucher.SelectedRows[0].Cells[10].Value.ToString();
            txtQuantityRule.Text = dgvVoucher.SelectedRows[0].Cells[11].Value.ToString();
            txtPriceRule.Text = dgvVoucher.SelectedRows[0].Cells[12].Value.ToString();
            image_QrCode = dgvVoucher.SelectedRows[0].Cells[5].Value.ToString();
            ptQr_Code.Image = ConvertBase64ToImage(image_QrCode);
            image = dgvVoucher.SelectedRows[0].Cells[4].Value.ToString();
            ptImage.Image = ConvertBase64ToImage(image);
            if (Convert.ToInt32(dgvVoucher.SelectedRows[0].Cells[13].Value.ToString()) == 1)
            {
                rbStatus1.Checked = true;
            }
            if (Convert.ToInt32(dgvVoucher.SelectedRows[0].Cells[13].Value.ToString()) == 0)
            {
                rbStatus2.Checked = true;
            }
            status = Convert.ToInt32(dgvVoucher.SelectedRows[0].Cells[13].Value.ToString());
        }

        private void btnEdit_Click(object sender, EventArgs e)
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
            if (txtCoupon.Text.Trim() == " ")
            {
                MessageBox.Show("Coupen code Đang Trống ");
                return;
            }
            if (txtQuantityRule.Text.Trim() == " ")
            {
                MessageBox.Show("Điều Kiện Của Voucher Đang Trống ");
                return;
            }

            if (cbApplyFor.Text.Trim() == "")
            {
                MessageBox.Show(" Áp Dụng Cho Không Được Để Trống");
                return;
            }

            if (cbDiscountUnit.Text.Trim() == "")
            {
                MessageBox.Show(" Phương Thức Áp Dụng Không Được Để Trống");
                return;
            }

            //if ((DbVoucher.CheckDb(txtCoupon.Text)) == true)
            //{
            //    MessageBox.Show("Tên Coupon Đã Tồn Tại ");
            //    return;
            //}

            if (btnEdit.Text == "Sửa")
            {
                if (txtQuantityRule.Text == "")
                {
                    Voucher std1 = new Voucher(txtVoucherName.Text.Trim(), txtContent.Text.Trim(), txtCoupon.Text.Trim(), image, image_QrCode,
                                          dtpStart_Date.Text.Trim(), dtpExpiry_Date.Text.Trim(), cbDiscountUnit.Text.Trim(), int.Parse(txtDiscount.Text), cbApplyFor.Text.Trim(), 1, int.Parse(txtPriceRule.Text), status);
                    DbVoucher.UpdateVoucher(std1,id.ToString());
                    clear();
                    Display();
                }
                else if (txtPriceRule.Text == "")
                {
                    Voucher std1 = new Voucher(txtVoucherName.Text.Trim(), txtContent.Text.Trim(), txtCoupon.Text.Trim(), image, image_QrCode,
                                          dtpStart_Date.Text.Trim(), dtpExpiry_Date.Text.Trim(), cbDiscountUnit.Text.Trim(), int.Parse(txtDiscount.Text), cbApplyFor.Text.Trim(), int.Parse(txtQuantityRule.Text), int.Parse(txtPriceRule.Text), status);
                    DbVoucher.UpdateVoucher(std1, id.ToString());
                    clear();
                    Display();
                }
                else if (txtPriceRule.Text == "" && txtQuantityRule.Text == "")
                {
                    Voucher std1 = new Voucher(txtVoucherName.Text.Trim(), txtContent.Text.Trim(), txtCoupon.Text.Trim(), image, image_QrCode,
                                          dtpStart_Date.Text.Trim(), dtpExpiry_Date.Text.Trim(), cbDiscountUnit.Text.Trim(), int.Parse(txtDiscount.Text), cbApplyFor.Text.Trim(), 1, 0, status);
                    DbVoucher.UpdateVoucher(std1, id.ToString());
                    clear();
                    Display();
                }
                else
                {
                    Voucher std1 = new Voucher(txtVoucherName.Text.Trim(), txtContent.Text.Trim(), txtCoupon.Text.Trim(), image, image_QrCode,
                                           dtpStart_Date.Text.Trim(), dtpExpiry_Date.Text.Trim(), cbDiscountUnit.Text.Trim(), int.Parse(txtDiscount.Text), cbApplyFor.Text.Trim(), int.Parse(txtQuantityRule.Text), int.Parse(txtPriceRule.Text), status);
                    DbVoucher.UpdateVoucher(std1, id.ToString());
                    clear();
                    Display();
                }
            }
         }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnInsert.Text == "Thêm")
            {
                DbVoucher.DeleteVoucher(id.ToString());
                clear();
                Display();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DbVoucher.DisplayAndSearch("SELECT id,title,content,coupen_code,image,qr_code,start_date,expiry_date,discount_unit,discount,apply_for,quantity_rule,price_rule,status FROM vouchers WHERE title LIKE'%" + txtSearch.Text + "%' OR discount_unit LIKE'%" + txtSearch.Text + "%' OR discount LIKE'%" + txtSearch.Text + "%'", dgvVoucher);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Generate();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
            if (txtCoupon.Text.Trim()== " ")
            {
                MessageBox.Show("Coupen code Đang Trống ");
                return;
            }
            if (txtQuantityRule.Text.Trim() == " ")
            {
                MessageBox.Show("Điều Kiện Của Voucher Đang Trống ");
                return;
            }

            if (cbApplyFor.Text.Trim() == "")
            {
                MessageBox.Show(" Áp Dụng Cho Không Được Để Trống");
                return;
            }

            if (cbDiscountUnit.Text.Trim() == "")
            {
                MessageBox.Show(" Phương Thức Áp Dụng Không Được Để Trống");
                return;
            }

            if ((DbVoucher.CheckDb(txtCoupon.Text)) == true)
            {
                MessageBox.Show("Tên Coupon Đã Tồn Tại ");
                return;
            }

            if (btnInsert.Text == "Thêm")
            {
                if(txtQuantityRule.Text == "")
                {
                    Voucher std1 = new Voucher(txtVoucherName.Text.Trim(), txtContent.Text.Trim(), txtCoupon.Text.Trim(), image, image_QrCode,
                                          dtpStart_Date.Text.Trim(), dtpExpiry_Date.Text.Trim(), cbDiscountUnit.Text.Trim(), int.Parse(txtDiscount.Text), cbApplyFor.Text.Trim(),1, int.Parse(txtPriceRule.Text), status);
                    DbVoucher.AddVoucher(std1);
                    clear();
                    Display();

                }
                else if (txtPriceRule.Text == "")
                {
                    Voucher std1 = new Voucher(txtVoucherName.Text.Trim(), txtContent.Text.Trim(), txtCoupon.Text.Trim(), image, image_QrCode,
                                          dtpStart_Date.Text.Trim(), dtpExpiry_Date.Text.Trim(), cbDiscountUnit.Text.Trim(), int.Parse(txtDiscount.Text), cbApplyFor.Text.Trim(), int.Parse(txtQuantityRule.Text), int.Parse(txtPriceRule.Text), status);
                    DbVoucher.AddVoucher(std1);
                    clear();
                    Display();

                }
                else if (txtPriceRule.Text == "" && txtQuantityRule.Text == "")
                {
                    Voucher std1 = new Voucher(txtVoucherName.Text.Trim(), txtContent.Text.Trim(), txtCoupon.Text.Trim(), image, image_QrCode,
                                          dtpStart_Date.Text.Trim(), dtpExpiry_Date.Text.Trim(), cbDiscountUnit.Text.Trim(), int.Parse(txtDiscount.Text), cbApplyFor.Text.Trim(),1,0, status);
                    DbVoucher.AddVoucher(std1);
                    clear();
                    Display();
                }
                else
                {
                    Voucher std = new Voucher(txtVoucherName.Text.Trim(), txtContent.Text.Trim(), txtCoupon.Text.Trim(), image, image_QrCode,
                                           dtpStart_Date.Text.Trim(), dtpExpiry_Date.Text.Trim(), cbDiscountUnit.Text.Trim(), int.Parse(txtDiscount.Text), cbApplyFor.Text.Trim(), int.Parse(txtQuantityRule.Text), int.Parse(txtPriceRule.Text), status);
                    DbVoucher.AddVoucher(std);
                    clear();
                    Display();
                }
            }
        }

        public void Display()
        {
            DbVoucher.DisplayAndSearch("SELECT id,title,content,coupen_code,image,qr_code,start_date,expiry_date,discount_unit,discount,apply_for,quantity_rule,price_rule,status FROM vouchers", dgvVoucher);
        }

    }
}
