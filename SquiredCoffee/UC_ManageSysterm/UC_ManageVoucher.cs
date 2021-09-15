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
    public partial class UC_ManageVoucher : UserControl
    {
        public int totalVoucher;
        public int totalVoucherSearch;
        FormAddVoucher Form;
        FormInformationVoucher Form1;
        public UC_ManageVoucher()
        {
            InitializeComponent();
            Form = new FormAddVoucher(this);
            Form1 = new FormInformationVoucher(this);
        }

        public void clear()
        {
            totalVoucher = 0;
            totalVoucherSearch = 0;
        }

        public void clear1()
        {
            txtSearch.Text = string.Empty;
        }

        public void Display()
        {
            clear();
            clear1();
            dgvVoucher.Rows.Clear();
            List<Voucher> voucherList = DbVoucher.LoadVoucherList();
            foreach (Voucher item in voucherList)
            {
                totalVoucher += 1;
                DateTime start_date = Convert.ToDateTime(item.start_date);
                DateTime expiry_date = Convert.ToDateTime(item.expiry_date);
                dgvVoucher.Rows.Add(new object[] {
                    imageList1.Images[0], 
                    item.id,
                    item.title,
                    item.content,
                    item.coupen_code,
                    String.Format("{0:dd/MM/yyyy}",start_date),
                    String.Format("{0:dd/MM/yyyy}",expiry_date),
                    item.discount_unit,
                    item.discount,
                    item.apply_for,
                    item.quantity_rule,
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalVoucher.Text = totalVoucher.ToString();
            lblTotalVoucherSearch.Text = totalVoucher.ToString();
        }

        public void ListVoucherSearchClick(string status)
        {
            clear();
            clear1();
            dgvVoucher.Rows.Clear();
            List<Voucher> voucherList = DbVoucher.LoadVoucherListSearchClick(status);
            foreach (Voucher item in voucherList)
            {
                totalVoucherSearch += 1;
                DateTime start_date = Convert.ToDateTime(item.start_date);
                DateTime expiry_date = Convert.ToDateTime(item.expiry_date);
                dgvVoucher.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.title,
                    item.content,
                    item.coupen_code,
                    String.Format("{0:dd/MM/yyyy}",start_date),
                    String.Format("{0:dd/MM/yyyy}",expiry_date),
                    item.discount_unit,
                    item.discount,
                    item.apply_for,
                    item.quantity_rule,
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalVoucherSearch.Text = totalVoucherSearch.ToString();
        }


        private void UC_ManageVoucher_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            Display();
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            ListVoucherSearchClick("1");
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            ListVoucherSearchClick("0");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            clear();
            dgvVoucher.Rows.Clear();
            List<Voucher> voucherList = DbVoucher.LoadVoucherListSearch(txtSearch.Text);
            foreach (Voucher item in voucherList)
            {
                totalVoucherSearch += 1;
                DateTime start_date = Convert.ToDateTime(item.start_date);
                DateTime expiry_date = Convert.ToDateTime(item.expiry_date);
                dgvVoucher.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.title,
                    item.content,
                    item.coupen_code,
                    String.Format("{0:dd/MM/yyyy}",start_date),
                    String.Format("{0:dd/MM/yyyy}",expiry_date),
                    item.discount_unit,
                    item.discount,
                    item.apply_for,
                    item.quantity_rule,
                    Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalVoucherSearch.Text = totalVoucherSearch.ToString();
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            Form.ShowDialog();
        }

        private void dgvVoucher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id_voucher = dgvVoucher.Rows[e.RowIndex].Cells[1].Value.ToString();
            Form1.id_voucher = Convert.ToInt32(id_voucher);
            Form1.ShowDialog();
        }
    }
}
