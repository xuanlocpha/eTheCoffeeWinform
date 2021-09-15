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
    public partial class FormListTableChange : Form
    {

        public int tagTable_id;
        public string tagTable_title;
        public int orderTable_id;
        private readonly FormStaff _parent;
        public PictureBox pic = new PictureBox();
        public Label title = new Label();
        public Label status = new Label();
        public FormListTableChange(FormStaff parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        //public void LoadOrderId(string id_table)
        //{
        //    List<Order> tableList = DbOrder.LoadOrderId(id_table);

        //    foreach (Order item in tableList)
        //    {
        //        orderTable_id = item.id;
        //    }
        //}

        public void LoadTable()
        {
            List<Table> tableList = DbTable.LoadTableListDrum();

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

        public void Onclick(object sender, EventArgs e)
        {
            int tag = ((sender as PictureBox).Tag as Table).id;
            string tag2 = ((sender as PictureBox).Tag as Table).title;
            tagTable_id = tag;
            tagTable_title = tag2;
            //LoadOrderId(tagTable_id.ToString());
            this.Close();
        }


        private void pbClose_Click(object sender, EventArgs e)
        {
            flpTable.Controls.Clear();
            this.Close();
        }

        private void FormListTableChange_Load(object sender, EventArgs e)
        {
            flpTable.Controls.Clear();
            LoadTable();
        }
    }
}
