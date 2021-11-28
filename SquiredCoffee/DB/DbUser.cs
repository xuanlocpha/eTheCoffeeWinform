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
    class DbUser
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



        public static void UpdateUser(string point,string id)
        {
            string sql = "UPDATE users SET point = @point  WHERE id=@id ";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@point", MySqlDbType.VarChar).Value = point;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Tích Điểm Không Thành Công! \n" + ex.Message, " Cảnh Báo Lỗi ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();

        }


        public static List<User> UserList(string phone)
        {
            List<User> userList = new List<User>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,first_name,last_name,gender,email,phone,point FROM users  WHERE  phone = '"+phone+"'");

            foreach (DataRow item in data.Rows)
            {
                User user = new User(item);
                userList.Add(user);
            }

            return userList;
        }


        public static List<User> ListUser(string phone)
        {
            List<User> userList = new List<User>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,display_name,gender,birthday,email,phone,image,point,total_point,level,bar_code,status,password FROM users  WHERE  phone = '" + phone + "'");

            foreach (DataRow item in data.Rows)
            {
                User user = new User(item);
                userList.Add(user);
            }

            return userList;
        }


        public static List<User> ListUser()
        {
            List<User> userList = new List<User>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,display_name,gender,birthday,email,phone,image,point,total_point,level,bar_code,status,password FROM users  WHERE status = 1 OR status = 0");

            foreach (DataRow item in data.Rows)
            {
                User user = new User(item);
                userList.Add(user);
            }

            return userList;
        }


        public static List<User> ListUserSearchStatus(string status)
        {
            List<User> userList = new List<User>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,display_name,gender,birthday,email,phone,image,point,total_point,level,bar_code,status,password FROM users  WHERE status = '"+status+"' ");

            foreach (DataRow item in data.Rows)
            {
                User user = new User(item);
                userList.Add(user);
            }

            return userList;
        }

        public static List<User> ListUserInformation(string id)
        {
            List<User> userList = new List<User>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,display_name,gender,birthday,email,phone,image,point,total_point,level,bar_code,status,password FROM users  WHERE id = '"+id+"'");

            foreach (DataRow item in data.Rows)
            {
                User user = new User(item);
                userList.Add(user);
            }

            return userList;
        }


        public static List<User> ListUserSearchClick(string status)
        {
            List<User> userList = new List<User>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,display_name,gender,birthday,email,phone,image,point,total_point,level,bar_code,status,password FROM users WHERE status = '"+status+"'  ");

            foreach (DataRow item in data.Rows)
            {
                User user = new User(item);
                userList.Add(user);
            }

            return userList;
        }


        public static List<User> ListUserSearch(string key)
        {
            List<User> userList = new List<User>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,display_name,gender,birthday,email,phone,image,point,total_point,level,bar_code,status,password FROM users WHERE phone LIKE'%" + @key + "%' OR email LIKE'%" + @key + "%'  ");

            foreach (DataRow item in data.Rows)
            {
                User user = new User(item);
                userList.Add(user);
            }

            return userList;
        }
        
        public static bool CheckDb(string @phone)
        {
            string sql = "select * from users where phone = '" + @phone + "'";
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


        public static bool accumulatePoints(string @point,string @id)
        {
            UpdateUser(point, id);
            string sql = "select * from users where point = '" +@point +"' and id ='"+@id+"'";
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

        public static List<User> UserSearch(string phone)
        {
            List<User> userList = new List<User>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,display_name,gender,birthday,email,phone,image,point,total_point,level,bar_code,status,password FROM users  WHERE  phone = '" + phone + "'");

            foreach (DataRow item in data.Rows)
            {
                User user = new User(item);
                userList.Add(user);
            }

            return userList;
        }

        public static void UpdateUserShow(string status,string id)
        {

            string sql = "UPDATE users SET status=@status WHERE id = @id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = status;
            try
            {
                cmd.ExecuteNonQuery();
         //       MessageBox.Show("Update Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Update Không Thành Công ! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }


        public static bool CheckUpdateUser(string status, string id)
        {
            UpdateUserShow(status, id);
            string sql = "select * from users where  id= '" + id + "' AND status = '" + status + "'";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = status;
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
