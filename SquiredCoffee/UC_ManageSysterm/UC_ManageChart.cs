using SquiredCoffee.DB;
using SquiredCoffee.FormManage;
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

namespace SquiredCoffee.UC_ManageSysterm
{
    public partial class UC_ManageChart : UserControl
    {
        FormInformationStatisticalOrder Form1;
        FormInformationStatisticalProduct Form2;
        public int option;
        public UC_ManageChart()
        {
            InitializeComponent();
            Form1 = new FormInformationStatisticalOrder(this);
            Form2 = new FormInformationStatisticalProduct();
            UC_InformationStatictisOrder uC_InformationStatictis = new UC_InformationStatictisOrder(this);
            uC_InformationStatictis.title = DateTime.Now.ToString("dd-MM-yyyy");
            uC_InformationStatictis.key = DateTime.Now.ToString("yyyy-MM-dd");
            AddControlsToPanel(uC_InformationStatictis);
        }

        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelMenu.Controls.Clear();
            panelMenu.Controls.Add(c);
        }


        private void rbOption1_CheckedChanged(object sender, EventArgs e)
        {
            option = 1;
        }

        public void load(int option)
        {
            if(option == 1)
            {
                cbSelect.Items[1] = "Doanh thu theo tháng";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            switch (option)
            {
                case 1:
                    UC_InformationStatictisOrder uC_InformationStatictis = new UC_InformationStatictisOrder(this);
                    uC_InformationStatictis.title = DateTime.Now.ToString("dd-MM-yyyy");
                    uC_InformationStatictis.key = DateTime.Now.ToString("yyyy-MM-dd");
                    AddControlsToPanel(uC_InformationStatictis);
                    break;
                case 2:
                    UC_InformationStatictisOrder uC_InformationStatictis1 = new UC_InformationStatictisOrder(this);
                    uC_InformationStatictis1.title = dtpDate.Value.Date.ToString("dd-MM-yyyy");
                    uC_InformationStatictis1.key = dtpDate.Value.Date.ToString("yyyy-MM-dd");
                    AddControlsToPanel(uC_InformationStatictis1);
                    break;
                case 3:
                    UC_InformationStatictisOrder uC_InformationStatictis2 = new UC_InformationStatictisOrder(this);
                    uC_InformationStatictis2.title = "tháng " + cbMonth.Text;
                    uC_InformationStatictis2.key = cbYear.Text+"-"+cbMonth.Text;
                    AddControlsToPanel(uC_InformationStatictis2);
                    break;
                case 4:
                    UC_InformationStatictisOrder uC_InformationStatictis3 = new UC_InformationStatictisOrder(this);
                    uC_InformationStatictis3.title = "năm " + cbYear.Text;
                    uC_InformationStatictis3.key = cbYear.Text ;
                    AddControlsToPanel(uC_InformationStatictis3);
                    break;
                case 5:
                    UC_InformationStatictisProduct uC_InformationStatictisProduct = new UC_InformationStatictisProduct(this);
                    uC_InformationStatictisProduct.titleForm = DateTime.Now.ToString("dd-MM-yyyy");
                    uC_InformationStatictisProduct.key = dtpDate.Value.Date.ToString("yyyy-MM-dd");
                    AddControlsToPanel(uC_InformationStatictisProduct);
                    break;
                case 6:
                    UC_InformationStatictisProduct uC_InformationStatictisProduct1 = new UC_InformationStatictisProduct(this);
                    uC_InformationStatictisProduct1.titleForm = "tháng " + cbMonth.Text;
                    uC_InformationStatictisProduct1.key = cbYear.Text + "-" + cbMonth.Text;
                    AddControlsToPanel(uC_InformationStatictisProduct1);
                    break;
                case 7:
                    UC_InformationStatictisProduct uC_InformationStatictisProduct2 = new UC_InformationStatictisProduct(this);
                    uC_InformationStatictisProduct2.titleForm = "năm " + cbYear.Text;
                    uC_InformationStatictisProduct2.key = cbYear.Text ;
                    AddControlsToPanel(uC_InformationStatictisProduct2);
                    break;
                case 8:
                    UC_InformationStatictisUser uC_InformationStatictisUser = new UC_InformationStatictisUser();
                    AddControlsToPanel(uC_InformationStatictisUser);
                    break;
                case 9:
                    UC_InformationStatictisAssignment uC_InformationStatictisAssignment = new UC_InformationStatictisAssignment();
                    AddControlsToPanel(uC_InformationStatictisAssignment);
                    break;
            }
        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void UC_ManageChart_Load(object sender, EventArgs e)
        {
            dtpDate.Enabled = false;
            cbMonth.Enabled = false;
            cbYear.Enabled = false;
            dtpDate.Value = DateTime.Now;
        }

        private void cbSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSelect.Text == "- Thống kê hóa đơn hôm nay")
            {
                dtpDate.Enabled = false;
                cbMonth.Enabled = false;
                cbYear.Enabled = false;
                option = 1;
            }
            if (cbSelect.Text == "- Thống kê hóa đơn theo ngày")
            {
                dtpDate.Enabled = true;
                option = 2;
            }
            if (cbSelect.Text == "- Thống kê hóa đơn theo tháng")
            {
                dtpDate.Enabled = false;
                cbMonth.Enabled = true;
                cbYear.Enabled = true;
                option = 3;
            }
            if (cbSelect.Text == "- Thống kê hóa đơn theo năm")
            {
                dtpDate.Enabled = false;
                cbMonth.Enabled = false;
                cbYear.Enabled = true;
                option = 4;
            }
            if (cbSelect.Text == "- Top 10 sản phẩm bán chạy theo ngày")
            {
                dtpDate.Enabled = true;
                option = 5;
            }
            if (cbSelect.Text == "- Top 10 sản phẩm bán chạy theo tháng")
            {
                dtpDate.Enabled = false;
                cbMonth.Enabled = true;
                cbYear.Enabled = true;
                option = 6;
            }
            if (cbSelect.Text == "- Top 10 sản phẩm bán chạy theo năm")
            {
                dtpDate.Enabled = false;
                cbMonth.Enabled = false;
                cbYear.Enabled = true;
                option = 7;
            }
            if (cbSelect.Text == "- Khách hàng mua nhiều nhất")
            {
                dtpDate.Enabled = false;
                cbMonth.Enabled = false;
                cbYear.Enabled = false;
                option = 8;
            }
            //if (cbSelect.Text == "- Nhân viên làm nhiều nhất")
            //{
            //    dtpDate.Enabled = false;
            //    cbMonth.Enabled = false;
            //    cbYear.Enabled = false;
            //    option = 9;
            //}
        }
    }
}
