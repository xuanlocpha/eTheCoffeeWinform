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
    class DbReward
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

        public static void AddReward(Rewards std)
        {
            string sql = "INSERT INTO rewards (voucher_id,title,brand_name,content,image,point,quantity,status) VALUES(@voucher_id,@title,@brand_name,@content,@image,@point,@quantity,@status)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@voucher_id", MySqlDbType.VarChar).Value = std.voucher_id;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
            cmd.Parameters.Add("@brand_name", MySqlDbType.VarChar).Value = std.brand_name;
            cmd.Parameters.Add("@content", MySqlDbType.VarChar).Value = std.content;
            cmd.Parameters.Add("@image", MySqlDbType.VarChar).Value = std.image;
            cmd.Parameters.Add("@point", MySqlDbType.VarChar).Value = std.point;
            cmd.Parameters.Add("@quantity", MySqlDbType.VarChar).Value = std.quantity;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;

            try
            {
                cmd.ExecuteNonQuery();
              //  MessageBox.Show("Thêm Phần Thưởng  Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Không Thể Thêm Phần Thưởng ! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static void UpdateReward(Rewards std, string id)
        {
            string sql = "UPDATE  rewards SET voucher_id = @voucher_id,title=@title,brand_name=@brand_name,content=@content,image=@image,point=@point,quantity=@quantity,status=@status  WHERE id = @id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@voucher_id", MySqlDbType.VarChar).Value = std.voucher_id;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
            cmd.Parameters.Add("@brand_name", MySqlDbType.VarChar).Value = std.brand_name;
            cmd.Parameters.Add("@content", MySqlDbType.VarChar).Value = std.content;
            cmd.Parameters.Add("@image", MySqlDbType.VarChar).Value = std.image;
            cmd.Parameters.Add("@point", MySqlDbType.VarChar).Value = std.point;
            cmd.Parameters.Add("@quantity", MySqlDbType.VarChar).Value = std.quantity;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
            try
            {
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Chỉnh Sửa Thành Công", " Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Chỉnh Sửa Không Thành Công! \n" + ex.Message, " Cảnh Báo Lỗi ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();

        }


        public static void DeleteReward(string id)
        {
            string sql = "DELETE FROM rewards  WHERE id = @id";
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


        public static List<RewardShow> LoadReward()
        {
            List<RewardShow> rewardShowsList = new List<RewardShow>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,voucher_id,title,brand_name,content,image,point,quantity,status FROM rewards");
            foreach (DataRow item in data.Rows)
            {
                RewardShow rewardShow = new RewardShow(item);
                rewardShowsList.Add(rewardShow);
            }

            return rewardShowsList  ;
        }


        public static List<RewardShow> LoadRewardStatus(string status)
        {
            List<RewardShow> rewardShowsList = new List<RewardShow>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,voucher_id,title,brand_name,content,image,point,quantity,status FROM rewards WHERE status = '"+status+"'");
            foreach (DataRow item in data.Rows)
            {
                RewardShow rewardShow = new RewardShow(item);
                rewardShowsList.Add(rewardShow);
            }

            return rewardShowsList;
        }


        public static List<RewardShow> LoadReward(string id)
        {
            List<RewardShow> rewardShowsList = new List<RewardShow>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,voucher_id,title,brand_name,content,image,point,quantity,status FROM rewards WHERE id = '"+id+"'");
            foreach (DataRow item in data.Rows)
            {
                RewardShow rewardShow = new RewardShow(item);
                rewardShowsList.Add(rewardShow);
            }

            return rewardShowsList;
        }


        public static List<RewardShow> LoadRewardVoucher(string voucher_id)
        {
            List<RewardShow> rewardShowsList = new List<RewardShow>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,voucher_id,title,brand_name,content,image,point,quantity,status FROM rewards WHERE voucher_id = '" + voucher_id + "'");
            foreach (DataRow item in data.Rows)
            {
                RewardShow rewardShow = new RewardShow(item);
                rewardShowsList.Add(rewardShow);
            }

            return rewardShowsList;
        }


        public static void UpdatePointUser(string point, string id)
        {
            string sql = "UPDATE users SET point='"+point+"' WHERE id='"+id+"'";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
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

        public static void UpdateQuantityRewards(string quantity, string id)
        {
            string sql = "UPDATE rewards SET quantity='" + quantity + "' WHERE id='" + id + "'";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
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


        public static bool CheckPointUser(string point,string id)
        {
            UpdatePointUser(point, id);
            string sql = "select * from users where point = '" + point + "' and id ='"+id+"'";
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


        public static bool CheckAddReward(Rewards std)
        {
            AddReward(std);
            string sql = "select * from rewards where title = @title and brand_name = @brand_name";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
            cmd.Parameters.Add("@brand_name", MySqlDbType.VarChar).Value = std.brand_name;
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


        public static bool CheckUpdateReward(Rewards std,string id)
        {
            UpdateReward(std,id);
            string sql = "select * from rewards where id = @id and title = @title and brand_name = @brand_name";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
            cmd.Parameters.Add("@brand_name", MySqlDbType.VarChar).Value = std.brand_name;
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


        public static bool CheckDeleteReward(string id)
        {
            DeleteReward(id);
            string sql = "select * from rewards where id = @id ";
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
