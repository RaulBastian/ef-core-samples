using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace multiLingual_approach2
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var db = new MultiDbContext(GetConnectionString()))
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
        }

        static string GetConnectionString()
        {
            var c = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .Build();

            return c["ConnectionString"];
        }
    }
}
