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
    class DbOrder
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
            string sql = "INSERT INTO orders (table_number,staff_id,user_id,address_id,subtotal,voucher_discount,shipping_discount,shipping,promo,grandtotal,content,status) " +
                "VALUES(@table_number,@staff_id,@user_id,@address_id,@subtotal,@voucher_discount,@shipping_discount,@shipping,@promo,@grandtotal,@content,@status)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@table_number", MySqlDbType.VarChar).Value = std.table_number;
            cmd.Parameters.Add("@staff_id", MySqlDbType.VarChar).Value = std.staff_id;
            cmd.Parameters.Add("@user_id", MySqlDbType.VarChar).Value = std.user_id;
            cmd.Parameters.Add("@address_id", MySqlDbType.VarChar).Value = std.address_id;
            cmd.Parameters.Add("@subtotal", MySqlDbType.VarChar).Value = std.subtotal;
            cmd.Parameters.Add("@voucher_discount", MySqlDbType.VarChar).Value = std.voucher_discount;
            cmd.Parameters.Add("@shipping_discount", MySqlDbType.VarChar).Value = std.shipping_discount;
            cmd.Parameters.Add("@shipping", MySqlDbType.VarChar).Value = std.shipping;
            cmd.Parameters.Add("@promo", MySqlDbType.VarChar).Value = std.promo;
            cmd.Parameters.Add("@grandtotal", MySqlDbType.VarChar).Value = std.grandtotal;
            cmd.Parameters.Add("@content", MySqlDbType.VarChar).Value = std.content;
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


        public static void UpdateOrder(Order std,string id)
        {
            string sql = "UPDATE orders SET table_number=@table_number,staff_id=@staff_id,user_id=@user_id,address_id=@address_id,subtotal=@subtotal,voucher_discount=@voucher_discount,shipping_discount=@shipping_discount,shipping=@shipping,promo=@promo,grandtotal=@grandtotal,content=@content,status=@status  WHERE id = @id";

            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@table_number", MySqlDbType.VarChar).Value = std.table_number;
            cmd.Parameters.Add("@staff_id", MySqlDbType.VarChar).Value = std.staff_id;
            cmd.Parameters.Add("@user_id", MySqlDbType.VarChar).Value = std.user_id;
            cmd.Parameters.Add("@address_id", MySqlDbType.VarChar).Value = std.address_id;
            cmd.Parameters.Add("@subtotal", MySqlDbType.VarChar).Value = std.subtotal;
            cmd.Parameters.Add("@voucher_discount", MySqlDbType.VarChar).Value = std.voucher_discount;
            cmd.Parameters.Add("@shipping_discount", MySqlDbType.VarChar).Value = std.shipping_discount;
            cmd.Parameters.Add("@shipping", MySqlDbType.VarChar).Value = std.shipping;
            cmd.Parameters.Add("@promo", MySqlDbType.VarChar).Value = std.promo;
            cmd.Parameters.Add("@grandtotal", MySqlDbType.VarChar).Value = std.grandtotal;
            cmd.Parameters.Add("@content", MySqlDbType.VarChar).Value = std.content;
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

        public static List<Order> LoadOrder()
        {
            List<Order> orderList = new List<Order>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,table_number,staff_id,user_id,address_id,subtotal,voucher_discount,shipping_discount,shipping,promo,grandtotal,content,status FROM orders WHERE status = '" + 0+"' ");

            foreach (DataRow item in data.Rows)
            {
                Order order = new Order(item);
                orderList.Add(order);
            }

            return orderList;
        }

        public static List<Order> LoadOrderUpdate(string id)
        {
            List<Order> orderList = new List<Order>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,table_number,staff_id,user_id,address_id,subtotal,voucher_discount,shipping_discount,shipping,promo,grandtotal,content,status FROM orders WHERE status = '" + 0 + "' and id ='"+id+"'");

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

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,table_number,staff_id,user_id,address_id,subtotal,voucher_discount,shipping_discount,shipping,promo,grandtotal,content,status FROM orders WHERE status = '" + 0 + "' AND table_number ='"+table_number+"' ");

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


        public static List<OrderShow> LoadOrderShow(string @type)
        {
            List<OrderShow> orderShowLists = new List<OrderShow>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT o.id,u.display_name,a.address,o.grandtotal as grand_total,o.status,o.shipping FROM orders o,users u,transactions t,address a WHERE t.mode = '"+@type+"' and t.order_id = o.id and t.user_id = u.id and o.address_id = a.id and o.status = 0");

            foreach (DataRow item in data.Rows)
            {
                OrderShow orderShow = new OrderShow(item);
                orderShowLists.Add(orderShow);
            }

            return orderShowLists;
        }



        public static bool CheckTypeOrderProduct(string id_order,string type)
        {
            string sql = "select * from products p, categories c where c.type = '"+type+"' and p.id = '"+id_order+"' and c.id = p.category_id";
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

    }
}
