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
    class DbOrderItem
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

        public static bool CheckDb(string @id_order, string  @id_product)
        {
            string sql = "select * from order_items where id_order = '" + id_order + "' and id_product ='"+id_product+"' ";
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



        public static void AddOrderItem(Order_Items std)
        {
            string sql = "INSERT INTO order_items (id_order,id_product,count,price,provisional) " +
                "VALUES(@id_order,@id_product,@count,@price,@provisional)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id_order", MySqlDbType.VarChar).Value = std.id_order;
            cmd.Parameters.Add("@id_product", MySqlDbType.VarChar).Value = std.id_product;
            cmd.Parameters.Add("@count", MySqlDbType.VarChar).Value = std.count;
            cmd.Parameters.Add("@price", MySqlDbType.VarChar).Value = std.price;
            cmd.Parameters.Add("@provisional", MySqlDbType.VarChar).Value = std.provisional;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm Sản Phẩm Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Thêm Sản Phẩm Không Thành Công ! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static void UpdateOrderItem(Order_Items std, string id, string created_at)
        {
            string sql = "UPDATE order_items SET id_order=@id_order,id_product=@id_product,count=@count,price=@price,provisional=@provisional WHERE id = @id AND id_order = @id_order AND id_product = @id_product ";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@id_order", MySqlDbType.VarChar).Value = std.id_order;
            cmd.Parameters.Add("@id_product", MySqlDbType.VarChar).Value = std.id_product;
            cmd.Parameters.Add("@count", MySqlDbType.VarChar).Value = std.count;
            cmd.Parameters.Add("@price", MySqlDbType.VarChar).Value = std.price;
            cmd.Parameters.Add("@provisional", MySqlDbType.VarChar).Value = std.provisional;
            cmd.Parameters.Add("@created_at", MySqlDbType.VarChar).Value = created_at;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Cập Nhật Không Thành Công! \n" + ex.Message, " Cảnh Báo Lỗi ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }




        public static void UpdateOrderItem1(Order_Items std, string id)
        {
            string sql = "UPDATE order_items SET id_order=@id_order,id_product=@id_product,count=@count,price=@price,provisional=@provisional WHERE id = @id AND id_order = @id_order AND id_product = @id_product ";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@id_order", MySqlDbType.VarChar).Value = std.id_order;
            cmd.Parameters.Add("@id_product", MySqlDbType.VarChar).Value = std.id_product;
            cmd.Parameters.Add("@count", MySqlDbType.VarChar).Value = std.count;
            cmd.Parameters.Add("@price", MySqlDbType.VarChar).Value = std.price;
            cmd.Parameters.Add("@provisional", MySqlDbType.VarChar).Value = std.provisional;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Cập Nhật Không Thành Công! \n" + ex.Message, " Cảnh Báo Lỗi ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static List<Order_Items> OrderItemsList(string id_order, string id_table, string id_product )
        {
            List<Order_Items> orderItemsList = new List<Order_Items>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT oi.id,oi.id_order,oi.id_product,oi.count,oi.price,oi.provisional,oi.created_at FROM order_items oi, orders o ,products p  WHERE  oi.id_order = o.id  AND oi.id_order = '" + id_order + "' AND o.status='" + 0 + "' AND o.id_table ='" + id_table + "' AND p.id = oi.id_product AND oi.id_product = '" + id_product + "' ");

            foreach (DataRow item in data.Rows)
            {
                Order_Items order_Items = new Order_Items(item);
                orderItemsList.Add(order_Items);
            }

            return orderItemsList;
        }


        public static void DeleteIngredient(string id)
        {
            string sql = "DELETE FROM order_items  WHERE id = @id";
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

    }
}
