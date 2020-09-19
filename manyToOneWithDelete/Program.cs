using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace manyToOneWithDelete
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var db = new TestDbContext(GetConnectionString()))
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                var author = db.Authors.Where(a => a.Name == "William Golding").SingleOrDefault();

                if(author == null)
                {
                    author = new Author()
                    {
                        Name = "William Golding"
                    };

                    author.AddBook("Lord of the flies");

                    db.Authors.Add(author);
                    db.SaveChanges();
                }
                else
                {
                    var b = author.Books;
                }

                db.Authors.Remove(author);
                db.SaveChanges();
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
