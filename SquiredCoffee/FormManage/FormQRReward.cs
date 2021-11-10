using AForge.Video;
using AForge.Video.DirectShow;
using SquiredCoffee.Class;
using SquiredCoffee.DB;
using SquiredCoffee.ViewModels;
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
    public partial class FormQRReward : Form
    {
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;
        public int id_voucher;
        FormError Form1;
        FormCheckVoucherReward Form2;
        public int id_user;
        public int id_reward;
        public int point_user;
        FormReward _parent;
        public FormQRReward(FormReward parent)
        {
            InitializeComponent();
            _parent = parent;
            Form1 = new FormError();
            Form2 = new FormCheckVoucherReward(this);
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
            if (result != null)
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
            if (videoCaptureDevice != null)
            {
                if (videoCaptureDevice.IsRunning)
                {
                    videoCaptureDevice.Stop();
                }
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            List<Voucher> voucherList = DbVoucher.LoadVoucherList();
            foreach (Voucher item in voucherList)
            {
                if (item.coupon_code.Contains(txtDisplay.Text) == true)
                {
                    id_voucher = item.id;
                }
            }

            if (DbVoucher.CheckVoucherReward(id_voucher.ToString(), DateTime.Now.ToString("yyyy-MM-dd")) == true)
            {
                List<RewardShow> rewardShowList = DbReward.LoadRewardVoucher(id_voucher.ToString());
                foreach (RewardShow item in rewardShowList)
                {
                    Form2.id_user = id_user;
                    Form2.id_reward = item.id;
                    Form2.point_user = point_user;
                    Form2.qr_code = txtDisplay.Text;
                    this.Hide();
                    Form2.ShowDialog();
                }
            }
            else
            {
                Form1.title = "Voucher này đã hết hạn sử dụng ";
                Form1.ShowDialog();
                return;
            }
        }

        public void LoadReward()
        {
            _parent.LoadInformationUser();
            _parent.Show();
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = string.Empty;
            this.Close();
            _parent.Show();
        }

        private void FormQRReward_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoCaptureDevice != null)
            {
                if (videoCaptureDevice.IsRunning)
                {
                    videoCaptureDevice.Stop();
                }
            }
        }

        private void FormQRReward_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in filterInfoCollection)
            {
                cbCamera.Items.Add(device.Name);
                cbCamera.SelectedIndex = 0;
            }
        }
    }
}
