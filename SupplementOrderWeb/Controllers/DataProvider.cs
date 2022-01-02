using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace SupplementOrderWeb.Controllers
{
    public class DataProvider
    {
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        private DataProvider() { }

        private static string getConnectionString()
        {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string connectionStringPath = Directory.GetParent(sCurrentDirectory).ToString();
            for (int i = 0; i < 1; i++)
            {
                connectionStringPath = Directory.GetParent(connectionStringPath).ToString();
            }
            connectionStringPath = connectionStringPath + "\\ConnectionString.txt";

            string[] connectionString = System.IO.File.ReadAllLines(connectionStringPath);

            return connectionString[0].ToString();
        }
        string connString = getConnectionString();
        //string connString = "Data Source=Kawai;Initial Catalog=SupplementManagement;Integrated Security=True";

        public DataTable ExecuteQuery(string query, object[] para = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                if (para != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, para[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);

                connection.Close();
            }

            return data;
        }

        public int ExecuteNonQuery(string query, object[] para = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                if (para != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, para[i]);
                            i++;
                        }
                    }
                }

                data = cmd.ExecuteNonQuery();


                connection.Close();
            }

            return data;
        }

        public object ExecuteScalar(string query, object[] para = null)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                if (para != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, para[i]);
                            i++;
                        }
                    }
                }

                data = cmd.ExecuteScalar();

                connection.Close();
            }

            return data;
        }
        public void ExecuteNonQuery()
        {
        }
    }
}