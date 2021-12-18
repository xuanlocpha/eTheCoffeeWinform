using MySql.Data.MySqlClient;
using SquiredCoffee.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SquiredCoffee.DB
{
    class DbAssignment
    {
        public static MySqlConnection GetConnection()
        {
            string sql = "SERVER=45.252.251.29;PORT=3306;DATABASE=sodopxlg_koffeeholic;UID=sodopxlg;PASSWORD=05qT1yfRp9;charset=utf8";
            MySqlConnection con = new MySqlConnection(sql);
            try
            {
                con.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySQL Connection! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return con;
        }


        public static void AddAssignment(Assignment std)
        {
            string sql = "INSERT INTO assignment (staff_id,date,start_time,expiry_time,check_shift,total_min,total_time_late,type) VALUES(@staff_id,@date,@start_time,@expiry_time,@check_shift,@total_min,@total_time_late,@type)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@staff_id", MySqlDbType.VarChar).Value = std.staff_id;
            cmd.Parameters.Add("@date", MySqlDbType.VarChar).Value = std.date;
            cmd.Parameters.Add("@start_time", MySqlDbType.VarChar).Value = std.start_time;
            cmd.Parameters.Add("@expiry_time", MySqlDbType.VarChar).Value = std.expiry_time;
            cmd.Parameters.Add("@check_shift", MySqlDbType.VarChar).Value = std.check_shift;
            cmd.Parameters.Add("@total_min", MySqlDbType.VarChar).Value = std.total_min;
            cmd.Parameters.Add("@total_time_late", MySqlDbType.VarChar).Value = std.total_time_late;
            cmd.Parameters.Add("@type", MySqlDbType.VarChar).Value = std.type;
            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Không Thể Thêm Loại Sản Phẩm ! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }



        public static void UpdateAssignmentCheck(string check_shift,string id,string total_time_late)
        {
            string sql = "UPDATE assignment SET check_shift = '"+check_shift+"', total_time_late ='"+total_time_late+"' WHERE id = '"+id+"'";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Không Thể Thêm Loại Sản Phẩm ! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static void UpdateAssignmentTotalMin(string totalMin,string id)
        {
            string sql = "UPDATE assignment SET total_min = '" + totalMin + "' WHERE id = '" + id + "'";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Không Thể Thêm Loại Sản Phẩm ! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }


        public static void UpdateAssignmentCheck1(string check_shift, string id)
        {
            string sql = "UPDATE assignment SET check_shift = '" + check_shift + "' WHERE id = '" + id + "'";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Không Thể Thêm Loại Sản Phẩm ! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }


        public static void UpdateAssignmentCheck(Assignment std,string id)
        {
            string sql = "UPDATE assignment SET staff_id = @staff_id,date=@date,start_time=@start_time,expiry_time = @expiry_time ,check_shift = @check_shift ,total_min= @total_min , total_time_late = @total_time_late , type = @type WHERE id = @id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@staff_id", MySqlDbType.VarChar).Value = std.staff_id;
            cmd.Parameters.Add("@date", MySqlDbType.VarChar).Value = std.date;
            cmd.Parameters.Add("@start_time", MySqlDbType.VarChar).Value = std.start_time;
            cmd.Parameters.Add("@expiry_time", MySqlDbType.VarChar).Value = std.expiry_time;
            cmd.Parameters.Add("@check_shift", MySqlDbType.VarChar).Value = std.check_shift;
            cmd.Parameters.Add("@total_min", MySqlDbType.VarChar).Value = std.total_min;
            cmd.Parameters.Add("@total_time_late", MySqlDbType.VarChar).Value = std.total_time_late;
            cmd.Parameters.Add("@type", MySqlDbType.VarChar).Value = std.type;
            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Không Thể Sửa ! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }


        public static bool CheckAddAssignment(Assignment std)
        {
            AddAssignment(std);
            string sql = "select * from assignment where staff_id=@staff_id and date = @date and start_time = @start_time and expiry_time = @expiry_time and check_shift = @check_shift and total_min= @total_min and total_time_late = @total_time_late and type = @type";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@staff_id", MySqlDbType.VarChar).Value = std.staff_id;
            cmd.Parameters.Add("@date", MySqlDbType.VarChar).Value = std.date;
            cmd.Parameters.Add("@start_time", MySqlDbType.VarChar).Value = std.start_time;
            cmd.Parameters.Add("@expiry_time", MySqlDbType.VarChar).Value = std.expiry_time;
            cmd.Parameters.Add("@check_shift", MySqlDbType.VarChar).Value = std.check_shift;
            cmd.Parameters.Add("@total_min", MySqlDbType.VarChar).Value = std.total_min;
            cmd.Parameters.Add("@total_time_late", MySqlDbType.VarChar).Value = std.total_time_late;
            cmd.Parameters.Add("@type", MySqlDbType.VarChar).Value = std.type;
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet tbl = new DataSet();
            adp.Fill(tbl);
            int i = tbl.Tables[0].Rows.Count;
            if (i > 0)
            {
                return true;  // data exist
            }
            else
            {
                return false; //data not exist
            }
        }



        public static bool CheckAssignment(Assignment std)
        {
            string sql = "select * from assignment where staff_id=@staff_id and date = @date and start_time = @start_time and expiry_time = @expiry_time and check_shift = @check_shift and total_min= @total_min and total_time_late = @total_time_late and type = @type";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@staff_id", MySqlDbType.VarChar).Value = std.staff_id;
            cmd.Parameters.Add("@date", MySqlDbType.VarChar).Value = std.date;
            cmd.Parameters.Add("@start_time", MySqlDbType.VarChar).Value = std.start_time;
            cmd.Parameters.Add("@expiry_time", MySqlDbType.VarChar).Value = std.expiry_time;
            cmd.Parameters.Add("@check_shift", MySqlDbType.VarChar).Value = std.check_shift;
            cmd.Parameters.Add("@total_min", MySqlDbType.VarChar).Value = std.total_min;
            cmd.Parameters.Add("@total_time_late", MySqlDbType.VarChar).Value = std.total_time_late;
            cmd.Parameters.Add("@type", MySqlDbType.VarChar).Value = std.type;
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet tbl = new DataSet();
            adp.Fill(tbl);
            int i = tbl.Tables[0].Rows.Count;
            if (i > 0)
            {
                return true;  // data exist
            }
            else
            {
                return false; //data not exist
            }
        }


        public static bool CheckUpdateAssignment(Assignment std,string id)
        {
            UpdateAssignmentCheck(std,id);
            string sql = "select * from assignment where staff_id=@staff_id and date = @date and start_time = @start_time and expiry_time = @expiry_time and check_shift = @check_shift and total_min= @total_min and total_time_late = @total_time_late and type = @type and id = @id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@staff_id", MySqlDbType.VarChar).Value = std.staff_id;
            cmd.Parameters.Add("@date", MySqlDbType.VarChar).Value = std.date;
            cmd.Parameters.Add("@start_time", MySqlDbType.VarChar).Value = std.start_time;
            cmd.Parameters.Add("@expiry_time", MySqlDbType.VarChar).Value = std.expiry_time;
            cmd.Parameters.Add("@check_shift", MySqlDbType.VarChar).Value = std.check_shift;
            cmd.Parameters.Add("@total_min", MySqlDbType.VarChar).Value = std.total_min;
            cmd.Parameters.Add("@total_time_late", MySqlDbType.VarChar).Value = std.total_time_late;
            cmd.Parameters.Add("@type", MySqlDbType.VarChar).Value = std.type;
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet tbl = new DataSet();
            adp.Fill(tbl);
            int i = tbl.Tables[0].Rows.Count;
            if (i > 0)
            {
                return true;  // data exist
            }
            else
            {
                return false; //data not exist
            }
        }


        public static void DeleteAssignment(string id)
        {
            string sql = "DELETE FROM assignment  WHERE id = @id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Xóa Không Thành Công! \n" + ex.Message, " Cảnh Báo Lỗi ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }


        public static bool CheckDeleteAssignment(string id)
        {
            DeleteAssignment(id);
            string sql = "select * from assignment where id = @id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet tbl = new DataSet();
            adp.Fill(tbl);
            int i = tbl.Tables[0].Rows.Count;
            if (i > 0)
            {
                return true;  // data exist
            }
            else
            {
                return false; //data not exist
            }
        }


        public static List<Assignment> LoadAssginmentListSearch(string id_staff,string date)
        {
            List<Assignment> assignmentList = new List<Assignment>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM assignment WHERE  staff_id='"+id_staff+"' AND date = '"+date+"' ");
            foreach (DataRow item in data.Rows)
            {
                Assignment assignment = new Assignment(item);
                assignmentList.Add(assignment);
            }

            return assignmentList;
        }


        public static List<Assignment> LoadAssginmentList()
        {
            List<Assignment> assignmentList = new List<Assignment>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT a.id,a.staff_id,a.date,a.start_time,a.expiry_time,a.check_shift,a.total_min,a.total_time_late,a.type,CONCAT(first_name,last_name) AS name_staff FROM assignment a , staffs s WHERE a.staff_id = s.id");
            foreach (DataRow item in data.Rows)
            {
                Assignment assignment = new Assignment(item);
                assignmentList.Add(assignment);
            }

            return assignmentList;
        }


        public static List<Assignment> LoadAssginmentListDate(string date)
        {
            List<Assignment> assignmentList = new List<Assignment>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT a.id,a.staff_id,a.date,a.start_time,a.expiry_time,a.check_shift,a.total_min,a.total_time_late,a.type,CONCAT(first_name,last_name) AS name_staff FROM assignment a , staffs s WHERE a.staff_id = s.id and a.date ='"+date+"'");
            foreach (DataRow item in data.Rows)
            {
                Assignment assignment = new Assignment(item);
                assignmentList.Add(assignment);
            }

            return assignmentList;
        }

        public static List<Assignment> LoadAssginmentListNot()
        {
            List<Assignment> assignmentList = new List<Assignment>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT a.id,a.staff_id,a.date,a.start_time,a.expiry_time,a.check_shift,a.total_min,a.total_time_late,a.type,CONCAT(first_name,last_name) AS name_staff FROM assignment a , staffs s WHERE a.staff_id = s.id and a.check_shift = '"+"0"+"'");
            foreach (DataRow item in data.Rows)
            {
                Assignment assignment = new Assignment(item);
                assignmentList.Add(assignment);
            }

            return assignmentList;
        }


        public static List<Assignment> LoadAssginmentListSearchText(string key)
        {
            List<Assignment> assignmentList = new List<Assignment>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT a.id,a.staff_id,a.date,a.start_time,a.expiry_time,a.check_shift,a.total_min,a.total_time_late,a.type,CONCAT(first_name,last_name) AS name_staff FROM assignment a , staffs s WHERE a.staff_id = s.id and s.last_name LIKE'%" + @key + "%'");
            foreach (DataRow item in data.Rows)
            {
                Assignment assignment = new Assignment(item);
                assignmentList.Add(assignment);
            }

            return assignmentList;
        }

        public static List<Assignment> LoadAssginmentList(string id)
        {
            List<Assignment> assignmentList = new List<Assignment>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT a.id,a.staff_id,a.date,a.start_time,a.expiry_time,a.check_shift,a.total_min,a.total_time_late,a.type,CONCAT(first_name,last_name) AS name_staff FROM assignment a , staffs s WHERE a.staff_id = s.id AND a.id = '"+id+"'");
            foreach (DataRow item in data.Rows)
            {
                Assignment assignment = new Assignment(item);
                assignmentList.Add(assignment);
            }

            return assignmentList;
        }

    }
}
