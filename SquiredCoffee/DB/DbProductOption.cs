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
    class DbProductOption
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


        public static void AddProductOption(ProductOption std)
        {
            string sql = "INSERT INTO product_options (product_id,option_id,title,price,defaults,status) VALUES(@product_id,@option_id,@title,@price,@defaults,@status)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@product_id", MySqlDbType.VarChar).Value = std.product_id;
            cmd.Parameters.Add("@option_id", MySqlDbType.VarChar).Value = std.option_id;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
            cmd.Parameters.Add("@price", MySqlDbType.VarChar).Value = std.price;
            cmd.Parameters.Add("@defaults", MySqlDbType.VarChar).Value = std.defaults;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm Option cho sản phẩm Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Thêm Option cho sản phẩm Không Thành Công ! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }


        public static void UpdateProductOption(ProductOption std, string id)
        {
            string sql = "UPDATE product_options SET product_id=@product_id,option_id=@option_id,title=@title,price=@price,defaults=@defaults,status=@status  WHERE id = @id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@product_id", MySqlDbType.VarChar).Value = std.product_id;
            cmd.Parameters.Add("@option_id", MySqlDbType.VarChar).Value = std.option_id;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
            cmd.Parameters.Add("@price", MySqlDbType.VarChar).Value = std.price;
            cmd.Parameters.Add("@defaults", MySqlDbType.VarChar).Value = std.defaults;
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


        public static void DeleteProductOption(string id)
        {
            string sql = "DELETE FROM product_options  WHERE id = @id";
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
    }
}
