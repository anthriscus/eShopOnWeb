namespace Microsoft.eShopWeb.Infrastructure;

public class ConnectionProfile
{
    public string ConnectionString { get; private set; } = string.Empty;
    public int CommandTimeout { get; private set; } = 30;
    public ConnectionProfile(string connectionString, int commandTimeout) => (ConnectionString, CommandTimeout) = (connectionString, commandTimeout);
    public ConnectionProfile(string connectionString) => (ConnectionString) = (connectionString);
    public ConnectionProfile()
    {
    }
}
