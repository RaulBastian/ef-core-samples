using Microsoft.Extensions.Configuration;
using ownsOne;
using System;
using System.IO;

namespace EFCore_OwnsOne
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var db = new OwnsOneContext(GetConnectionString()))
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
        }

        private static string GetConnectionString()
        {
            var b = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .Build();

            return b["ConnectionString"];
        }
    }
}
