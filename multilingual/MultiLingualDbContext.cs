using Microsoft.EntityFrameworkCore;
using MultiLingualConsoleDB.model;
using System.Collections.Generic;
using System.Linq;

namespace MultiLingualConsoleDB
{
    public class MultiLingualDbContext : DbContext
    {
        public MultiLingualDbContext(DbContextOptions<MultiLingualDbContext> options) : base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Language> Languages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(x =>
            {
                x.ToTable("Course").HasKey(x => x.Id);
                x.Property(p => p.Price);
                x.HasMany(p => p.Course_Ts).WithOne(p => p.Course);
            });

            modelBuilder.Entity<Course_T>(x =>
            {
                x.ToTable("Course_T").HasKey(x => x.Id);
                x.Property(p => p.Name);
                x.HasOne(p => p.Language);
                x.HasOne(p => p.Course).WithMany(p => p.Course_Ts);
            });

            modelBuilder.Entity<Language>(x =>
            {
                x.ToTable("Language").HasKey(x => x.Id);
                x.Property(x=>x.Id).ValueGeneratedNever();
                x.Property(p => p.Desc);
            });

        }

        public static void Initialize(MultiLingualDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (!context.Courses.Any())
            {
                context.Languages.Add(Language.EN);
                context.Languages.Add(Language.ES);
                context.Languages.Add(Language.PT);

                var course1 = new Course() { Price = 10 };
                var course1_t_en = new Course_T() { Name = "Course A", Language = Language.EN, Course = course1 };


                course1.Course_Ts = new List<Course_T>();
                course1.Course_Ts.Add(course1_t_en);

                context.Courses.Add(course1);

                //https://docs.microsoft.com/en-us/ef/core/saving/explicit-values-generated-properties#explicit-values-into-sql-server-identity-columns

                //context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Language ON");
                context.SaveChanges();
                //context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Language OFF");
            }

         
        }
    }


}
