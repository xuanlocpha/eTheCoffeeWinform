using MySql.Data.MySqlClient;
using SquiredCoffee.Class;
using SquiredCoffee.ViewModels;
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
            string sql = "SERVER=45.252.251.21;PORT=3306;DATABASE=sodopxlg_koffeeholic;UID=sodopxlg;PASSWORD=05qT1yfRp9;charset=utf8";
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
            
            string sql = "INSERT INTO options (option_group_id,title,status) VALUES(@option_group_id,@title,@status)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@option_group_id", MySqlDbType.VarChar).Value = std.option_group_id;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
            try
            {
                cmd.ExecuteNonQuery();
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Không Thể Thêm Option ! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }


        public static void UpdateOption(Option std, string id)
        {
            string sql = "UPDATE options SET option_group_id = @option_group_id,title=@title,status=@status  WHERE id = @id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@option_group_id", MySqlDbType.VarChar).Value = std.option_group_id;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
            try
            {
                cmd.ExecuteNonQuery();
              
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Chỉnh Sửa  ( Không Thành Công )! \n" + ex.Message, " Cảnh Báo Lỗi ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Xóa ( Thành công )", " Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Xóa ( Không thành công )! \n" + ex.Message, " Cảnh Báo Lỗi ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        public static List<OptionShow1> LoadOption()
        {
            List<OptionShow1> optionShow1List = new List<OptionShow1>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT o.id,o.title,o.option_group_id,o.status,og.title as name_option_group FROM options o, option_groups og WHERE  o.option_group_id = og.id");
            foreach (DataRow item in data.Rows)
            {
                OptionShow1 optionShow1 = new OptionShow1(item);
                optionShow1List.Add(optionShow1);
            }

            return optionShow1List;
        }


        public static List<OptionShow1> LoadOption(string id)
        {
            List<OptionShow1> optionShow1List = new List<OptionShow1>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT o.id,o.title,o.option_group_id,o.status,og.title as name_option_group FROM options o, option_groups og WHERE  o.option_group_id = og.id AND o.id ='"+id+"'");
            foreach (DataRow item in data.Rows)
            {
                OptionShow1 optionShow1 = new OptionShow1(item);
                optionShow1List.Add(optionShow1);
            }

            return optionShow1List;
        }


        public static List<OptionShow1> LoadOptionSearch(string @key)
        {
            List<OptionShow1> optionShow1List = new List<OptionShow1>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT o.id,o.title,o.option_group_id,o.status,og.title as name_option_group FROM options o, option_groups og WHERE  o.option_group_id = og.id AND o.status = '"+@key+"'");
            foreach (DataRow item in data.Rows)
            {
                OptionShow1 optionShow1 = new OptionShow1(item);
                optionShow1List.Add(optionShow1);
            }

            return optionShow1List;
        }


        public static List<OptionShow1> LoadOptionSearch1(string @key)
        {
            List<OptionShow1> optionShow1List = new List<OptionShow1>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT o.id,o.title,o.option_group_id,o.status,og.title as name_option_group FROM options o INNER JOIN option_groups og ON o.option_group_id = og.id  WHERE o.title LIKE '%" + @key + "%' OR og.title LIKE '%" + @key + "%'");
            foreach (DataRow item in data.Rows)
            {
                OptionShow1 optionShow1 = new OptionShow1(item);
                optionShow1List.Add(optionShow1);
            }

            return optionShow1List;
        }


        public static List<Option> LoadOption(string id_product,string nameOption)
        {
            List<Option> optionLists = new List<Option>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT po.id,po.title,po.price,po.defaults,o.title as name_option,o.id as id_option  FROM products p INNER JOIN product_options po ON p.id = po.product_id , product_options po INNER JOIN options o ON po.option_id = o.id , options o INNER JOIN option_groups og ON o.option_group_id = og.id WHERE p.id ='"+id_product+"' AND og.title ='"+nameOption+"' ");
            foreach (DataRow item in data.Rows)
            {
                Option option = new Option(item);
                optionLists.Add(option);
            }

            return optionLists;
        }


        public static bool CheckOption(string @id_option)
        {
            string sql = "select * from options where id = '" +@id_option+ "'";
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


        public static List<OptionShow> OptionShow(string @id_option,string @id_product)
        {
            List<OptionShow> option_Show_List = new List<OptionShow>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT o.id,o.title,o.option_group_id,o.status,po.price as price FROM options o,product_options po WHERE o.id = '"+@id_option+ "' and po.option_id = '" + @id_option + "' and po.product_id = '"+@id_product+"'");
            foreach (DataRow item in data.Rows)
            {
                OptionShow option_Show = new OptionShow(item);
                option_Show_List.Add(option_Show);
            }

            return option_Show_List;
        }

        public static bool CheckCreateOption(Option std)
        {
            AddOption(std);
            string sql = "select * from options where title = @title";
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

        public static bool CheckUpdateOption(Option std,string id)
        {
            UpdateOption(std,id);
            string sql = "select * from options where id = @id and option_group_id = @option_group_id and title = @title  and status = @status";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@option_group_id", MySqlDbType.VarChar).Value = std.option_group_id;
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


        public static bool CheckLockOption(Option std, string id)
        {
            UpdateOption(std, id);
            string sql = "select * from options where id = @id and option_group_id = @option_group_id and title = @title  and status = @status";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@option_group_id", MySqlDbType.VarChar).Value = std.option_group_id;
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
