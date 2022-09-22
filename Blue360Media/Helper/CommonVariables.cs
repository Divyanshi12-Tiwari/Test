using System.Data.SqlClient;

namespace Blue360Media.Helper
{
    public static class CommonVariables
    {
        public static string ConnectionString { get; set; }
        public static SqlConnection GetSqlConnection()
        {
           return new SqlConnection(ConnectionString);
        }
    }
}
