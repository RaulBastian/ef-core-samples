using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ownsOne
{
    public class OwnsOneContext : DbContext
    {
        private readonly string connectionString;


        public OwnsOneContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>((p) =>
            {
                p.ToTable("Person");
                p.HasKey(x => x.Id);
                p.Property(x => x.Id).HasColumnName("PersonId");
                p.Property(x => x.Name);
                p.Property(x => x.Surname);
                p.Ignore(x => x.INTERNAL_FullName);
                p.OwnsOne(x => x.Detail, x =>
                {
                    //We can create a column, doesn't need to belong to person detail....
                    x.Property(pp => pp.Weight).HasColumnName(nameof(PersonDetail.Weight)); //belong to person detail class
                    x.Property(pp => pp.Height).HasColumnName(nameof(PersonDetail.Height));
                    x.HasOne(pp => pp.FootballTeam).WithMany().HasForeignKey("FootballTeamId").IsRequired(false);
                    //If we don't use this, the navigation field would appear in the DB as Detail_FootballTeamId
                    x.Property<int?>("FootballTeamId").HasColumnName("FootballTeamId");
                });
            });

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);


            optionsBuilder.UseSqlServer(this.connectionString);
        }
    }
}
