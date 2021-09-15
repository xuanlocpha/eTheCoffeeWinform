using MySql.Data.MySqlClient;
using SquiredCoffee.Class;
using SquiredCoffee.DB;
using SquiredCoffee.UC_ManageSysterm;
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
    public partial class FormAddOption : Form
    {
        MySqlConnection con = new MySqlConnection();
        public static UC_ManageOption1 _parent;
        public int status = 1;
        public FormAddOption(UC_ManageOption1 parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        void ketnoi()
        {
            con.ConnectionString = "datasource=localhost;port=3306;username=root;password=;database=coffeeshop";
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

        private void FormAddOption_Load(object sender, EventArgs e)
        {
            ListOptionGroup();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbOptionGroup.Text == "")
            {
                MessageBox.Show("Tên tùy chọn món không được để ( Trống )");
                return;
            }
            if (txtTitleOption.Text.Trim() == "")
            {
                MessageBox.Show("Tên của tùy chọn không được ( Trống )");
                return;
            }
            if (txtTitleOption.Text.Trim().Length < 1)
            {
                MessageBox.Show("Tên của tùy chọn phải lớn hơn (  1 ký tự )");
                return;
            }
            if (DbOption.CheckDb(txtTitleOption.Text) == true)
            {
                MessageBox.Show("Tên của tùy chọn  (  Đã tồn tại )");
                return;
            }
            if (btnSave.Text == "Lưu")
            {
                Option std = new Option(txtTitleOption.Text, Convert.ToInt32(cbOptionGroup.SelectedValue),status);
                DbOption.AddOption(std);
                this.Close();
                clear();
                _parent.clear1();
                _parent.clear();
                _parent.Display();
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
    }
}
