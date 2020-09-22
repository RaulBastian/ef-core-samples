using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using multiLingual_approach2;
using System.Security.Cryptography.X509Certificates;
using multiLingual_approach2.model;

namespace multiLingual_approach2
{
    public class MultiDbContext:DbContextBase
    {
        public MultiDbContext(string connectionString):base(connectionString)
        {
            
        }

        public DbSet<Book> Book { get; set; }
        
        public DbSet<Language> Language { get; set; }

       
    }
}
