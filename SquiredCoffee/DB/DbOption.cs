using MySql.Data.MySqlClient;
using SquiredCoffee.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SquiredCoffee.DB
{
    class DbOption
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




        public static bool CheckDb(string @title)
        {
            string sql = "select * from options where title = '" + @title + "'";
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

        public static void AddOption(Option std)
        {
            
            string sql = "INSERT INTO options (title,status) VALUES(@title,@status)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
            
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm Option Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Không Thể Thêm Option ! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }


        public static void UpdateOption(Option std, string id)
        {
            string sql = "UPDATE Options SET title=@title,status=@status  WHERE id = @id";
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

        public static void DeleteOption(string id)
        {
            string sql = "DELETE FROM options  WHERE id = @id";
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
    }
}
