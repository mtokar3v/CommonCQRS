using System.Data.SqlClient;

namespace RootDb.Configurations
{
    public class RootDbConfigurations
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string DataSource { get; set; }
        public bool IntegratedSecurity { get; set; }

        public string GetConnectionString()
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = DataSource,
                IntegratedSecurity = false,
                UserID = UserId,
                Password = Password
            };

            return connectionStringBuilder.ToString();
        }
    }
}
