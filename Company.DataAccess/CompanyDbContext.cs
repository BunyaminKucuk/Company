using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Company.Entities;

namespace Company.DataAccess
{
    public class CompanyDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString: "Server=DESKTOP-9TUJNUE\\SQLEXPRESS;Database=CompanyDb;" + 
                                                          "Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        public DbSet<Corporation> Corporations { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}
