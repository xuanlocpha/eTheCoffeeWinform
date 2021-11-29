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

    class DbSupplier
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


        public static List<Supplier> LoadSupplierList()
        {
            List<Supplier> supplierList = new List<Supplier>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,name_supplier,address,phone,email,status FROM suppliers");

            foreach (DataRow item in data.Rows)
            {
                Supplier supplier = new Supplier(item);
                supplierList.Add(supplier);
            }

            return supplierList;
        }


        public static List<Supplier> LoadSupplierList(string id)
        {
            List<Supplier> supplierList = new List<Supplier>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,name_supplier,address,phone,email,status FROM suppliers WHERE id ='"+id+"'");

            foreach (DataRow item in data.Rows)
            {
                Supplier supplier = new Supplier(item);
                supplierList.Add(supplier);
            }

            return supplierList;
        }

        public static List<Supplier> LoadSupplierListSearchClick(string status)
        {
            List<Supplier> supplierList = new List<Supplier>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,name_supplier,address,phone,email,status FROM suppliers WHERE status = '"+status+"'");

            foreach (DataRow item in data.Rows)
            {
                Supplier supplier = new Supplier(item);
                supplierList.Add(supplier);
            }

            return supplierList;
        }


        public static List<Supplier> LoadSupplierListSearch(string @key)
        {
            List<Supplier> supplierList = new List<Supplier>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT id,name_supplier,address,phone,email,status FROM suppliers WHERE name_supplier LIKE'%" + @key + "%' OR phone LIKE'%" + @key + "%' OR email LIKE'%" + @key + "%'");

            foreach (DataRow item in data.Rows)
            {
                Supplier supplier = new Supplier(item);
                supplierList.Add(supplier);
            }

            return supplierList;
        }

        public static bool CheckAdd(string @key)
        {
            string sql = "select * from suppliers where name_supplier = '" + @key + "'";
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

        public static void AddSupplier(Supplier std)
        {
            string sql = "INSERT INTO suppliers (name_supplier,address,phone,email,status) " +
                "VALUES(@name_supplier,@address,@phone,@email,@status)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@name_supplier", MySqlDbType.VarChar).Value = std.name_supplier;
            cmd.Parameters.Add("@address", MySqlDbType.VarChar).Value = std.address;
            cmd.Parameters.Add("@phone", MySqlDbType.VarChar).Value = std.phone;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = std.email;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Khởi tạo không thành công !!! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }


        public static void UpdateSupplier(Supplier std,string id)
        {
            string sql = "UPDATE suppliers SET name_supplier = @name_supplier,address = @address,phone = @phone,email = @email,status = @status WHERE id = @id ";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@name_supplier", MySqlDbType.VarChar).Value = std.name_supplier;
            cmd.Parameters.Add("@address", MySqlDbType.VarChar).Value = std.address;
            cmd.Parameters.Add("@phone", MySqlDbType.VarChar).Value = std.phone;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = std.email;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = std.status;
            try
            {
                cmd.ExecuteNonQuery();
   
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Chỉnh sửa không thành công !!! \n" + ex.Message, "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }


        public static void DeleteSupplier(string id)
        {
            string sql = "DELETE FROM suppliers  WHERE id = @id";
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
                MessageBox.Show("Xóa ( Không thành công! ) \n" + ex.Message, " Cảnh Báo Lỗi ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }



        public static bool CheckCreateSupplier(Supplier std)
        {
            AddSupplier(std);
            string sql = "select * from suppliers where name_supplier = @name_supplier";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@name_supplier", MySqlDbType.VarChar).Value = std.name_supplier;
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


        public static bool CheckUpdateSupplier(Supplier std,string id)
        {
            UpdateSupplier(std,id);
            string sql = "select * from suppliers where id = @id and name_supplier = @name_supplier and address = @address and phone = @phone and email = @email and status = @status ";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@name_supplier", MySqlDbType.VarChar).Value = std.name_supplier;
            cmd.Parameters.Add("@address", MySqlDbType.VarChar).Value = std.address;
            cmd.Parameters.Add("@phone", MySqlDbType.VarChar).Value = std.phone;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = std.email;
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




        public static bool CheckDeleteSupplier(string id)
        {
            DeleteSupplier(id);
            string sql = "select * from suppliers where id = '"+id+"'";
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
