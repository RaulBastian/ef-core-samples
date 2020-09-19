using ManyToOne.DomainModel;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ManyToOne
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ManyToOneDbContext(GetConnectionString()))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Init();

                //Student student = context.Students.Find(1L);

                //Student student = context.Students
                //    .Include(x => x.FavoriteCourse)
                //    .SingleOrDefault(x => x.Id == 1);
            }

        }

        static string GetConnectionString()
        {
            var c = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("applicationsettings.json")
                        .Build();

            return c["ConnectionString"];
        }
    }
}
