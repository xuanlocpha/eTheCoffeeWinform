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
            string sql = "INSERT INTO roles (title,quantity,unit,status) VALUES(@title,@quantity,@unit,@status)";
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
                MessageBox.Show("Thêm Sản Phẩm Kho ( Thành Công )", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Chỉnh Sửa ( Thành Công )", " Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Xóa Sản Phẩm Kho( Thành Công )", " Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Xóa Sản Phẩm Kho( Không Thành Công ) \n" + ex.Message, " Cảnh Báo Lỗi ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }



    }
}
