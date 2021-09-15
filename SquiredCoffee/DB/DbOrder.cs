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
    class DbOrder
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


        public static bool CheckDb(string @table_number)
        {
            string sql = "select * from orders where table_number = '" + @table_number + "' and status ='" +0+ "' ";
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

        public static void AddOrder(Order std)
        {
            string sql = "INSERT INTO orders (table_number,staff_id,subtotal,discount,item_discount,shipping,promo,grandtotal,content,status,address,phone) " +
                "VALUES(@table_number,@staff_id,@subtotal,@discount,@item_discount,@shipping,@promo,@grandtotal,@content,@status,@address,@phone)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@table_number", MySqlDbType.VarChar).Value = std.table_number;
            cmd.Parameters.Add("@staff_id", MySqlDbType.VarChar).Value = std.staff_id;
            cmd.Parameters.Add("@subtotal", MySqlDbType.VarChar).Value = std.subtotal;
            cmd.Parameters.Add("@discount", MySqlDbType.VarChar).Value = std.discount;
            cmd.Parameters.Add("@item_discount", MySqlDbType.VarChar).Value = std.item_discount;
            cmd.Parameters.Add("@shipping", MySqlDbType.VarChar).Value = std.shipping;
            cmd.Parameters.Add("@promo", MySqlDbType.VarChar).Value = std.promo;
            cmd.Parameters.Add("@grandtotal", MySqlDbType.VarChar).Value = std.grandtotal;
            cmd.Parameters.Add("@content", MySqlDbType.VarChar).Value = std.content;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
            cmd.Parameters.Add("@address", MySqlDbType.VarChar).Value = std.address;
            cmd.Parameters.Add("@phone", MySqlDbType.VarChar).Value = std.phone;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Tạo Bàn Không Thành Công ! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static List<Order> LoadOrder()
        {
            List<Order> orderList = new List<Order>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,table_number,staff_id,subtotal,discount,item_discount,shipping,promo,grandtotal,content,status,address,phone FROM orders WHERE status = '"+0+"' ");

            foreach (DataRow item in data.Rows)
            {
                Order order = new Order(item);
                orderList.Add(order);
            }

            return orderList;
        }


        public static List<Order> LoadOrder(string table_number)
        {
            List<Order> orderList = new List<Order>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,table_number,staff_id,subtotal,discount,item_discount,shipping,promo,grandtotal,content,status,address,phone FROM orders WHERE status = '" + 0 + "' AND table_number ='"+table_number+"' ");

            foreach (DataRow item in data.Rows)
            {
                Order order = new Order(item);
                orderList.Add(order);
            }

            return orderList;
        }


        public static void DeleteOrder(string id)
        {
            string sql = "DELETE FROM orders  WHERE id = @id";
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
