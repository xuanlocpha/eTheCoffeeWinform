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
    class DbProductOption
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


        public static bool CheckProductOption(string @product_id,string option_id)
        {
            string sql = "select * from product_options where product_id = '"+ @product_id +"' AND  option_id = '"+ @option_id +"'";
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


        public static void AddProductOption(ProductOption std)
        {
            string sql = "INSERT INTO product_options (product_id,option_id,title,price,defaults,status) VALUES(@product_id,@option_id,@title,@price,@defaults,@status)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@product_id", MySqlDbType.VarChar).Value =std.product_id;
            cmd.Parameters.Add("@option_id", MySqlDbType.VarChar).Value = std.option_id;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
            cmd.Parameters.Add("@price", MySqlDbType.VarChar).Value = std.price;
            cmd.Parameters.Add("@defaults", MySqlDbType.VarChar).Value = std.defaults;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm Tùy Chọn Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Không Thể Thêm Tùy Chọn ! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static void UpdateProductOption(ProductOption std, string id)
        {
            string sql = "UPDATE product_options SET product_id=@product_id,option_id=@option_id,title=@title,price=@price,defaults=@defaults,status=@status  WHERE id = @id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@product_id", MySqlDbType.VarChar).Value = std.product_id;
            cmd.Parameters.Add("@option_id", MySqlDbType.VarChar).Value = std.option_id;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
            cmd.Parameters.Add("@price", MySqlDbType.VarChar).Value = std.price;
            cmd.Parameters.Add("@defaults", MySqlDbType.VarChar).Value = std.defaults;
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


        public static void DeleteProductOption(string id)
        {
            string sql = "DELETE FROM product_options  WHERE id = @id";
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
        public static List<ProductOptionShow> LoadProductOption()
        {
            List<ProductOptionShow> productOptionShowLists = new List<ProductOptionShow>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT po.id,po.product_id,po.option_id,po.title,po.price,po.defaults,po.status,p.title as name_product ,o.title as name_option FROM product_options po,products p,options o WHERE po.product_id = p.id AND po.option_id = o.id");
            foreach (DataRow item in data.Rows)
            {
                ProductOptionShow productOptionShow = new ProductOptionShow(item);
                productOptionShowLists.Add(productOptionShow);
            }

            return productOptionShowLists;
        }



        public static List<ProductOptionShow> LoadProductOption(string @key)
        {
            List<ProductOptionShow> productOptionShowLists = new List<ProductOptionShow>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT po.id,po.product_id,po.option_id,po.title,po.price,po.defaults,po.status,p.title as name_product ,o.title as name_option FROM product_options po,products p,options o WHERE po.product_id = p.id AND po.option_id = o.id AND po.id ='" + @key+"'");
            foreach (DataRow item in data.Rows)
            {
                ProductOptionShow productOptionShow = new ProductOptionShow(item);
                productOptionShowLists.Add(productOptionShow);
            }

            return productOptionShowLists;
        }

        public static List<ProductOptionShow> LoadProductOptionSearchClick(string @key)
        {
            List<ProductOptionShow> productOptionShowLists = new List<ProductOptionShow>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT po.id,po.product_id,po.option_id,po.title,po.price,po.defaults,po.status,p.title as name_product ,o.title as name_option FROM product_options po,products p,options o WHERE po.product_id = p.id AND po.option_id = o.id AND po.status ='" + @key+"'");
            foreach (DataRow item in data.Rows)
            {
                ProductOptionShow productOptionShow = new ProductOptionShow(item);
                productOptionShowLists.Add(productOptionShow);
            }

            return productOptionShowLists;
        }


        public static List<ProductOptionShow> LoadProductOptionSearch(string @key)
        {
            List<ProductOptionShow> productOptionShowLists = new List<ProductOptionShow>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT po.id,po.product_id,po.option_id,po.title,po.price,po.defaults,po.status,p.title as name_product ,o.title as name_option FROM product_options po INNER JOIN products p ON po.product_id = p.id INNER JOIN options o ON po.option_id = o.id WHERE  p.title LIKE'%" + @key + "%' OR o.title LIKE'%" + @key + "%'");
            foreach (DataRow item in data.Rows)
            {
                ProductOptionShow productOptionShow = new ProductOptionShow(item);
                productOptionShowLists.Add(productOptionShow);
            }

            return productOptionShowLists;
        }

    }
}
