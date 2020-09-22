using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using multiLingual_approach2;

namespace multiLingual_approach2.model
{
    public class DbContextBase:DbContext
    {
        private readonly string connectionString;

        public DbContextBase(string connectionString)
        {
            this.connectionString = connectionString;
        }

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
