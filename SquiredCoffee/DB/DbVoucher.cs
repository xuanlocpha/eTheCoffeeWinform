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
    class DbVoucher
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

        public static void AddVoucher(Voucher std)
        {
            string sql = "INSERT INTO tables (title,content,coupen_code,image,qr_code,start_date,expiry_date,disscount_unit,disscount,minimum_order,status) VALUES(@title,@content,@coupen_code,@image,qr_code,@start_date,@expiry_date,@disscount_unit,@disscount,@minimum_order,@status)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
            cmd.Parameters.Add("@content", MySqlDbType.VarChar).Value = std.content;
            cmd.Parameters.Add("@coupen_code", MySqlDbType.VarChar).Value = std.coupen_code;
            cmd.Parameters.Add("@image", MySqlDbType.VarChar).Value = std.image;
            cmd.Parameters.Add("@qr_code", MySqlDbType.VarChar).Value = std.qr_code;
            cmd.Parameters.Add("@start_date", MySqlDbType.VarChar).Value = std.start_date;
            cmd.Parameters.Add("@expiry_date", MySqlDbType.VarChar).Value = std.expiry_date;
            cmd.Parameters.Add("@disscount_unit", MySqlDbType.VarChar).Value = std.disscount_unit;
            cmd.Parameters.Add("@disscount", MySqlDbType.VarChar).Value = std.disscount;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm Bàn  Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Không Thể Thêm Bàn ! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
