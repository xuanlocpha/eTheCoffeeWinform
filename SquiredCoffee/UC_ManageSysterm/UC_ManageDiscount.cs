using SquiredCoffee.Class;
using SquiredCoffee.CustomControls;
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
    public partial class UC_ManageDiscount : UserControl
    {
        FormInformationDiscount Form;
        FormAddDiscount Form1;
        List<int> str1 = new List<int>();
        public UC_ManageDiscount()
        {
            InitializeComponent();
            Form = new FormInformationDiscount();
            Form1 = new FormAddDiscount();
        }


        public void Display()
        {
            dgvDiscount.Rows.Clear();
            List<Discount> discounts = DbDiscount.LoadDiscountList();
            foreach (Discount item in discounts)
            {
                DateTime dt = Convert.ToDateTime(item.start_date);
                string start_date = dt.ToString("dd-MM-yyyy");
                DateTime dt1 = Convert.ToDateTime(item.expiry_date);
                string expiry_date = dt.ToString("dd-MM-yyyy");
                dgvDiscount.Rows.Add(new object[]
                {
                    imageList1.Images[0],
                    item.id,
                    item.discount,
                    start_date,
                    expiry_date
                });
            }
        }
        
        private void UC_ManageDiscount_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void dgvDiscount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FormBackGround formBackGround = new FormBackGround();
            try
            {
                using (FormInformationDiscount Form = new FormInformationDiscount())
                {
                    formBackGround.StartPosition = FormStartPosition.Manual;
                    formBackGround.FormBorderStyle = FormBorderStyle.None;
                    formBackGround.Opacity = .70d;
                    formBackGround.BackColor = Color.Black;
                    formBackGround.WindowState = FormWindowState.Maximized;
                    formBackGround.TopMost = true;
                    formBackGround.Location = this.Location;
                    formBackGround.ShowInTaskbar = false;
                    formBackGround.Show();
                    Form.Owner = formBackGround;
                    Form.id_discount = dgvDiscount.Rows[e.RowIndex].Cells[1].Value.ToString();
                    Form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                formBackGround.Dispose();
            }
        }

        private void dgvDiscount_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = dgvDiscount.RowCount - 1;
            }
            catch
            {

            }
        }

        private void dgvDiscount_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = dgvDiscount.RowCount - 1;
            }
            catch
            {

            }
        }

        private void bunifuVScrollBar1_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            try
            {
                dgvDiscount.FirstDisplayedScrollingRowIndex = dgvDiscount.Rows[e.Value].Index;
            }
            catch (Exception)
            {

            }
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            Form1.ShowDialog();
        }
    }
}
