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


        public static void AddOrder(Order std)
        {
            string sql = "INSERT INTO orders (id_staff,id_table,grandtotal,disscount,item_disscount,shipping,promo,content,address,phone,status) " +
                "VALUES(@id_staff,@id_table,@grandtotal,@disscount,@item_disscount,@shipping,@promo,@content,@address,@phone,@status)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id_staff", MySqlDbType.VarChar).Value = std.id_staff;
            cmd.Parameters.Add("@id_table", MySqlDbType.VarChar).Value = std.id_table;
            cmd.Parameters.Add("@grandtotal", MySqlDbType.VarChar).Value = std.grandtotal;
            cmd.Parameters.Add("@disscount", MySqlDbType.VarChar).Value = std.disscount;
            cmd.Parameters.Add("@item_disscount", MySqlDbType.VarChar).Value = std.item_disscount;
            cmd.Parameters.Add("@shipping", MySqlDbType.VarChar).Value = std.shipping;
            cmd.Parameters.Add("@promo", MySqlDbType.VarChar).Value = std.promo;
            cmd.Parameters.Add("@content", MySqlDbType.VarChar).Value = std.content;
            cmd.Parameters.Add("@address", MySqlDbType.VarChar).Value = std.address;
            cmd.Parameters.Add("@phone", MySqlDbType.VarChar).Value = std.phone;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
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

        public static List<Order> LoadOrderId(string id_table)
        {
            List<Order> orderList = new List<Order>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,id_staff,id_table,grandtotal,disscount,item_disscount,shipping,promo,content,address,phone,status FROM orders WHERE id_table = '" + id_table+"' AND status = 0 ");

            foreach (DataRow item in data.Rows)
            {
                Order order = new Order(item);
                orderList.Add(order);
            }

            return orderList;
        }
    }
}
