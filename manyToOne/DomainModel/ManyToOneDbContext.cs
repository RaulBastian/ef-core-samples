using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ManyToOne.DomainModel
{
    public class ManyToOneDbContext : DbContext
    {
        private readonly string connectionString;

        public ManyToOneDbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DbSet<Person> Person { get; set; }

        public DbSet<Book> Book { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>(x =>
            {
                x.ToTable("Person");
                x.HasKey(p => p.Id);
                x.Property(p => p.Name);
                x.HasOne(p => p.FavoriteBook).WithMany();
            });

            modelBuilder.Entity<Book>(x =>
            {
                x.ToTable("Book");
                x.HasKey(p => p.Id);
                x.Property(p => p.Name);
            });
        }

        public void Init()
        {
            if(!this.Person.Any())
            {
                var b = new Book()
                {
                    Name = "Book 1"
                };

                var p = new Person()
                {
                    Name="Person 1",
                    FavoriteBook = b
                };

                this.Book.Add(b);
                this.Person.Add(p);
                this.SaveChanges();
            }
        }
    }
}
