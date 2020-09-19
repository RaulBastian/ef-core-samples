using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Schema;

namespace manyToOneWithDelete
{
    public class TestDbContext:DbContext
    {
        private readonly string connectionString;

        public TestDbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>(e =>
            {
                e.ToTable(nameof(Author));
                e.HasKey(x => x.Id);
                e.Property(x => x.Id).HasColumnName("AuthorId");
                e.Property(x => x.Name).HasColumnName(nameof(Author.Name));

                //Maybe the author isn't required for some reason...
                //By deleting it would only set the author id to null, we need to define de delete behaviour for the book to be deleted too...
                e.HasMany(x => x.Books).WithOne(x => x.Author).Metadata.DeleteBehavior = DeleteBehavior.Cascade;

                //By making the author required, deleting the book is done implicitly
                //e.HasMany(x => x.Books).WithOne(x => x.Author).IsRequired();
            });

            modelBuilder.Entity<Book>(e =>
            {
                e.ToTable(nameof(Book));
                e.HasKey(x => x.Id);
                e.Property(x => x.Id).HasColumnName("BookId");
                e.Property(x => x.Name).HasColumnName(nameof(Book.Name));
            });
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter((category, level) =>
                        category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information)
                    .AddConsole();
            });


            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.EnableSensitiveDataLogging();
        }

    }
}
