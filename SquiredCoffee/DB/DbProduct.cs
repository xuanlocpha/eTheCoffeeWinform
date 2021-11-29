using MySql.Data.MySqlClient;
using SquiredCoffee.Class;
using SquiredCoffee.CustomControls;
using SquiredCoffee.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
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


        public static List<ProductShow> LoadProductList1()
        {
            List<ProductShow> productShowList = new List<ProductShow>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT p.id,p.category_id,p.title,p.price,p.image,p.content,p.status,c.title as title_category FROM products p,categories c WHERE p.category_id = c.id ");

            foreach (DataRow item in data.Rows)
            {
                ProductShow productShow = new ProductShow(item);
                productShowList.Add(productShow);
            }

            return productShowList;
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


        public static List<ProductShow> LoadProductStatusList(string @status)
        {
            List<ProductShow> productShowList = new List<ProductShow>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT p.id,p.category_id,p.title,p.price,p.image,p.content,p.status,c.title as title_category FROM products p,categories c WHERE p.category_id = c.id AND p.status ='"+@status+"'");

            foreach (DataRow item in data.Rows)
            {
                ProductShow productShow = new ProductShow(item);
                productShowList.Add(productShow);
            }

            return productShowList;
        }


        public static List<ProductShow> LoadProductSearchList(string @key)
        {
            List<ProductShow> productShowList = new List<ProductShow>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT p.id,p.category_id,p.title,p.price,p.image,p.content,p.status,c.title as title_category FROM products p INNER JOIN categories c ON p.category_id = c.id WHERE c.title LIKE'%" + @key + "%' OR p.title LIKE'%" + @key + "%' OR p.price LIKE'%" + @key + "%'");

            foreach (DataRow item in data.Rows)
            {
                ProductShow productShow = new ProductShow(item);
                productShowList.Add(productShow);
            }

            return productShowList;
        }


        public static List<ProductShow> LoadProductSearchList1(string @key)
        {
            List<ProductShow> productShowList = new List<ProductShow>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT p.id,p.category_id,p.title,p.price,p.image,p.content,p.status,c.title as title_category FROM products p INNER JOIN categories c ON p.category_id = c.id WHERE c.title = '" + @key + "' ");

            foreach (DataRow item in data.Rows)
            {
                ProductShow productShow = new ProductShow(item);
                productShowList.Add(productShow);
            }

            return productShowList;
        }



        public static List<ProductShow> LoadProductList2(string @key)
        {
            List<ProductShow> productShowList = new List<ProductShow>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT p.id,p.category_id,p.title,p.price,p.image,p.content,p.status,c.title as title_category FROM products p INNER JOIN categories c ON p.category_id = c.id WHERE p.id ='" + @key + "%' ");

            foreach (DataRow item in data.Rows)
            {
                ProductShow productShow = new ProductShow(item);
                productShowList.Add(productShow);
            }

            return productShowList;
        }



        public static bool CheckProduct(string @key)
        {
            string sql = "select * from products where title = '" + @key + "'";
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

        public static Image LoadBase64(string base64)
        {
            byte[] bytes = Convert.FromBase64String(base64);
            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }
            return image;
        }


        public static List<ProductShow> LoadProductListTop()
        {
            List<ProductShow> productShowList = new List<ProductShow>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT p.id,p.category_id,p.title,p.price,p.image,p.content,p.status,c.title as title_category FROM products p,categories c WHERE p.category_id = c.id ");

            foreach (DataRow item in data.Rows)
            {
                ProductShow productShow = new ProductShow(item);
                productShowList.Add(productShow);
            }

            return productShowList;
        }



        public static bool CheckCreateProduct(Product std)
        {
            AddProduct(std);
            string sql = "select * from products where title = @title";
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


        public static bool CheckUpdateProduct(Product std,string id)
        {
            UpdateProduct(std,id);
            string sql = "select * from products where category_id = @category_id and title = @title and title = @title and price = @price and image = @image and content = @content and status = @status";
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


        public static bool CheckDeleteProduct(string id)
        {
            DeleteProduct(id);
            string sql = "select * from products where id = @id";
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
