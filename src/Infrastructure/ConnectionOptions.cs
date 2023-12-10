using Microsoft.Extensions.Configuration;

namespace Microsoft.eShopWeb.Infrastructure;
// see example of options at  https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-7.0

public class ConnectionOptions
{
    public const string Connection = "datasource";
    [ConfigurationKeyName("connectionName")]
    public string ConnectionName { get; set; } = System.String.Empty;
    [ConfigurationKeyName("commandTimeout")]
    public int CommandTimeout {get;set;} = 30;
}
