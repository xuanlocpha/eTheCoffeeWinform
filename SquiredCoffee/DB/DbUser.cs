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
            string sql = "datasource=localhost;port=3306;username=root;password=;database=coffeeshop";
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



        public static void UpdateUser(User std,string id)
        {
            string sql = "UPDATE users SET point = @point  WHERE id=@id AND phone = @phone";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@phone", MySqlDbType.VarChar).Value = std.phone;
            cmd.Parameters.Add("@point", MySqlDbType.VarChar).Value = std.point;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Tích Điểm  Thành Công", " Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
