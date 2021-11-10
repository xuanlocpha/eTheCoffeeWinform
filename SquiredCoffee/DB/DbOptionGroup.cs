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
            string sql = "SERVER=45.252.251.29;PORT=3306;DATABASE=sodopxlg_koffeeholic;UID=sodopxlg;PASSWORD=05qT1yfRp9";
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
  
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Chỉnh sửa ( Không thành công ) ! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }


        public static void LockOptionGroup(OptionGroup std, string id)
        {
            string sql = "UPDATE option_groups SET title=@title,status=@status  WHERE id = @id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = 0;
            try
            {
                cmd.ExecuteNonQuery();

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

        public static bool CheckCreateOptionGroup(OptionGroup std)
        {
            AddOptionGoup(std);
            string sql = "select * from option_groups where title = @title";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
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

        public static bool CheckUpdateOptionGroup(OptionGroup std, string id)
        {
            UpdateOptionGroup(std,id);
            string sql = "select * from option_groups where title = @title and status = @status";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
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

        public static bool CheckLockOptionGroup(OptionGroup std, string id)
        {
            LockOptionGroup(std, id);
            string sql = "select * from option_groups where title = @title and status = @status";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
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
