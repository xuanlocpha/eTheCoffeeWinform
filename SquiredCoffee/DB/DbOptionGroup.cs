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
    class DbOptionGroup
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


        public static List<OptionGroup> LoadOptionGroup()
        {
            List<OptionGroup> optionGroupLists = new List<OptionGroup>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,title,status FROM option_groups ");
            foreach (DataRow item in data.Rows)
            {
                OptionGroup optionGroup = new OptionGroup(item);
                optionGroupLists.Add(optionGroup);
            }

            return optionGroupLists;
        }

        public static List<OptionGroup> LoadOptionGroup(string title)
        {
            List<OptionGroup> optionGroupLists = new List<OptionGroup>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,title,status FROM option_groups WHERE title ='"+title+"'");
            foreach (DataRow item in data.Rows)
            {
                OptionGroup optionGroup = new OptionGroup(item);
                optionGroupLists.Add(optionGroup);
            }

            return optionGroupLists;
        }


        public static List<OptionGroup> LoadOptionGroup1(string @key)
        {
            List<OptionGroup> optionGroupLists = new List<OptionGroup>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,title,status FROM option_groups WHERE id='"+@key+"' ");
            foreach (DataRow item in data.Rows)
            {
                OptionGroup optionGroup = new OptionGroup(item);
                optionGroupLists.Add(optionGroup);
            }

            return optionGroupLists;
        }

        public static List<OptionGroup> LoadOptionGroupSearch(string @key)
        {
            List<OptionGroup> optionGroupLists = new List<OptionGroup>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,title,status FROM option_groups WHERE status ='" + @key + "'");
            foreach (DataRow item in data.Rows)
            {
                OptionGroup optionGroup = new OptionGroup(item);
                optionGroupLists.Add(optionGroup);
            }

            return optionGroupLists;
        }


        public static List<OptionGroup> LoadOptionGroupSearchKey(string @key)
        {
            List<OptionGroup> optionGroupLists = new List<OptionGroup>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,title,status FROM option_groups WHERE title like'%" + @key + "%'");
            foreach (DataRow item in data.Rows)
            {
                OptionGroup optionGroup = new OptionGroup(item);
                optionGroupLists.Add(optionGroup);
            }

            return optionGroupLists;
        }


        public static void AddOptionGoup(OptionGroup std)
        {
            string sql = "INSERT INTO option_groups (title,status) VALUES(@title,@status)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm tùy chọn sản phẩm ( Thành công )", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Thêm tùy chọn sản phẩm ( Không thành công ) ! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }



        public static void UpdateOptionGroup(OptionGroup std,string id)
        {
            string sql = "UPDATE option_groups SET title=@title,status=@status  WHERE id = @id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Chỉnh sửa ( Thành công )", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Chỉnh sửa ( Không thành công ) ! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }


        public static void DeleteOptionGroup(string id)
        {
            string sql = "DELETE FROM option_groups  WHERE id = @id";
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


        public static bool CheckOptionGroup(string @title)
        {
            string sql = "select * from option_groups where title = '" + @title + "'";
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
    }
}
