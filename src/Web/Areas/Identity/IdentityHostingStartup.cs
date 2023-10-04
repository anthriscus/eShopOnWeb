using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Microsoft.eShopWeb.Web.Areas.Identity.IdentityHostingStartup))]
namespace Microsoft.eShopWeb.Web.Areas.Identity;

public class IdentityHostingStartup : IHostingStartup
{
    public void Configure(IWebHostBuilder builder)
    {
        builder.ConfigureServices((context, services) =>
        {            
        });
        
        // try out stuff to pick up in a page.
        builder.ConfigureAppConfiguration( config =>
        {
            var dict = new Dictionary<string, string>
                {
                    {"lastwho", "demouser@microsoft.com"}
                };
            config.AddInMemoryCollection(from entry in dict select entry );
        });
    }
}
