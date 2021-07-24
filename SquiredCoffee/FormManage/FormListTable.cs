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

namespace SquiredCoffee.FormManage
{
    public partial class FormListTable : Form
    {
        public int tag_id;
        public string tag_title;
        public int status_form;
        public int order_id;
        private readonly FormStaff _parent;
        public PictureBox pic = new PictureBox();
        public Label title = new Label();
        public Label status = new Label();
        public FormListTable(FormStaff parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadOrderId(string id_table)
        {
            List<Order> tableList = DbOrder.LoadOrderId(id_table);

            foreach (Order item in tableList)
            {
                order_id = item.id;
            }
        }

        public void LoadTable()
        {
            List<Table> tableList = DbTable.LoadTableList();

            foreach (Table item in tableList)
            {
                pic = new PictureBox();
                pic.Width = 146;
                pic.Height = 146;
                pic.BackColor = Color.White;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.BackgroundImage = new Bitmap(Application.StartupPath + "\\Resource\\chair.png");
                pic.Tag = item;

                title = new Label();
                title.Text = (item.title).ToString();
                title.BackColor = Color.FromArgb(46, 134, 222);
                title.TextAlign = ContentAlignment.MiddleCenter;
                title.ForeColor = Color.White;
                title.Dock = DockStyle.Bottom;
               

                status = new Label();
                status.TextAlign = ContentAlignment.MiddleCenter;
                status.ForeColor = Color.White;
                status.Dock = DockStyle.Bottom;
               

                switch (item.status)
                {
                    case 0:
                        status.BackColor = Color.FromArgb(166, 88, 10);
                        status.Text = "( Đã có khách )";
                        break;
                    default:
                        status.BackColor = Color.FromArgb(255, 121, 121);
                        status.Text = "( Trống )";
                        break;
                }
                pic.Controls.Add(status);
                pic.Controls.Add(title);
                flpTable.Controls.Add(pic);

                pic.Click += new EventHandler(Onclick);
                
            }
        }

        public void Onclick(object sender,EventArgs e)
        {
            int tag = ((sender as PictureBox).Tag as Table).id;
            string tag2 = ((sender as PictureBox).Tag as Table).title;
            tag_id = tag;
            tag_title = tag2;
            Table std = new Table(tag_title, 0);
            if (DbTable.CheckStatusDb(tag_id.ToString()) != true)
            {
                DbTable.UpdateStatusTable(std, tag_id.ToString());
                Order data = new Order(1, tag_id, 0, 0, 0, 0, null, null, null, null, 0);
                DbOrder.AddOrder(data);
            }
           
            LoadOrderId(tag_id.ToString());
            status_form = 1;
            this.Close();
        }


        private void FormListTable_Load(object sender, EventArgs e)
        {
            flpTable.Controls.Clear();
            LoadTable();
        }

        private void pbClose_Click_1(object sender, EventArgs e)
        {
            flpTable.Controls.Clear();
            this.Close();
        }
    }
}
