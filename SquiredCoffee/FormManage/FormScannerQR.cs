using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

namespace SquiredCoffee.FormManage
{
    public partial class FormScannerQR : Form
    {
        public FormScannerQR()
        {
            InitializeComponent();
        }

        FilterInfoCollection fitleInfoCollection;
        VideoCaptureDevice captureDevice;

        private void FormScannerQR_Load(object sender, EventArgs e)
        {
            fitleInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in fitleInfoCollection)
                cbCamera.Items.Add(filterInfo.Name);
            cbCamera.SelectedIndex = 0;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            captureDevice = new VideoCaptureDevice(fitleInfoCollection[cbCamera.SelectedIndex].MonikerString);
            captureDevice.NewFrame += CaptureDevice_NewFrame;
            captureDevice.Start();
            timer1.Start();
        }

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            ptCamera.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void FormScannerQR_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (captureDevice.IsRunning)
                captureDevice.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(ptCamera.Image != null)
            {
                BarcodeReader barcodeReader = new BarcodeReader();
                Result result = barcodeReader.Decode((Bitmap)ptCamera.Image);
                if(result != null)
                {
                    txtDisplay.Text = result.ToString();
                    timer1.Stop();
                    if (captureDevice.IsRunning)
                        captureDevice.Stop();
                }
            }
        }

        private void ptCamera_Click(object sender, EventArgs e)
        {

        }

        private void txtDisplay_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbCamera_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
