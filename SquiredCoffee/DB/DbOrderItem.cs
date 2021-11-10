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
            string sql = "SERVER=45.252.251.29;PORT=3306;DATABASE=sodopxlg_koffeeholic;UID=sodopxlg;PASSWORD=05qT1yfRp9";
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
            string sql = "INSERT INTO order_items (product_id,item_detail,order_id,quantity,price,content) " +
                "VALUES(@product_id,@item_detail,@order_id,@quantity,@price,@content)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@order_id", MySqlDbType.VarChar).Value = std.order_id;
            cmd.Parameters.Add("@product_id", MySqlDbType.VarChar).Value = std.product_id;
            cmd.Parameters.Add("@item_detail", MySqlDbType.VarChar).Value = std.item_detail;
            cmd.Parameters.Add("@quantity", MySqlDbType.VarChar).Value = std.quantity;
            cmd.Parameters.Add("@price", MySqlDbType.VarChar).Value = std.price;
            cmd.Parameters.Add("@content", MySqlDbType.VarChar).Value = std.content;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Order Không Thành Công ! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        //public static void UpdateOrderItem(Order_Items std, string id, string created_at)
        //{
        //    string sql = "UPDATE order_items SET id_order=@id_order,id_product=@id_product,count=@count,price=@price,provisional=@provisional WHERE id = @id AND id_order = @id_order AND id_product = @id_product ";
        //    MySqlConnection con = GetConnection();
        //    MySqlCommand cmd = new MySqlCommand(sql, con);
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
        //    cmd.Parameters.Add("@id_order", MySqlDbType.VarChar).Value = std.id_order;
        //    cmd.Parameters.Add("@id_product", MySqlDbType.VarChar).Value = std.id_product;
        //    cmd.Parameters.Add("@count", MySqlDbType.VarChar).Value = std.count;
        //    cmd.Parameters.Add("@price", MySqlDbType.VarChar).Value = std.price;
        //    cmd.Parameters.Add("@provisional", MySqlDbType.VarChar).Value = std.provisional;
        //    cmd.Parameters.Add("@created_at", MySqlDbType.VarChar).Value = created_at;
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show("Cập Nhật Không Thành Công! \n" + ex.Message, " Cảnh Báo Lỗi ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    con.Close();
        //}




        //public static void UpdateOrderItem1(Order_Items std, string id)
        //{
        //    string sql = "UPDATE order_items SET id_order=@id_order,id_product=@id_product,count=@count,price=@price,provisional=@provisional WHERE id = @id AND id_order = @id_order AND id_product = @id_product ";
        //    MySqlConnection con = GetConnection();
        //    MySqlCommand cmd = new MySqlCommand(sql, con);
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
        //    cmd.Parameters.Add("@id_order", MySqlDbType.VarChar).Value = std.id_order;
        //    cmd.Parameters.Add("@id_product", MySqlDbType.VarChar).Value = std.id_product;
        //    cmd.Parameters.Add("@count", MySqlDbType.VarChar).Value = std.count;
        //    cmd.Parameters.Add("@price", MySqlDbType.VarChar).Value = std.price;
        //    cmd.Parameters.Add("@provisional", MySqlDbType.VarChar).Value = std.provisional;
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show("Cập Nhật Không Thành Công! \n" + ex.Message, " Cảnh Báo Lỗi ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    con.Close();
        //}

        public static List<Order_Items> order_Items_List(string id_order)
        {
            List<Order_Items> order_Items_List = new List<Order_Items>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT oi.id,oi.product_id,oi.order_id,oi.item_detail,oi.quantity,oi.content,p.title,p.price FROM order_items oi, orders o , products p   WHERE  oi.order_id = '" + id_order + "' AND o.id ='" + id_order + "' AND p.id = oi.product_id");
            foreach (DataRow item in data.Rows)
            {
                Order_Items order_Items= new Order_Items(item);
                order_Items_List.Add(order_Items);
            }

            return order_Items_List;
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
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Xóa Không Thành Công! \n" + ex.Message, " Cảnh Báo Lỗi ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }


        public static void DeleteOrderItem(string id)
        {
            string sql = "DELETE FROM order_items  WHERE id = @id";
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


    }
}
