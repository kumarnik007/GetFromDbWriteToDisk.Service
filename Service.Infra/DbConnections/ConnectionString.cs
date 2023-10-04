namespace Service.Infra.DbConnections
{
    public class ConnectionString
    {
        /// <summary>
        /// Read database and table name from environment and
        /// creates an SQL connection string based on it. Uses
        /// windows authentication for connecting to database.
        /// Throws if mandatory environment variables for db
        /// name and table name are not provided.
        /// </summary>
        public static string Create()
        {
            var dbName = Environment.GetEnvironmentVariable("CONNECTION_DB_NAME")
                ?? throw new ArgumentNullException("Mandatory environment variable", "CONNECTION_DB_NAME");
            var tableName = Environment.GetEnvironmentVariable("CONNECTION_DB_TABLE")
                ?? throw new ArgumentNullException("Mandatory environment variable", "CONNECTION_DB_TABLE");

            return $"Server=tcp:{dbName};" 
                + $"Initial Catalog={tableName};"
                + "Persist Security Info=False;"
                + "Integrated Security=SSPI;"
                + "MultipleActiveResultSets=False;"
                + "Encrypt=True;"
                + "TrustServerCertificate=True;"
                + "Connection Timeout=30;";
        }
    }
}
