using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace SharedDoc
{
    public class DatabaseConnector
    {


        private SqlConnection _connection;
        private string _conectionStrings;

        public DatabaseConnector()
        {
            _conectionStrings = ConfigurationManager.ConnectionStrings["SharedDocDatabaseConnection"].ConnectionString;
            _connection = new SqlConnection(_conectionStrings);
        }

        public LoginData GetLoginData()
        {
            DataSet dataSet = GetTableData();

            string username = dataSet.Tables[0].Rows[0]["Username"].ToString();
            string password = dataSet.Tables[0].Rows[0]["Password"].ToString();

            username.Replace(" ", "");
            password.Replace(" ", "");

            return new LoginData(username, password);
        }

   
       

        private DataSet GetTableData()
        {
            string query = "SELECT * FROM Users";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, _connection);

            DataSet dataSet = new DataSet();

            _connection.Open();
            dataAdapter.Fill(dataSet, "Users");
            _connection.Close();

            return dataSet;
        }

        public void SaveFileIntoDatabase(string fileName, string text)
        {
            using (SqlConnection connection = new SqlConnection(_conectionStrings))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Documents (FileName, Text) VALUES (@FileName, @Text)");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@FileName", fileName);
                cmd.Parameters.AddWithValue("@Text", text);

                _connection.Open();
                cmd.Connection = _connection;
                cmd.ExecuteNonQuery();
                _connection.Close();
            }
        }
    }
}
