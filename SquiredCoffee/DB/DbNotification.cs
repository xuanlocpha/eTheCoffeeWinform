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
    class DbNotification
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


        public static void AddNotification(NotificationSystem std)
        {
            string sql = "INSERT INTO notifications (id_staff,title,content,create_date,status) VALUES(@id_staff,@title,@content,@create_date,@status)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id_Staff", MySqlDbType.VarChar).Value = std.id_staff;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
            cmd.Parameters.Add("@content", MySqlDbType.VarChar).Value = std.content;
            cmd.Parameters.Add("@create_date", MySqlDbType.VarChar).Value = std.create_date;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Không Thể Thông Báo Sản Phẩm ! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }


        public static List<NotificationSystem> LoadNotificationList()
        {
            List<NotificationSystem> notificationSystemList = new List<NotificationSystem>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT n.id,n.id_staff,n.title,n.content,n.create_date,n.status,CONCAT(s.first_name,s.last_name) as name_staff FROM notifications n INNER JOIN staffs s ON s.id = n.id_staff");
            foreach (DataRow item in data.Rows)
            {
                NotificationSystem notificationSystem = new NotificationSystem(item);
                notificationSystemList.Add(notificationSystem);
            }

            return notificationSystemList;
        }


        public static List<NotificationSystem> LoadNotificationListActive(string x)
        {
            List<NotificationSystem> notificationSystemList = new List<NotificationSystem>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT n.id,n.id_staff,n.title,n.content,n.create_date,n.status,CONCAT(s.first_name,s.last_name) as name_staff FROM notifications n INNER JOIN staffs s ON s.id = n.id_staff WHERE n.status = '" + x+"'");
            foreach (DataRow item in data.Rows)
            {
                NotificationSystem notificationSystem = new NotificationSystem(item);
                notificationSystemList.Add(notificationSystem);
            }

            return notificationSystemList;
        }

        public static bool CheckNotification(NotificationSystem std)
        {
            AddNotification(std);
            string sql = "select * from notifications where id_staff = @id_staff and title = @title and content = @content and create_date = @create_date and status = @status ";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id_staff", MySqlDbType.VarChar).Value = std.id_staff;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
            cmd.Parameters.Add("@content", MySqlDbType.VarChar).Value = std.content;
            cmd.Parameters.Add("@create_date", MySqlDbType.VarChar).Value = std.create_date;
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
    }
}
