using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using multiLingual_approach2;

namespace multiLingual_approach2
{
    public class MultiDbContext:DbContext
    {
        private readonly string connectionString;

        public MultiDbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Language>(builder => {
                builder.HasKey(k => k.Id);
                builder.Property(p => p.Id);
                builder.Property(p => p.Short);
            });


            modelBuilder.Entity<Book>(builder => {
                builder.HasKey(k => k.Id);
                builder.Property(p => p.Id);
                builder.Property(p => p.Price);
                builder.Ignore(p => p.T);
            });

            modelBuilder.Entity<Book_T>().BuildTranslation();
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
