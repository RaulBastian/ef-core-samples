using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using multiLingual_approach2;
using System.Security.Cryptography.X509Certificates;

namespace multiLingual_approach2
{
    public class MultiDbContext:DbContext
    {
        private readonly string connectionString;

        public MultiDbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DbSet<Book> Book { get; set; }
        public DbSet<Book_C> Book_C { get; set; }

        public DbSet<Language> Language { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Language>(builder => {
                builder.HasKey(k => k.Id);
                builder.Property(p => p.Id).ValueGeneratedNever();
                builder.Property(p => p.Short);
            });

            modelBuilder.BuildTranslation<Book, Book_C>((translatableBuilder) =>
            {
                translatableBuilder.Property(p => p.Name);
            },
            (commonBuilder) =>
            {
                commonBuilder.Property(p => p.Price);
            });

            //modelBuilder.Entity<Book_C>(builder => {
            //    builder.HasKey(k => k.Id);
            //    builder.Property(p => p.Id);
            //    builder.Property(p => p.Price);
            //});

            //modelBuilder.Entity<Book>().BuildTranslation<Book,Book_C>(builder =>
            //{
            //    builder.Property(p => p.Name);

            //},null);

            //modelBuilder.Entity<Book>().BuildTranslation(builder=>
            //{
            //    builder.Property(p => p.Name);
            //});
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

           var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddFilter((category, level) =>
                    category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information
                ).AddConsole();
            });

            optionsBuilder.UseSqlServer(this.connectionString);

            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.EnableSensitiveDataLogging(true);

        }
    }
}
