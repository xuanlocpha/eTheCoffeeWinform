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

namespace SquiredCoffee.UC_ManageSysterm
{
    public partial class UC_TableList : UserControl
    {
        public int order_id;
        private readonly FormStaff _parent;
        public UC_TableList(FormStaff parent)
        {
            InitializeComponent();
            _parent = parent;
        }

     

        private PictureBox pic = new PictureBox();
        private RadioButton rad = new RadioButton();
        public Label price;
        public Label title;
        //private int stateCounter = 0;
        //private Color[] states = new Color[] { Color.Black, Color.Red };


        public void LoadOrderList()
        {
            List<Order> orderList = DbOrder.LoadOrder();

            foreach (Order item in orderList)
            {

                rad = new RadioButton();
                rad.Width = 170;
                rad.Height = 170;
                rad.Text = "Bàn Số : "+item.table_number+"";
                rad.Appearance = Appearance.Button;
                rad.ForeColor = Color.White;
                rad.BackColor = Color.FromArgb(41, 121, 255);
                rad.TextAlign = ContentAlignment.MiddleCenter;
                rad.Checked = true;
                rad.Tag = item;
                flpOrder.Controls.Add(rad);
                rad.Click += new EventHandler(Onclick);
               
            }
        }



        public void Onclick(object sender, EventArgs e)
        {
            //stateCounter = stateCounter == 1 ? 1 : 0;
            //rad.BackColor = states[stateCounter];
            int tag = ((sender as RadioButton).Tag as Order).id;
            string tag1 = ((sender as RadioButton).Tag as Order).table_number;
            //MessageBox.Show("Bạn Chưa Chọn ( BÀN ) !!!", tag);
            order_id = tag;
            UC_ProductList uC_ProductList = new UC_ProductList(_parent);
            _parent.id_order = order_id;
            _parent.table_name = tag1;
            _parent.clear();
            _parent.Display();
            _parent.AddControlsToPanel(uC_ProductList);
            //return;
        }
 

        private void UC_TableList_Load(object sender, EventArgs e)
        {
            LoadOrderList();
        }
    }
}
