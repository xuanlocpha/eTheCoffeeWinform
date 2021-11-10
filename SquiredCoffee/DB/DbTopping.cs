using MySql.Data.MySqlClient;
using SquiredCoffee.Class;
using SquiredCoffee.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SquiredCoffee.DB
{
    class DbTopping
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
                System.Windows.Forms.MessageBox.Show("MySQL Connection! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return con;
        }


        public static bool CheckTopping(string @id_topping)
        {
            string sql = "select * from toppings where id = '" + @id_topping + "'";
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


        public static List<Topping> LoadTopping()
        {
            List<Topping> ToppingLists = new List<Topping>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,title,description,price,status FROM toppings ");
            foreach (DataRow item in data.Rows)
            {
                Topping topping = new Topping(item);
                ToppingLists.Add(topping);
            }

            return ToppingLists;
        }

        public static List<Topping> LoadToppingSearch(string @key)
        {
            List<Topping> ToppingLists = new List<Topping>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,title,description,price,status FROM toppings WHERE title LIKE '%" + @key + "%' OR price LIKE '%"+ @key +"%'");
            foreach (DataRow item in data.Rows)
            {
                Topping topping = new Topping(item);
                ToppingLists.Add(topping);
            }

            return ToppingLists;
        }



        public static List<Topping> LoadToppingSearchList(string @key)
        {
            List<Topping> ToppingLists = new List<Topping>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,title,description,price,status FROM toppings WHERE status = " + @key + "");
            foreach (DataRow item in data.Rows)
            {
                Topping topping = new Topping(item);
                ToppingLists.Add(topping);
            }

            return ToppingLists;
        }

        public static List<Topping> LoadTopping(string id)
        {
            List<Topping> ToppingLists = new List<Topping>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,title,description,price,status FROM toppings WHERE id = " + id + "");
            foreach (DataRow item in data.Rows)
            {
                Topping topping = new Topping(item);
                ToppingLists.Add(topping);
            }

            return ToppingLists;
        }


        public static void AddTopping(Topping std)
        {
            string sql = "INSERT INTO toppings (title,description,price,status) VALUES(@title,@description,@price,@status)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
            cmd.Parameters.Add("@description", MySqlDbType.VarChar).Value = std.description;
            cmd.Parameters.Add("@price", MySqlDbType.VarChar).Value = std.price;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
            try
            {
                cmd.ExecuteNonQuery();
              
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Thêm Topping ( Không Thành Công )! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }


        public static void UpdateTopping(Topping std,string id)
        {
            string sql = "UPDATE toppings SET title=@title,description=@description,price=@price,status=@status WHERE id=@id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
            cmd.Parameters.Add("@description", MySqlDbType.VarChar).Value = std.description;
            cmd.Parameters.Add("@price", MySqlDbType.VarChar).Value = std.price;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
            try
            {
                cmd.ExecuteNonQuery();
               
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Chỉnh sửa ( Không Thành Công )! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }


        public static void DeleteTopping(string id)
        {
            string sql = "DELETE FROM toppings  WHERE id = @id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            try
            {
                cmd.ExecuteNonQuery();
               
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Xóa Không Thành Công! \n" + ex.Message, " Cảnh Báo Lỗi ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static bool CheckToppingForm(string @key)
        {
            string sql = "select * from toppings where title = '" + @key + "'";
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




        public static List<ToppingShow> LoadToppingClick(string @key)
        {
            List<ToppingShow> toppingShows = new List<ToppingShow>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT t.id,t.title,t.description,t.price,t.status FROM toppings t WHERE t.id = '"+ @key + "'");
            foreach (DataRow item in data.Rows)
            {
                ToppingShow toppingShow = new ToppingShow(item);
                toppingShows.Add(toppingShow);
            }

            return toppingShows;
        }


        public static bool CheckCreateTopping(Topping std)
        {
            AddTopping(std);
            string sql = "select * from toppings where title = @title";
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


        public static bool CheckUpdateTopping(Topping std,string id)
        {
            UpdateTopping(std,id);
            string sql = "select * from toppings where id=@id and title = @title and description = @description and price = @price and status = @status";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
            cmd.Parameters.Add("@description", MySqlDbType.VarChar).Value = std.description;
            cmd.Parameters.Add("@price", MySqlDbType.VarChar).Value = std.price;
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

        public static bool CheckDeleteTopping(string id)
        {
            DeleteTopping(id);
            string sql = "select * from toppings where id = @id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
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
