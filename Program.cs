using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LabW06StudentGrades.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LabW06StudentGrades
{
   public class Program
   {
      public static void Main(string[] args)
      {
         var host = CreateWebHostBuilder(args).Build();
         SeedData(host);
         host.Run();
      }

      public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
          WebHost.CreateDefaultBuilder(args)
              .UseStartup<Startup>();

      public static void SeedData(IWebHost host)
      {
         using (var scope = host.Services.CreateScope())
         {
            var services = scope.ServiceProvider;
            try
            {
               var context = services.GetRequiredService<StudentGradesDbContext>();
               context.Seed();
            }
            catch (Exception)
            {
               var logger = services.GetRequiredService<ILogger<Program>>();
               logger.LogError("An error occurred while seeding the database.");
            }
         }
      }
   }
}
