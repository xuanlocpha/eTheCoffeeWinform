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


        public static void AddRole(Role std)
        {
            string sql = "INSERT INTO categories (title) VALUES(@title)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;

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
            string sql = "UPDATE categories SET title = @title  WHERE id = @id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;

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
    }
}
