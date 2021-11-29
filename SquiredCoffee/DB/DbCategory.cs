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
    class DbCategory
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


        public static void AddCategory(Category std)
        {
            string sql = "INSERT INTO categories (title,type,status) VALUES(@title,@type,@status)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
            cmd.Parameters.Add("@type", MySqlDbType.VarChar).Value = std.type;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
            try
            {
                cmd.ExecuteNonQuery();
               
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Không Thể Thêm Loại Sản Phẩm ! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }


        public static void UpdateCategory(Category std, string id)
        {
            string sql = "UPDATE categories SET title = @title,type = @type,status = @status  WHERE id = @id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
            cmd.Parameters.Add("@type", MySqlDbType.VarChar).Value = std.type;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
            try
            {
                cmd.ExecuteNonQuery();
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Chỉnh sửa loại sản phẩm  ( Không thành công !) \n" + ex.Message, " Cảnh Báo Lỗi ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
           
        }


        public static void LockCategory(string id)
        {
            string sql = "UPDATE categories SET status = @status  WHERE id = @id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = 0;
            try
            {
                cmd.ExecuteNonQuery();
               
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Khóa loại sản phẩm  ( Không thành công !) \n" + ex.Message, " Cảnh Báo Lỗi ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        public static List<Category> LoadCategoryList()
        {
            List<Category> categoryList = new List<Category>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,title,type,status FROM categories ");
            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                categoryList.Add(category);
            }

            return categoryList;
        }


        public static List<Category> LoadCategoryList(string @id_category)
        {
            List<Category> categoryList = new List<Category>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,title,type,status FROM categories WHERE id = '"+id_category+"' ");
            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                categoryList.Add(category);
            }

            return categoryList;
        }


        public static List<Category> LoadCategorySearchList(string @key)
        {
            List<Category> categoryList = new List<Category>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,title,type,status FROM categories WHERE title LIKE'%" + @key + "%' OR type LIKE'%" + @key + "%'");
            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                categoryList.Add(category);
            }

            return categoryList;
        }



        public static List<Category> LoadCategoryStatusList(string @status)
        {
            List<Category> categoryList = new List<Category>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,title,type,status FROM categories WHERE status = '"+@status+"'");
            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                categoryList.Add(category);
            }

            return categoryList;
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

        public static bool CheckTitleCategory(string @titleCategory)
        {
            string sql = "select * from categories where title ='"+titleCategory+"'";
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


        public static bool CheckCreateCategory(Category std)
        {
            AddCategory(std);
            string sql = "select * from categories where title = @title";
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


        public static bool CheckUpdateCategory(Category std,string id)
        {
            UpdateCategory(std,id);
            string sql = "select * from categories where id = @id and title = @title and type = @type and status = @status";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
            cmd.Parameters.Add("@type", MySqlDbType.VarChar).Value = std.type;
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


        public static bool CheckLockCategory(Category std, string id)
        {
            UpdateCategory(std, id);
            string sql = "select * from categories where id = @id and title = @title and type = @type and status = @status";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
            cmd.Parameters.Add("@type", MySqlDbType.VarChar).Value = std.type;
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
