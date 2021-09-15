using SquiredCoffee.Class;
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
    public partial class UC_ManageOption1 : UserControl
    {
        public int totalOption;
        public int totalOptionSearch;
        FormAddOption Form;
        FormInformationOption Form1;
        public UC_ManageOption1()
        {
            InitializeComponent();
            Form = new FormAddOption(this);
            Form1 = new FormInformationOption(this);
        }

        public void clear()
        {
            totalOption = 0;
            totalOptionSearch = 0;
        }

        public void clear1()
        {
            txtSearch.Text = string.Empty;
        }

        public void Display()
        {
            clear();
            clear1();
            dgvOption.Rows.Clear();
            List<OptionShow1> optionShow1List = DbOption.LoadOption();
            foreach (OptionShow1 item in optionShow1List)
            {
                totalOption += 1;
                dgvOption.Rows.Add(new object[] {
                   imageList1.Images[0],
                   item.id,
                   item.name_option_group,
                   item.title,
                   Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalOptionGroup.Text = totalOption.ToString();
            lblTotalOptionGroupSearch.Text = totalOption.ToString();
        }


        public void LoadOptionSearch(string @status)
        {
            clear();
            clear1();
            dgvOption.Rows.Clear();
            List<OptionShow1> optionShow1List = DbOption.LoadOptionSearch(status);
            foreach (OptionShow1 item in optionShow1List)
            {
                totalOptionSearch += 1;
                dgvOption.Rows.Add(new object[] {
                   imageList1.Images[0],
                   item.id,
                   item.name_option_group,
                   item.title,
                   Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalOptionGroupSearch.Text = totalOptionSearch.ToString();
        }

        private void UC_ManageOption1_Load(object sender, EventArgs e)
        {
            Display();
        }

       

        private void bunifuVScrollBar1_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            try
            {
                dgvOption.FirstDisplayedScrollingRowIndex = dgvOption.Rows[e.Value].Index;
            }
            catch (Exception)
            {

            }
        }

        private void dgvOption_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = dgvOption.RowCount - 1;
            }
            catch
            {

            }
        }

        private void dgvOption_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = dgvOption.RowCount - 1;
            }
            catch
            {

            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            clear();
            clear1();
            Display();
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            LoadOptionSearch("1");
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            LoadOptionSearch("0");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            clear();
            dgvOption.Rows.Clear();
            List<OptionShow1> optionShow1List = DbOption.LoadOptionSearch1(txtSearch.Text);
            foreach (OptionShow1 item in optionShow1List)
            {
                totalOptionSearch += 1;
                dgvOption.Rows.Add(new object[] {
                   imageList1.Images[0],
                   item.id,
                   item.name_option_group,
                   item.title,
                   Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalOptionGroupSearch.Text = totalOptionSearch.ToString();
        }

        private void btnAddOptionGroup_Click(object sender, EventArgs e)
        {
            Form.ShowDialog();
        }

        private void dgvOption_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id_option = dgvOption.Rows[e.RowIndex].Cells[1].Value.ToString();
            Form1.id_option = Convert.ToInt32(id_option);
            Form1.ShowDialog();
        }
    }
}
