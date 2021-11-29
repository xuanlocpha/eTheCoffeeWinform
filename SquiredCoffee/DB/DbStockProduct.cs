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
    class DbStockProduct
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


        public static List<StockProduct> LoadStockProductList()
        {
            List<StockProduct> stockProductList = new List<StockProduct>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,title,quantity,unit,status FROM stock_products ");
            foreach (DataRow item in data.Rows)
            {
                StockProduct stockProduct = new StockProduct(item);
                stockProductList.Add(stockProduct);
            }

            return stockProductList;
        }

        public static List<StockProduct> LoadStockProductList(string @key)
        {
            List<StockProduct> stockProductList = new List<StockProduct>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,title,quantity,unit,status FROM stock_products WHERE id ='"+@key+"' ");
            foreach (DataRow item in data.Rows)
            {
                StockProduct stockProduct = new StockProduct(item);
                stockProductList.Add(stockProduct);
            }

            return stockProductList;
        }



        public static List<StockProduct> LoadStockProductSearchClickList(string @key)
        {
            List<StockProduct> stockProductList = new List<StockProduct>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,title,quantity,unit,status FROM stock_products WHERE status ='"+@key+"' ");
            foreach (DataRow item in data.Rows)
            {
                StockProduct stockProduct = new StockProduct(item);
                stockProductList.Add(stockProduct);
            }

            return stockProductList;
        }



        public static List<StockProduct> LoadStockProductSearchList(string @key)
        {
            List<StockProduct> stockProductList = new List<StockProduct>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,title,quantity,unit,status FROM stock_products WHERE title LIKE'%" + @key + "%' OR unit LIKE'%" + @key + "%' ");
            foreach (DataRow item in data.Rows)
            {
                StockProduct stockProduct = new StockProduct(item);
                stockProductList.Add(stockProduct);
            }

            return stockProductList;
        }


        public static List<StockProduct> LoadStockProductSearchList1(string @key)
        {
            List<StockProduct> stockProductList = new List<StockProduct>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,title,quantity,unit,status FROM stock_products WHERE id = '"+key+"'");
            foreach (DataRow item in data.Rows)
            {
                StockProduct stockProduct = new StockProduct(item);
                stockProductList.Add(stockProduct);
            }

            return stockProductList;
        }

        public static bool CheckAdd(string @key)
        {
            string sql = "select * from stock_products where title = '" + @key + "'";
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

        public static void AddStockProduct(StockProduct std)
        {
            string sql = "INSERT INTO stock_products (title,quantity,unit,status) VALUES(@title,@quantity,@unit,@status)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
            cmd.Parameters.Add("@quantity", MySqlDbType.VarChar).Value = std.quantity;
            cmd.Parameters.Add("@unit", MySqlDbType.VarChar).Value = std.unit;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
            try
            {
                cmd.ExecuteNonQuery();
          
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Thêm Sản Phẩm Kho ( Không Thành Công ) ! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }


        public static void UpdateStockProduct(StockProduct std, string id)
        {
            string sql = "UPDATE stock_products SET title=@title,quantity=@quantity,unit=@unit,status=@status  WHERE id = @id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
            cmd.Parameters.Add("@quantity", MySqlDbType.VarChar).Value = std.quantity;
            cmd.Parameters.Add("@unit", MySqlDbType.VarChar).Value = std.unit;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
            try
            {
                cmd.ExecuteNonQuery();
    
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Chỉnh Sửa ( Không Thành Công )! \n" + ex.Message, " Cảnh Báo Lỗi ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();

        }
        public static void DeleteStockProduct(string id)
        {
            string sql = "DELETE FROM stock_products  WHERE id = @id";
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
                MessageBox.Show("Xóa Sản Phẩm Kho( Không Thành Công ) \n" + ex.Message, " Cảnh Báo Lỗi ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static List<StockProduct> LoadStockProductCheck(string @key)
        {
            List<StockProduct> stockProductList = new List<StockProduct>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,title,quantity,unit,status FROM stock_products WHERE id ='"+@key+"' ");
            foreach (DataRow item in data.Rows)
            {
                StockProduct stockProduct = new StockProduct(item);
                stockProductList.Add(stockProduct);
            }

            return stockProductList;
        }

        public static bool CheckCreateStockProduct(StockProduct std)
        {
            AddStockProduct(std);
            string sql = "select * from stock_products where title = @title";
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


        public static bool CheckUpdateStockProduct(StockProduct std,string id)
        {
            UpdateStockProduct(std,id);
            string sql = "select * from stock_products where id =@id and title=@title and quantity=@quantity and unit=@unit and status=@status";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
            cmd.Parameters.Add("@quantity", MySqlDbType.VarChar).Value = std.quantity;
            cmd.Parameters.Add("@unit", MySqlDbType.VarChar).Value = std.unit;
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


        public static bool CheckDeleteStockProduct(string id)
        {
            DeleteStockProduct(id);
            string sql = "select * from stock_products where id = @id";
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
