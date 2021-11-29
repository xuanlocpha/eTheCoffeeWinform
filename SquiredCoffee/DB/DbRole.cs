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
    class DbRole
    {
        public static MySqlConnection GetConnection()
        {
            string sql = "SERVER=45.252.251.21;PORT=3306;DATABASE=sodopxlg_koffeeholic;UID=sodopxlg;PASSWORD=05qT1yfRp9;charset=utf8";
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


        public static void AddRole(Role std)
        {
            string sql = "INSERT INTO roles (title,status) VALUES(@title,@status)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm Quyền Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Không Thể Thêm Quyền ! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }


        public static void UpdateRole(Role std, string id)
        {
            string sql = "UPDATE roles SET title = @title,status = @status  WHERE id = @id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Chỉnh Sửa Thành Công", " Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Chỉnh Sửa Không Thành Công! \n" + ex.Message, " Cảnh Báo Lỗi ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();

        }


        public static void DeleteCategory(string id)
        {
            string sql = "DELETE FROM categories  WHERE id = @id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa Thành Công ", " Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Xóa Không Thành Công! \n" + ex.Message, " Cảnh Báo Lỗi ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        public static List<Role> LoadRoleList()
        {
            List<Role> roleList = new List<Role>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,title,status FROM roles ");
            foreach (DataRow item in data.Rows)
            {
                Role role = new Role(item);
                roleList.Add(role);
            }

            return roleList;
        }


        public static bool CheckRole(string @title)
        {
            string sql = "select * from roles where title = '" + @title + "'";
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

        public static List<Role> LoadRoleList(string @key)
        {
            List<Role> roleList = new List<Role>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,title,status FROM roles WHERE id ='"+@key+"' ");
            foreach (DataRow item in data.Rows)
            {
                Role role = new Role(item);
                roleList.Add(role);
            }

            return roleList;
        }


        public static List<Role> LoadStatusRoleList(string @key)
        {
            List<Role> roleList = new List<Role>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,title,status FROM roles WHERE status ='"+@key+"' ");
            foreach (DataRow item in data.Rows)
            {
                Role role = new Role(item);
                roleList.Add(role);
            }

            return roleList;
        }


        public static List<Role> LoadSearchRoleList(string @key)
        {
            List<Role> roleList = new List<Role>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,title,status FROM roles WHERE title LIKE'%" + @key + "%'");
            foreach (DataRow item in data.Rows)
            {
                Role role = new Role(item);
                roleList.Add(role);
            }

            return roleList;
        }
    }
}
