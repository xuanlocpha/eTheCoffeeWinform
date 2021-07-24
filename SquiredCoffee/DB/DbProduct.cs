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
    class DbProduct
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

        public static void AddProduct(Product std)
        {
            string sql = "INSERT INTO products (category_id,title,price,image,content,status) VALUES(@category_id,@title,@price,@image,@content,@status)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@category_id", MySqlDbType.VarChar).Value = std.category_id;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
            cmd.Parameters.Add("@price", MySqlDbType.VarChar).Value = std.price;
            cmd.Parameters.Add("@image", MySqlDbType.VarChar).Value = std.image;
            cmd.Parameters.Add("@content", MySqlDbType.VarChar).Value = std.content;
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

        public static void UpdateProduct(Product std, string id)
        {
            string sql = "UPDATE products SET category_id=@category_id,title=@title,price=@price,image=@image,content=@content,status=@status  WHERE id = @id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@category_id", MySqlDbType.VarChar).Value = std.category_id;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
            cmd.Parameters.Add("@price", MySqlDbType.VarChar).Value = std.price;
            cmd.Parameters.Add("@image", MySqlDbType.VarChar).Value = std.image;
            cmd.Parameters.Add("@content", MySqlDbType.VarChar).Value = std.content;
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

        public static void DeleteProduct(string id)
        {
            string sql = "DELETE FROM products  WHERE id = @id";
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


        public static List<Product> LoadProductList()
        {
            List<Product> productList = new List<Product>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,category_id,title,price,image,content,status FROM products WHERE status = 1");

            foreach (DataRow item in data.Rows)
            {
                Product product = new Product(item);
                productList.Add(product);
            }

            return productList;
        }

        public static List<Product> LoadProductList(string query)
        {
            List<Product> productList = new List<Product>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,category_id,title,price,image,content,status FROM products WHERE title LIKE'%" + query + "%'");
            foreach (DataRow item in data.Rows)
            {
                Product product = new Product(item);
                productList.Add(product);
            }

            return productList;
        }


        public static List<Product> LoadProductListOnCategory(string query)
        {
            List<Product> productList = new List<Product>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,category_id,title,price,image,content,status FROM products WHERE category_id = '"+query+"' ");
            foreach (DataRow item in data.Rows)
            {
                Product product = new Product(item);
                productList.Add(product);
            }

            return productList;
        }

        public static List<Product> LoadProduct(string id)
        {
            List<Product> productList = new List<Product>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,category_id,title,price,image,content,status FROM products WHERE id = "+id+"");
            foreach (DataRow item in data.Rows)
            {
                Product product = new Product(item);
                productList.Add(product);
            }

            return productList;
        }
    }
}
