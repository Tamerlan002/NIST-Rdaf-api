using Microsoft.AspNetCore;
using Microsoft.Extensions.Options;
using RDaF.Api;
using RDaF.Api.Extensions;
using RDaF.Data.EntityFramework.Context;
using RDaF.Shared.Constants;
public class Program
{
    public static void Main(string[] args)
    {


        var host = CreateHostBuilder(args).Build();

        //host.MigrateDbContext<RDaFDbContext>(async (context, services) =>
        //{
        //    var env = services.GetService<IWebHostEnvironment>();
        //    var settings = services.GetService<IOptions<RDaFSettings>>();

        //});

        host.Run();

    }

    public static IWebHostBuilder CreateHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args).ConfigureLogging(logging => { logging.ClearProviders(); }).UseStartup<Startup>()
        .ConfigureServices((hostContext, services) =>
        {});

}