using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Hosting;
using CUSTOMER;

namespace Test.Infras;

public class CustomerAppFactory : WebApplicationFactory<Startup>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {   
        builder.UseEnvironment("Test");
    }
}
