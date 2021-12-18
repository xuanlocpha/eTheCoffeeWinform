using MySql.Data.MySqlClient;
using SquiredCoffee.Class;
using SquiredCoffee.DB;
using SquiredCoffee.FormManage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SquiredCoffee.UC_ManageSysterm
{
    public partial class UC_ManageAssignment : UserControl
    {
        MySqlConnection con = new MySqlConnection();
        public string start_time;
        public string end_time;
        FormError Form1;
        FormSuccess Form2;
        public int type;
        public string id_assignment;
       
        public UC_ManageAssignment()
        {
            InitializeComponent();
            Form1 = new FormError();
            Form2 = new FormSuccess();
        }

        void ketnoi()
        {
            con.ConnectionString = "SERVER=45.252.251.21;PORT=3306;DATABASE=sodopxlg_koffeeholic;UID=sodopxlg;PASSWORD=05qT1yfRp9";
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

        void ListStaff()
        {
            string sql = "SELECT CONCAT(first_name,last_name) AS title ,id FROM staffs WHERE role_id = '" + "2" + "'";
            DataSet ListCategory = new DataSet();
            ListCategory = LoadDB(sql);
            cbStaffName.DataSource = ListCategory.Tables[0];
            cbStaffName.DisplayMember = "title";
            cbStaffName.ValueMember = "id";
            cbStaffName.SelectedIndex = -1;
            con.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbStaffName.Text == "")
            {
                Form1.title = "Tên Của Nhân Viên (Trống) ";
                Form1.ShowDialog();
                return;
            }
            if (cbCa.Text == "")
            {
                Form1.title = "Ca Làm Của Nhân Viên (Trống) ";
                Form1.ShowDialog();
                return;
            }
            if (btnSave.Text == "Thêm Mới")
            {
                string date = dtpDate.Value.Date.ToString("yyyy-MM-dd");
                Assignment std = new Assignment(Convert.ToInt32(cbStaffName.SelectedValue), date, start_time, end_time, 0, 0, 0, type);
                if (DbAssignment.CheckAddAssignment(std) == true)
                {
                    if (DbAssignment.CheckAssignment(std) == true)
                    {
                        Form1.title = "Ca này đã tồn tại";
                        Form1.ShowDialog();
                        return;
                    }
                    else
                    {
                        Form2.title = "Thêm mới ca làm việc thành công";
                        Form2.ShowDialog();
                        clear();
                        Display();
                    }
                }
                else
                {
                    Form2.title = "Thêm mới ca làm việc không thành công";
                    Form1.ShowDialog();
                }
            }
        }

        public void clear()
        {
            dtpDate.Value = DateTime.Now;
            cbStaffName.SelectedIndex = -1;
            cbCa.SelectedIndex = -1;
        }

        private void UC_ManageAssignment_Load(object sender, EventArgs e)
        {
            ListStaff();
            Display();
            dtpDate.Value = DateTime.Now;
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (cbCa.Text == "Ca Sáng")
            {
                type = 1;
                start_time = "07:00:00";
                end_time = "13:00:00";
            }
            if (cbCa.Text == "Ca Chiều")
            {
                type = 2;
                start_time = "14:00:00";
                end_time = "13:0:00";
            }
            if (cbCa.Text == "Ca Tối")
            {
                type = 3;
                start_time = "19:00:00";
                end_time = "22:0:00";
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            clear();
        }


        public void Display()
        {
            dgvStaff.Rows.Clear();
            List<Assignment> assignmentList = DbAssignment.LoadAssginmentList();
            foreach (Assignment item in assignmentList)
            {
                dgvStaff.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.name_staff,
                    String.Format("{0:dd/MM/yyyy}", item.date),
                    item.start_time,
                    item.expiry_time,
                    Convert.ToBoolean(item.check_shift)?  imageList1.Images[1] : imageList1.Images[2],
                    item.total_min + "  phút",
                    item.total_time_late +" phút",
                });;
            }
        }

       
        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_assignment = dgvStaff.Rows[e.RowIndex].Cells[1].Value.ToString();
            List<Assignment> assignmentList = DbAssignment.LoadAssginmentList(id_assignment);
            foreach (Assignment item in assignmentList)
            {
                cbStaffName.Text = item.name_staff;
                if(item.type == 1)
                {
                    cbCa.Text = "Ca Sáng";
                }
                if (item.type == 2)
                {
                    cbCa.Text = "Ca Chiều";
                }
                if (item.type == 3)
                {
                    cbCa.Text = "Ca Tối";
                }
                dtpDate.Text = String.Format("{0:dd/MM/yyyy}", item.date);
            }
        }

        private void cbCa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCa.Text == "Ca Sáng")
            {
                type = 1;
                start_time = "07:00:00";
                end_time = "13:00:00";
            }
            if (cbCa.Text == "Ca Chiều")
            {
                type = 2;
                start_time = "14:00:00";
                end_time = "18:00:00";
            }
            if (cbCa.Text == "Ca Tối")
            {
                type = 3;
                start_time = "19:00:00";
                end_time = "22:00:00";
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cbStaffName.Text == "")
            {
                Form1.title = "Tên Của Nhân Viên (Trống) ";
                Form1.ShowDialog();
                return;
            }
            if (cbCa.Text == "")
            {
                Form1.title = "Ca Làm Của Nhân Viên (Trống) ";
                Form1.ShowDialog();
                return;
            }
            if (btnUpdate.Text == "Sửa")
            {
                string date = dtpDate.Value.Date.ToString("yyyy-MM-dd");
                Assignment std = new Assignment(Convert.ToInt32(cbStaffName.SelectedValue), date, start_time, end_time, 0, 0, 0, type);
                if (DbAssignment.CheckUpdateAssignment(std, id_assignment.ToString()) == true)
                {
                    Form2.title = "Cập nhật ca làm việc thành công";
                    Form2.ShowDialog();
                    clear();
                    Display();
                }
                else
                {
                    Form1.title = "Cập nhật ca làm việc không thành công";
                    Form1.ShowDialog();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DbAssignment.CheckDeleteAssignment(id_assignment.ToString()) == false)
            {
                Form2.title = "Xóa ca làm việc thành công";
                Form2.ShowDialog();
                Display();
                clear();
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            Display();
        }

        private void btnDateNow_Click(object sender, EventArgs e)
        {
            dgvStaff.Rows.Clear();
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            List<Assignment> assignmentList = DbAssignment.LoadAssginmentListDate(date);
            foreach (Assignment item in assignmentList)
            {
                dgvStaff.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.name_staff,
                    String.Format("{0:dd/MM/yyyy}", item.date),
                    item.start_time,
                    item.expiry_time,
                    Convert.ToBoolean(item.check_shift)?  imageList1.Images[1] : imageList1.Images[2],
                    item.total_min + "  phút",
                    item.total_time_late +" phút",
                }); ;
            }
        }

        private void btnNot_Click(object sender, EventArgs e)
        {
            dgvStaff.Rows.Clear();
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            List<Assignment> assignmentList = DbAssignment.LoadAssginmentListNot();
            foreach (Assignment item in assignmentList)
            {
                dgvStaff.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.name_staff,
                    String.Format("{0:dd/MM/yyyy}", item.date),
                    item.start_time,
                    item.expiry_time,
                    Convert.ToBoolean(item.check_shift)?  imageList1.Images[1] : imageList1.Images[2],
                    item.total_min + "  phút",
                    item.total_time_late +" phút",
                }); ;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvStaff.Rows.Clear();
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            List<Assignment> assignmentList = DbAssignment.LoadAssginmentListSearchText(txtSearch.Text);
            foreach (Assignment item in assignmentList)
            {
                dgvStaff.Rows.Add(new object[] {
                    imageList1.Images[0],
                    item.id,
                    item.name_staff,
                    String.Format("{0:dd/MM/yyyy}", item.date),
                    item.start_time,
                    item.expiry_time,
                    Convert.ToBoolean(item.check_shift)?  imageList1.Images[1] : imageList1.Images[2],
                    item.total_min + "  phút",
                    item.total_time_late +" phút",
                }); ;
            }
        }

        private void cbNameStaffSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }


    }
}
