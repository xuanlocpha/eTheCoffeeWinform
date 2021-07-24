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

        private readonly FormStaff _parent;
        public FormScannerBarCode(FormStaff parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;

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
        }

        private void button1_Click(object sender, EventArgs e)
        {

            List<User> userList = DbUser.UserList(txtDisplay.Text);

            foreach (User item in userList)
            {
                int point = item.point + 10;
                User std = new User( item.last_name, item.first_name, item.gender, item.email, item.phone,point);
                DbUser.UpdateUser(std,item.id.ToString());
            }
                this.Close();
        }
    }
}
