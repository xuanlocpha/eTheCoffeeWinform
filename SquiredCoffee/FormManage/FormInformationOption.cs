using MySql.Data.MySqlClient;
using SquiredCoffee.Class;
using SquiredCoffee.DB;
using SquiredCoffee.UC_ManageSysterm;
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

namespace SquiredCoffee.FormManage
{
    public partial class FormInformationOption : Form
    {
        MySqlConnection con = new MySqlConnection();
        public static UC_ManageOption1 _parent;
        public int status;
        public int id_option;
        FormSuccess Form1;
        FormError Form2;
        public FormInformationOption(UC_ManageOption1 parent)
        {
            InitializeComponent();
            _parent = parent;
            ListOptionGroup();
            Form1 = new FormSuccess();
            Form2 = new FormError();
        }

        void ketnoi()
        {
            con.ConnectionString = "SERVER=45.252.251.29;PORT=3306;DATABASE=sodopxlg_koffeeholic;UID=sodopxlg;PASSWORD=05qT1yfRp9";
            if (con.State == ConnectionState.Closed)
                con.Open();
        }

        public DataSet LoadDB(string sql)
        {
            ketnoi();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
            da.Fill(ds);
            return ds;
        }

        void ListOptionGroup()
        {
            string sql = "SELECT * FROM option_groups";
            DataSet ListCategory = new DataSet();
            ListCategory = LoadDB(sql);
            cbOptionGroup.DataSource = ListCategory.Tables[0];
            cbOptionGroup.DisplayMember = "title";
            cbOptionGroup.ValueMember = "id";
            cbOptionGroup.SelectedIndex = -1;
            con.Close();
        }
        public void clear()
        {
            txtTitleOption.Text = string.Empty;
            cbOptionGroup.SelectedIndex = -1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Display()
        {
            List<OptionShow1> optionShow1List = DbOption.LoadOption(id_option.ToString());
            foreach (OptionShow1 item in optionShow1List)
            {
                cbOptionGroup.Text = item.name_option_group;
                txtTitleOption.Text = item.title;
                if (item.status == 1)
                {
                    rdStatus1.Checked = true;
                }
                else if (item.status == 0)
                {
                    rdStatus2.Checked = true;
                }
                status = item.status;
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (cbOptionGroup.Text == "")
            {
                Form2.title = "Tên Nhóm Option Không Được (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtTitleOption.Text.Trim() == "")
            {
                Form2.title = "Tên Option Không Được (Trống) ";
                Form2.ShowDialog();
                return;
            }
            if (txtTitleOption.Text.Trim().Length < 1)
            {
                Form2.title = "Tên Option Phải (> 1 Ký Tự) ";
                Form2.ShowDialog();
                return;
            }
            if (btnEdit.Text == "Sửa")
            {
                Option std = new Option(txtTitleOption.Text, Convert.ToInt32(cbOptionGroup.SelectedValue), status);
                if ((DbOption.CheckUpdateOption(std,id_option.ToString())) == true)
                {
                    Form1.title = "Sửa Thành Công";
                    Form1.ShowDialog();
                    this.Close();
                    clear();
                    _parent.clear1();
                    _parent.clear();
                    _parent.Display();
                }
                else
                {
                    Form2.title = "Sửa Không Thành Công";
                    Form2.ShowDialog();
                    this.Close();
                    clear();
                    _parent.clear1();
                    _parent.clear();
                    _parent.Display();
                }
            }
            
        }

        private void rdStatus1_CheckedChanged(object sender, EventArgs e)
        {
            status = 1;
        }

        private void rdStatus2_CheckedChanged(object sender, EventArgs e)
        {
            status = 0;
        }

        private void FormInformationOption_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            status = 0;
            Option std = new Option(txtTitleOption.Text, Convert.ToInt32(cbOptionGroup.SelectedValue), status);
            if ((DbOption.CheckLockOption(std, id_option.ToString())) == true)
            {
                if (btnDelete.Text == "Xóa")
                {
                    Form1.title = "Khóa Thành Công";
                    Form1.ShowDialog();
                    this.Close();
                    clear();
                    _parent.clear1();
                    _parent.clear();
                    _parent.Display();
                }
                else
                {
                    Form2.title = "Khóa Không Thành Công";
                    Form2.ShowDialog();
                    this.Close();
                    clear();
                    _parent.clear1();
                    _parent.clear();
                    _parent.Display();
                }
            }
        }
    }
}
