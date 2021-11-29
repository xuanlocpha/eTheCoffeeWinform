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
    class DbDiscount
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


        //public static List<Discount> LoadDiscountList()
        //{
        //    List<Discount> discountList = new List<Discount>();

        //    DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,discount,products,start_date,expiry_date FROM discounts WHERE '" + date + "' >= start_date and '" + date + "' <= expiry_date");
        //    foreach (DataRow item in data.Rows)
        //    {
        //        Discount discount = new Discount(item);
        //        discountList.Add(discount);
        //    }

        //    return discountList;
        //}

        public static List<Discount> LoadDiscountList(string date)
        {
            List<Discount> discountList = new List<Discount>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,discount,products,start_date,expiry_date FROM discounts WHERE '" + date + "' >= start_date and '" + date + "' <= expiry_date");
            foreach (DataRow item in data.Rows)
            {
                Discount discount = new Discount(item);
                discountList.Add(discount);
            }

            return discountList;
        }


        public static bool CheckDiscountOrder(string @key)
        {
            string sql = "SELECT id,discount,products,start_date,expiry_date FROM discounts WHERE  '" + key + "' >= start_date and '"+key+"' <= expiry_date";
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

        //public static List<Discount> LoadDiscountList(string @key)
        //{
        //    List<Discount> discountList = new List<Discount>();

        //    DataTable data = DataProvider.Instance.ExecuteQuery("SELECT d.id,d.discount,d.product_id,d.start_date,d.expiry_date,d.status,p.title as title_product FROM discounts d, products p WHERE d.product_id = p.id AND d.id = '"+@key+"'");
        //    foreach (DataRow item in data.Rows)
        //    {
        //        Discount discount = new Discount(item);
        //        discountList.Add(discount);
        //    }

        //    return discountList;
        //}

        //public static List<Discount> LoadDiscountSearchList(string @key)
        //{
        //    List<Discount> discountList = new List<Discount>();

        //    DataTable data = DataProvider.Instance.ExecuteQuery("SELECT d.id,d.discount,d.product_id,d.start_date,d.expiry_date,d.status,p.title as title_product FROM discounts d, products p WHERE d.product_id = p.id AND d.status = '"+@key+"'");
        //    foreach (DataRow item in data.Rows)
        //    {
        //        Discount discount = new Discount(item);
        //        discountList.Add(discount);
        //    }

        //    return discountList;
        //}





        //public static List<Discount> LoadtSearchList(string @key)
        //{
        //    List<Discount> discountList = new List<Discount>();

        //    DataTable data = DataProvider.Instance.ExecuteQuery("SELECT d.id,d.discount,d.product_id,d.start_date,d.expiry_date,d.status,p.title as title_product FROM discounts d INNER JOIN products p ON d.product_id = p.id WHERE p.title LIKE'%" + @key + "%' ");
        //    foreach (DataRow item in data.Rows)
        //    {
        //        Discount discount = new Discount(item);
        //        discountList.Add(discount);
        //    }

        //    return discountList;
        //}


        //public static void AddDiscount(Discount std)
        //{
        //    string sql = "INSERT INTO discounts (discount,product_id,start_date,expiry_date,status) VALUES(@discount,@product_id,@start_date,@expiry_date,@status)";
        //    MySqlConnection con = GetConnection();
        //    MySqlCommand cmd = new MySqlCommand(sql, con);
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Parameters.Add("@discount", MySqlDbType.VarChar).Value = std.discount;
        //    cmd.Parameters.Add("@product_id", MySqlDbType.VarChar).Value = std.product_id;
        //    cmd.Parameters.Add("@start_date", MySqlDbType.VarChar).Value = std.start_date;
        //    cmd.Parameters.Add("@expiry_date", MySqlDbType.VarChar).Value = std.expiry_date;
        //    cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        MessageBox.Show("Thêm Giảm Giá ( Thành Công ) ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show("Thêm Giảm Giá ( Không Thành Công ) ! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    con.Close();
        //}


        public static bool CheckDiscount(string @key,string @discount)
        {
            string sql = "select * from discounts where product_id = '" + @key + "' AND discount ='" + @discount + "' AND status ='"+1+"'";
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


        //public static void UpdateDiscountStatus(Discount std, string id)
        //{
        //    string sql = "UPDATE discounts SET discount = @discount,product_id = @product_id,start_date = @start_date,expiry_date = @expiry_date , status=@status  WHERE id = @id";
        //    MySqlConnection con = GetConnection();
        //    MySqlCommand cmd = new MySqlCommand(sql, con);
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
        //    cmd.Parameters.Add("@discount", MySqlDbType.VarChar).Value = std.discount;
        //    cmd.Parameters.Add("@product_id", MySqlDbType.VarChar).Value = std.product_id;
        //    cmd.Parameters.Add("@start_date", MySqlDbType.VarChar).Value = std.start_date;
        //    cmd.Parameters.Add("@expiry_date", MySqlDbType.VarChar).Value = std.expiry_date;
        //    cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
  
        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show("Thêm Giảm Giá ( Không Thành Công ) ! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    con.Close();
        //}



        //public static void UpdateDiscount(Discount std, string id)
        //{
        //    string sql = "UPDATE discounts SET discount = @discount,product_id = @product_id,start_date = @start_date,expiry_date = @expiry_date , status=@status  WHERE id = @id";
        //    MySqlConnection con = GetConnection();
        //    MySqlCommand cmd = new MySqlCommand(sql, con);
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
        //    cmd.Parameters.Add("@discount", MySqlDbType.VarChar).Value = std.discount;
        //    cmd.Parameters.Add("@product_id", MySqlDbType.VarChar).Value = std.product_id;
        //    cmd.Parameters.Add("@start_date", MySqlDbType.VarChar).Value = std.start_date;
        //    cmd.Parameters.Add("@expiry_date", MySqlDbType.VarChar).Value = std.expiry_date;
        //    cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        MessageBox.Show("Chỉnh Sửa ( Thành Công ) ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show("Chỉnh Sửa  ( Không Thành Công ) ! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    con.Close();
        //}

        public static void DeleteDiscount(string id)
        {
            string sql = "DELETE FROM discounts  WHERE id = @id";
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
