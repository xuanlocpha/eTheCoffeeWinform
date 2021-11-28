using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using SquiredCoffee.Class;
using SquiredCoffee.DB;
using SquiredCoffee.UC_ManageSysterm;
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

namespace SquiredCoffee.FormManage
{
    public partial class FormAddNotification : Form
    {

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "a9dcTERVqKjXumq650cZgtQelwv2uqFTmAejZjjj",
            BasePath = "https://koffeeholic-75e48-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;

        FormSuccess Form1;
        FormError Form2;
        public int id_staff;
        UC_ManageNotification _parent;
        public FormAddNotification(UC_ManageNotification parent)
        {
            InitializeComponent();
            _parent = parent;
            Form1 = new FormSuccess();
            Form2 = new FormError();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text.Trim() == "")
            {
                Form2.title = "Tiêu đề thông báo đang (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtTitle.Text.Trim().Length < 1)
            {
                Form2.title = "Tiêu đề (> 1 Ký Tự) ";
                Form2.ShowDialog();
                return;
            }
            if (txtContent.Text.Trim() == "")
            {
                Form2.title = "Nội dung đang (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtTitle.Text.Trim().Length < 1)
            {
                Form2.title = "Nội dung (> 1 Ký Tự)";
                Form2.ShowDialog();
                return;
            }
            if (btnSave.Text == "Lưu")
            {
                string date = DateTime.Now.ToString("yyyy-MM-dd");
                int x = id_staff;
                NotificationSystem std = new NotificationSystem(x,txtTitle.Text,txtContent.Text,date,1);
                if (DbNotification.CheckNotification(std) == true)
                {
                    notification(txtTitle.Text, txtContent.Text);
                    Form1.title = "Tạo Thành Công";
                    Form1.ShowDialog();
                    this.Close();
                    _parent.Display();
                }
            }
        }


        public async void notification(string Title,string Body)
        {
            var data = new Notification
            {
                title = Title,
                body = Body,
                sound = "default"
            };
            var data1 = new Data
            {
                click_action = "Nhấn để xem các khuyến mãi từ chúng tôi ^-^)!!!",
                type = "Thông báo"
            };

            var priority = "high";

            var to = "/topics/all";

            SetResponse response = await client.SetAsync("notification",data);
            SetResponse response1 = await client.SetAsync("data",data1);
            SetResponse response2 = await client.SetAsync("priority", priority);
            SetResponse response3 = await client.SetAsync("to", to);
        }

        private void FormAddNotification_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
        }
    }
}
