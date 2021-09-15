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
    class DbProductTopping
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
                System.Windows.Forms.MessageBox.Show("MySQL Connection! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return con;
        }



        public static void AddProductTopping(ProductTopping std)
        {
            string sql = "INSERT INTO product_toppings (product_id,topping_id,status) VALUES(@product_id,@topping_id,@status)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@product_id", MySqlDbType.VarChar).Value = std.product_id;
            cmd.Parameters.Add("@topping_id", MySqlDbType.VarChar).Value = std.topping_id;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm Topping Sản Phẩm  ( Thành Công ) ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Thêm Topping Sản Phẩm ( Không Thành Công )! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }


        public static void UpdateProductTopping(ProductTopping std,string id)
        {
            string sql = "UPDATE product_toppings SET product_id=@product_id,topping_id=@topping_id,status=@status  WHERE id = @id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@product_id", MySqlDbType.VarChar).Value = std.product_id;
            cmd.Parameters.Add("@topping_id", MySqlDbType.VarChar).Value = std.topping_id;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Chỉnh sửa Topping Sản Phẩm  ( Thành Công ) ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Chỉnh sửa Topping Sản Phẩm  ( Không Thành Công ) ! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static List<ProductToppingShow> LoadProductTopping()
        {
            List<ProductToppingShow> productToppingShows = new List<ProductToppingShow>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT pt.id,pt.product_id,pt.topping_id,pt.status,p.title as name_product,t.title as name_topping FROM product_toppings pt INNER JOIN products p ON pt.product_id = p.id INNER JOIN toppings t ON pt.topping_id = t.id ");
            foreach (DataRow item in data.Rows)
            {
                ProductToppingShow productToppingShow = new ProductToppingShow(item);
               productToppingShows.Add(productToppingShow);
            }

            return productToppingShows;
        }

        public static List<ProductToppingShow> LoadProductTopping1(string @key)
        {
            List<ProductToppingShow> productToppingShows = new List<ProductToppingShow>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT pt.id,pt.product_id,pt.topping_id,pt.status,p.title as name_product,t.title as name_topping FROM product_toppings pt INNER JOIN products p ON pt.product_id = p.id INNER JOIN toppings t ON pt.topping_id = t.id WHERE pt.id ='"+@key+"'");
            foreach (DataRow item in data.Rows)
            {
                ProductToppingShow productToppingShow = new ProductToppingShow(item);
                productToppingShows.Add(productToppingShow);
            }

            return productToppingShows;
        }

        public static void DeleteProductTopping(string id)
        {
            string sql = "DELETE FROM product_toppings  WHERE id = @id";
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

        public static bool CheckProductTopping(string @product_id, string topping_id)
        {
            string sql = "select * from product_toppings where product_id = '" + @product_id + "' AND  topping_id = '" + @topping_id + "'";
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


        public static List<ProductToppingShow> LoadProductToppingSearch(string @key)
        {
            List<ProductToppingShow> productToppingShows = new List<ProductToppingShow>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT pt.id,pt.product_id,pt.topping_id,pt.status,p.title as name_product,t.title as name_topping FROM product_toppings pt INNER JOIN products p ON pt.product_id = p.id INNER JOIN toppings t ON pt.topping_id = t.id WHERE pt.status ='"+@key+"' ");
            foreach (DataRow item in data.Rows)
            {
                ProductToppingShow productToppingShow = new ProductToppingShow(item);
                productToppingShows.Add(productToppingShow);
            }

            return productToppingShows;
        }


        public static List<ProductToppingShow> LoadProductToppingSearch1(string @key)
        {
            List<ProductToppingShow> productToppingShows = new List<ProductToppingShow>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT pt.id,pt.product_id,pt.topping_id,pt.status,p.title as name_product,t.title as name_topping FROM product_toppings pt INNER JOIN products p ON pt.product_id = p.id INNER JOIN toppings t ON pt.topping_id = t.id WHERE p.title LIKE'%" + @key + "%' OR  t.title LIKE'%" + @key + "%'");
            foreach (DataRow item in data.Rows)
            {
                ProductToppingShow productToppingShow = new ProductToppingShow(item);
                productToppingShows.Add(productToppingShow);
            }

            return productToppingShows;
        }

        public static List<ProductTopping> LoadProductTopping(string product_id)
        {
            List<ProductTopping> productListToppings = new List<ProductTopping>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,product_id,topping_id,status FROM product_toppings WHERE product_id = " + product_id + "");
            foreach (DataRow item in data.Rows)
            {
                ProductTopping productTopping = new ProductTopping(item);
                productListToppings.Add(productTopping);
            }

            return productListToppings;
        }
    }
}
