using MySql.Data.MySqlClient;

namespace ReportGeneration_Kilunina.Classes.Common
{
    public class Connection
    {
        public static string config = "server=127.0.0.1;uid=root;pwd=;database=journal;";

        public static MySqlConnection OpenConnection()
        {
            MySqlConnection connection = new MySqlConnection(config);
            connection.Open();
            return connection;
        }

        public static MySqlDataReader Query(string SQL, MySqlConnection connection)
        {
            return new MySqlCommand(SQL, connection).ExecuteReader();
        }

        public static void CloseConnection(MySqlConnection connection)
        {
            connection.Close();
            MySqlConnection.ClearPool(connection);
        }
    }
}
