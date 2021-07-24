using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquiredCoffee.DB
{
    class DataProvider
    {
        private static DataProvider instance; //ctrl + r + e

        private string conectionSTR = "datasource=localhost;port=3306;username=root;password=;database=coffeeshop";

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        private DataProvider() { }

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(conectionSTR))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(query,connection);
                
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                adapter.Fill(data);

                connection.Close();
            }

            return data;
        } // trả  ra những dòng kết quả 

    }
}
