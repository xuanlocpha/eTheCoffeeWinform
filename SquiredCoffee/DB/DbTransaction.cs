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
    class DbTransaction
    {
        public static MySqlConnection GetConnection()
        {
            string sql = "SERVER=45.252.251.29;PORT=3306;DATABASE=sodopxlg_koffeeholic;UID=sodopxlg;PASSWORD=05qT1yfRp9;charset=utf8";
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


        public static bool CheckDb(string @order_id)
        {
            string sql = "select * from transactions where order_id = '" + @order_id + "'";
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

        public static void AddTransaction(Trannsaction std)
        {
            string sql = "INSERT INTO transactions (user_id,order_id,code,type,mode,delivery_method,status,content) VALUES(@user_id,@order_id,@code,@type,@mode,@delivery_method,@status,@content)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@user_id", MySqlDbType.VarChar).Value = std.user_id;
            cmd.Parameters.Add("@order_id", MySqlDbType.VarChar).Value = std.order_id;
            cmd.Parameters.Add("@code", MySqlDbType.VarChar).Value = std.code;
            cmd.Parameters.Add("@type", MySqlDbType.VarChar).Value = std.type;
            cmd.Parameters.Add("@mode", MySqlDbType.VarChar).Value = std.mode;
            cmd.Parameters.Add("@delivery_method", MySqlDbType.VarChar).Value = std.delivery_method;
            cmd.Parameters.Add("@content", MySqlDbType.VarChar).Value = std.content;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
            try
            {
                cmd.ExecuteNonQuery();
               
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Không thể khởi tạo Transaction (Giao dịch)! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }



        public static void UpdateTransaction(Trannsaction std,string id)
        {
            string sql = "UPDATE transactions SET user_id = @user_id ,order_id=@order_id,code=@code,type=@type,mode=@mode,delivery_method=@delivery_method,status=@status,content=@content WHERE id = @id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@user_id", MySqlDbType.VarChar).Value = std.user_id;
            cmd.Parameters.Add("@order_id", MySqlDbType.VarChar).Value = std.order_id;
            cmd.Parameters.Add("@code", MySqlDbType.VarChar).Value = std.code;
            cmd.Parameters.Add("@type", MySqlDbType.VarChar).Value = std.type;
            cmd.Parameters.Add("@mode", MySqlDbType.VarChar).Value = std.mode;
            cmd.Parameters.Add("@delivery_method", MySqlDbType.VarChar).Value = std.delivery_method;
            cmd.Parameters.Add("@content", MySqlDbType.VarChar).Value = std.content;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Không thể khởi tạo Transaction (Giao dịch)! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static List<Trannsaction> LoadTransaction(string @id)
        {
            List<Trannsaction> transactionLists = new List<Trannsaction>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,user_id,order_id,code,type,mode,delivery_method,status,content FROM transactions WHERE order_id ='"+@id+"' ");
            foreach (DataRow item in data.Rows)
            {
                Trannsaction trannsaction = new Trannsaction(item);
                transactionLists.Add(trannsaction);
            }

            return transactionLists;
        }

    }
}
