using Nancy.Json;
using SquiredCoffee.Class;
using SquiredCoffee.DB;
using SquiredCoffee.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SquiredCoffee.FormManage
{
    public partial class FormInvoice : Form
    {
        public static FormPaymentSale _parent;
        public string tableName;
        public int id_order;
        public string name_staff;
        public string name_user;
        public string total;
        public string total_voucher;
        public string payment;
        public string take;
        public string excess_cash;
        public int size_id;
        public FormInvoice(FormPaymentSale parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void LoadView()
        {
            lblDateTime.Text = DateTime.Now.ToString("HH:mm:ss / dd.MM.yyyy");
            lblNumberTable.Text = tableName;
            lblNumberOrder.Text = "HD" + id_order.ToString();
            lblNameStaff.Text = name_staff;
            lblNameUser.Text = name_user;
            lblTotal.Text = total;
            lblTotalVoucher.Text = total_voucher;
            lblPayment.Text = payment;
            lblTake.Text = take;
            lblExcessCash.Text = excess_cash;
            lblCash.Text = payment;
            Display();
        }

        private void FormInvoice_Load(object sender, EventArgs e)
        {
            LoadView();
        }

        public void LoadJson(string file)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            ItemDetail[] itemDetails = js.Deserialize<ItemDetail[]>(file);
            foreach (ItemDetail item in itemDetails)
            {
               
            }
        }

        public void Display()
        {
            List<Order_Items> order_Items_List = DbOrderItem.order_Items_List(id_order.ToString());
            foreach (Order_Items item in order_Items_List)
            {
                dgvInvoice.Rows.Add(new object[]
                    {
                            item.title,
                            item.quantity,
                            //item1.title,
                            string.Format("{0:#,##0} đ",item.price),
                           
                    });
                //LoadJson(item.item_detail);
                //List<OptionShow> option_Show_List = DbOption.OptionShow(size_id.ToString());
                //foreach (OptionShow item1 in option_Show_List)
                //{
                //    dgvInvoice.Rows.Add(new object[]
                //    {
                //            item.title,
                //            item.quantity,
                //            item1.title,
                //            string.Format("{0:#,##0} đ",item.price),
                //           // string.Format("{0:#,##0} đ",item.total_product)
                //    });
                //}
            }
        }

        private void ptClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Print(Panel pnl)
        {
            PrinterSettings p = new PrinterSettings();
            panelPrinter = pnl;
            getPrinter(pnl);
            printPreviewDialog1.Document = printDocument1;
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printPreviewDialog1.ShowDialog();
        }

        private Bitmap memoryimg;

        private void getPrinter(Panel pnl)
        {
            memoryimg = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(memoryimg, new Rectangle(0, 0, pnl.Width, pnl.Height));

        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(memoryimg, (pagearea.Width / 2) - (this.panelPrinter.Width / 2), this.panelPrinter.Location.Y);

        }

        private void ptPrint_Click(object sender, EventArgs e)
        {
            Print(this.panelPrinter);
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
