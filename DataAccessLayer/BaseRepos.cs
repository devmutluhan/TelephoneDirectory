using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class BaseRepos
    {
        private readonly string connectionString;
        public BaseRepos(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public IDbConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}