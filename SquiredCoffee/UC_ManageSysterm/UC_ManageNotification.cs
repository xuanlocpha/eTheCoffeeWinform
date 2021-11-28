using SquiredCoffee.Class;
using SquiredCoffee.DB;
using SquiredCoffee.FormManage;
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
    public partial class UC_ManageNotification : UserControl
    {
        public int totalNotification;
        public int totalSearchNotification;
        public int id_staff;
        FormAddNotification Form;

        public UC_ManageNotification()
        {
            InitializeComponent();
            Form = new FormAddNotification(this);
        }

        public void clear()
        {
            totalNotification = 0;
            totalSearchNotification = 0;
        }

        public void clear1()
        {
            totalSearchNotification = 0;
        }

        public void Display()
        {
            clear();
            dgvNotification.Rows.Clear();
            List<NotificationSystem> notificationSystemList = DbNotification.LoadNotificationList();
            foreach (NotificationSystem item in notificationSystemList)
            {
                totalNotification += 1;
                dgvNotification.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.name_staff,
                    item.title,
                    String.Format("{0:dd/MM/yyyy}",item.create_date),
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalNotification.Text = totalNotification.ToString();
            lblTotalNotificationSearch.Text = totalNotification.ToString();
        }

        private void UC_ManageNotification_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            Display();
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            clear1();
            dgvNotification.Rows.Clear();
            int x = 1;
            List<NotificationSystem> notificationSystemList = DbNotification.LoadNotificationListActive(x.ToString());
            foreach (NotificationSystem item in notificationSystemList)
            {
                totalSearchNotification += 1;
                dgvNotification.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.name_staff,
                    item.title,
                    String.Format("{0:dd/MM/yyyy}",item.create_date),
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalNotification.Text = totalNotification.ToString();
            lblTotalNotificationSearch.Text = totalSearchNotification.ToString();
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            clear1();
            dgvNotification.Rows.Clear();
            int x = 0;
            List<NotificationSystem> notificationSystemList = DbNotification.LoadNotificationListActive(x.ToString());
            foreach (NotificationSystem item in notificationSystemList)
            {
                totalSearchNotification += 1;
                dgvNotification.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.name_staff,
                    item.title,
                    String.Format("{0:dd/MM/yyyy}",item.create_date),
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalNotification.Text = totalNotification.ToString();
            lblTotalNotificationSearch.Text = totalSearchNotification.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form.id_staff = id_staff;
            Form.ShowDialog();
        }
    }
}
