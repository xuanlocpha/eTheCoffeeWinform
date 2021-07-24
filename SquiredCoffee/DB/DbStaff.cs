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


        public static void AddStaff(Staff std)
        {
            string sql = "INSERT INTO staffs (employee_code,full_name,username,password,gender,birthday,image,phone,email,address,role_id,status) VALUES(@employee_code,@full_name,@username,@password,@gender,@birthday,@image,@phone,@email,@address,@role_id,@status)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@employee_code", MySqlDbType.VarChar).Value = std.employee_code;
            cmd.Parameters.Add("@full_name", MySqlDbType.VarChar).Value = std.full_name;
            cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = std.username;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = std.password;
            cmd.Parameters.Add("@gender", MySqlDbType.VarChar).Value = std.gender;
            cmd.Parameters.Add("@birthday", MySqlDbType.VarChar).Value = std.birthday;
            cmd.Parameters.Add("@image", MySqlDbType.VarChar).Value = std.image;
            cmd.Parameters.Add("@phone", MySqlDbType.VarChar).Value = std.phone;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = std.email;
            cmd.Parameters.Add("@address", MySqlDbType.VarChar).Value = std.address;
            cmd.Parameters.Add("@role_id", MySqlDbType.VarChar).Value = std.role_id;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;


            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm Sản Phẩm Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Không Thể Thêm Sản Phẩm ! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static void UpdateStaff(Staff std, string id)
        {
            string sql = "UPDATE staffs SET employee_code=@employee_code,full_name=@full_name,username=@username,password=@password,gender=@gender,birthday=@birthday,image=@image,phone=@phone,email=@email,address=@address,role_id=@role_id,status=@status  WHERE id = @id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@employee_code", MySqlDbType.VarChar).Value = std.employee_code;
            cmd.Parameters.Add("@full_name", MySqlDbType.VarChar).Value = std.full_name;
            cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = std.username;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = std.password;
            cmd.Parameters.Add("@gender", MySqlDbType.VarChar).Value = std.gender;
            cmd.Parameters.Add("@birthday", MySqlDbType.VarChar).Value = std.birthday;
            cmd.Parameters.Add("@image", MySqlDbType.VarChar).Value = std.image;
            cmd.Parameters.Add("@phone", MySqlDbType.VarChar).Value = std.phone;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = std.email;
            cmd.Parameters.Add("@address", MySqlDbType.VarChar).Value = std.address;
            cmd.Parameters.Add("@role_id", MySqlDbType.VarChar).Value = std.role_id;
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
