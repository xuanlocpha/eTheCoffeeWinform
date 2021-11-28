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
    class DbVoucher
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

        public static void AddVoucher(Voucher std)
        {
            string sql = "INSERT INTO vouchers (title,content,coupon_code,image,qr_code,start_date,expiry_date,discount_unit,discount,apply_for,quantity_rule,price_rule,status) " +
                        "VALUES(@title,@content,@coupon_code,@image,@qr_code,@start_date,@expiry_date,@discount_unit,@discount,@apply_for,@quantity_rule,@price_rule,@status)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
            cmd.Parameters.Add("@content", MySqlDbType.VarChar).Value = std.content;
            cmd.Parameters.Add("@coupon_code", MySqlDbType.VarChar).Value = std.coupon_code;
            cmd.Parameters.Add("@image", MySqlDbType.VarChar).Value = std.image;
            cmd.Parameters.Add("@qr_code", MySqlDbType.VarChar).Value = std.qr_code;
            cmd.Parameters.Add("@start_date", MySqlDbType.VarChar).Value = std.start_date;
            cmd.Parameters.Add("@expiry_date", MySqlDbType.VarChar).Value = std.expiry_date;
            cmd.Parameters.Add("@discount_unit", MySqlDbType.VarChar).Value = std.discount_unit;
            cmd.Parameters.Add("@discount", MySqlDbType.VarChar).Value = std.discount;
            cmd.Parameters.Add("@apply_for", MySqlDbType.VarChar).Value = std.apply_for;
            cmd.Parameters.Add("@quantity_rule", MySqlDbType.VarChar).Value = std.quantity_rule;
            cmd.Parameters.Add("@price_rule", MySqlDbType.VarChar).Value = std.price_rule;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm Voucher Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Thêm Voucher Không Thành Công ! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }


        public static void UpdateVoucher(Voucher std,string id)
        {
            
            string sql = "UPDATE vouchers SET title=@title,content=@content,coupon_code=@coupon_code,image=@image,qr_code=@qr_code,start_date=@start_date,expiry_date=@expiry_date,discount_unit=@discount_unit,discount=@discount,apply_for=@apply_for,quantity_rule=@quantity_rule,price_rule=@price_rule,status=@status WHERE id = @id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = std.title;
            cmd.Parameters.Add("@content", MySqlDbType.VarChar).Value = std.content;
            cmd.Parameters.Add("@coupon_code", MySqlDbType.VarChar).Value = std.coupon_code;
            cmd.Parameters.Add("@image", MySqlDbType.VarChar).Value = std.image;
            cmd.Parameters.Add("@qr_code", MySqlDbType.VarChar).Value = std.qr_code;
            cmd.Parameters.Add("@start_date", MySqlDbType.VarChar).Value = std.start_date;
            cmd.Parameters.Add("@expiry_date", MySqlDbType.VarChar).Value = std.expiry_date;
            cmd.Parameters.Add("@discount_unit", MySqlDbType.VarChar).Value = std.discount_unit;
            cmd.Parameters.Add("@discount", MySqlDbType.VarChar).Value = std.discount;
            cmd.Parameters.Add("@apply_for", MySqlDbType.VarChar).Value = std.apply_for;
            cmd.Parameters.Add("@quantity_rule", MySqlDbType.VarChar).Value = std.quantity_rule;
            cmd.Parameters.Add("@price_rule", MySqlDbType.VarChar).Value = std.price_rule;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Update Không Thành Công ! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }



        public static void UpdateVoucherReward(string coupon_code, string id)
        {

            string sql = "UPDATE vouchers SET coupon_code = @coupon_code WHERE id = @id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@coupon_code", MySqlDbType.VarChar).Value = coupon_code;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Update Không Thành Công ! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static List<Voucher> LoadVoucherListToday(string date, string type)
        {

            List<Voucher> voucherList = new List<Voucher>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,title,content,type,coupon_code,image,qr_code,start_date,expiry_date,discount_unit,discount,apply_for,quantity_rule,price_rule,status FROM vouchers WHERE '" + date + "' >= start_date and '" + date + "' <= expiry_date and type = '" + type + "'");
            foreach (DataRow item in data.Rows)
            {
                Voucher voucher = new Voucher(item);
                voucherList.Add(voucher);
            }

            return voucherList;
        }


        public static bool CheckAdd(string discount,string couponcode)
        {
            string sql = "select * from vouchers where  discount= '" + discount + "' AND coupon_code = '" + couponcode + "'";
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

        public static bool CheckDb(string @coupon_code)
        {
            string sql = "select * from vouchers where coupon_code = '" + @coupon_code + "' AND expiry_date < '"+DateTime.Now+"'";
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

        public static void DeleteVoucher(string id)
        {
            string sql = "DELETE FROM vouchers  WHERE id = @id";
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


        public static List<Voucher> LoadVoucherList()
        {
          
            List<Voucher> voucherList = new List<Voucher>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,title,content,coupon_code,image,qr_code,start_date,expiry_date,discount_unit,discount,apply_for,quantity_rule,price_rule,status FROM vouchers ");
            foreach (DataRow item in data.Rows)
            {
                Voucher voucher = new Voucher(item);
                voucherList.Add(voucher);
            }

            return voucherList;
        }


        public static List<Voucher> SearchVoucherListWithReward(string coupon_code)
        {

            List<Voucher> voucherList = new List<Voucher>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,title,content,coupon_code,image,qr_code,start_date,expiry_date,discount_unit,discount,apply_for,quantity_rule,price_rule,status FROM vouchers WHERE coupon_code = '"+coupon_code+"' ");
            foreach (DataRow item in data.Rows)
            {
                Voucher voucher = new Voucher(item);
                voucherList.Add(voucher);
            }
            return voucherList;
        }

        public static List<Voucher> LoadVoucherList(string @key)
        {
            List<Voucher> voucherList = new List<Voucher>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,title,content,coupon_code,image,qr_code,start_date,expiry_date,discount_unit,discount,apply_for,quantity_rule,price_rule,status FROM vouchers WHERE id='"+@key+"'");
            foreach (DataRow item in data.Rows)
            {
                Voucher voucher = new Voucher(item);
                voucherList.Add(voucher);
            }

            return voucherList;
        }

        public static List<Voucher> LoadVoucherListSearchClick(string @key)
        {
            List<Voucher> voucherList = new List<Voucher>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,title,content,coupon_code,image,qr_code,start_date,expiry_date,discount_unit,discount,apply_for,quantity_rule,price_rule,status FROM vouchers WHERE status ='"+@key+"' ");
            foreach (DataRow item in data.Rows)
            {
                Voucher voucher = new Voucher(item);
                voucherList.Add(voucher);
            }

            return voucherList;
        }


        public static List<Voucher> LoadVoucherListSearch(string @key)
        {
            List<Voucher> voucherList = new List<Voucher>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,title,content,coupen_code,image,qr_code,start_date,expiry_date,discount_unit,discount,apply_for,quantity_rule,price_rule,status FROM vouchers WHERE title LIKE'%" + @key + "%' OR discount LIKE'%" + @key + "%' OR discount_unit LIKE'%" + @key + "%' ");
            foreach (DataRow item in data.Rows)
            {
                Voucher voucher = new Voucher(item);
                voucherList.Add(voucher);
            }

            return voucherList;
        }


        public static List<Voucher> LoadVoucherSearch(string @key,string @date)
        {
            List<Voucher> voucherList = new List<Voucher>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,title,content,coupon_code,image,qr_code,start_date,expiry_date,discount_unit,discount,apply_for,quantity_rule,price_rule,status FROM vouchers WHERE coupon_code ='" + @key + "' and '" + @date + "' >= start_date and '" +@date + "' <= expiry_date ");
            foreach (DataRow item in data.Rows)
            {
                Voucher voucher = new Voucher(item);
                voucherList.Add(voucher);
            }

            return voucherList;
        }

        public static bool CheckVoucher(string @key, string @date)
        {
            string sql = "SELECT id,title,content,coupon_code,image,qr_code,start_date,expiry_date,discount_unit,discount,apply_for,quantity_rule,price_rule,status FROM vouchers WHERE coupon_code ='" + @key + "' and '" + @date + "' >= start_date and '" + @date + "' <= expiry_date ";
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


        public static bool CheckVoucherReward(string @id, string @date)
        {
            string sql = "SELECT id,title,content,coupon_code,image,qr_code,start_date,expiry_date,discount_unit,discount,apply_for,quantity_rule,price_rule,status FROM vouchers WHERE id ='" + @id + "' and '" + @date + "' >= start_date and '" + @date + "' <= expiry_date ";
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



        public static bool CheckVoucherQuantityRuler(string id, string quantity)
        {
            string sql = "SELECT id,title,content,coupon_code,image,qr_code,start_date,expiry_date,discount_unit,discount,apply_for,quantity_rule,price_rule,status FROM vouchers WHERE id = '"+id+"' and '"+quantity+"' >= quantity_rule";
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

        public static bool CheckForExistence(string coupen_code)
        {
            string sql = "select * from vouchers where  coupen_code= '" + coupen_code + "' AND expiry_date > '"+DateTime.Now+"'";
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
