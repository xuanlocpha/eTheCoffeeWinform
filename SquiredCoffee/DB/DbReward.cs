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
    class DbReward
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

        public static void AddReward(Rewards std)
        {
            string sql = "INSERT INTO rewards (title,content,image,start_date,expiry_date,point,status) VALUES(@title,@content,@image,@start_date,@expiry_date,@point,@status)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
            cmd.Parameters.Add("@content", MySqlDbType.VarChar).Value = std.content;
            cmd.Parameters.Add("@image", MySqlDbType.VarChar).Value = std.image;
            cmd.Parameters.Add("@start_date", MySqlDbType.VarChar).Value = std.start_date;
            cmd.Parameters.Add("@expiry_date", MySqlDbType.VarChar).Value = std.expiry_date;
            cmd.Parameters.Add("@point", MySqlDbType.VarChar).Value = std.point;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm Phần Thưởng  Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Không Thể Thêm Phần Thưởng ! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static void UpdateReward(Rewards std, string id)
        {
            string sql = "UPDATE  rewards SET title=@title,content=@content,image=@image,start_date=@start_date,expiry_date=@expiry_date,point=@point,status=@status  WHERE id = @id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
            cmd.Parameters.Add("@content", MySqlDbType.VarChar).Value = std.content;
            cmd.Parameters.Add("@image", MySqlDbType.VarChar).Value = std.image;
            cmd.Parameters.Add("@start_date", MySqlDbType.VarChar).Value = std.start_date;
            cmd.Parameters.Add("@expiry_date", MySqlDbType.VarChar).Value = std.expiry_date;
            cmd.Parameters.Add("@point", MySqlDbType.VarChar).Value = std.point;
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


        public static void DeleteReward(string id)
        {
            string sql = "DELETE FROM rewards  WHERE id = @id";
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
