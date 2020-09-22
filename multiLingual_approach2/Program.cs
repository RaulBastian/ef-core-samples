using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using multiLingual_approach2.repositories;
using System;
using System.IO;
using System.Linq;

namespace multiLingual_approach2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MultiDbContext(GetConnectionString()))
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                var rp = new BookRepository(db);

                if (!db.Language.Any())
                {
                    db.Language.Add(Language.EN);
                    db.Language.Add(Language.PT);
                    db.SaveChanges();
                }

                if (!db.Book.Any())
                {
                    var flies = new Book()
                    {
                        Name = "The lord of the flies",
                    };
                    flies.CommonEntity.Price = 4.00;

                    var hobbit = new Book()
                    {
                        Name = "The Hobbit",
                    };
                    hobbit.CommonEntity.Price = 3.00;

                    rp.Add(flies);
                    rp.Add(hobbit);

                    db.SaveChanges();
                };

                var all = rp.GetAll();
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

