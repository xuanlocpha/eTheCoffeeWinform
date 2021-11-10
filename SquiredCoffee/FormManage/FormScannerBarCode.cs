using AForge.Video;
using AForge.Video.DirectShow;
using SquiredCoffee.Class;
using SquiredCoffee.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace SquiredCoffee.FormManage
{
    public partial class FormScannerBarCode : Form
    {
        public int discount;
        public int quantity;
        public decimal total;
        private readonly FormPaymentSale _parent;
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;
        FormError Form2;
       
        public FormScannerBarCode(FormPaymentSale parent)
        {
            InitializeComponent();
            _parent = parent;
            Form2 = new FormError();
        }

        private void FormScannerBarCode_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach(FilterInfo device in filterInfoCollection)
            {
                cbCamera.Items.Add(device.Name);
                cbCamera.SelectedIndex = 0;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cbCamera.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            BarcodeReader reader = new BarcodeReader();
            var result = reader.Decode(bitmap);
            if(result != null)
            {
                txtDisplay.Invoke(new MethodInvoker(delegate ()
                {
                    txtDisplay.Text = result.ToString();
                }));
            }
            ptCamera.Image = bitmap;
        }

        private void FormScannerBarCode_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(videoCaptureDevice != null)
            {
                if (videoCaptureDevice.IsRunning)
                {
                    videoCaptureDevice.Stop();
                }
            }
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
            videoCaptureDevice.Stop();
            _parent.Show();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (DbVoucher.CheckDb(txtDisplay.Text) == true)
            {

            }
            else
            {
                if(DbVoucher.CheckVoucher(txtDisplay.Text, DateTime.Now.ToString("yyyy-MM-dd"))== true)
                {
                    List<Voucher> voucherList = DbVoucher.LoadVoucherSearch(txtDisplay.Text, DateTime.Now.ToString("yyyy-MM-dd"));
                    foreach (Voucher item in voucherList)
                    {
                        if(quantity >= item.quantity_rule)
                        {
                            if (total >= item.price_rule)
                            {
                                discount = item.discount;
                            }
                            else
                            {
                                Form2.title = "Tổng Tiền Hóa Đơn Không Đủ Hạn Mức!";
                                Form2.ShowDialog();
                                return;
                            }
                        }
                        else
                        {
                            Form2.title = "Số Lượng Sản Phẩm Không Đủ Hạn Mức!";
                            Form2.ShowDialog();
                            return;
                        }
                      
                    }
                }
                else
                {
                    Form2.title = "Voucher đã hết hạn sử dụng !";
                    Form2.ShowDialog();
                    return;
                }
                
            }
            _parent.Voucher(discount);
            this.Close();
            _parent.Show();
        }
    }
}
