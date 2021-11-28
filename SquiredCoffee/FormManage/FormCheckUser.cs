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
    public partial class FormCheckUser : Form
    {
        public int point;
        public decimal total;
        private readonly FormPaymentSale _parent;
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;
        FormSuccess Form1;
        FormError Form2;

        public FormCheckUser(FormPaymentSale parent)
        {
            InitializeComponent();
            _parent = parent;
            Form1 = new FormSuccess();
            Form2 = new FormError();
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            videoCaptureDevice.Start();
            this.Close();
            _parent.Show();
        }

        private void FormCheckUser_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in filterInfoCollection)
            {
                cbCamera.Items.Add(device.Name);
                cbCamera.SelectedIndex = 0;
            }
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

        private void btnStart_Click(object sender, EventArgs e)
        {
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cbCamera.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (DbUser.CheckDb(txtDisplay.Text) == true)
            {
                List<User> userList = DbUser.UserSearch(txtDisplay.Text);
                foreach (User item in userList)
                {
                    decimal kq = Math.Round(total / 1000);
                    decimal kq1 = kq + item.point;
                    if(DbUser.accumulatePoints(kq1.ToString(),item.id.ToString())== true)
                    {
                        Form1.title = "Tích Điểm Thành Công";
                        Form1.ShowDialog();
                        txtDisplay.Text = string.Empty;
                        this.Close();
                        _parent.Show();
                    }
                }    
            }
            else
            {
                Form2.title = "Khách hàng không tồn tại ! ";
                Form2.ShowDialog();
                txtDisplay.Text = string.Empty;
            }
        }


        //private void btnCheck_Click(object sender, EventArgs e)
        //{
        //    if (DbUser.CheckDb(txtDisplay.Text) == true)
        //    {
        //        List<User> userList = DbUser.UserSearch(txtDisplay.Text);
        //        foreach (User item in userList)
        //        {
        //            first_name = item.first_name;
        //            last_name = item.last_name;
        //            point = item.point;
        //        }
        //        this.Close();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Tài khoản Không Tồn Tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
    }
}
