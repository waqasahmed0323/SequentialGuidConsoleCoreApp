using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EFGetStarted.AspNetCore.NewDb.Models
{
    public class SequentialGuidContext : DbContext
    {
        
        //public SequentialGuidContext(DbContextOptions<SequentialGuidContext> options)
        //    : base(options)
        //{ }

        public DbSet<GuidTable> GuidTables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB;Initial Catalog=GuidDB;Integrated Security=True");
        }   
    }

    public class GuidTable
    {
        public int Id { get; set; }
        public string GuidID { get; set; }

    }
}
