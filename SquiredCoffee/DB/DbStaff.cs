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
    class DbStaff
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


        public static bool CheckAdd(string @userName,string @phone)
        {
            string sql = "select * from staffs where username = '" + @userName + "' AND phone = '"+ @phone +"'";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
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

        public static void AddStaff(Staff std)
        {
            string sql = "INSERT INTO staffs (username,password,last_name,first_name,gender,birthday,image,phone,email,role_id,status) " +
                "VALUES(@username,@password,@last_name,@first_name,@gender,@birthday,@image,@phone,@email,@role_id,@status)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
          
            cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = std.username;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = std.password;
            cmd.Parameters.Add("@last_name", MySqlDbType.VarChar).Value = std.last_name;
            cmd.Parameters.Add("@first_name", MySqlDbType.VarChar).Value = std.first_name;
            cmd.Parameters.Add("@gender", MySqlDbType.VarChar).Value = std.gender;
            cmd.Parameters.Add("@birthday", MySqlDbType.VarChar).Value = std.birthday;
            cmd.Parameters.Add("@image", MySqlDbType.VarChar).Value = std.image;
            cmd.Parameters.Add("@phone", MySqlDbType.VarChar).Value = std.phone;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = std.email;
            cmd.Parameters.Add("@role_id", MySqlDbType.VarChar).Value = std.role_id;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;


            try
            {
                cmd.ExecuteNonQuery();
               
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Khởi tạo không thành công !!! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static void UpdateStaff(Staff std,string id)
        {
            string sql = "UPDATE staffs SET username=@username,password=@password,last_name=@last_name,first_name=@first_name,gender=@gender,birthday=@birthday,image=@image,phone=@phone,email=@email,role_id=@role_id,status=@status WHERE id = @id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = std.username;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = std.password;
            cmd.Parameters.Add("@last_name", MySqlDbType.VarChar).Value = std.last_name;
            cmd.Parameters.Add("@first_name", MySqlDbType.VarChar).Value = std.first_name;
            cmd.Parameters.Add("@gender", MySqlDbType.VarChar).Value = std.gender;
            cmd.Parameters.Add("@birthday", MySqlDbType.VarChar).Value = std.birthday;
            cmd.Parameters.Add("@image", MySqlDbType.VarChar).Value = std.image;
            cmd.Parameters.Add("@phone", MySqlDbType.VarChar).Value = std.phone;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = std.email;
            cmd.Parameters.Add("@role_id", MySqlDbType.VarChar).Value = std.role_id;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
            try
            {
                cmd.ExecuteNonQuery();
              
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Chỉnh sửa không thành công !!! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }


        public static void DeleteStaff(string id)
        {
            string sql = "DELETE FROM staffs  WHERE id = @id";
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
                MessageBox.Show("Xóa tài khoản ( Không thành công! ) \n" + ex.Message, " Cảnh Báo Lỗi ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static void DisplayAndSearch(string query, DataGridView dgv)
        {
            string sql = query;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dgv.DataSource = tbl;
            con.Close();
        }


        public static List<Staff> LoadStaffList()
        {
            List<Staff> staffList = new List<Staff>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT s.id,s.last_name,s.first_name,s.username,s.password,s.gender,s.birthday,s.image,s.phone,s.email,s.role_id,s.status,r.Title FROM staffs s, roles r WHERE s.role_id = r.id");

            foreach (DataRow item in data.Rows)
            {
                Staff staff = new Staff(item);
                staffList.Add(staff);
            }

            return staffList;
        }


        public static List<Staff> LoadInfomationStaff(string id_staff)
        {
            List<Staff> staffList = new List<Staff>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT s.id,s.last_name,s.first_name,s.username,s.password,s.gender,s.birthday,s.image,s.phone,s.email,s.role_id,s.status,r.Title FROM staffs s, roles r WHERE s.role_id = r.id AND s.id = '"+id_staff+"'");

            foreach (DataRow item in data.Rows)
            {
                Staff staff = new Staff(item);
                staffList.Add(staff);
            }

            return staffList;
        }



        public static List<Staff> LoadStaffStatusList(string status)
        {
            List<Staff> staffList = new List<Staff>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT s.id,s.last_name,s.first_name,s.username,s.password,s.gender,s.birthday,s.image,s.phone,s.email,s.role_id,s.status,r.Title FROM staffs s, roles r WHERE s.role_id = r.id AND s.status = '"+status+"'");

            foreach (DataRow item in data.Rows)
            {
                Staff staff = new Staff(item);
                staffList.Add(staff);
            }

            return staffList;
        }

        public static List<Staff> Search(string search)
        {
            List<Staff> staffList = new List<Staff>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT s.id,s.last_name,s.first_name,s.username,s.password,s.gender,s.birthday,s.image,s.phone,s.email,s.role_id,s.status,r.Title FROM staffs s  " +
                " INNER JOIN roles r ON s.role_id = r.id  WHERE s.username LIKE'%" + search + "%' OR s.phone LIKE'%" + search + "%' OR s.first_name LIKE'%" + search + "%' OR s.last_name LIKE'%" + search + "%' OR s.email LIKE'%" + search + "%'");

            foreach (DataRow item in data.Rows)
            {
                Staff staff = new Staff(item);
                staffList.Add(staff);
            }

            return staffList;
        }



        public static bool CheckLoginStaff(string @username,string @password)
        {
            string sql = "select * from staffs where username = '" + @username + "' AND password ='"+@password+"'";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
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


        public static void UpdateInformationStaff(string @username,string password)
        {
            string sql = "UPDATE staffs SET password=@password WHERE username = @username";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Chỉnh sửa không thành công !!! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }


        public static bool CheckUpdatePasswordStaff(string @username, string @password)
        {
            UpdateInformationStaff(username, password);
            string sql = "select * from staffs where username = '" + @username + "' AND password ='" + @password + "'";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
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


        public static List<Staff> CheckRole(string @username)
        {
            List<Staff> staffList = new List<Staff>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT s.id,s.last_name,s.first_name,s.username,s.password,s.gender,s.birthday,s.image,s.phone,s.email,s.role_id,s.status,r.Title FROM staffs s, roles r WHERE s.username = '"+@username+"' ");

            foreach (DataRow item in data.Rows)
            {
                Staff staff = new Staff(item);
                staffList.Add(staff);
            }

            return staffList;
        }


        public static bool CheckCreateStaff(Staff std)
        {
            AddStaff(std);
            string sql = "select * from staffs where username = @username and password = @password";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = std.username;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = std.password;
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


        public static bool CheckUpdateStaff(Staff std,string id)
        {
            UpdateStaff(std,id);
            string sql = "select * from staffs where id = @id and username = @username and password=@password and last_name=@last_name and first_name=@first_name and gender=@gender and birthday=@birthday and image=@image and phone=@phone and email=@email and role_id=@role_id and status=@status";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = std.username;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = std.password;
            cmd.Parameters.Add("@last_name", MySqlDbType.VarChar).Value = std.last_name;
            cmd.Parameters.Add("@first_name", MySqlDbType.VarChar).Value = std.first_name;
            cmd.Parameters.Add("@gender", MySqlDbType.VarChar).Value = std.gender;
            cmd.Parameters.Add("@birthday", MySqlDbType.VarChar).Value = std.birthday;
            cmd.Parameters.Add("@image", MySqlDbType.VarChar).Value = std.image;
            cmd.Parameters.Add("@phone", MySqlDbType.VarChar).Value = std.phone;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = std.email;
            cmd.Parameters.Add("@role_id", MySqlDbType.VarChar).Value = std.role_id;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
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


        public static bool CheckDeleteStaff(string id)
        {
            DeleteStaff(id);
            string sql = "select * from staffs where id = @id";
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
    }
}
