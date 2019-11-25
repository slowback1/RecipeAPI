using System.Data.SqlClient;
using System.Text;
using RecipieConfig;

namespace DBConnection
{
    public class Connection
    {
        public SqlConnection connection;
        public Connection()
        {
            
            DbConfig d = new DbConfig();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = d.DataSource,
                UserID = d.UserID,
                Password = d.Password,
                InitialCatalog = d.InitialCatalog
            };
            connection = new SqlConnection(builder.ConnectionString);
            
        }
    }
}
