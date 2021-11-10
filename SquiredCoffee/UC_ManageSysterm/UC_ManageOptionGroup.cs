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
    public partial class UC_ManageOptionGroup : UserControl
    {
        public int totalOptionGroup;
        public int totalOptionGroupSearch;
        FormAddGroupOption From;
        FormInformationOptionGroup From1;
        public UC_ManageOptionGroup()
        {
            InitializeComponent();
            From = new FormAddGroupOption(this);
            From1 = new FormInformationOptionGroup(this);
        }


        public void clear()
        {
            totalOptionGroup = 0;
            totalOptionGroupSearch = 0;
        }

        public void clear1()
        {
            txtSearch.Text = string.Empty;
        }

        public void Display()
        {
            dgvOptionGroup.Rows.Clear();
            List<OptionGroup> optionGroupList = DbOptionGroup.LoadOptionGroup();
            foreach (OptionGroup item in optionGroupList)
            {
                totalOptionGroup += 1;
                dgvOptionGroup.Rows.Add(new object[] {
                   imageList1.Images[0],
                   item.id,
                   item.title,
                   Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalOptionGroup.Text = totalOptionGroup.ToString();
            lblTotalOptionGroupSearch.Text = totalOptionGroup.ToString();
        }

        public void LoadOptionGroupSearch(string status)
        {
            dgvOptionGroup.Rows.Clear();
            List<OptionGroup> optionGroupList = DbOptionGroup.LoadOptionGroupSearch(status);
            foreach (OptionGroup item in optionGroupList)
            {
                totalOptionGroupSearch += 1;
                dgvOptionGroup.Rows.Add(new object[] {
                   imageList1.Images[0],
                   item.id,
                   item.title,
                   Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2] ,
                });
            }
            lblTotalOptionGroupSearch.Text = totalOptionGroupSearch.ToString();
        }


        private void UC_ManageOptionGroup_Load(object sender, EventArgs e)
        {
            clear1();
            clear();
            Display();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            clear1();
            clear();
            Display();
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            clear1();
            clear();
            LoadOptionGroupSearch("1");
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            clear1();
            clear();
            LoadOptionGroupSearch("0");
        }

        private void dgvOptionGroup_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = dgvOptionGroup.RowCount - 1;
            }
            catch
            {

            }
        }

        private void dgvOptionGroup_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = dgvOptionGroup.RowCount - 1;
            }
            catch
            {

            }
        }

        private void bunifuVScrollBar1_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            try
            {
                dgvOptionGroup.FirstDisplayedScrollingRowIndex = dgvOptionGroup.Rows[e.Value].Index;
            }
            catch (Exception)
            {

            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            clear();
            dgvOptionGroup.Rows.Clear();
            List<OptionGroup> optionGroupList = DbOptionGroup.LoadOptionGroupSearchKey(txtSearch.Text);
            foreach (OptionGroup item in optionGroupList)
            {
                totalOptionGroupSearch += 1;
                dgvOptionGroup.Rows.Add(new object[] {
                   imageList1.Images[0],
                   item.id,
                   item.title,
                   Convert.ToBoolean(item.status)?  imageList1.Images[1] : imageList1.Images[2],
                });
            }
            lblTotalOptionGroupSearch.Text = totalOptionGroupSearch.ToString();
        }

        private void btnAddOptionGroup_Click(object sender, EventArgs e)
        {
            FormBackGround formBackGround = new FormBackGround();
            try
            {
                using (FormAddGroupOption Form = new FormAddGroupOption(this))
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

        private void dgvOptionGroup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FormBackGround formBackGround = new FormBackGround();
            try
            {
                using (FormInformationOptionGroup Form = new FormInformationOptionGroup(this))
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
                    string id_group_option = dgvOptionGroup.Rows[e.RowIndex].Cells[1].Value.ToString();
                    Form.id_option_group = Convert.ToInt32(id_group_option);
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
    }
}
