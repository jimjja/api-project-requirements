using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ShalekKavy.Api.Context;
using Microsoft.Extensions.DependencyInjection;

namespace ShalekKavy.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            // Seed db with data 
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<BeverageContext>();

                SeedDatabase.SeedDatabaseWithMockData(context);
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
